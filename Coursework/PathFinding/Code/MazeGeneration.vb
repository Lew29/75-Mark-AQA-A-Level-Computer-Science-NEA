' Class that stores maze generation algorithms
Public Class MazeGeneration
    ' Stores properties needed for maze generation
    ' ReadOnly means it acts like a constant but it can be assigned in the constructor
    ReadOnly selectedMazeAlgorithm As GridCustomisation

    ' Constructor that sets the properties needed for maze generation
    Public Sub New(newSelectedMazeAlgorithm As GridCustomisation)
        selectedMazeAlgorithm = newSelectedMazeAlgorithm
    End Sub

    ' Subroutine that generates a maze using or the selected maze algorithm
    Public Sub Generate(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        Select Case selectedMazeAlgorithm
            Case GridCustomisation.RecursiveBacktracking
                GenerateRecursiveBacktracking(grid, drawQueue)
            Case GridCustomisation.RecursiveDivision
                GenerateRecursiveDivision(grid, drawQueue)
            Case GridCustomisation.Kruskals
                GenerateKruskals(grid, drawQueue)
            Case GridCustomisation.BinaryTree
                GenerateBinaryTree(grid, drawQueue)
            Case GridCustomisation.Prims
                GeneratePrims(grid, drawQueue)
        End Select

        ' Calculates the metrics for the generated maze
        AverageLength(grid)
        Branches(grid)
    End Sub

    ' Subroutine that generates a maze using the recursive backtracking maze generation algorithm
    Private Sub GenerateRecursiveBacktracking(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        ' Initialize a variable to store the time taken and a stop watch to record the time
        Dim timeTaken As Decimal
        Dim sw As New Stopwatch

        ' Sets all cells in grid to walls
        Fill(Type.Wall, grid, drawQueue)

        ' Start the stopwatch
        sw.Start()

        ' Creates a stack to store the visited cells to backtrack
        Dim visitedStack As New Stack(Of Point)
        ' Chooses a random Cell to start generating the maze from
        Dim currentCell As New Point(RandomNum(0, (grid.GetSize) / 2 - 1) * 2,
                                     RandomNum(0, (grid.GetSize) / 2 - 1) * 2)

        ' Sets the CurrentCell to empty and pushes it onto stack
        SetCell(CurrentCell, Type.Empty, grid, drawQueue)
        visitedStack.Push(currentCell)

        ' Loop until the stack is empty
        Do Until visitedStack.Count = 0
            Dim neighbours As New List(Of Point)

            ' Define possible movement directions
            Dim directions As New List(Of Point) From {New Point(-2, 0), New Point(2, 0),
                                                       New Point(0, -2), New Point(0, 2)}

            ' Checks all 4 neighbouring cells to CurrentCell
            For Each direction In directions
                ' Creates a variable to store the NeighbouringCell
                Dim neighbouringCell As New Point(currentCell.X + direction.X, currentCell.Y + direction.Y)

                ' Checks if the NewCell is in the bounds of the array and is a wall
                If VerifyPoint(neighbouringCell, grid.GetSize) Then
                    If grid(neighbouringCell) = Type.Wall Then
                        ' Adds NewCell to the list of neighbours
                        neighbours.Add(neighbouringCell)
                    End If
                End If
            Next

            ' If there is any neighbours
            If neighbours.Count > 0 Then
                ' Chooses random neighbour and calculates the CorridorCell
                Dim neighbourCell As Point = neighbours(RandomNum(0, neighbours.Count - 1))
                Dim corridorCell As New Point((neighbourCell.X + currentCell.X) \ 2, (neighbourCell.Y + currentCell.Y) \ 2)

                ' Pushes NeighbourCell to the stack
                visitedStack.Push(neighbourCell)

                ' Sets the NeighbourCell and CorridorCell to Empty
                SetCell(corridorCell, Type.Empty, grid, drawQueue)
                SetCell(neighbourCell, Type.Empty, grid, drawQueue)

                ' Sets NeighbouringCell as the CurrentCell
                currentCell = neighbourCell
            Else
                ' If the CurrentCell has no neighbours then backtrack
                currentCell = visitedStack.Pop
            End If
        Loop

        ' Stop the stopwatch and calculate the TimeTaken
        sw.Stop()
        timeTaken = Math.Round(sw.ElapsedTicks / Stopwatch.Frequency * 1000, 3)

        ' Updates the controls on the form with the new metric
        Main.txtTimeTakenGrid.Text = timeTaken
    End Sub

    ' Subroutine that generates a maze using the random Kruskals maze generation algorithm
    Private Sub GenerateKruskals(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        ' Initialize a variable to store the time taken and a stop watch to record the time
        Dim timeTaken As Decimal
        Dim sw As New Stopwatch

        ' Sets all cells in grid to walls
        Fill(Type.Wall, grid, drawQueue)

        ' Start the stopwatch
        sw.Start()

        ' Creates list to store all edges in the grid
        Dim connections As New List(Of Connection)
        ' Create a dictionary to keep track of connected cells
        Dim parents As New Dictionary(Of Point, Point)

        ' Add all edges to the list
        For X = 0 To grid.GetSize - 1 Step 2
            For Y = 0 To grid.GetSize - 1 Step 2
                ' Right from the cell
                If VerifyPoint(X + 2, Y, grid.GetSize) Then
                    connections.Add(New Connection(X, Y, X + 2, Y))
                End If

                ' Down from the cell
                If VerifyPoint(X, Y + 2, grid.GetSize) Then
                    connections.Add(New Connection(X, Y, X, Y + 2))
                End If
            Next
        Next

        ' Shuffle the edges list
        Dim r As New Random
        connections = connections.OrderBy(Function(i) r.Next()).ToList

        ' Iterate through all the connections in random order
        For Each connection In connections
            ' Find the parent of each cell in the connection
            Dim FromParent As Point = FindParent(connection.From, parents)
            Dim TargetParent As Point = FindParent(connection.Target, parents)

            ' If the two cells have different parents then they belong to different sets so connect them
            If FromParent <> TargetParent Then
                ' Update the parents of the from cell
                parents(FromParent) = TargetParent

                ' If the FromCell isn't empty then set it to empty
                If grid(connection.From) <> Type.Empty Then
                    SetCell(connection.From, Type.Empty, grid, drawQueue)
                End If

                ' Set the CorridorCell to empty
                SetCell(connection.Corridor, Type.Empty, grid, drawQueue)

                ' If the TargetCell isn't empty then set it to empty
                If grid(connection.Target) <> Type.Empty Then
                    SetCell(connection.Target, Type.Empty, grid, drawQueue)
                End If
            End If
        Next

        ' Stop the stopwatch and calculate the TimeTaken
        sw.Stop()
        timeTaken = Math.Round(sw.ElapsedTicks / Stopwatch.Frequency * 1000, 3)

        ' Updates the controls on the form with the new metric
        Main.txtTimeTakenGrid.Text = timeTaken
    End Sub

    ' Helper Function for Kruskals to find the parent of a cell
    Private Function FindParent(cell As Point, parents As Dictionary(Of Point, Point)) As Point
        ' If the cell isn't in the dictionary add it with itself as the value
        If Not parents.ContainsKey(cell) Then
            parents(cell) = cell

            ' If the CurrentCell isn't equal to the ParentCell then run this subroutine recursively until it is
        ElseIf parents(cell) <> cell Then
            parents(cell) = FindParent(parents(cell), parents)
        End If

        ' Return the ParentCell
        Return parents(cell)
    End Function

    ' Subroutine that generates a maze using the Binary Tree maze generation algorithm
    Private Sub GenerateBinaryTree(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        ' Initialize a variable to store the time taken and a stop watch to record the time
        Dim timeTaken As Decimal
        Dim sw As New Stopwatch

        ' Sets all cells in grid to walls
        Fill(Type.Wall, grid, drawQueue)

        ' Start the stopwatch
        sw.Start()

        ' Iterate through all cells in the grid
        For X = 0 To grid.GetSize - 1 Step 2
            For Y = 0 To grid.GetSize - 1 Step 2
                ' Choose a random direction (1=down or 2-right)
                Dim direction As Integer = RandomNum(1, 2)

                ' If the direction is down or on the left border remove the cell down
                If (direction = 1 Or X = 0) And VerifyPoint(X, Y - 1, grid.GetSize) Then
                    SetCell(X, Y - 1, Type.Empty, grid, drawQueue)
                End If

                ' If the direction is right or on the top border remove the cell to the right
                If (direction = 2 Or Y = 0) And VerifyPoint(X - 1, Y, grid.GetSize) Then
                    SetCell(X - 1, Y, Type.Empty, grid, drawQueue)
                End If

                ' Set the CurrentCell to Empty
                SetCell(X, Y, Type.Empty, grid, drawQueue)
            Next
        Next

        ' Stop the stopwatch and calculate the TimeTaken
        sw.Stop()
        timeTaken = Math.Round(sw.ElapsedTicks / Stopwatch.Frequency * 1000, 3)

        ' Updates the controls on the form with the new metric
        Main.txtTimeTakenGrid.Text = timeTaken
    End Sub

    ' Subroutine that generates a maze using Prims maze generation algorithm
    Private Sub GeneratePrims(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        ' Initialize variables to record metrics of the maze generation algorithm
        Dim timeTaken As Decimal
        Dim sw As New Stopwatch

        ' Sets all cells in grid to walls
        Fill(Type.Wall, grid, drawQueue)

        ' Start the stopwatch
        sw.Start()

        ' Choose a random starting cell
        Dim randomStartingCell As New Point(RandomNum(0, (grid.GetSize) / 2 - 1) * 2,
                                            RandomNum(0, (grid.GetSize) / 2 - 1) * 2)

        ' Creates a list to store frontier and visited cells
        Dim frontierList As New List(Of Connection)
        Dim visited As New List(Of Point)

        ' Define possible movement directions
        Dim directions As New List(Of Point) From {New Point(-2, 0), New Point(2, 0),
                                                   New Point(0, -2), New Point(0, 2)}

        ' Adds the RandomStartingCell to the list of frontier cells
        visited.Add(randomStartingCell)
        frontierList.Add(New Connection(randomStartingCell, randomStartingCell))

        ' Loop until no FrountierCells left
        While frontierList.Count > 0
            ' Pick a random cell from the frontier list
            Dim currentConnection As Connection = frontierList(RandomNum(0, frontierList.Count - 1))
            frontierList.Remove(CurrentConnection)

            Dim currentCell As Point = currentConnection.Target

            SetCell(currentConnection.Corridor, Type.Empty, grid, drawQueue)
            SetCell(currentCell, Type.Empty, grid, drawQueue)

            ' Find neighbours of the current cell that have not been visited
            Dim unvisitedNeighbours As New List(Of Point)
            For Each direction In directions
                Dim neighbour As New Point(currentCell.X + direction.X, currentCell.Y + direction.Y)

                If VerifyPoint(neighbour, grid.GetSize) AndAlso Not visited.Contains(neighbour) Then
                    visited.Add(neighbour)
                    frontierList.Add(New Connection(currentCell, neighbour))
                End If
            Next
        End While

        ' Stop the stopwatch and calculate the TimeTaken
        sw.Stop()
        timeTaken = Math.Round(sw.ElapsedTicks / Stopwatch.Frequency * 1000, 3)

        ' Updates the controls on the form with the new metric
        Main.txtTimeTakenGrid.Text = timeTaken
    End Sub

    ' Subroutine that generates a maze using Recursive Division maze generation algorithm
    Private Sub GenerateRecursiveDivision(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        ' Initialize a variable to store the time taken and a stop watch to record the time
        Dim timeTaken As Decimal
        Dim sw As New Stopwatch

        ' Sets all cells in grid to walls
        Fill(Type.Empty, grid, drawQueue)

        ' Start the stopwatch
        sw.Start()

        Dim boundary As Integer = grid.GetSize - 2 + grid.GetSize Mod 2

        ' Call the recursive division function to generate the maze
        RecursiveDivisionHelper(New Point(0, 0), New Point(boundary, boundary), grid, drawQueue)

        ' Stop the stopwatch and calculate the TimeTaken
        sw.Stop()
        timeTaken = Math.Round(sw.ElapsedTicks / Stopwatch.Frequency * 1000, 3)

        ' Updates the controls on the form with the new metric
        Main.txtTimeTakenGrid.Text = timeTaken
    End Sub

    ' Helper subroutine used for recursive division
    Private Sub RecursiveDivisionHelper(tL As Point, bR As Point, grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        ' TL is TopLeft, BR is BottomRight

        ' Base case: If the bounds are too small, stop dividing
        If (bR.X - tL.X) > 1 And (bR.Y - tL.Y) > 1 Then
            ' Choose whether to divide horizontally or vertically
            Dim divideHorizontally As Boolean
            If (bR.X - tL.X) = 0 Then
                DivideHorizontally = True
            ElseIf (bR.Y - tL.Y) = 0 Then
                DivideHorizontally = False
            Else
                divideHorizontally = RandomNum(0, 1)
            End If


            ' Choose a random cell for the wall
            Dim wallPosition As Integer
            If divideHorizontally Then
                ' Divide horizontally
                wallPosition = (tL.Y + 1) + RandomNum(0, Math.Floor((bR.Y - tL.Y - 1) / 2)) * 2

                ' Create a horizontal wall
                For X = tL.X To bR.X
                    SetCell(X, wallPosition, Type.Wall, grid, drawQueue)
                Next
            Else
                ' Divide vertically
                wallPosition = (tL.X + 1) + RandomNum(0, Math.Floor((bR.X - tL.X - 1) / 2)) * 2

                ' Create a vertical wall
                For Y = tL.Y To bR.Y
                    SetCell(wallPosition, Y, Type.Wall, grid, drawQueue)
                Next
            End If

            ' Create openings in the wall
            Dim openingPosition As Integer
            If DivideHorizontally Then
                openingPosition = tL.X + RandomNum(0, Math.Floor((bR.X - tL.X) / 2)) * 2

                ' Create an opening in the wall horizontally
                SetCell(openingPosition, wallPosition, Type.Empty, grid, drawQueue)
            Else
                openingPosition = tL.Y + RandomNum(0, Math.Floor((bR.Y - tL.Y) / 2)) * 2

                ' Create an opening in the wall vertically
                SetCell(wallPosition, openingPosition, Type.Empty, grid, drawQueue)
            End If

            ' Recursive calls to divide the sub-regions
            If divideHorizontally Then
                RecursiveDivisionHelper(tL, New Point(bR.X, wallPosition - 1), grid, drawQueue)
                RecursiveDivisionHelper(New Point(tL.X, wallPosition + 1), bR, grid, drawQueue)
            Else
                RecursiveDivisionHelper(tL, New Point(wallPosition - 1, bR.Y), grid, drawQueue)
                RecursiveDivisionHelper(New Point(wallPosition + 1, tL.Y), bR, grid, drawQueue)
            End If
        End If
    End Sub

    ' Subroutine that works out the average path length in a maze
    Private Sub AverageLength(ByRef grid As Grid)
        ' Variable to store current length whilst calculating
        Dim currentLength As Integer
        ' Dictionary to store all the path lengths
        Dim lengths As New Dictionary(Of Integer, Integer)

        ' Go through all horizontals and add their lengths to the dictionary
        For Y = 0 To grid.GetSize - 1 Step 2
            For X = 0 To grid.GetSize - 1
                ' If the cell is empty increase the current length
                If grid(X, Y) = Type.Empty Then
                    currentLength += 1
                End If

                ' If its the final cell or wall of a path then add the length to the dictionary
                If grid(X, Y) = Type.Wall Or X = grid.GetSize - 1 Then
                    If currentLength > 1 Then
                        If lengths.ContainsKey(currentLength) Then
                            lengths(currentLength) += 1
                        Else
                            lengths.Add(currentLength, 1)
                        End If
                    End If
                    currentLength = 0
                End If
            Next
            currentLength = 0
        Next

        ' Go through all verticals and add their lengths to the dictionary
        For X = 0 To grid.GetSize - 1 Step 2
            For Y = 0 To grid.GetSize - 1
                ' If the cell is empty increase the current length
                If grid(X, Y) = Type.Empty Then
                    currentLength += 1
                End If

                ' If its the final cell or wall of a path then add the length to the dictionary
                If grid(X, Y) = Type.Wall Or Y = grid.GetSize - 1 Then
                    If currentLength > 1 Then
                        If lengths.ContainsKey(currentLength) Then
                            lengths(currentLength) += 1
                        Else
                            lengths.Add(currentLength, 1)
                        End If
                    End If
                    currentLength = 0
                End If
            Next
            currentLength = 0
        Next

        ' Creates variables to store the total path length and number of paths
        Dim totalLength As Integer
        Dim totalPaths As Integer
        Dim averageLength As Decimal

        ' Goes through each length in the dictionary and works out total length and number of paths
        For Each length In lengths
            totalLength += length.Key * length.Value
            totalPaths += length.Value
        Next

        ' Work out the average length
        averageLength = Math.Round(totalLength / totalPaths * 100) / 100

        ' Updates the controls on the form with the new metric
        Main.txtAverageLength.Text = averageLength
    End Sub

    ' Works out the branch and dead-end percentage in a maze
    Private Sub Branches(ByRef grid As Grid)
        ' Creates a list of potential branch directions
        Dim directions As New List(Of Point) From {New Point(0, -1), New Point(1, 0), New Point(0, 1), New Point(-1, 0)}
        ' Creates a dictionary to store the number of branches at each point
        Dim branches As New Dictionary(Of Integer, Integer)

        ' Iterate through each cell to see how many branches it has
        For X = 0 To grid.GetSize - 1 Step 2
            For Y = 0 To grid.GetSize - 1 Step 2
                Dim branchNumber As Integer = 0

                ' Check all 4 directions and if its open increase the branch number
                For Each direction In directions
                    Dim newPT As New Point(X + direction.X, Y + direction.Y)

                    ' Adds cell as a branch if it is empty
                    If VerifyPoint(newPT, grid.GetSize) AndAlso grid(newPT) = Type.Empty Then
                        branchNumber += 1
                    End If
                Next

                ' Add the branch number to the dictionary or increment the number
                If branches.ContainsKey(branchNumber) Then
                    branches(branchNumber) += 1
                Else
                    branches.Add(branchNumber, 1)
                End If
            Next
        Next

        ' Creates variables to store the total branches and branch numbers
        Dim totalBranches As Integer
        Dim totalBranchNumber As Integer
        Dim differentBranches As Integer

        Dim percentageOfDeadends As Decimal
        Dim percentageOfBranches As Decimal

        ' Works out the total number of branches and number of cells with branches
        For Each branch In branches
            totalBranchNumber += branch.Key * branch.Value
            totalBranches += branch.Value
        Next

        ' Work out percentage of dead ends which is cells with 1 branch
        percentageOfDeadends = Math.Round(branches(1) / totalBranches * 1000) / 10

        ' Works out percentage of cells which branch out which means they have 3 or 4 branches from a cell
        If branches.ContainsKey(3) Then differentBranches += branches(3)
        If branches.ContainsKey(4) Then differentBranches += branches(4)

        percentageOfBranches = Math.Round(differentBranches / totalBranches * 1000) / 10

        ' Updates the controls on the form with the new metrics
        Main.txtDeadends.Text = percentageOfDeadends & "%"
        Main.txtBranches.Text = percentageOfBranches & "%"
    End Sub
End Class