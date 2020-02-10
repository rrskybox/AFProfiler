Imports System.IO

'Windows Visual Basic Class: UtilityLightAF
'
'Culled down verion of TTUtilities module for use with the Focus/Temperature Profile Application
'
' ------------------------------------------------------------------------
'
' Author: R.McAlister (2015)
' Version 1.0
'
' ------------------------------------------------------------------------

Public Class TTutility
    'Common utilities for TSX connections
    '
    Public Shared Target_Name
    Public Shared Cam_Delay
    Public Shared Cam_Reduction
    Public Shared Cam_Filter
    Public Shared Cam_Exposure
    Public Shared AG_Reduction
    Public Shared AG_Exposure
    Public Shared AG_Delay
    Public Shared AG_MinMove
    Public Shared AG_Aggressiveness

    Public Shared ConfigName
    Public Shared FocuserName
    Public Shared FilterCountText
    Public Shared FilterCount

    Public Const SettlingTime = 5
    Const FtextFields = 2
    Const FtextColorField = 0
    Const FtextDataField = 1
    Const FdataFieldCount = 4
    Const FfilterNumberIndex = 0
    Const FdateDataOffset = 0
    Const FposDataOffset = 1
    Const FtempDataOffset = 3

    Public Shared Sub SaveTSXState()

        'Saves the current target and camera configuration information in TTutility public variables
        '   Target Name (for TSX Find)
        '   Camera Delay
        '   Camera Exposure
        '   Camera Image Reduction
        '   Camera Filter

        'target name
        Dim tsx_oi = CreateObject("TheSkyX.Sky6ObjectInformation")
        tsx_oi.Property(TheSkyXLib.Sk6ObjectInformationProperty.sk6ObjInfoProp_NAME1)
        Target_Name = tsx_oi.ObjInfoPropOut
        'camera configuration
        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftCamera")
        Cam_Delay = tsx_cc.Delay
        Cam_Reduction = tsx_cc.ImageReduction
        Cam_Filter = tsx_cc.FilterIndexZeroBased
        Cam_Exposure = tsx_cc.ExposureTime
        'guider configuration
        Dim tsx_ag = CreateObject("TheSkyX.ccdsoftCamera")
        tsx_ag.Autoguider = 1
        AG_Delay = tsx_ag.Delay
        AG_Reduction = tsx_ag.ImageReduction
        AG_Exposure = tsx_ag.ExposureTime
        AG_MinMove = tsx_ag.AutoguiderMinimumMove
        AG_Aggressiveness = tsx_ag.AutoguiderAggressiveness

        tsx_oi = Nothing
        tsx_cc = Nothing
        tsx_ag = Nothing
        Return
    End Sub

    Public Shared Sub RestoreTSXState()

        'Clears the observing list, restores the current target and camera configuration information in TTutility public variables,
        'Open camera object
        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftCamera")

        'target star
        TSX_Find(Target_Name)
        'camera settings
        tsx_cc.ImageReduction = Cam_Reduction
        tsx_cc.FilterIndexZeroBased = Cam_Filter
        tsx_cc.ExposureTime = Cam_Exposure
        tsx_cc.Delay = Cam_Delay
        'autoguider settings
        Dim tsx_ag = CreateObject("TheSkyX.ccdsoftCamera")
        tsx_ag.Autoguider = 1
        tsx_ag.Delay = AG_Delay
        tsx_ag.ImageReduction = AG_Reduction
        tsx_ag.ExposureTime = AG_Exposure
        tsx_ag.AutoguiderMinimumMove = AG_MinMove
        tsx_ag.AutoguiderAggressiveness = AG_Aggressiveness
        'Clean up
        tsx_cc = Nothing
        tsx_ag = Nothing
        Return

    End Sub

    Public Shared Function ClosedLoopSlew(clearfilter As Integer, ExposureTime As Double) As Integer
        'Calls a TSX Closed Loop Slew using the whatever target is in the current Find
        'A successful slew will return zero.

        Dim CLSstatus As Integer
        'Open camera object
        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftCamera")

        'If CLS is required, then create cls object, set the exposure, filter to luminance and reduction, set the camera delay to 15
        ' should be picked up in the mount driver

        Dim tsx_cls = CreateObject("TheSkyX.ClosedLoopSlew")
        tsx_cc.ImageReduction = TheSkyXLib.ccdsoftImageReduction.cdAutoDark
        tsx_cc.FilterIndexZeroBased = clearfilter
        tsx_cc.ExposureTime = ExposureTime
        tsx_cc.Delay = SettlingTime 'Set some settling time for the mount

        Try
            CLSstatus = tsx_cls.exec()
        Catch ex As Exception
            'Just close up: TSX will spawn error window
            CLSstatus = -1
        End Try

        'Clean up
        tsx_cls = Nothing
        Return (CLSstatus)
    End Function

    Public Shared Function OptimizeExposure(targetADU As Integer, filterIndex As Integer, InitialExposureTime As Double) As Double
        'Returns an exposure time that optimizes for a particular ADU using the given filter (index), and starting from the InitialExposureTime

        Dim CLSstatus As Integer
        'Open camera object
        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftCamera")
        Dim exposure As Double = InitialExposureTime

        tsx_cc.ImageReduction = TheSkyXLib.ccdsoftImageReduction.cdAutoDark
        tsx_cc.FilterIndexZeroBased = filterIndex
        tsx_cc.ExposureTime = exposure
        'Get the best exposure time based on the target ADU
        '
        'Subrountine loops up to 4 times, taking an image, And calulating a New exposure that would meet
        '   the ADU goal
        'If the returned exposure Is very small, the star was probably saturated, so reduce by 1/2 And do again
        'If the returned exposure Is very large, the star was probably severely underexposed, Or lost, so increase by 2 And do again
        'If just right, then update the exposure settings And return
        '
        'Only take at max 4 shots at getting a good exposure, otherwise return the max Or min
        For i As Integer = 0 To 4 Step 1
            'Take a subframe image
            'Get maximum pixels ADU
            'Calculate correct exposure to get target max pixels
            'If the maximum pixel value Is at Or over 90% of the maximum, then cut the exposure in half And try again
            'If the maximum pixel valiue Is less than a quarter of the target ADU, then double the exposure And try again
            'Otherwise, the exposure Is good enough for a calculation And return.
            tsx_cc.TakeImage()
            If (tsx_cc.MaximumPixel >= (0.9 * 65000)) Then

                exposure = exposure / 2
            ElseIf (tsx_cc.MaximumPixel < targetADU / 4) Then

                exposure = exposure * 2
            Else
                exposure = targetADU * (tsx_cc.ExposureTime / tsx_cc.MaximumPixel)
                Exit For
            End If
        Next
        tsx_cc = Nothing
        Return exposure
    End Function

    Public Shared Sub TSX_Find(targetname As String)
        'Clears all entries in observing list, in absence of same function in TSX automation
        'Upon clearing, the routine will "find" the target name, if any 

        If targetname <> Nothing Then
            Dim tsx_sc = CreateObject("TheSkyX.Sky6StarChart")
            Try
                tsx_sc.Find(targetname)
            Catch ex As Exception
                'Continue
            End Try
            tsx_sc = Nothing
        End If
        Return
    End Sub

    Public Shared Function checkTSX() As Boolean
        Dim pname As String = "TheSkyX"
        Dim pList() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcesses
        For Each proc As System.Diagnostics.Process In pList
            If String.Compare(proc.ProcessName, pname) = 0 Then
                Return True
            End If
        Next
        MsgBox("TSX is not open")
        Return False
    End Function

    Public Shared Sub TSXWaitLoop(tsx_cc As Object)
        Do While tsx_cc.state = TheSkyXLib.ccdsoftCameraState.cdStateTakePicture
            System.Threading.Thread.Sleep(1000)
        Loop
        Return
    End Sub

    Public Shared Function GetFOCdata(focFilePath As String) As String(,)

        'Opens and interpolates .foc file for luminance filter, returns computed position in steps based on Current Temperature 

        'File and filter data structure

        'Open foc file

        Dim sr As New StreamReader(focFilePath)
        Try
            Dim FocuserCount = sr.ReadLine()
        Catch e As Exception
            MsgBox("The focus file could not be found: " + e.Message)
            Return (Nothing)
        End Try

        'Open, read in and partially parse the focus file to a text array, then close it up 
        ConfigName = sr.ReadLine()
        FocuserName = sr.ReadLine()
        FilterCountText = sr.ReadLine()
        FilterCount = Int(FilterCountText)

        Dim ftextdata((FilterCount - 1), (FtextFields - 1)) As String

        Dim ftextrecord As Integer = 0
        For ftextrecord = 0 To FilterCount - 1
            ftextdata(ftextrecord, FtextColorField) = sr.ReadLine()
            ftextdata(ftextrecord, FtextDataField) = sr.ReadLine()
        Next
        sr.Close()
        Return ftextdata
    End Function

    Public Shared Function GetFilterName(ftextdata, filter) As String
        Dim fname_filter() = Split(ftextdata(filter, FtextColorField), ",")
        Return fname_filter(0)
    End Function

    Public Shared Function GetfilterCount(ftextdata) As Integer
        Return (FilterCount)
    End Function

    Public Shared Function ComputePosition(ftextdata, filter, currenttemp) As Integer
        'Compute a focuser position based on the trendline from filter's focus data
        Dim filData As New FilterData(ftextdata, filter)
        Dim filterTrendline = New Trendline(filData.Positions, filData.Temperatures)
        Return filterTrendline.Position(currenttemp)

    End Function

    Public Shared Function ComputeSlope(ftextdata, filter) As Integer
        'Compute a trendline slope from a filter's focus data
        Dim filData As New FilterData(ftextdata, filter)
        Dim currentTrendline = New Trendline(filData.Positions, filData.Temperatures)
        Return currentTrendline.Slope

    End Function

    Public Shared Function ComputeOffset(ftextdata, refFilter, offsetFilter, ofsTemperature)
        'Determines the offset for a filter against the reference filter
        '  by comparing the positions for the reference trendline and the offset trendline
        '  at the given temperature.
        Dim refData = New FilterData(ftextdata, refFilter)
        Dim ofsData = New FilterData(ftextdata, offsetFilter)
        Dim refLine = New Trendline(refData.Positions, refData.Temperatures)
        Dim ofsLine = New Trendline(ofsData.Positions, ofsData.Temperatures)
        Return (ofsLine.Position(ofsTemperature) - refLine.Position(ofsTemperature))

    End Function

    Public Shared Function ComputeAccuracy(ftextdata,
                                           refFilter,
                                           tgtFilter,
                                           offset,
                                           cfzSteps) As Integer
        'Determine the percentage of focus data positions that fall within the CFZ associated with the
        '  temperature compensation parameters.  criticalFocusZone is in focuser steps.
        '
        'For each measurement in ftextdata for the filter fiternum, count the number of measurements that lie within
        '  1/2 CFZ steps of the "ideal" position given the temperature compensation (reference temp + slope * diff)
        'Parse out the filter data

        Dim refData As New FilterData(ftextdata, refFilter)
        Dim refLine = New Trendline(refData.Positions, refData.Temperatures)
        Dim filData As New FilterData(ftextdata, tgtFilter)
        Dim refPosition As Integer = 0
        Dim coverCount As Integer = 0

        'for each measurement made for this filter
        For i = 0 To filData.Count - 1
            'Calculate the position the focuser would take after temperature-compensation was applied
            '  for the temperature at that measurement, assuming that the focuser was initially focused
            '  somewhere on the trendline set by the reference filter
            'refPosition = (filData.Tmp(i) * refLine.Slope) + refLine.Intercept + offset
            refPosition = refLine.Position(filData.Tmp(i)) + offset
            'Determine the difference between the ideal compensated position and the actual position measured
            '  at that temperature
            If (Math.Abs(refPosition - filData.Pos(i)) <= (cfzSteps / 2)) Then
                coverCount += 1
            End If
        Next

        If filData.Count > 0 Then
            Return 100 * coverCount / filData.Count
        Else
            Return 0
        End If

    End Function

    Public Shared Function ComputeAverage(positionData)
        'Computes the average position for a data set irrespection of temperature changes

        Dim ptotal As Double = 0
        Dim datacount As Integer = positionData.length

        For i = 0 To datacount - 1
            ptotal += positionData(i)
        Next

        Return (ptotal / datacount)

    End Function

    Public Class FilterData
        'Class that encapsulates methods and properties for reading *.foc file data for a particular filter

        Private positionData() As Integer = {0}
        Private temperatureData() As Double = {0}
        Private filterNum As Integer = 0
        Private filterDataCount As Integer = 0

        Public Sub New(ftextdata, filter)
            Dim fdata_filter() = Split(ftextdata(filter, FtextDataField), ",")
            filterDataCount = (fdata_filter.Length - 1) / FdataFieldCount
            filterNum = filter
            'parse out temp and position arrays
            Dim i As Integer
            For i = 0 To filterDataCount - 1
                ReDim Preserve positionData(i)
                positionData(i) = fdata_filter((i * FdataFieldCount) + FposDataOffset + 1)
                ReDim Preserve temperatureData(i)
                temperatureData(i) = fdata_filter((i * FdataFieldCount) + FtempDataOffset + 1)
            Next
            Return
        End Sub

        Public ReadOnly Property Average
            Get
                Return temperatureData.Average
            End Get
        End Property

        Public ReadOnly Property Count
            Get
                Return filterDataCount
            End Get
        End Property

        Public ReadOnly Property Positions
            Get
                Return positionData
            End Get
        End Property

        Public ReadOnly Property Temperatures
            Get
                Return temperatureData
            End Get
        End Property

        Public Function Pos(indx) As Integer
            'returns indx'th value in position array
            Return positionData(indx)
        End Function

        Public Function Tmp(indx) As Double
            'returns indx'th value in temperature array
            Return temperatureData(indx)
        End Function

    End Class

    Public Class Trendline
        'Class encapsulates properties and functions of producing a trendline through a set of temperature measurements
        '  Produces an object that has a integer property for slope and an integer property for intercept
        '  Has function for calculating value at a specific temperature or position on the trendline

        Private slopeVal As Integer
        Private interceptVal As Integer

        Public Sub New(PositionData, TemperatureData)

            Dim posmean As Double = 0
            Dim tempmean As Double = 0
            Dim datacount As Integer = PositionData.length

            For i = 0 To datacount - 1
                posmean += PositionData(i)
                tempmean += TemperatureData(i)
            Next
            posmean = posmean / datacount
            tempmean = tempmean / datacount
            Dim sumtemppos As Double = 0
            Dim sumtemp As Double = 0
            For i = 0 To datacount - 1
                sumtemppos += (PositionData(i) - posmean) * (TemperatureData(i) - tempmean)
                sumtemp += (TemperatureData(i) - tempmean) ^ 2
            Next
            If sumtemppos <> 0 Then
                slopeVal = sumtemppos / sumtemp
            Else
                slopeVal = 0
            End If
            interceptVal = posmean - (slopeVal * tempmean)
            Return
        End Sub

        Public ReadOnly Property Slope As Integer
            Get
                Return slopeVal
            End Get
        End Property

        Public ReadOnly Property Intercept As Integer
            Get
                Return interceptVal
            End Get
        End Property

        Public Function Position(cTemp As Double) As Integer
            'Computes position from temperature on slope
            Return (interceptVal + (slopeVal * cTemp))
        End Function

    End Class

    Public Shared Function DoubleClip(ByVal dvalue As Double, ByVal decimals As Integer) As String
        'Converts a double value (dvalue) to a string truncated to the specified number (decimals) of decimal points, adds a leading 0 if necessary
        Dim ss As String
        Dim decpos As Integer

        ss = Str(Math.Round(dvalue * 100) / 100)
        decpos = InStr(ss, ".")
        If (decpos <> 0) And (decpos + 2 < ss.Length) Then
            ss = Strings.Left(ss, decpos + 2)
        End If
        ss = LTrim(ss)
        If dvalue < 1 Then
            ss = "0" + ss
        End If
        Return (ss)
    End Function

End Class
