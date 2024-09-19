' Class that stores path finding algorithms
Public Class PathFinding
    ' Stores properties needed for path finding
    ' ReadOnly means it acts like a constant but it can be assigned in the constructor
    ReadOnly selectedPathAlgorithm As PathfindingAlgorithm
    ReadOnly startCell As Point
    ReadOnly finishCell As Point

    ' Constructor that sets the properties needed for maze generation
    Public Sub New(newSelectedPathAlgorithm As PathfindingAlgorithm, newStartCell As Point, newFinishCell As Point)
        selectedPathAlgorithm = newSelectedPathAlgorithm
        startCell = newStartCell
        finishCell = newFinishCell
    End Sub

    ' Subroutine that solves a grid using the selected path finding algorithm
    Public Sub FindPath(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        ' Sets the start and finish cell
        SetCell(startCell, Type.Start, grid, drawQueue)
        SetCell(finishCell, Type.Finish, grid, drawQueue)

        Select Case selectedPathAlgorithm
            Case PathfindingAlgorithm.BreadthFirst
                FindPathBFS(grid, drawQueue)
            Case PathfindingAlgorithm.AStar
                FindPathAStar(grid, drawQueue)
            Case PathfindingAlgorithm.DepthFirst
                FindPathDFS(grid, drawQueue)
            Case PathfindingAlgorithm.GreedyDFS
                FindPathGreedyDFS(grid, drawQueue)
        End Select
    End Sub

    ' Subroutine that solves the grid using the Breath-First Search algorithm
    Public Sub FindPathBFS(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        ' Initialises variables to record metrics of the path finding algorithm
        Dim shortestPath As Integer = 1
        Dim cellsExplored As Integer = 1
        Dim timeTaken As Decimal
        Dim sw As New Stopwatch

        ' Starts the stop watch
        sw.Start()

        ' Create a queue to keep track of cells for BFS
        Dim openQueue As New Queue(Of Point)
        ' Creates a dictionary to keep track of the parent cells for each cell explored
        Dim returnCells As New Dictionary(Of Point, Point)
        ' Store the current return cell to reconstruct the path to the start cell
        Dim returnCell As Point
        ' Keeps a boolean that shows whether the FinishCell has been found or not
        Dim pathFound As Boolean

        ' Enqueue the start cell to the OpenQueue
        openQueue.Enqueue(startCell)

        ' Loop until the list is empty or a path has been found from StartCell to FinishCell
        Do Until openQueue.Count = 0 Or pathFound = True
            ' Dequeues from OpenQueue and sets it to CurrentCell
            Dim currentCell As Point = openQueue.Dequeue()

            ' Updates coordinates of the ReturnCell
            returnCell = currentCell

            ' Sets the CurrentCell to closed if it isn't the start or finish cell
            If grid(currentCell) < Type.Start Then
                SetCell(currentCell, Type.Closed, grid, drawQueue)
                cellsExplored += 1
            End If

            ' Define a list of possible movement directions
            Dim directions As New List(Of Point) From {New Point(0, -1), New Point(1, 0), New Point(0, 1), New Point(-1, 0)}

            ' Checks all 4 neighbouring cells to CurrentCell
            For Each direction In directions
                CheckNeighboursBFS(grid, drawQueue, currentCell, returnCells, openQueue, pathFound, direction)
            Next
        Loop

        ' Reconstructs the path if the FinishCell is found
        If pathFound Then
            ' Loops until StartCell is found
            Do Until returnCell = startCell
                shortestPath += 1
                SetCell(returnCell, Type.Path, grid, drawQueue)
                returnCell = returnCells(returnCell)
            Loop

            ' Stops the stopwatch and calculates the TimeTaken
            sw.Stop()
            timeTaken = Math.Round(sw.ElapsedTicks / Stopwatch.Frequency * 1000, 3)

            ' Updates all the controls on the form with recorded metrics
            UpdateMetrics(shortestPath, cellsExplored, timeTaken)
        End If
    End Sub

    ' Helper subroutine that checks the neighbouring cells for BFS
    Private Sub CheckNeighboursBFS(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions), currentCell As Point, ByRef returnCells As Dictionary(Of Point, Point),
                                   ByRef openQueue As Queue(Of Point), ByRef pathFound As Boolean, direction As Point)
        ' Initialises a variable to store coordinates of the neighbour cell
        Dim neighbour As New Point(currentCell.X + direction.X, currentCell.Y + direction.Y)

        ' Checks if the neighbour is within the bounds of the array
        If VerifyPoint(neighbour, grid.GetSize) Then
            ' If the neighbour is empty enqueues it and sets it to open
            If grid(neighbour) = Type.Empty Then
                openQueue.Enqueue(neighbour)
                SetCell(neighbour, Type.Open, grid, drawQueue)
                returnCells(neighbour) = currentCell

                ' If the neighbour is the FinishCell the path is found
            ElseIf grid(neighbour) = Type.Finish Then
                pathFound = True
            End If
        End If
    End Sub

    ' Subroutine that solves the grid using the Depth-First Search algorithm
    Private Sub FindPathDFS(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        ' Initialise variables to record metrics of the path finding algorithm
        Dim shortestPath As Integer = 1
        Dim cellsExplored As Integer = 1
        Dim timeTaken As Decimal
        Dim sw As New Stopwatch

        ' Start the stopwatch
        sw.Start()

        ' Create a stack to keep track of cells for DFS
        Dim openStack As New Stack(Of Point)
        ' Create a dictionary to keep track of the parent cell for each cell explored
        Dim returnCells As New Dictionary(Of Point, Point)
        ' Store the current ReturnCell to reconstruct the path to the StartCell
        Dim returnCell As Point
        ' Keep a boolean that shows whether the FinishCell has been found or not
        Dim pathFound As Boolean

        ' Push the StartCell to the OpenStack
        openStack.Push(startCell)

        ' Loop until the stack is empty or a path has been found from StartCell to FinishCell
        Do Until openStack.Count = 0 Or pathFound = True
            ' Pop a cell from the stack
            Dim currentCell As Point = openStack.Pop()

            ' Update coordinates of the ReturnCell
            returnCell = currentCell

            ' Set the CurrentCell to closed if it isn't the StartCell
            If grid(currentCell) < Type.Start Then
                cellsExplored += 1
                SetCell(currentCell, Type.Closed, grid, drawQueue)
            End If

            ' Define possible movement directions
            Dim directions As New List(Of Point) From {New Point(0, -1), New Point(-1, 0), New Point(0, 1), New Point(1, 0)}

            ' Checks all 4 neighbouring cells to CurrentCell
            For Each direction In directions
                CheckNeighboursDFS(grid, drawQueue, currentCell, returnCells, openStack, pathFound, direction)
            Next
        Loop

        ' Reconstruct the path if the FinishCell is found
        If pathFound Then
            ' Loop until StartCell is found 
            Do Until returnCell = startCell
                shortestPath += 1
                SetCell(returnCell, Type.Path, grid, drawQueue)
                returnCell = returnCells(returnCell)
            Loop

            ' Stops the stopwatch and calculates the TimeTaken
            sw.Stop()
            timeTaken = Math.Round(sw.ElapsedTicks / Stopwatch.Frequency * 1000, 3)

            ' Updates all the controls on the form with the new metrics
            UpdateMetrics(shortestPath, cellsExplored, timeTaken)
        End If
    End Sub

    ' Helper subroutine that checks the neighbouring cells for DFS
    Private Sub CheckNeighboursDFS(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions), currentCell As Point, ByRef returnCells As Dictionary(Of Point, Point),
                                   ByRef openStack As Stack(Of Point), ByRef pathFound As Boolean, direction As Point)
        ' Initialises a variable to store coordinates of the neighbour cell
        Dim neighbour As New Point(currentCell.X + direction.X, currentCell.Y + direction.Y)

        ' Checks if the neighbour is within the bounds of the array
        If VerifyPoint(neighbour, grid.GetSize) Then
            ' If the neighbour is empty set it to open
            If grid(neighbour) = Type.Empty Then
                openStack.Push(neighbour)
                SetCell(neighbour, Type.Open, grid, drawQueue)

                returnCells(neighbour) = currentCell

                ' If the neighbour is the FinishCell the path is found
            ElseIf grid(neighbour) = Type.Finish Then
                pathFound = True
            End If
        End If
    End Sub

    ' Subroutine that solves the grid using the A* search algorithm
    Private Sub FindPathAStar(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        ' Initialise variables to record metrics of the path finding algorithm
        Dim shortestPath As Integer = 1
        Dim cellsExplored As Integer = 1
        Dim timeTaken As Decimal
        Dim sw As New Stopwatch

        ' Start the stopwatch
        sw.Start()

        ' Create a priority queue to keep track of cells to be searched
        Dim openQueue As New PriorityQueue(Of Point)
        ' Create a dictionary to store all of the cell properties
        Dim cellProperties As New Dictionary(Of Point, CellProperties)
        ' Store the current ReturnCell to reconstruct the path to the startCell
        Dim returnCell As Point
        ' Keep a boolean that shows whether the FinishCell has been found or not
        Dim pathFound As Boolean

        ' Add the StartCell to the queue
        openQueue.Enqueue(startCell, 0, 0)
        cellProperties(startCell) = New CellProperties

        ' Loop until the list is empty or a path has been found from StartCell to FinishCell
        Do Until openQueue.IsEmpty Or pathFound = True
            ' Get the first item in the queue as CurrentCell
            Dim currentCell As Point = openQueue.Dequeue()

            ' If the CurrentCell isn't closed
            If grid(currentCell) <> Type.Closed Then
                ' Update ReturnCell, acting as the starting cell to reconstruct
                returnCell = currentCell

                ' Set the CurrentCell to closed if it isn't the StartCell
                If grid(currentCell) < Type.Start Then
                    SetCell(currentCell, Type.Closed, grid, drawQueue)
                    cellsExplored += 1
                End If

                ' Define possible movement directions
                Dim directions As New List(Of Point) From {New Point(0, -1), New Point(1, 0), New Point(0, 1), New Point(-1, 0)}

                ' Checks all 4 neighbouring cells to CurrentCell
                For Each direction In directions
                    CheckNeighboursAstar(grid, drawQueue, currentCell, cellProperties, openQueue, pathFound, direction)
                Next
            End If
        Loop

        ' Reconstruct the path if FinishCell is found
        If pathFound Then
            ' Loop until StartCell is found
            Do Until returnCell = startCell
                shortestPath += 1
                SetCell(returnCell, Type.Path, grid, drawQueue)
                returnCell = cellProperties(returnCell).ReturnCell
            Loop

            ' Stops the stopwatch and calculates the TimeTaken
            sw.Stop()
            timeTaken = Math.Round(sw.ElapsedTicks / Stopwatch.Frequency * 1000, 3)

            ' Updates all the controls on the form with new metrics
            UpdateMetrics(shortestPath, cellsExplored, timeTaken)
        End If
    End Sub

    ' Helper subroutine that checks the neighbouring cells for A* search algorithm
    Private Sub CheckNeighboursAstar(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions), currentCell As Point, ByRef cellProperties As Dictionary(Of Point, CellProperties),
                                     ByRef openlist As PriorityQueue(Of Point), ByRef pathFound As Boolean, direction As Point)
        ' Initialises variables to store coordinates and properties of new neighbour cell 
        Dim neighbour As New Point(currentCell.X + direction.X, currentCell.Y + direction.Y)

        ' Checks if the x and y coordinates are within the bounds of the array
        If VerifyPoint(neighbour, grid.GetSize) Then
            If {Type.Empty, Type.Open, Type.Closed}.Contains(grid(neighbour)) Then
                ' Calculate all the properties and set the ReturnCell of the NewCell
                Dim newProperties As New CellProperties(neighbour, currentCell, finishCell, cellProperties)

                ' If the NewCell is empty then update the properties, enqueue the cell and set it to open
                If grid(neighbour) = Type.Empty Then
                    cellProperties(neighbour) = newProperties
                    openlist.Enqueue(neighbour, newProperties.fCost, newProperties.hCost)
                    SetCell(neighbour, Type.Open, grid, drawQueue)

                    ' If the cell isn't empty and has a lower FCost then update the properties and enqueue the cell
                ElseIf cellProperties.ContainsKey(neighbour) AndAlso newProperties.fCost < cellProperties(neighbour).fCost Then
                    cellProperties(neighbour) = newProperties
                    openlist.Enqueue(neighbour, newProperties.fCost, newProperties.hCost)
                End If

                ' If the neighbour is the FinishCell the path is found
            ElseIf grid(neighbour) = Type.Finish Then
                pathFound = True
            End If
        End If
    End Sub

    '  Subroutine that solves the grid using the Greedy Best-First Search algorithm
    Private Sub FindPathGreedyDFS(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions))
        ' Initialise variables to record metrics of the path finding algorithm
        Dim shortestPath As Integer = 1
        Dim cellsExplored As Integer = 1
        Dim timeTaken As Decimal
        Dim sw As New Stopwatch

        ' Start the stopwatch
        sw.Start()

        ' Use a priority queue to keep track of cells to be searched
        Dim openQueue As New PriorityQueue(Of Point)
        ' Create a dictionary to store all of the cells properties
        Dim cellProperties As New Dictionary(Of Point, CellProperties)
        ' Store the current ReturnCell to reconstruct the path to the StartCell
        Dim returnCell As Point
        ' Keep a boolean that shows whether the FinishCell has been found or not
        Dim pathFound As Boolean

        ' Add the StartCell to the queue
        cellProperties(startCell) = New CellProperties
        OpenQueue.Enqueue(startCell, 0, 0)

        ' Loop until the list is empty or a path has been found from StartCell to FinishCell
        Do Until openQueue.IsEmpty Or pathFound = True
            ' Set the CurrentCell to the first item in the queue
            Dim currentCell As Point = openQueue.Dequeue()

            If grid(currentCell) <> Type.Closed Then
                ' Update the coordinates of the ReturnCell
                returnCell = currentCell

                ' Set the CurrentCell to closed if it isn't the StartCell
                If grid(currentCell) < Type.Start Then
                    SetCell(currentCell, Type.Closed, grid, drawQueue)
                    cellsExplored += 1
                End If

                ' Define possible movement directions
                Dim directions As New List(Of Point) From {New Point(0, -1), New Point(1, 0), New Point(0, 1), New Point(-1, 0)}

                ' Checks all 4 neighbouring cells to CurrentCell
                For Each direction In directions
                    CheckNeighboursGreedyDFS(grid, drawQueue, currentCell, cellProperties, openQueue, pathFound, direction)
                Next
            End If
        Loop

        ' Reconstruct the path if FinishCell is found
        If pathFound Then
            ' Loop until StartCell is found
            Do Until returnCell = startCell
                shortestPath += 1
                SetCell(returnCell, Type.Path, grid, drawQueue)
                returnCell = cellProperties(returnCell).ReturnCell
            Loop

            ' Stops the stopwatch and calculates the TimeTaken
            sw.Stop()
            timeTaken = Math.Round(sw.ElapsedTicks / Stopwatch.Frequency * 1000, 3)

            ' Updates all the controls on the form with new metrics
            UpdateMetrics(shortestPath, cellsExplored, timeTaken)
        End If
    End Sub

    ' Helper subroutine that checks the neighbouring cells for Greedy Best-First Search algorithm
    Private Sub CheckNeighboursGreedyDFS(ByRef grid As Grid, ByRef drawQueue As Queue(Of Instructions), currentCell As Point, ByRef cellProperties As Dictionary(Of Point, CellProperties),
                                         ByRef openlist As PriorityQueue(Of Point), ByRef pathFound As Boolean, direction As Point)
        ' Initialises variables to store coordinates and properties of the new neighbour cell 
        Dim neighbour As New Point(currentCell.X + direction.X, currentCell.Y + direction.Y)

        ' Checks if the x and y coordinates are within the bounds of the array
        If VerifyPoint(neighbour, grid.GetSize) Then
            ' If it's empty set it to open
            If grid(neighbour) = Type.Empty Then
                ' Calculate all the properties and set the ReturnCell of the NewCell
                Dim newProperties As New CellProperties(neighbour, currentCell, finishCell, cellProperties)

                ' Add the NewCells properties to the CellProperties dictionary
                cellProperties(neighbour) = newProperties

                ' Enqueue the new cell in the priority queue using the H-cost as the priority
                openlist.Enqueue(neighbour, newProperties.hCost)

                ' Set the NewCell to Open
                SetCell(neighbour, Type.Open, grid, drawQueue)

                ' If the neighbour is the FinishCell the path is found
            ElseIf grid(neighbour) = Type.Finish Then
                pathFound = True
            End If
        End If
    End Sub

    ' Subroutine updates the controls on the form with the new metrics
    Private Sub UpdateMetrics(shortestPath As Integer, cellsExplored As Integer, timeTaken As Decimal)
        Main.txtShortestPath.Text = shortestPath
        Main.txtCellsExplored.Text = cellsExplored
        Main.txtTimeTakenPath.Text = timeTaken
    End Sub
End Class