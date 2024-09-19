<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DisplayGrid
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.tmrDraw = New System.Windows.Forms.Timer(Me.components)
        Me.picGrid = New System.Windows.Forms.PictureBox()
        CType(Me.picGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrDraw
        '
        '
        'picGrid
        '
        Me.picGrid.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.picGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picGrid.Location = New System.Drawing.Point(0, 0)
        Me.picGrid.Name = "picGrid"
        Me.picGrid.Size = New System.Drawing.Size(600, 600)
        Me.picGrid.TabIndex = 0
        Me.picGrid.TabStop = False
        '
        'DisplayGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Controls.Add(Me.picGrid)
        Me.Name = "DisplayGrid"
        Me.Size = New System.Drawing.Size(600, 600)
        CType(Me.picGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tmrDraw As Timer
    Friend WithEvents picGrid As PictureBox
End Class
