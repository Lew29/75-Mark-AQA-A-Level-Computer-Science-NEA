' Module that stores methods that are used across the solution
Module Methods
    ' Function that returns the colour of a CellType
    Public Function GetColour(cellType As Type)
        ' Defines the colours for each Type
        Dim Empty As Color = Color.FromArgb(255, 255, 255, 255)
        Dim Wall As Color = Color.FromArgb(255, 90, 90, 90)
        Dim Open As Color = Color.FromArgb(255, 0, 220, 170)
        Dim Closed As Color = Color.FromArgb(255, 0, 220, 220)
        Dim Path As Color = Color.FromArgb(255, 0, 170, 220)
        Dim Start As Color = Color.FromArgb(255, 0, 220, 0)
        Dim Finish As Color = Color.FromArgb(255, 220, 0, 0)

        ' Creates an array of the Colours
        Dim colours() As Color = {Empty, Wall, Open, Closed, Path, Start, Finish}

        ' Returns the colour of CellType
        Return colours(cellType)
    End Function

    ' Function that verifies the X and Y coordinates or a point are within the bounds of the array
    Public Function VerifyPoint(X As Integer, Y As Integer, gridSize As Integer) As Boolean
        If X >= 0 And X < gridSize And Y >= 0 And Y < gridSize Then
            Return True
        Else Return False
        End If
    End Function
    Public Function VerifyPoint(pt As Point, gridSize As Integer) As Boolean
        Return VerifyPoint(pt.X, pt.Y, gridSize)
    End Function

    ' Function that generates a random number between an upper and lower bound
    Public Function RandomNum(lBound As Integer, uBound As Integer) As Integer
        Return Math.Floor(((uBound - lBound + 1) * Rnd()) + lBound)
    End Function

    ' Subroutine that sets a Cell to type in the array and enqueues the instruction to draw this change
    Public Sub SetCell(X As Integer, Y As Integer, cellType As Type, grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        grid(X, Y) = cellType
        DrawEnqueue(drawQueue, X, Y, GetColour(cellType))
    End Sub
    Public Sub SetCell(pt As Point, cellType As Type, grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        SetCell(pt.X, pt.Y, cellType, grid, drawQueue)
    End Sub

    ' Subroutine that enqueues a new drawing instruction using the parameters
    Public Sub DrawEnqueue(drawQueue As Queue(Of Instructions), X As Integer, Y As Integer, newColour As Color, Optional newSize As Integer = 1)
        drawQueue.Enqueue(New Instructions(X, Y, newColour, newSize))
    End Sub

    ' Fills the grid with one type
    Public Sub Fill(cellType As Type, grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        ' Sets all cells in the array to CellType
        grid.Fill(cellType)

        ' Makes the entire grid CellType
        DrawEnqueue(drawQueue, 0, 0, GetColour(cellType), grid.GetSize)
    End Sub
End Module