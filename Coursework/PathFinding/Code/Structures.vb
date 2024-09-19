' Structure used in Kruskals and Prims maze generation algorithm to store connections between two cells
Public Structure Connection
    ' Creates 3 variables to store the from, target and corridor cells
    ReadOnly from As Point
    ReadOnly target As Point
    Dim corridor As Point

    ' Constructor that takes the points or coordinates of two cells and calculates the corridor cell
    Public Sub New(newFromX As Integer, newFromY As Integer, newTargetX As Integer, newTargetY As Integer)
        from = New Point(newFromX, newFromY)
        target = New Point(newTargetX, newTargetY)
        corridor = GetCorridor()
    End Sub
    Public Sub New(newFrom As Point, newTarget As Point)
        From = newFrom
        Target = newTarget
        Corridor = GetCorridor()
    End Sub

    ' Function that returns the corridor cell calculated using the FromCell and TargetCell
    Private Function GetCorridor()
        Dim newCorridor As New Point((From.X + Target.X) / 2, (From.Y + Target.Y) / 2)

        Return newCorridor
    End Function
End Structure

' Structure used to represent instructions for drawing on the grid
Public Structure Instructions
    ' Creates 4 variables to store the information needed to draw a cell
    Dim X As Integer
    Dim Y As Integer
    Dim colour As Color
    Dim size As Integer

    ' Constructor for creating an instruction with specified coordinates, colour, and size
    ' Size is optional so it can be set to grid size and be used to fill the entire grid
    Sub New(newX As Integer, newY As Integer, newColour As Color, Optional newSize As Integer = 1)
        X = newX
        Y = newY
        colour = newColour
        size = newSize
    End Sub
End Structure

' Structure used in A* Search and GreedyDFS which stores heuristics used in path finding
Public Structure CellProperties
    ' Store the CurrentCell's ParentCell
    Dim returnCell As Point
    ' Store the H-Cost an estimation of the distance to the FinishCell
    Dim hCost As Integer
    ' Store the G-Cost the total distance to reach the CurrentCell from the StartCell
    Dim gCost As Integer
    ' Store the F-cost the sum of H-cost and G-cost
    Dim fCost As Integer

    ' Subroutine that calculates the sets the return cell and calculated the costs
    Sub New(currentCell As Point, parentCell As Point, finishCell As Point, cellProperties As Dictionary(Of Point, CellProperties))
        returnCell = parentCell
        hCost = Math.Abs(finishCell.X - currentCell.X) + Math.Abs(finishCell.Y - currentCell.Y)
        gCost = cellProperties(returnCell).gCost + 1
        fCost = hCost + gCost
    End Sub
End Structure