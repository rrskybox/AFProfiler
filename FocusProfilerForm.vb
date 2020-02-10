Public Class FocusProfilerForm

    'Windows Visual Basic Forms Application: AFAnalysis
    '
    'Standalone application version to run a series of @Focus2 commands over
    '  sufficiently long period to get a good temperature curve
    '
    ' ------------------------------------------------------------------------
    '
    ' Author: R.McAlister (2015)
    ' Version 1.0 (Superceded)
    ' Version 1.1
    '   Added a second try on Focus error with double the initial exposure time for narrow band filters
    ' Version 1.2
    ' Version 1.3
    '   Fixed the exposure such that it set the focus exposure rather than the camera exposure
    '   Monkeyed around with the abort (stop) function to make it more responsive -- but needs more work
    '   Changed the exposure time on the CLS to be set by the focus exposure time
    '   Changed the settling time from 20 seconds to 5 seconds
    '   Added Analysis features to read .foc file and compute various stuff
    ' Version 1.4
    '   Added current temperature read out
    '   Added reference temperature and changed Analyze to use it
    ' Version 1.5
    '   Recompiled for Windows updates and TSX Build 11080
    ' Version 1.6
    '   Fixed a problem with AtFocus2 not returning an integer error on "focus did not converge"
    ' Version 1.7
    '   Added a CFZ focus calculator added
    '   Added "accuracy" calculation and report
    '   Gave the windows form a facelift
    ' Version 1.8
    '   Added a CLS checkbox to disable CLS, if desired
    '   Modified the exposure variables to allow sub-increment exposures
    '   Modified interloop delay to allow for 0 minute durations (no delay)
    ' Version 1.9
    '   Added @Focus3 option
    '   Fixed some errors associated with analyzing sparse data files
    ' Version 1.91
    '   Fixed a bug in the utility class where no change in temperature could produce an
    '       division by zero.  Now it just zero's the slope.
    '   Added a temperature-independent average to the Analysis line so that very low accuracy
    '       test runs (very little temperature variation) could still generate some data
    '   Widened the form so that more could print without wrapping
    '   Added a decimal to the reference temperature on Analysis so that sub-degree temperatures
    '       could be displayed.  Also changed the default to 20 degrees.
    ' Version 1.92
    '   Added a method to find the exposure time for a given target ADU
    ' Version 1.93
    '   Changed maximum filter index number to 23
    ' Version 1.94
    '   Fixed some tool tips and changed the "Clear Filter" label to "CLS Filter"
    ' ------------------------------------------------------------------------
    'This form encapsulates the FocusProfile user interface
    'One data results box
    'Four button controls:  Pre-Focus, Start, Stop, and Cancel -- should be self-explanatory, har, har
    '
    Const NarrowBandExposureMultiplier = 2

    Public focalRatioCFZ As Double = 7.2
    Public resolutionCFZ As Double = 0.11
    Public calculatedCFZ As Integer = 0

    Private focusprofileabort As Boolean
    Private tfp As Object
    Private currentfocuserfilter As Integer
    Private currentfocuserposition As Integer
    Private currentfocusertemp As Double

    Dim alertmsg =
        vbCrLf + "Notes:" + vbCrLf + vbCrLf +
        vbCrLf + "For the focuser profiling to work correctly:" + vbCrLf + vbCrLf +
        vbTab + "1. The Sky X Pro Ver 10.5.0 (DB 11086 or greater) with Camera Add On must be running," + vbCrLf +
        vbTab + "2. The Telescope, Camera and Focuser must be connected," + vbCrLf +
        vbTab + "3. The focuser position should be near focus (Focus tab), " + vbCrLf +
        vbTab + "4. A decent focus star must have been selected (Find tab) which will not cross the meridian for at least four hours." + vbCrLf +
        vbTab + "5. If using @Focus2, 'Automatically Find Focus Star' must be deselected (@Focus2 setup)." + vbCrLf +
        vbTab + "6. 'Protect Data Points' must be deselected (Focuser tab)." + vbCrLf +
        vbTab + "7. 'If using @Focus3, a successful standalone run is recommended before running this application." + vbCrLf + vbCrLf +
       "Note that this procedure (if selected) uses TSX Closed Loop Slew to maintain position over the target star for this long period." + vbCrLf +
        vbTab + "If the CLS fails, then this profiling can fail." + vbCrLf + vbCrLf +
        "Press Start when ready, the profiling takes around four hours, so go to bed." + vbCrLf + vbCrLf +
        "Upon completion or Stop, do not disconnect the focuser before the data points are Saved in TSX (Focuser tab)" + vbCrLf

    Private Sub FocusProfilerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Initializes the form and creates an AutoGuideProfile object to run the profiling
        ProfileDataBox.Text = alertmsg
        ' Set up the delays for the ToolTip.
        ProfileDataBox.SelectionStart = 0
        ProfileDataBox.SelectionLength = 0
        AFToolTips.AutoPopDelay = 5000
        AFToolTips.InitialDelay = 1000
        AFToolTips.ReshowDelay = 500
        ' Force the ToolTip text to be displayed whether or not the form is active.
        AFToolTips.ShowAlways = True

        ' Set up the ToolTip text for the Button and Checkbox.
        AFToolTips.SetToolTip(Me.StartButton, "Begins autoguide profiling")
        AFToolTips.SetToolTip(Me.StopButton, "Aborts autoguide profiling")
        AFToolTips.SetToolTip(Me.DoneButton, "Closes the application")
        AFToolTips.SetToolTip(Me.PreFocusButton, "Moves focuser to position based on current temperature and a user selected *.foc data point file")
        AFToolTips.SetToolTip(Me.FirstFilterNumber, "Lowest numbered filter on which to run focusing -- first filter in filter wheel is 0")
        AFToolTips.SetToolTip(Me.LastFilterNumber, "Highest numbered filter on which to run focusing-- first filter in filter wheel is 0")
        AFToolTips.SetToolTip(Me.ClearFilterNumber, "Filter number for filter to be used for Closed Loop Slew to the target, normally clear or luminance -- first filter in filter wheel is 0")
        AFToolTips.SetToolTip(Me.RepetitionsNumber, "Number of times to repeat focusing for the set of filters")
        AFToolTips.SetToolTip(Me.WaitNumber, "The time (in minutes) to wait between focusing runs of each filter set")
        AFToolTips.SetToolTip(Me.ExposureNumberBox, "The time (in seconds) of the initial focusing xposure")

        FocalRatioVal.Value = focalRatioCFZ
        ResolutionVal.Value = resolutionCFZ
        calculatedCFZ = CalculateCFZ()
        CFZStepsText.Text = Str(TTutility.DoubleClip(calculatedCFZ, 0))

        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftCamera")
        If tsx_cc.focIsConnected <> 1 Then
            'No focuser; no bueno
            TemperatureReadout.Text = "None"
            ReferenceTemperature.Value = 20.0
            Return
        Else
            Dim currenttemp = tsx_cc.focTemperature()
            TemperatureReadout.Text = Str(TTutility.DoubleClip(currenttemp, 1))
            ReferenceTemperature.Value = currenttemp
        End If

        Return
    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        'Initiates a profile run
        ProfileDataBox.AppendText("Focus Profiling Started" + vbCrLf)
        focusprofileabort = False
        ProfileFocuser()
        ProfileDataBox.AppendText(vbCrLf + vbCrLf + "Focus Profiling Finished: Remember to save Focus Data Points (Focus tab)" + vbCrLf)
        Return
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        'Signals the profile run to abort
        focusprofileabort = True
        ProfileDataBox.AppendText(vbCrLf + "Focus Profiling Aborting: Remember to save Focus Data Points (Focus tab) if desired" + vbCrLf)
        Return
    End Sub

    Private Sub DoneButton_Click(sender As Object, e As EventArgs) Handles DoneButton.Click
        Close()
        Return
    End Sub

    Private Sub ProfileFocuser()
        'Routine runs an autofocus set every 20 minutes or so for about 4 hours with the purpose of calibrating the focuser against temperature change
        'The "Protect Data Points" in the focuser window must be turned off, and a suitable starting target set that will be available, without meridian flip
        ' for the full four hours.
        'At the end of the run, the datapoints must be saved to a file and the observatory secured.

        'Procedure:
        ' 1.  See if we are set up for the run correctly
        ' 2. Run autofocus set about three times per hour for four hours (12 times)
        '   assuming the autofocus takes about fifteen minutes of the twenty to finish a loop
        '
        'Dim fstat As Boolean
        Dim firstfilter = FirstFilterNumber.Value
        Dim lastfilter = LastFilterNumber.Value
        Dim filtercount As Integer = lastfilter - firstfilter + 1

        'Set reference filter by running the "clear" filter first
        'Check to see if TSX is launched, and still running
        If Not TTutility.checkTSX Then
            ProfileDataBox.AppendText(vbCrLf + "TSX not running")
            Return
        End If
        'Don't worry about an abort yet
        'Save the current TSX settings
        TTutility.SaveTSXState()

        'Main loop runs autofocusruncount number of times
        For runcounter = 0 To (Int(RepetitionsNumber.Value) - 1)
            'Check to see if TSX is launched, and still running
            If Not TTutility.checkTSX Then
                ProfileDataBox.AppendText(vbCrLf + "TSX not running")
                Return
            End If
            'check to see if we've had an abort
            If HaltRequest() Then
                Return
            End If
            'Save the current TSX settings
            ProfileDataBox.AppendText(vbCrLf + "CLS to target star, if enabled")
            ' Close Loop Slew to the target star, assuming some drift might have occurred during the last twenty minutes
            If (CLSCheckBox.Checked) Then
                If TTutility.ClosedLoopSlew(Int(ClearFilterNumber.Value), Convert.ToDouble(ExposureNumberBox.Value)) <> 0 Then
                    ProfileDataBox.AppendText(vbCrLf + "CLS Failure")
                End If
            End If

            'Filter loop:  runs @focus2 from the lowest to highest filter number entered
            For currentfilter = firstfilter To lastfilter
                'Check for abort, note it if it happens, but move on to finish out restoring the system state, etc
                '  the loop will still run out, but without doing @focus2 (or @focus3) so it will be a rapid spin
                'if no abort, run @focus2 for the filter
                Dim fStatus As Integer
                If HaltRequest() Then
                    Return
                Else
                    fStatus = FocusFilter(currentfilter)
                    If AtFocus3CheckBox.Checked Then
                        If fStatus <> 0 Then
                            ProfileDataBox.AppendText("   @Focus3 Error: " + fStatus.ToString())
                        Else
                            ProfileDataBox.AppendText("   Focused at: " + Str(currentfocuserposition))
                        End If
                    Else
                        If fStatus <> 0 Then
                            ProfileDataBox.AppendText("   @Focus2 Error: " + fStatus.ToString())
                        Else
                            ProfileDataBox.AppendText("   Focused at: " + Str(currentfocuserposition))
                        End If
                    End If
                End If
            Next
            'Restore original settings, including target star
            TTutility.RestoreTSXState()

            'Run wait loop for five minutes or so before next run
            If runcounter < (Int(RepetitionsNumber.Value) - 1) Then
                For i = 1 To Int(WaitNumber.Value * 60)
                    If Not HaltRequest() Then
                        Show()
                        Application.DoEvents()
                        System.Threading.Thread.Sleep(1000)
                    Else
                        ProfileDataBox.AppendText(vbCrLf + "Profiling Aborted" + vbCrLf)
                        Return
                    End If
                Next
            End If
        Next
        If HaltRequest() Then
            ProfileDataBox.AppendText(vbCrLf + "Profiling Aborted" + vbCrLf)
        End If
        Return
    End Sub

    Private Function FocusFilter(filternumber As Integer) As Integer
        'Run @Focus2 with filternumber.  Return True if successful, False if not

        Const af3ShotCount = 3
        Const af3AutoStar = True

        'Create camera object
        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftCamera")
        Dim tstat As Integer = 0
        'Configure @Focus2
        tsx_cc.Asynchronous = False
        tsx_cc.AutoSaveFocusImages = False
        tsx_cc.ImageReduction = TheSkyXLib.ccdsoftImageReduction.cdAutoDark
        tsx_cc.FilterIndexZeroBased = filternumber
        tsx_cc.Delay = 0 'Don't delay for every focus image, just the first
        'Delay for one seconds for the filter to settle
        System.Threading.Thread.Sleep(1000)
        currentfocuserposition = tsx_cc.focPosition
        currentfocusertemp = tsx_cc.focTemperature
        AverageTemperatureReadout.Text = Str(TTutility.DoubleClip(currentfocusertemp, 1))
        currentfocuserfilter = tsx_cc.FilterIndexZeroBased
        If OptimizeExposureBox.Checked Then
            ExposureNumberBox.Value = TTutility.OptimizeExposure(2000, currentfocuserfilter, Convert.ToDouble(ExposureNumberBox.Value))
        End If
        tsx_cc.FocusExposureTime = Convert.ToDouble(ExposureNumberBox.Value)
        DisplayFocuserStatus()
        'Run @Focus2 or @Focus3
        '   Create a camera object
        '   Launch the autofocus watching out for an exception -- which will be posted in TSX
        ' **********************************
        ' Note -- V1.6 Changed atfocus to a synchronous call because there is no other way to find out if it failed
        '   to converge
        ' **********************************
        Dim focstat As Integer = 0
        tsx_cc.Asynchronous = False
        If (AtFocus3CheckBox.Checked) Then
            Try
                focstat = tsx_cc.AtFocus3(af3ShotCount, af3AutoStar)
            Catch ex As Exception
                focstat = ex.HResult
                If HaltRequest() Then
                    Return (focstat)
                End If
            End Try
        Else
            Try
                focstat = tsx_cc.AtFocus2()
            Catch ex As Exception
                focstat = ex.HResult
                If HaltRequest() Then
                    Return (focstat)
                End If
            End Try
        End If
        'Just close up, TSX will spawn error window unless this is an abort
        'If @focus2 has returned an error, assume that focus has diverged or insufficent exposure error 
        ' then double the exposure and try once again, but just once
        If focstat <> 0 Then
            tsx_cc.FocusExposureTime = Convert.ToDouble((ExposureNumberBox.Value * 2))
            If (AtFocus3CheckBox.Checked) Then
                Try
                    focstat = tsx_cc.AtFocus3(af3ShotCount, af3AutoStar)
                Catch ex As Exception
                    'Don't do anything
                End Try
            Else
                Try
                    focstat = tsx_cc.AtFocus2()
                Catch ex As Exception
                    'Don't do anything
                End Try
            End If
        End If
        currentfocuserposition = tsx_cc.focPosition
        tsx_cc = Nothing
        Return (focstat)
    End Function

    Private Sub PreFocusButton_Click(sender As Object, e As EventArgs) Handles PreFocusButton.Click
        'Moves focuser to critical focus position for current temperature based on a focus data file:
        '   Checks for focuser connection
        '   Gets current temperature from focuser
        '   Calls function to compute new position from a selected focus training data file and current temperature
        '   Moves focuser to new position from current position

        Dim focusfilelist = FocusFileDialog.ShowDialog()
        Dim focusfile = FocusFileDialog.FileNames(0)
        Dim movestat As Integer

        Dim tsx_cc = CreateObject("TheSkyX.ccdsoftCamera")
        If tsx_cc.focIsConnected <> 1 Then
            'No focuser; no bueno
            Return
        End If

        Dim currenttemp = tsx_cc.focTemperature()

        Dim focdata = TTutility.GetFOCdata(focusfile)

        Dim newfocusposition = TTutility.ComputePosition(focdata, ReferenceFilter.Value, currenttemp)

        If newfocusposition = 0 Then
            'Insufficient data to compute new position so, just leave it.
            Return
        Else
            If newfocusposition < tsx_cc.focPosition Then
                movestat = tsx_cc.focMoveIn(tsx_cc.focPosition - newfocusposition)
            Else
                movestat = tsx_cc.focMoveOut(newfocusposition - tsx_cc.focPosition)
            End If
        End If

        Return
    End Sub

    Private Sub DisplayFocuserStatus()
        'Displays the current filter, position and temperature of the focuser in the data window
        ProfileDataBox.AppendText(vbCrLf + "Temperature = " + TTutility.DoubleClip(currentfocusertemp, 1) +
                              "   Filter = " + Str(currentfocuserfilter) +
                              "   Start Position = " + Str(currentfocuserposition))
        Show()
        Return
    End Sub

    Private Function HaltRequest() As Boolean
        'Returns true if an abort has been set
        'otherwise returns false

        Application.DoEvents()
        System.Threading.Thread.Sleep(1000)
        If focusprofileabort Then
            ProfileDataBox.AppendText("   Profile Abort")
            Return (True)
        Else
            Return (False)
        End If
    End Function

    Private Sub AnalyzeButton_Click(sender As Object, e As EventArgs) Handles AnalyzeButton.Click

        Dim filtername As String

        Dim focusfilelist = FocusFileDialog.ShowDialog()
        If focusfilelist = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        Dim focusfile = FocusFileDialog.FileNames(0)

        Dim focData = TTutility.GetFOCdata(focusfile)
        Dim filtercount = TTutility.GetfilterCount(focData)

        'Reference filter is the filter that all offsets are calculated from -- normally the clear/lum filter
        Dim refFilter As Integer = ReferenceFilter.Value

        Dim reffiltername = TTutility.GetFilterName(focData, refFilter)
        Dim refData = New TTutility.FilterData(focData, refFilter)
        Dim refAvgTemp As Double = refData.Average
        'AverageTemperatureReadout.Text = Str(TTutility.DoubleClip(refAvgTemp, 0))
        AverageTemperatureReadout.Text = refAvgTemp.ToString("0.0")
        If refData.Count < 2 Then
            ProfileDataBox.AppendText(vbCrLf + "Insufficient data for analysis")
            Return
        End If
        Dim refLine = New TTutility.Trendline(refData.Positions, refData.Temperatures)
        Dim refAccuracy = TTutility.ComputeAccuracy(focData,
                                                    refFilter,
                                                    refFilter,
                                                    0,
                                                    calculatedCFZ)

        ProfileDataBox.AppendText(vbCrLf +
                                   "Analyzing focus data:  " + focusfile +
                                   "  Ref Temp:" + Str(ReferenceTemperature.Value).PadRight(4) + " (Deg C)" +
                                   "  Position @ Ref Temp: " + Str(refLine.Position(ReferenceTemperature.Value)))

        ProfileDataBox.AppendText(vbCrLf + vbCrLf +
                                  "Filter: " + reffiltername.PadRight(10) + vbTab +
                                  "Avg:" + Str(Convert.ToInt32(TTutility.ComputeAverage(refData.Positions))) + vbTab +
                                  "Pos:" + Str(refLine.Position(ReferenceTemperature.Value)) + vbTab +
                                  "Offset: " + "  Ref" + vbTab +
                                  "Comp: " + Str(refLine.Slope).PadRight(4) + " (Per Deg)" + vbTab +
                                  "Accuracy: " + Str(refAccuracy) + ("%"))

        For i = 0 To filtercount - 1
            If i <> refFilter Then
                filtername = TTutility.GetFilterName(focData, i)
                Dim nxtfiltername = TTutility.GetFilterName(focData, i)
                Dim nxtData = New TTutility.FilterData(focData, i)
                If nxtData.Count > 1 Then
                    Dim nxtLine As New TTutility.Trendline(nxtData.Positions, nxtData.Temperatures)
                    Dim nxtoffset = TTutility.ComputeOffset(focData, refFilter, i, ReferenceTemperature.Value)
                    Dim ofsAccuracy = TTutility.ComputeAccuracy(focData,
                                                            refFilter,
                                                            i,
                                                            nxtoffset,
                                                            calculatedCFZ)

                    ProfileDataBox.AppendText(vbCrLf +
                                          "Filter: " + filtername.PadRight(10) + vbTab +
                                          "Avg:" + Str(Convert.ToInt32(TTutility.ComputeAverage(nxtData.Positions))) + vbTab +
                                          "Pos:" + Str(nxtLine.Position(ReferenceTemperature.Value)) + vbTab +
                                          "Offset: " + Str(nxtoffset).PadLeft(5) + vbTab +
                                          "Comp: " + Str(nxtLine.Slope).PadLeft(4) + " (Per Deg)" + vbTab +
                                          "Accuracy: " + Str(ofsAccuracy) + ("%"))
                End If
            End If
        Next
        ProfileDataBox.AppendText(vbCrLf + vbCrLf)
        Return
    End Sub

    Private Sub FocalRatioVal_ValueChanged(sender As Object, e As EventArgs) Handles FocalRatioVal.ValueChanged
        'Focal value changed: calculate new CFZ value
        CFZStepsText.Text = CalculateCFZ().ToString
        Return
    End Sub

    Private Sub ResolutionVal_ValueChanged(sender As Object, e As EventArgs) Handles ResolutionVal.ValueChanged
        'Resolution value changed: calculate new CFZ value
        CFZStepsText.Text = CalculateCFZ().ToString
        Return
    End Sub

    Private Function CalculateCFZ() As Integer
        If ResolutionVal.Value <> 0 Then
            Return ((FocalRatioVal.Value ^ 2) * 2.2) / ResolutionVal.Value
        Else
            Return (0)
        End If
        Return (0)
    End Function

End Class