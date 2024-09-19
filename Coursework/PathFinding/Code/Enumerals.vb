' Define an Enum to represent the different cells in the grid
Public Enum Type
    Empty
    Wall
    Open
    Closed
    Path
    Start
    Finish
End Enum

' Define an Enum to represent the different path finding algorithms
Public Enum PathfindingAlgorithm
    BreadthFirst
    AStar
    DepthFirst
    GreedyDFS
End Enum

' Define an Enum to represent the different grid customisation options
Public Enum GridCustomisation
    RecursiveBacktracking
    RecursiveDivision
    Kruskals
    BinaryTree
    Prims
    UserCustomisation
End Enum