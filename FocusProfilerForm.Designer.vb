<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FocusProfilerForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.DoneButton = New System.Windows.Forms.Button()
        Me.FocusFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.AFToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.RepetitionsNumber = New System.Windows.Forms.NumericUpDown()
        Me.RepetitionsLabel = New System.Windows.Forms.Label()
        Me.WaitLabel = New System.Windows.Forms.Label()
        Me.WaitNumber = New System.Windows.Forms.NumericUpDown()
        Me.AnalyzeButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ReferenceFilter = New System.Windows.Forms.NumericUpDown()
        Me.ReferenceTemperature = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AnalysisBox = New System.Windows.Forms.GroupBox()
        Me.AverageTemperatureReadout = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ClearFilterNumber = New System.Windows.Forms.NumericUpDown()
        Me.ClearFilterLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LastFilterNumber = New System.Windows.Forms.NumericUpDown()
        Me.FirstFilterNumber = New System.Windows.Forms.NumericUpDown()
        Me.FirstFilterLabel = New System.Windows.Forms.Label()
        Me.ExposureNumberBox = New System.Windows.Forms.NumericUpDown()
        Me.ExposureLabel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ZBFSLabel = New System.Windows.Forms.Label()
        Me.ProfileDataBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OptimizeExposureBox = New System.Windows.Forms.CheckBox()
        Me.AtFocus3CheckBox = New System.Windows.Forms.CheckBox()
        Me.CLSCheckBox = New System.Windows.Forms.CheckBox()
        Me.PreFocusButton = New System.Windows.Forms.Button()
        Me.FocalRatioVal = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ResolutionVal = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CFZStepsText = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TemperatureReadout = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.RepetitionsNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WaitNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReferenceFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReferenceTemperature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AnalysisBox.SuspendLayout()
        CType(Me.ClearFilterNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LastFilterNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstFilterNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExposureNumberBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.FocalRatioVal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResolutionVal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.BackColor = System.Drawing.Color.LightCoral
        Me.StartButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StartButton.Location = New System.Drawing.Point(12, 36)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(82, 26)
        Me.StartButton.TabIndex = 1
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = False
        '
        'StopButton
        '
        Me.StopButton.BackColor = System.Drawing.Color.LightCoral
        Me.StopButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StopButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StopButton.Location = New System.Drawing.Point(12, 68)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(82, 26)
        Me.StopButton.TabIndex = 2
        Me.StopButton.Text = "Stop"
        Me.StopButton.UseVisualStyleBackColor = False
        '
        'DoneButton
        '
        Me.DoneButton.BackColor = System.Drawing.Color.LightCoral
        Me.DoneButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoneButton.Location = New System.Drawing.Point(547, 533)
        Me.DoneButton.Name = "DoneButton"
        Me.DoneButton.Size = New System.Drawing.Size(89, 26)
        Me.DoneButton.TabIndex = 4
        Me.DoneButton.Text = "Done"
        Me.DoneButton.UseVisualStyleBackColor = False
        '
        'FocusFileDialog
        '
        Me.FocusFileDialog.FileName = "*.foc"
        Me.FocusFileDialog.InitialDirectory = "C:\Users\*\Documents\Software Bisque\TheSky64 Professional Edition\Focuser Data"
        '
        'RepetitionsNumber
        '
        Me.RepetitionsNumber.Location = New System.Drawing.Point(450, 38)
        Me.RepetitionsNumber.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.RepetitionsNumber.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepetitionsNumber.Name = "RepetitionsNumber"
        Me.RepetitionsNumber.Size = New System.Drawing.Size(52, 20)
        Me.RepetitionsNumber.TabIndex = 13
        Me.RepetitionsNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RepetitionsNumber.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'RepetitionsLabel
        '
        Me.RepetitionsLabel.AutoSize = True
        Me.RepetitionsLabel.ForeColor = System.Drawing.SystemColors.Control
        Me.RepetitionsLabel.Location = New System.Drawing.Point(290, 40)
        Me.RepetitionsLabel.Name = "RepetitionsLabel"
        Me.RepetitionsLabel.Size = New System.Drawing.Size(60, 13)
        Me.RepetitionsLabel.TabIndex = 14
        Me.RepetitionsLabel.Text = "Repetitions"
        '
        'WaitLabel
        '
        Me.WaitLabel.AutoSize = True
        Me.WaitLabel.ForeColor = System.Drawing.SystemColors.Control
        Me.WaitLabel.Location = New System.Drawing.Point(290, 63)
        Me.WaitLabel.Name = "WaitLabel"
        Me.WaitLabel.Size = New System.Drawing.Size(155, 13)
        Me.WaitLabel.TabIndex = 15
        Me.WaitLabel.Text = "Wait Between Repetitions (min)"
        '
        'WaitNumber
        '
        Me.WaitNumber.Location = New System.Drawing.Point(450, 61)
        Me.WaitNumber.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.WaitNumber.Name = "WaitNumber"
        Me.WaitNumber.Size = New System.Drawing.Size(52, 20)
        Me.WaitNumber.TabIndex = 16
        Me.WaitNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.WaitNumber.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'AnalyzeButton
        '
        Me.AnalyzeButton.BackColor = System.Drawing.Color.LightCoral
        Me.AnalyzeButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnalyzeButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.AnalyzeButton.Location = New System.Drawing.Point(10, 20)
        Me.AnalyzeButton.Name = "AnalyzeButton"
        Me.AnalyzeButton.Size = New System.Drawing.Size(83, 26)
        Me.AnalyzeButton.TabIndex = 19
        Me.AnalyzeButton.Text = "Analyze"
        Me.AnalyzeButton.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(136, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Reference Filter"
        '
        'ReferenceFilter
        '
        Me.ReferenceFilter.Location = New System.Drawing.Point(224, 53)
        Me.ReferenceFilter.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.ReferenceFilter.Name = "ReferenceFilter"
        Me.ReferenceFilter.Size = New System.Drawing.Size(41, 20)
        Me.ReferenceFilter.TabIndex = 21
        Me.ReferenceFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ReferenceFilter.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'ReferenceTemperature
        '
        Me.ReferenceTemperature.DecimalPlaces = 1
        Me.ReferenceTemperature.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.ReferenceTemperature.Location = New System.Drawing.Point(224, 25)
        Me.ReferenceTemperature.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.ReferenceTemperature.Minimum = New Decimal(New Integer() {50, 0, 0, -2147483648})
        Me.ReferenceTemperature.Name = "ReferenceTemperature"
        Me.ReferenceTemperature.Size = New System.Drawing.Size(45, 20)
        Me.ReferenceTemperature.TabIndex = 23
        Me.ReferenceTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ReferenceTemperature.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(130, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Reference Temp"
        '
        'AnalysisBox
        '
        Me.AnalysisBox.Controls.Add(Me.AverageTemperatureReadout)
        Me.AnalysisBox.Controls.Add(Me.ReferenceTemperature)
        Me.AnalysisBox.Controls.Add(Me.Label4)
        Me.AnalysisBox.Controls.Add(Me.Label3)
        Me.AnalysisBox.Controls.Add(Me.AnalyzeButton)
        Me.AnalysisBox.ForeColor = System.Drawing.SystemColors.Control
        Me.AnalysisBox.Location = New System.Drawing.Point(15, 513)
        Me.AnalysisBox.Name = "AnalysisBox"
        Me.AnalysisBox.Size = New System.Drawing.Size(455, 57)
        Me.AnalysisBox.TabIndex = 33
        Me.AnalysisBox.TabStop = False
        Me.AnalysisBox.Text = "Focus Analysis"
        '
        'AverageTemperatureReadout
        '
        Me.AverageTemperatureReadout.AutoSize = True
        Me.AverageTemperatureReadout.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.AverageTemperatureReadout.ForeColor = System.Drawing.SystemColors.ControlText
        Me.AverageTemperatureReadout.Location = New System.Drawing.Point(397, 27)
        Me.AverageTemperatureReadout.Name = "AverageTemperatureReadout"
        Me.AverageTemperatureReadout.Size = New System.Drawing.Size(13, 13)
        Me.AverageTemperatureReadout.TabIndex = 25
        Me.AverageTemperatureReadout.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(309, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Average Temp"
        '
        'ClearFilterNumber
        '
        Me.ClearFilterNumber.Location = New System.Drawing.Point(648, 84)
        Me.ClearFilterNumber.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.ClearFilterNumber.Name = "ClearFilterNumber"
        Me.ClearFilterNumber.Size = New System.Drawing.Size(40, 20)
        Me.ClearFilterNumber.TabIndex = 12
        Me.ClearFilterNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ClearFilterNumber.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'ClearFilterLabel
        '
        Me.ClearFilterLabel.AutoSize = True
        Me.ClearFilterLabel.ForeColor = System.Drawing.SystemColors.Control
        Me.ClearFilterLabel.Location = New System.Drawing.Point(580, 86)
        Me.ClearFilterLabel.Name = "ClearFilterLabel"
        Me.ClearFilterLabel.Size = New System.Drawing.Size(52, 13)
        Me.ClearFilterLabel.TabIndex = 11
        Me.ClearFilterLabel.Text = "CLS Filter"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(580, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Last Filter"
        '
        'LastFilterNumber
        '
        Me.LastFilterNumber.Location = New System.Drawing.Point(648, 61)
        Me.LastFilterNumber.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.LastFilterNumber.Name = "LastFilterNumber"
        Me.LastFilterNumber.Size = New System.Drawing.Size(40, 20)
        Me.LastFilterNumber.TabIndex = 7
        Me.LastFilterNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LastFilterNumber.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'FirstFilterNumber
        '
        Me.FirstFilterNumber.Location = New System.Drawing.Point(648, 38)
        Me.FirstFilterNumber.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.FirstFilterNumber.Name = "FirstFilterNumber"
        Me.FirstFilterNumber.Size = New System.Drawing.Size(40, 20)
        Me.FirstFilterNumber.TabIndex = 5
        Me.FirstFilterNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FirstFilterLabel
        '
        Me.FirstFilterLabel.AutoSize = True
        Me.FirstFilterLabel.ForeColor = System.Drawing.SystemColors.Control
        Me.FirstFilterLabel.Location = New System.Drawing.Point(580, 40)
        Me.FirstFilterLabel.Name = "FirstFilterLabel"
        Me.FirstFilterLabel.Size = New System.Drawing.Size(51, 13)
        Me.FirstFilterLabel.TabIndex = 6
        Me.FirstFilterLabel.Text = "First Filter"
        '
        'ExposureNumberBox
        '
        Me.ExposureNumberBox.DecimalPlaces = 2
        Me.ExposureNumberBox.Location = New System.Drawing.Point(450, 84)
        Me.ExposureNumberBox.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.ExposureNumberBox.Name = "ExposureNumberBox"
        Me.ExposureNumberBox.Size = New System.Drawing.Size(52, 20)
        Me.ExposureNumberBox.TabIndex = 17
        Me.ExposureNumberBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ExposureNumberBox.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ExposureLabel
        '
        Me.ExposureLabel.AutoSize = True
        Me.ExposureLabel.ForeColor = System.Drawing.SystemColors.Control
        Me.ExposureLabel.Location = New System.Drawing.Point(290, 86)
        Me.ExposureLabel.Name = "ExposureLabel"
        Me.ExposureLabel.Size = New System.Drawing.Size(77, 13)
        Me.ExposureLabel.TabIndex = 18
        Me.ExposureLabel.Text = "Exposure (sec)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(331, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Profile Sequence Control"
        '
        'ZBFSLabel
        '
        Me.ZBFSLabel.AutoSize = True
        Me.ZBFSLabel.ForeColor = System.Drawing.SystemColors.Control
        Me.ZBFSLabel.Location = New System.Drawing.Point(566, 15)
        Me.ZBFSLabel.Name = "ZBFSLabel"
        Me.ZBFSLabel.Size = New System.Drawing.Size(139, 13)
        Me.ZBFSLabel.TabIndex = 10
        Me.ZBFSLabel.Text = "Filter Selection (Zero-based)"
        '
        'ProfileDataBox
        '
        Me.ProfileDataBox.Location = New System.Drawing.Point(16, 12)
        Me.ProfileDataBox.Multiline = True
        Me.ProfileDataBox.Name = "ProfileDataBox"
        Me.ProfileDataBox.ReadOnly = True
        Me.ProfileDataBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ProfileDataBox.Size = New System.Drawing.Size(733, 281)
        Me.ProfileDataBox.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptimizeExposureBox)
        Me.GroupBox1.Controls.Add(Me.AtFocus3CheckBox)
        Me.GroupBox1.Controls.Add(Me.CLSCheckBox)
        Me.GroupBox1.Controls.Add(Me.ZBFSLabel)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.LastFilterNumber)
        Me.GroupBox1.Controls.Add(Me.FirstFilterLabel)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ExposureLabel)
        Me.GroupBox1.Controls.Add(Me.FirstFilterNumber)
        Me.GroupBox1.Controls.Add(Me.ExposureNumberBox)
        Me.GroupBox1.Controls.Add(Me.ClearFilterLabel)
        Me.GroupBox1.Controls.Add(Me.ClearFilterNumber)
        Me.GroupBox1.Controls.Add(Me.WaitNumber)
        Me.GroupBox1.Controls.Add(Me.WaitLabel)
        Me.GroupBox1.Controls.Add(Me.RepetitionsLabel)
        Me.GroupBox1.Controls.Add(Me.RepetitionsNumber)
        Me.GroupBox1.Controls.Add(Me.StopButton)
        Me.GroupBox1.Controls.Add(Me.StartButton)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(15, 393)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(734, 114)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Focus Profile"
        '
        'OptimizeExposureBox
        '
        Me.OptimizeExposureBox.AutoSize = True
        Me.OptimizeExposureBox.Location = New System.Drawing.Point(113, 76)
        Me.OptimizeExposureBox.Name = "OptimizeExposureBox"
        Me.OptimizeExposureBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.OptimizeExposureBox.Size = New System.Drawing.Size(113, 17)
        Me.OptimizeExposureBox.TabIndex = 37
        Me.OptimizeExposureBox.Text = "Optimize Exposure"
        Me.OptimizeExposureBox.UseVisualStyleBackColor = True
        '
        'AtFocus3CheckBox
        '
        Me.AtFocus3CheckBox.AutoSize = True
        Me.AtFocus3CheckBox.Location = New System.Drawing.Point(132, 58)
        Me.AtFocus3CheckBox.Name = "AtFocus3CheckBox"
        Me.AtFocus3CheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AtFocus3CheckBox.Size = New System.Drawing.Size(94, 17)
        Me.AtFocus3CheckBox.TabIndex = 36
        Me.AtFocus3CheckBox.Text = "Use @Focus3"
        Me.AtFocus3CheckBox.UseVisualStyleBackColor = True
        '
        'CLSCheckBox
        '
        Me.CLSCheckBox.AutoSize = True
        Me.CLSCheckBox.Checked = True
        Me.CLSCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CLSCheckBox.Location = New System.Drawing.Point(158, 40)
        Me.CLSCheckBox.Name = "CLSCheckBox"
        Me.CLSCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CLSCheckBox.Size = New System.Drawing.Size(68, 17)
        Me.CLSCheckBox.TabIndex = 35
        Me.CLSCheckBox.Text = "Use CLS"
        Me.CLSCheckBox.UseVisualStyleBackColor = True
        '
        'PreFocusButton
        '
        Me.PreFocusButton.BackColor = System.Drawing.Color.LightCoral
        Me.PreFocusButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PreFocusButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PreFocusButton.Location = New System.Drawing.Point(12, 36)
        Me.PreFocusButton.Name = "PreFocusButton"
        Me.PreFocusButton.Size = New System.Drawing.Size(82, 26)
        Me.PreFocusButton.TabIndex = 10
        Me.PreFocusButton.Text = "Pre-Focus"
        Me.PreFocusButton.UseVisualStyleBackColor = False
        '
        'FocalRatioVal
        '
        Me.FocalRatioVal.DecimalPlaces = 2
        Me.FocalRatioVal.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.FocalRatioVal.Location = New System.Drawing.Point(480, 18)
        Me.FocalRatioVal.Name = "FocalRatioVal"
        Me.FocalRatioVal.Size = New System.Drawing.Size(61, 20)
        Me.FocalRatioVal.TabIndex = 27
        Me.FocalRatioVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FocalRatioVal.Value = New Decimal(New Integer() {72, 0, 0, 65536})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(349, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Focal Ratio"
        '
        'ResolutionVal
        '
        Me.ResolutionVal.DecimalPlaces = 3
        Me.ResolutionVal.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.ResolutionVal.Location = New System.Drawing.Point(480, 53)
        Me.ResolutionVal.Name = "ResolutionVal"
        Me.ResolutionVal.Size = New System.Drawing.Size(61, 20)
        Me.ResolutionVal.TabIndex = 29
        Me.ResolutionVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ResolutionVal.Value = New Decimal(New Integer() {11, 0, 0, 131072})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(347, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Resolution (microns/step)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(580, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Critical Focus Zone (steps)"
        '
        'CFZStepsText
        '
        Me.CFZStepsText.AutoSize = True
        Me.CFZStepsText.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CFZStepsText.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CFZStepsText.Location = New System.Drawing.Point(629, 55)
        Me.CFZStepsText.Name = "CFZStepsText"
        Me.CFZStepsText.Size = New System.Drawing.Size(31, 13)
        Me.CFZStepsText.TabIndex = 32
        Me.CFZStepsText.Text = "0000"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TemperatureReadout)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.ReferenceFilter)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CFZStepsText)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ResolutionVal)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.FocalRatioVal)
        Me.GroupBox2.Controls.Add(Me.PreFocusButton)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Location = New System.Drawing.Point(15, 299)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(734, 88)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Focus Set Up"
        '
        'TemperatureReadout
        '
        Me.TemperatureReadout.AutoSize = True
        Me.TemperatureReadout.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TemperatureReadout.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TemperatureReadout.Location = New System.Drawing.Point(252, 20)
        Me.TemperatureReadout.Name = "TemperatureReadout"
        Me.TemperatureReadout.Size = New System.Drawing.Size(13, 13)
        Me.TemperatureReadout.TabIndex = 34
        Me.TemperatureReadout.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.Control
        Me.Label10.Location = New System.Drawing.Point(136, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Current Temp"
        '
        'FocusProfilerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(761, 582)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProfileDataBox)
        Me.Controls.Add(Me.DoneButton)
        Me.Controls.Add(Me.AnalysisBox)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "FocusProfilerForm"
        Me.Text = "Focus Temperature Profiler (Ver 1.94)"
        CType(Me.RepetitionsNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WaitNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReferenceFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReferenceTemperature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AnalysisBox.ResumeLayout(False)
        Me.AnalysisBox.PerformLayout()
        CType(Me.ClearFilterNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LastFilterNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstFilterNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExposureNumberBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.FocalRatioVal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResolutionVal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents StopButton As System.Windows.Forms.Button
    Friend WithEvents DoneButton As System.Windows.Forms.Button
    Friend WithEvents FocusFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AFToolTips As System.Windows.Forms.ToolTip
    Friend WithEvents RepetitionsNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents RepetitionsLabel As System.Windows.Forms.Label
    Friend WithEvents WaitLabel As System.Windows.Forms.Label
    Friend WithEvents WaitNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents AnalyzeButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ReferenceFilter As System.Windows.Forms.NumericUpDown
    Friend WithEvents ReferenceTemperature As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AnalysisBox As System.Windows.Forms.GroupBox
    Friend WithEvents ClearFilterNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents ClearFilterLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LastFilterNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents FirstFilterNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents FirstFilterLabel As System.Windows.Forms.Label
    Friend WithEvents ExposureNumberBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents ExposureLabel As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ZBFSLabel As System.Windows.Forms.Label
    Friend WithEvents ProfileDataBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PreFocusButton As System.Windows.Forms.Button
    Friend WithEvents FocalRatioVal As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ResolutionVal As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CFZStepsText As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AverageTemperatureReadout As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CLSCheckBox As CheckBox
    Friend WithEvents AtFocus3CheckBox As CheckBox
    Friend WithEvents OptimizeExposureBox As CheckBox
    Friend WithEvents TemperatureReadout As Label
    Friend WithEvents Label10 As Label
End Class
