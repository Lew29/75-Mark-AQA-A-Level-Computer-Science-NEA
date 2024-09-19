<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.cmbSelectedGridCustomisation = New System.Windows.Forms.ComboBox()
        Me.cmbSelectedPath = New System.Windows.Forms.ComboBox()
        Me.btnSolve = New System.Windows.Forms.Button()
        Me.trbDelay = New System.Windows.Forms.TrackBar()
        Me.lblDelay = New System.Windows.Forms.Label()
        Me.nudDelay = New System.Windows.Forms.NumericUpDown()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lbltextTimeTakenPath = New System.Windows.Forms.Label()
        Me.lblCellsExplored = New System.Windows.Forms.Label()
        Me.lblShortestPath = New System.Windows.Forms.Label()
        Me.lblPathfinding = New System.Windows.Forms.Label()
        Me.btnGenerateSolve = New System.Windows.Forms.Button()
        Me.lblGridCustomisation = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.nudSize = New System.Windows.Forms.NumericUpDown()
        Me.trbSize = New System.Windows.Forms.TrackBar()
        Me.txtTimeTakenPath = New System.Windows.Forms.Label()
        Me.txtCellsExplored = New System.Windows.Forms.Label()
        Me.txtShortestPath = New System.Windows.Forms.Label()
        Me.pnlCustomisation = New System.Windows.Forms.Label()
        Me.lblTimeTakenGrid = New System.Windows.Forms.Label()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.txtTimeTakenGrid = New System.Windows.Forms.Label()
        Me.lblSettings = New System.Windows.Forms.Label()
        Me.lblDeadends = New System.Windows.Forms.Label()
        Me.txtDeadends = New System.Windows.Forms.Label()
        Me.txtBranches = New System.Windows.Forms.Label()
        Me.lblBranches = New System.Windows.Forms.Label()
        Me.txtAverageLength = New System.Windows.Forms.Label()
        Me.lblAverageLength = New System.Windows.Forms.Label()
        Me.pnlMazeAlgorithm = New System.Windows.Forms.Panel()
        Me.dgGrid = New DisplayGrid()
        CType(Me.trbDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trbSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMazeAlgorithm.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSize
        '
        Me.lblSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSize.AutoSize = True
        Me.lblSize.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.ForeColor = System.Drawing.Color.White
        Me.lblSize.Location = New System.Drawing.Point(610, 538)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(43, 18)
        Me.lblSize.TabIndex = 9
        Me.lblSize.Text = "Size: "
        '
        'cmbSelectedGridCustomisation
        '
        Me.cmbSelectedGridCustomisation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSelectedGridCustomisation.BackColor = System.Drawing.Color.White
        Me.cmbSelectedGridCustomisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSelectedGridCustomisation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSelectedGridCustomisation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSelectedGridCustomisation.FormattingEnabled = True
        Me.cmbSelectedGridCustomisation.Items.AddRange(New Object() {"Recursive Backtracking", "Recursive Division", "Kruskals", "Binary Tree", "Prims", "User Customisation"})
        Me.cmbSelectedGridCustomisation.Location = New System.Drawing.Point(610, 229)
        Me.cmbSelectedGridCustomisation.Name = "cmbSelectedGridCustomisation"
        Me.cmbSelectedGridCustomisation.Size = New System.Drawing.Size(150, 21)
        Me.cmbSelectedGridCustomisation.TabIndex = 38
        '
        'cmbSelectedPath
        '
        Me.cmbSelectedPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSelectedPath.BackColor = System.Drawing.Color.White
        Me.cmbSelectedPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSelectedPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSelectedPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSelectedPath.FormattingEnabled = True
        Me.cmbSelectedPath.Items.AddRange(New Object() {"Breadth-first search", "A* search", "Depth-First Search", "GreedyDFS"})
        Me.cmbSelectedPath.Location = New System.Drawing.Point(610, 29)
        Me.cmbSelectedPath.Name = "cmbSelectedPath"
        Me.cmbSelectedPath.Size = New System.Drawing.Size(150, 21)
        Me.cmbSelectedPath.TabIndex = 42
        '
        'btnSolve
        '
        Me.btnSolve.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSolve.BackColor = System.Drawing.Color.White
        Me.btnSolve.FlatAppearance.BorderSize = 0
        Me.btnSolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSolve.Location = New System.Drawing.Point(610, 55)
        Me.btnSolve.Name = "btnSolve"
        Me.btnSolve.Size = New System.Drawing.Size(73, 40)
        Me.btnSolve.TabIndex = 43
        Me.btnSolve.Text = "Solve"
        Me.btnSolve.UseVisualStyleBackColor = False
        '
        'trbDelay
        '
        Me.trbDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trbDelay.Location = New System.Drawing.Point(652, 507)
        Me.trbDelay.Maximum = 200
        Me.trbDelay.Name = "trbDelay"
        Me.trbDelay.Size = New System.Drawing.Size(63, 45)
        Me.trbDelay.TabIndex = 49
        Me.trbDelay.TickFrequency = 100
        Me.trbDelay.Value = 100
        '
        'lblDelay
        '
        Me.lblDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDelay.AutoSize = True
        Me.lblDelay.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDelay.ForeColor = System.Drawing.Color.White
        Me.lblDelay.Location = New System.Drawing.Point(610, 505)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(54, 18)
        Me.lblDelay.TabIndex = 50
        Me.lblDelay.Text = "Delay: "
        '
        'nudDelay
        '
        Me.nudDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudDelay.Location = New System.Drawing.Point(710, 510)
        Me.nudDelay.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nudDelay.Name = "nudDelay"
        Me.nudDelay.Size = New System.Drawing.Size(50, 20)
        Me.nudDelay.TabIndex = 51
        Me.nudDelay.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.White
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Location = New System.Drawing.Point(687, 55)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(73, 40)
        Me.btnClear.TabIndex = 52
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'lbltextTimeTakenPath
        '
        Me.lbltextTimeTakenPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltextTimeTakenPath.AutoSize = True
        Me.lbltextTimeTakenPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbltextTimeTakenPath.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltextTimeTakenPath.ForeColor = System.Drawing.Color.White
        Me.lbltextTimeTakenPath.Location = New System.Drawing.Point(610, 150)
        Me.lbltextTimeTakenPath.Name = "lbltextTimeTakenPath"
        Me.lbltextTimeTakenPath.Size = New System.Drawing.Size(87, 18)
        Me.lbltextTimeTakenPath.TabIndex = 53
        Me.lbltextTimeTakenPath.Text = "Time taken:"
        '
        'lblCellsExplored
        '
        Me.lblCellsExplored.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCellsExplored.AutoSize = True
        Me.lblCellsExplored.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCellsExplored.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCellsExplored.ForeColor = System.Drawing.Color.White
        Me.lblCellsExplored.Location = New System.Drawing.Point(610, 125)
        Me.lblCellsExplored.Name = "lblCellsExplored"
        Me.lblCellsExplored.Size = New System.Drawing.Size(68, 18)
        Me.lblCellsExplored.TabIndex = 55
        Me.lblCellsExplored.Text = "Explored:"
        '
        'lblShortestPath
        '
        Me.lblShortestPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblShortestPath.AutoSize = True
        Me.lblShortestPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblShortestPath.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShortestPath.ForeColor = System.Drawing.Color.White
        Me.lblShortestPath.Location = New System.Drawing.Point(610, 100)
        Me.lblShortestPath.Name = "lblShortestPath"
        Me.lblShortestPath.Size = New System.Drawing.Size(101, 18)
        Me.lblShortestPath.TabIndex = 56
        Me.lblShortestPath.Text = "Shortest path:"
        '
        'lblPathfinding
        '
        Me.lblPathfinding.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPathfinding.Font = New System.Drawing.Font("Tahoma", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPathfinding.ForeColor = System.Drawing.Color.White
        Me.lblPathfinding.Location = New System.Drawing.Point(610, 5)
        Me.lblPathfinding.Name = "lblPathfinding"
        Me.lblPathfinding.Size = New System.Drawing.Size(150, 20)
        Me.lblPathfinding.TabIndex = 57
        Me.lblPathfinding.Text = "Pathfinding"
        Me.lblPathfinding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGenerateSolve
        '
        Me.btnGenerateSolve.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateSolve.BackColor = System.Drawing.Color.White
        Me.btnGenerateSolve.FlatAppearance.BorderSize = 0
        Me.btnGenerateSolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateSolve.Location = New System.Drawing.Point(610, 405)
        Me.btnGenerateSolve.Name = "btnGenerateSolve"
        Me.btnGenerateSolve.Size = New System.Drawing.Size(150, 40)
        Me.btnGenerateSolve.TabIndex = 44
        Me.btnGenerateSolve.Text = "Generator and Solve"
        Me.btnGenerateSolve.UseVisualStyleBackColor = False
        '
        'lblGridCustomisation
        '
        Me.lblGridCustomisation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGridCustomisation.Font = New System.Drawing.Font("Tahoma", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGridCustomisation.ForeColor = System.Drawing.Color.White
        Me.lblGridCustomisation.Location = New System.Drawing.Point(610, 205)
        Me.lblGridCustomisation.Name = "lblGridCustomisation"
        Me.lblGridCustomisation.Size = New System.Drawing.Size(150, 20)
        Me.lblGridCustomisation.TabIndex = 60
        Me.lblGridCustomisation.Text = "Grid Customisation"
        Me.lblGridCustomisation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGenerate
        '
        Me.btnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerate.BackColor = System.Drawing.Color.White
        Me.btnGenerate.FlatAppearance.BorderSize = 0
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerate.Location = New System.Drawing.Point(610, 255)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(150, 40)
        Me.btnGenerate.TabIndex = 61
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'nudSize
        '
        Me.nudSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudSize.Location = New System.Drawing.Point(710, 538)
        Me.nudSize.Maximum = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.nudSize.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudSize.Name = "nudSize"
        Me.nudSize.Size = New System.Drawing.Size(50, 20)
        Me.nudSize.TabIndex = 67
        Me.nudSize.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'trbSize
        '
        Me.trbSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trbSize.Location = New System.Drawing.Point(641, 535)
        Me.trbSize.Maximum = 18
        Me.trbSize.Name = "trbSize"
        Me.trbSize.Size = New System.Drawing.Size(74, 45)
        Me.trbSize.TabIndex = 66
        Me.trbSize.TickFrequency = 6
        Me.trbSize.Value = 6
        '
        'txtTimeTakenPath
        '
        Me.txtTimeTakenPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTimeTakenPath.BackColor = System.Drawing.Color.White
        Me.txtTimeTakenPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtTimeTakenPath.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtTimeTakenPath.Location = New System.Drawing.Point(705, 150)
        Me.txtTimeTakenPath.Name = "txtTimeTakenPath"
        Me.txtTimeTakenPath.Size = New System.Drawing.Size(55, 20)
        Me.txtTimeTakenPath.TabIndex = 69
        '
        'txtCellsExplored
        '
        Me.txtCellsExplored.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCellsExplored.BackColor = System.Drawing.Color.White
        Me.txtCellsExplored.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtCellsExplored.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtCellsExplored.Location = New System.Drawing.Point(705, 125)
        Me.txtCellsExplored.Name = "txtCellsExplored"
        Me.txtCellsExplored.Size = New System.Drawing.Size(55, 20)
        Me.txtCellsExplored.TabIndex = 70
        '
        'txtShortestPath
        '
        Me.txtShortestPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShortestPath.BackColor = System.Drawing.Color.White
        Me.txtShortestPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtShortestPath.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtShortestPath.Location = New System.Drawing.Point(705, 100)
        Me.txtShortestPath.Name = "txtShortestPath"
        Me.txtShortestPath.Size = New System.Drawing.Size(55, 20)
        Me.txtShortestPath.TabIndex = 71
        '
        'pnlCustomisation
        '
        Me.pnlCustomisation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCustomisation.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCustomisation.ForeColor = System.Drawing.Color.White
        Me.pnlCustomisation.Location = New System.Drawing.Point(610, 300)
        Me.pnlCustomisation.Name = "pnlCustomisation"
        Me.pnlCustomisation.Size = New System.Drawing.Size(150, 95)
        Me.pnlCustomisation.TabIndex = 72
        Me.pnlCustomisation.Text = "Start - C" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Finish - V" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Wall - LMB" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Empty - RMB"
        Me.pnlCustomisation.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTimeTakenGrid
        '
        Me.lblTimeTakenGrid.AutoSize = True
        Me.lblTimeTakenGrid.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeTakenGrid.ForeColor = System.Drawing.Color.White
        Me.lblTimeTakenGrid.Location = New System.Drawing.Point(0, 0)
        Me.lblTimeTakenGrid.Name = "lblTimeTakenGrid"
        Me.lblTimeTakenGrid.Size = New System.Drawing.Size(87, 18)
        Me.lblTimeTakenGrid.TabIndex = 73
        Me.lblTimeTakenGrid.Text = "Time taken:"
        '
        'btnDownload
        '
        Me.btnDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDownload.BackColor = System.Drawing.Color.White
        Me.btnDownload.FlatAppearance.BorderSize = 0
        Me.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDownload.Location = New System.Drawing.Point(610, 565)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(150, 40)
        Me.btnDownload.TabIndex = 74
        Me.btnDownload.Text = "Download"
        Me.btnDownload.UseVisualStyleBackColor = False
        '
        'txtTimeTakenGrid
        '
        Me.txtTimeTakenGrid.BackColor = System.Drawing.Color.White
        Me.txtTimeTakenGrid.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtTimeTakenGrid.Location = New System.Drawing.Point(95, 0)
        Me.txtTimeTakenGrid.Name = "txtTimeTakenGrid"
        Me.txtTimeTakenGrid.Size = New System.Drawing.Size(55, 20)
        Me.txtTimeTakenGrid.TabIndex = 75
        '
        'lblSettings
        '
        Me.lblSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSettings.Font = New System.Drawing.Font("Tahoma", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSettings.ForeColor = System.Drawing.Color.White
        Me.lblSettings.Location = New System.Drawing.Point(610, 485)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(150, 20)
        Me.lblSettings.TabIndex = 76
        Me.lblSettings.Text = "Settings"
        Me.lblSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDeadends
        '
        Me.lblDeadends.AutoSize = True
        Me.lblDeadends.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeadends.ForeColor = System.Drawing.Color.White
        Me.lblDeadends.Location = New System.Drawing.Point(0, 25)
        Me.lblDeadends.Name = "lblDeadends"
        Me.lblDeadends.Size = New System.Drawing.Size(78, 18)
        Me.lblDeadends.TabIndex = 77
        Me.lblDeadends.Text = "Deadends:"
        '
        'txtDeadends
        '
        Me.txtDeadends.BackColor = System.Drawing.Color.White
        Me.txtDeadends.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtDeadends.Location = New System.Drawing.Point(95, 25)
        Me.txtDeadends.Name = "txtDeadends"
        Me.txtDeadends.Size = New System.Drawing.Size(55, 20)
        Me.txtDeadends.TabIndex = 78
        '
        'txtBranches
        '
        Me.txtBranches.BackColor = System.Drawing.Color.White
        Me.txtBranches.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtBranches.Location = New System.Drawing.Point(95, 50)
        Me.txtBranches.Name = "txtBranches"
        Me.txtBranches.Size = New System.Drawing.Size(55, 20)
        Me.txtBranches.TabIndex = 80
        '
        'lblBranches
        '
        Me.lblBranches.AutoSize = True
        Me.lblBranches.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranches.ForeColor = System.Drawing.Color.White
        Me.lblBranches.Location = New System.Drawing.Point(0, 50)
        Me.lblBranches.Name = "lblBranches"
        Me.lblBranches.Size = New System.Drawing.Size(73, 18)
        Me.lblBranches.TabIndex = 79
        Me.lblBranches.Text = "Branches:"
        '
        'txtAverageLength
        '
        Me.txtAverageLength.BackColor = System.Drawing.Color.White
        Me.txtAverageLength.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtAverageLength.Location = New System.Drawing.Point(95, 75)
        Me.txtAverageLength.Name = "txtAverageLength"
        Me.txtAverageLength.Size = New System.Drawing.Size(55, 20)
        Me.txtAverageLength.TabIndex = 81
        '
        'lblAverageLength
        '
        Me.lblAverageLength.AutoSize = True
        Me.lblAverageLength.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblAverageLength.ForeColor = System.Drawing.Color.White
        Me.lblAverageLength.Location = New System.Drawing.Point(0, 75)
        Me.lblAverageLength.Name = "lblAverageLength"
        Me.lblAverageLength.Size = New System.Drawing.Size(87, 18)
        Me.lblAverageLength.TabIndex = 82
        Me.lblAverageLength.Text = "Avg Length:"
        '
        'pnlMazeAlgorithm
        '
        Me.pnlMazeAlgorithm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMazeAlgorithm.Controls.Add(Me.txtAverageLength)
        Me.pnlMazeAlgorithm.Controls.Add(Me.lblAverageLength)
        Me.pnlMazeAlgorithm.Controls.Add(Me.lblDeadends)
        Me.pnlMazeAlgorithm.Controls.Add(Me.txtDeadends)
        Me.pnlMazeAlgorithm.Controls.Add(Me.lblBranches)
        Me.pnlMazeAlgorithm.Controls.Add(Me.txtBranches)
        Me.pnlMazeAlgorithm.Controls.Add(Me.txtTimeTakenGrid)
        Me.pnlMazeAlgorithm.Controls.Add(Me.lblTimeTakenGrid)
        Me.pnlMazeAlgorithm.Location = New System.Drawing.Point(610, 300)
        Me.pnlMazeAlgorithm.Name = "pnlMazeAlgorithm"
        Me.pnlMazeAlgorithm.Size = New System.Drawing.Size(150, 95)
        Me.pnlMazeAlgorithm.TabIndex = 83
        '
        'dgGrid
        '
        Me.dgGrid.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dgGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.dgGrid.Location = New System.Drawing.Point(5, 5)
        Me.dgGrid.Name = "dgGrid"
        Me.dgGrid.Size = New System.Drawing.Size(600, 600)
        Me.dgGrid.TabIndex = 68
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(765, 610)
        Me.Controls.Add(Me.lblSettings)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.nudSize)
        Me.Controls.Add(Me.trbSize)
        Me.Controls.Add(Me.nudDelay)
        Me.Controls.Add(Me.trbDelay)
        Me.Controls.Add(Me.lblDelay)
        Me.Controls.Add(Me.dgGrid)
        Me.Controls.Add(Me.txtShortestPath)
        Me.Controls.Add(Me.txtCellsExplored)
        Me.Controls.Add(Me.txtTimeTakenPath)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.btnGenerateSolve)
        Me.Controls.Add(Me.lblPathfinding)
        Me.Controls.Add(Me.lblShortestPath)
        Me.Controls.Add(Me.lblCellsExplored)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSolve)
        Me.Controls.Add(Me.lbltextTimeTakenPath)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.cmbSelectedPath)
        Me.Controls.Add(Me.cmbSelectedGridCustomisation)
        Me.Controls.Add(Me.lblGridCustomisation)
        Me.Controls.Add(Me.pnlMazeAlgorithm)
        Me.Controls.Add(Me.pnlCustomisation)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(50, 50)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pathfinding & Maze Generation"
        CType(Me.trbDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trbSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMazeAlgorithm.ResumeLayout(False)
        Me.pnlMazeAlgorithm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSize As Label
    Friend WithEvents cmbSelectedGridCustomisation As ComboBox
    Friend WithEvents cmbSelectedPath As ComboBox
    Friend WithEvents btnSolve As Button
    Friend WithEvents trbDelay As TrackBar
    Friend WithEvents lblDelay As Label
    Friend WithEvents nudDelay As NumericUpDown
    Friend WithEvents btnClear As Button
    Friend WithEvents lbltextTimeTakenPath As Label
    Friend WithEvents lblCellsExplored As Label
    Friend WithEvents lblShortestPath As Label
    Friend WithEvents lblPathfinding As Label
    Friend WithEvents btnGenerateSolve As Button
    Friend WithEvents lblGridCustomisation As Label
    Friend WithEvents btnGenerate As Button
    Friend WithEvents nudSize As NumericUpDown
    Friend WithEvents trbSize As TrackBar
    Friend WithEvents dgGrid As DisplayGrid
    Friend WithEvents txtTimeTakenPath As Label
    Friend WithEvents txtCellsExplored As Label
    Friend WithEvents txtShortestPath As Label
    Friend WithEvents pnlCustomisation As Label
    Friend WithEvents lblTimeTakenGrid As Label
    Friend WithEvents btnDownload As Button
    Friend WithEvents txtTimeTakenGrid As Label
    Friend WithEvents lblSettings As Label
    Friend WithEvents lblDeadends As Label
    Friend WithEvents txtDeadends As Label
    Friend WithEvents txtBranches As Label
    Friend WithEvents lblBranches As Label
    Friend WithEvents txtAverageLength As Label
    Friend WithEvents lblAverageLength As Label
    Friend WithEvents pnlMazeAlgorithm As Panel
End Class
