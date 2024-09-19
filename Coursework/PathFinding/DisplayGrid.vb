' User control that allows for displaying of grid
Public Class DisplayGrid
    ' Function that returns whether or not a key is currently presses
    Private Declare Function GetAsyncKeyState Lib "user32" (vKey As Integer) As Integer

    ' Variables to the current grid customisation and path finding algorithms
    Private selectedMazeAlgorithm As GridCustomisation
    Private selectedPathAlgorithm As PathfindingAlgorithm

    Private delay As Integer = 100
    Private drawAmount As Integer = 1

    ' Array that stores the types of all cells on the grid
    Private grid As New Grid

    ' Boolean that stores whether or not the path has been clear which is needed for user customisation
    Private isCleared As Boolean

    ' Queue to store the instructions to draw the array
    Private bmGrid As New Bitmap(600, 600)
    Private drawQueue As New Queue(Of Instructions)

    ' Variables to store the StartCell and FinishCell coordinates
    Private startCell As Point
    Private finishCell As Point

    ' Subroutine that sets the selected path finding algorithm
    Public Sub SetPathAlgorithm(newPathAlgorithm As PathfindingAlgorithm)
        ' Updates the variable
        selectedPathAlgorithm = newPathAlgorithm

        ' Clears the path then solves the maze
        ClearPath()
        FindPath()
        DrawGrid()
    End Sub

    ' Subroutine that sets the selected maze algorithm
    Public Sub SetMazeAlgorithm(newMazeAlgorithm As GridCustomisation)
        ' Updates the variable
        selectedMazeAlgorithm = newMazeAlgorithm

        ' Generates new maze
        Generate()
        DrawGrid()
    End Sub

    ' Subroutine that sets the new delay for drawing the grid
    Public Sub SetDelay(newDelay As Integer)
        ' Updates the variable
        delay = newDelay

        tmrDraw.Interval = 1

        Select Case delay
            Case <= 5
                drawAmount = 7 - delay
            Case > 5
                drawAmount = 1
                tmrDraw.Interval = delay - 5
        End Select
    End Sub

    ' Subroutine that sets the new size of the grid
    Public Sub SetSize(newSize As Integer)
        ' Updates the variable and resizes the array
        grid.SetSize(newSize)

        ' Sets the size of the bitmap
        If grid.GetSize >= 600 Then
            bmGrid = New Bitmap(grid.GetSize, grid.GetSize)
        Else
            bmGrid = New Bitmap(600, 600)
        End If

        ' If the grid customisation is user customisation reset
        If selectedMazeAlgorithm = GridCustomisation.UserCustomisation Then
            Generate()

            ' If it's a maze generation algorithm stop drawing
        Else
            drawQueue.Clear()
        End If
    End Sub

    ' Subroutine that sets the start and finish cell dependent on the grid customisation option
    Private Sub SetStartFinish()
        If selectedMazeAlgorithm = GridCustomisation.UserCustomisation Then
            startCell = New Point(0, 0)
            finishCell = New Point(grid.GetSize - 1, grid.GetSize - 1)
        Else
            Dim boundary As Integer = grid.GetSize - 2 + grid.GetSize Mod 2

            startCell = New Point(0, 0)
            finishCell = New Point(boundary, boundary)
        End If
    End Sub

    ' Function that returns the bitmap
    Public Function GetBitmap()
        Return bmGrid
    End Function

    ' Subroutine that stops the timer then sets all the Closed, Open and Path cells to empty 
    Public Sub ClearPath()
        If Not isCleared Then
            isCleared = True

            ' Sets all the Closed, Open and Path cells to empty 
            DrawAll()

            For Y = 0 To grid.GetSize - 1
                For X = 0 To grid.GetSize - 1
                    If {Type.Path, Type.Open, Type.Closed}.Contains(grid(X, Y)) Then
                        UpdateCell(X, Y, Type.Empty)
                    End If
                Next
            Next
        End If
    End Sub

    ' Fills the grid with 1 colour
    Private Sub ClearGrid()
        grid.Fill(Type.Empty)
        Draw(0, 0, GetColour(Type.Empty), grid.GetSize)
    End Sub

    ' Subroutine that updates the cell and draws the update
    Private Sub UpdateCell(X As Integer, Y As Integer, cellType As Type)
        grid(X, Y) = cellType
        Draw(X, Y, GetColour(cellType))
    End Sub
    Private Sub UpdateCell(Point As Point, cellType As Type)
        UpdateCell(Point.X, Point.Y, cellType)
    End Sub

#Region "Main"
    ' Subroutine that allows the user to customise the job
    Private Sub UserCustomisation(sender As Object, e As MouseEventArgs) Handles picGrid.MouseMove, picGrid.MouseDown
        If selectedMazeAlgorithm = GridCustomisation.UserCustomisation Then
            ' Turn the location of the cursor on the grid into the corresponding coordinates in the array
            Dim X As Integer = Math.Floor(e.Location.X / (600 / grid.GetSize))
            Dim Y As Integer = Math.Floor(e.Location.Y / (600 / grid.GetSize))
            Dim newPT As New Point(X, Y)

            ' Check if the point is inside the bounds of the array and that it isnt the start or finish cell
            If VerifyPoint(newPT, grid.GetSize) AndAlso grid(newPT) < Type.Start Then
                ' Sets to wall when LMB is pressed
                If e.Button = MouseButtons.Left Then
                    UserAdd(newPT, Type.Wall)

                    ' Sets to empty when RMB is pressed
                ElseIf e.Button = MouseButtons.Right Then
                    UserAdd(newPT, Type.Empty)

                    ' Sets to StartCell when the C key is pressed
                ElseIf GetAsyncKeyState(Keys.C) Then
                    UpdateCell(startCell, Type.Empty)
                    startCell = newPT
                    UserAdd(newPT, Type.Start)

                    ' Sets to FinishCell when the V key is pressed
                ElseIf GetAsyncKeyState(Keys.V) Then
                    UpdateCell(finishCell, Type.Empty)
                    finishCell = newPT
                    UserAdd(newPT, Type.Finish)
                End If
            End If
        End If
    End Sub

    ' Subroutine used by UserCustomisation that updates the cell then clears the path
    Private Sub UserAdd(pt As Point, cellType As Type)
        UpdateCell(pt, cellType)

        ClearPath()
        UpdateGrid()
    End Sub

    ' Subroutine that generates a maze using the selected maze algorithm
    Public Sub Generate()
        ' Clears the metrics and drawing queue
        Main.ClearAllMetrics()
        drawQueue.Clear()

        ' Sets the start and finish cells
        SetStartFinish()

        ' If user customisation is selected clear the grid and set the start and finish point
        If selectedMazeAlgorithm = GridCustomisation.UserCustomisation Then
            ClearGrid()

            UpdateCell(startCell, Type.Start)
            UpdateCell(finishCell, Type.Finish)
            UpdateGrid()

            ' If a maze generation algorithm is selected generate a maze using that algorithm
        Else
            Dim mazeGeneration As New MazeGeneration(selectedMazeAlgorithm)

            Randomize()
            mazeGeneration.Generate(grid, drawQueue)
        End If
    End Sub

    ' Subroutine that solves the grid using the selected path finding algorithm
    Public Sub FindPath()
        Dim pathFinding As New PathFinding(selectedPathAlgorithm, startCell, finishCell)

        pathFinding.FindPath(grid, drawQueue)

        isCleared = False
    End Sub
#End Region

#Region "Grid Drawing"
    ' Subroutine that draws a cell on the grid using graphics
    Private Sub Draw(x As Integer, y As Integer, colour As Color, Optional size As Integer = 1)
        Dim gridScale As Integer = Math.Max(1, Math.Floor(600 / grid.GetSize))
        Dim bmGraphics As Graphics = Graphics.FromImage(bmGrid)

        bmGraphics.FillRectangle(New SolidBrush(colour), gridScale * x, gridScale * y, gridScale * size, gridScale * size)
    End Sub

    ' Subroutine that dequeues and draws an instruction from the drawing queue
    Private Sub DrawNext()
        Dim current As Instructions = drawQueue.Dequeue

        Draw(current.X, current.Y, current.colour, current.size)
    End Sub

    ' Subroutine that finishes drawing and empties queue
    Public Sub DrawAll()
        Do Until drawQueue.Count = 0
            DrawNext()
        Loop
    End Sub

    ' Subroutine that draws the grid
    Public Sub DrawGrid()
        ' Completes all the instructions in the drawing queue if there is no delay
        If delay = 0 Then
            DrawAll()
            UpdateGrid()

            ' Starts the timer which displays the grid with a interval delay
        Else
            tmrDraw.Start()
        End If
    End Sub

    ' Subroutine that is ran every tick of the drawing timer
    Private Sub tmrDraw_Tick() Handles tmrDraw.Tick
        ' If the drawing queue is empty stop the timer
        If drawQueue.Count = 0 Then
            tmrDraw.Stop()

            ' If the delay is 0 then draw all instructions
        ElseIf delay = 0 Then
            DrawAll()
            tmrDraw.Stop()

            UpdateGrid()

            ' Draws drawing amount of drawing instructions
        Else
            For i = 1 To drawAmount
                If drawQueue.Count <> 0 Then
                    DrawNext()
                Else
                    i = drawAmount
                End If
            Next

            UpdateGrid()
        End If
    End Sub

    ' Subroutine that updates the bitmap that is used to display the grid
    Public Sub UpdateGrid()
        picGrid.BackgroundImage = bmGrid

        picGrid.Refresh()
    End Sub
#End Region
End Class