' Form that acts as a pop up that allows the user to download the currently generated grid
Public Class Download
    ' Stores the path as a string and the bitmap to download
    Dim path As String = Application.StartupPath.Substring(0, Application.StartupPath.Length - 9) & "Images"
    Dim bmGrid As Bitmap

    ' Subroutine that sets the bitmap to download
    Public Sub SetBitMap(newBMGrid As Bitmap)
        bmGrid = newBMGrid
    End Sub

    ' Subroutine that sets the path for the folder browser
    Private Sub Download_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fbdChooseFileLocation.SelectedPath = path
    End Sub

    ' Subroutine that opens a file browser and allows user to select path
    Private Sub btnChangeFileLocation_Click(sender As Object, e As EventArgs) Handles btnChangeFileLocation.Click
        fbdChooseFileLocation.ShowDialog()
        path = fbdChooseFileLocation.SelectedPath
    End Sub

    ' Subroutine that downloads the bitmap to the selected file path 
    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        Dim stepper As Integer
        Dim saved As Boolean

        ' Loops through until it finds a file name that isn't taken
        Do Until saved
            Dim newPath As String = path & "\Grid" & stepper & ".png"

            ' If the file doesn't exist then save the bitmap
            If Not IO.File.Exists(newPath) Then
                bmGrid.Save(newPath)
                saved = True
            End If

            stepper += 1
        Loop

        ' Hides the form
        Hide()
    End Sub
End Class