<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Download
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
        Me.btnChangeFileLocation = New System.Windows.Forms.Button()
        Me.fbdChooseFileLocation = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnChangeFileLocation
        '
        Me.btnChangeFileLocation.BackColor = System.Drawing.Color.White
        Me.btnChangeFileLocation.FlatAppearance.BorderSize = 0
        Me.btnChangeFileLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeFileLocation.Location = New System.Drawing.Point(10, 10)
        Me.btnChangeFileLocation.Name = "btnChangeFileLocation"
        Me.btnChangeFileLocation.Size = New System.Drawing.Size(120, 50)
        Me.btnChangeFileLocation.TabIndex = 44
        Me.btnChangeFileLocation.Text = "Change File Location"
        Me.btnChangeFileLocation.UseVisualStyleBackColor = False
        '
        'fbdChooseFileLocation
        '
        Me.fbdChooseFileLocation.ShowNewFolderButton = False
        '
        'btnDownload
        '
        Me.btnDownload.BackColor = System.Drawing.Color.White
        Me.btnDownload.FlatAppearance.BorderSize = 0
        Me.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDownload.Location = New System.Drawing.Point(140, 10)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(120, 50)
        Me.btnDownload.TabIndex = 45
        Me.btnDownload.Text = "Download"
        Me.btnDownload.UseVisualStyleBackColor = False
        '
        'Download
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(270, 70)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.btnChangeFileLocation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Download"
        Me.Text = "Download"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnChangeFileLocation As Button
    Friend WithEvents fbdChooseFileLocation As FolderBrowserDialog
    Friend WithEvents btnDownload As Button
End Class
