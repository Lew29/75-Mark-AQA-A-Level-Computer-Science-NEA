' Form that acts as main page that has all controls and the display grid
Public Class Main
    ' Subroutine that's ran when the form is shown
    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Sets the default selected maze and path finding indexes in the combo box
        cmbSelectedGridCustomisation.SelectedIndex = GridCustomisation.RecursiveBacktracking
        cmbSelectedPath.SelectedIndex = PathfindingAlgorithm.BreadthFirst
        pnlCustomisation.BringToFront()

        ' Generates and displays the selected maze algorithm
        dgGrid.Generate()
        dgGrid.DrawAll()
        dgGrid.UpdateGrid()
    End Sub

#Region "Controls"
    ' Subroutine that sets the selected maze generation algorithm when the combo box is changed
    Private Sub cmbSelectedGridCustomisation_Selected(sender As Object, e As EventArgs) Handles cmbSelectedGridCustomisation.SelectedIndexChanged
        Dim selectedGridCustomisation As GridCustomisation = cmbSelectedGridCustomisation.SelectedIndex

        ' Sets the interface to grid customisation if it is the selected grid customisation option
        If selectedGridCustomisation = GridCustomisation.UserCustomisation Then
            InterfaceUserCustomisation()
        Else
            InterfaceMazeAlgorithm()
        End If

        dgGrid.SetMazeAlgorithm(selectedGridCustomisation)
    End Sub

    ' Subroutine that sets the selected path finding algorithm when the combo box is changed
    Private Sub cmbSelectedPath_Selected(sender As Object, e As EventArgs) Handles cmbSelectedPath.SelectedIndexChanged
        Dim selectedPathAlgorithm As PathfindingAlgorithm = cmbSelectedPath.SelectedIndex

        dgGrid.SetPathAlgorithm(selectedPathAlgorithm)
    End Sub

    ' Subroutine that sets the delay of the grid and updates the numeric up down box to match
    Private Sub trbDelay_Scroll(sender As Object, e As EventArgs) Handles trbDelay.Scroll
        Dim newDelay As Integer = trbDelay.Value

        ' If the numeric up down box value doesn't match the new delay updates it
        If nudDelay.Value <> newDelay Then
            nudDelay.Value = newDelay
        End If
    End Sub

    ' Subroutine that sets the delay of the grid and updates the numeric up down box to match
    Private Sub nudDelay_ValueChanged(sender As Object, e As EventArgs) Handles nudDelay.ValueChanged
        Dim newDelay As Integer = nudDelay.Value

        ' If the track bar value doesn't match the new delay updates it
        If trbDelay.Value <> newDelay Then
            trbDelay.Value = newDelay
        End If

        dgGrid.SetDelay(newDelay)
    End Sub

    ' Subroutine that sets the size of the grid and updates the numeric up down box to match
    Private Sub trbSize_Scroll(sender As Object, e As EventArgs) Handles trbSize.Scroll
        ' Creates an array that represents the custom scaling of the track bar
        Dim sizeList() As Integer = {5, 8, 10, 12, 15, 20, 25, 30, 40, 50, 60,
                                     75, 100, 120, 150, 200, 300, 600, 1200}
        ' Sets the new size as the index in the array 
        Dim newSize As Integer = sizeList(trbSize.Value)

        ' If the numeric up down box value doesn't match the new size updates it
        If nudSize.Value <> newSize Then
            nudSize.Value = newSize
        End If
    End Sub

    ' Subroutine that sets the size of the grid and updates the track bar to match
    Private Sub nudSize_ValueChanged(sender As Object, e As EventArgs) Handles nudSize.ValueChanged
        Dim newSize As Integer = nudSize.Value

        ' If the track bar value doesn't match the new size updates it
        If trbSize.Value <> newSize Then
            ' Creates an array that represents the custom scaling of the track bar
            Dim sizeList() As Integer = {5, 8, 10, 12, 15, 20, 25, 30, 40, 50, 60,
                                         75, 100, 120, 150, 200, 300, 600, 1200}
            Dim index As Integer

            ' Works out the track bar index of the new size
            Do Until newSize <= sizeList(index)
                index += 1
            Loop

            trbSize.Value = index
        End If

        dgGrid.SetSize(newSize)
    End Sub

    ' Subroutine that generates the selected grid customisation algorithm
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        dgGrid.Generate()
        dgGrid.DrawGrid()
    End Sub

    ' Subroutine that solves the grid using the selected path finding algorithm
    Private Sub btnSolve_Click(sender As Object, e As EventArgs) Handles btnSolve.Click
        dgGrid.ClearPath()
        dgGrid.FindPath()
        dgGrid.DrawGrid()
    End Sub

    ' Subroutine that clears all path finding cells on the grid
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        dgGrid.ClearPath()
        dgGrid.UpdateGrid()
    End Sub

    ' Subroutine that generate and solve button a maze using the selected maze and path finding algorithms
    Private Sub btnGenerateSolve_Click(sender As Object, e As EventArgs) Handles btnGenerateSolve.Click
        dgGrid.Generate()
        dgGrid.FindPath()
        dgGrid.DrawGrid()
    End Sub

    ' Subroutine that open the download form and sets the bitmap
    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        Download.Show()
        Download.BringToFront()
        Download.Location = New Point(Location.X + 200, Location.Y + 250)

        ' Draws all so the bitmap passed to download is the completed grid
        dgGrid.DrawAll()
        Download.SetBitMap(dgGrid.GetBitmap)
    End Sub
#End Region

#Region "Interface"
    ' Subroutine that shows the controls related to maze generation
    Public Sub InterfaceMazeAlgorithm()
        pnlCustomisation.Visible = False
        btnGenerate.Text = "Generate"
    End Sub

    ' Subroutine that shows the controls related to user customisation
    Public Sub InterfaceUserCustomisation()
        pnlCustomisation.Visible = True
        btnGenerate.Text = "Reset"
    End Sub

    ' Subroutine that resets all text boxes showing information about metrics
    Public Sub ClearAllMetrics()
        ' Path finding
        txtShortestPath.Text = ""
        txtCellsExplored.Text = ""
        txtTimeTakenPath.Text = ""

        ' Maze generation
        txtDeadends.Text = ""
        txtBranches.Text = ""
        txtAverageLength.Text = ""
        txtTimeTakenGrid.Text = ""
    End Sub
#End Region
End Class