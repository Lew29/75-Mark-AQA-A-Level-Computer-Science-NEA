' Defines a class to act as the Grid 2d array
Public Class Grid
    Private gridSize As Integer
    Private arrGrid(,) As Integer

    ' Uses the Default property to allow the class to be accessed as an array using either the x and y coordinates or a point
    Default Public Property Index(X As Integer, Y As Integer)
        Get
            Return arrGrid(X, Y)
        End Get
        Set(value)
            arrGrid(X, Y) = value
        End Set
    End Property
    Default Public Property Index(pt As Point)
        Get
            Return arrGrid(pt.X, pt.Y)
        End Get
        Set(value)
            arrGrid(pt.X, pt.Y) = value
        End Set
    End Property

    ' Subroutine that sets the grid size and redefines the array
    Public Sub SetSize(newSize As Integer)
        gridSize = newSize

        ReDim arrGrid(gridSize - 1, gridSize - 1)
    End Sub

    ' Function that returns the size of the grid
    Public Function GetSize() As Integer
        Return gridSize
    End Function

    ' Subroutine that fills the grid with CellType
    Public Sub Fill(cellType As Integer)
        For X = 0 To gridSize - 1
            For Y = 0 To gridSize - 1
                ' If not already CellType then set to CellType
                If arrGrid(X, Y) <> cellType Then
                    arrGrid(X, Y) = cellType
                End If
            Next
        Next
    End Sub
End Class