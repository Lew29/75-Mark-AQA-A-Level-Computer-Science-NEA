' Class that defines a priority queue data structure that can store any data type as t and has 2 priorities
Public Class PriorityQueue(Of t)
    ' Structure used to store an item and its priority
    Structure Data
        Dim item As t
        Dim priority1 As Integer
        Dim priority2 As Integer

        Sub New(newItem As t, newPriority1 As Integer, newPriority2 As Integer)
            item = newItem
            priority1 = newPriority1
            priority2 = newPriority2
        End Sub
    End Structure

    ' List that stores the data items in the priority queue
    Private values As New List(Of Data)

    ' Function that returns the number of items in the priority queue
    Public Function Count()
        Return values.Count
    End Function

    ' Function that returns True if the priority queue is empty and False otherwise
    Public Function IsEmpty()
        If values.Count = 0 Then
            Return True
        Else Return False
        End If
    End Function

    ' Subroutine that clears all the items in the priority queue
    Public Sub Clear()
        values.Clear()
    End Sub

    ' Subroutine that adds a new item to the priority queue, with the specified two priorities
    Public Sub Enqueue(newItem As t, newPriority1 As Integer, Optional newPriority2 As Integer = 0)
        ' Create a new data item with the specified item value and priorities
        Dim newData As New Data(newItem, newPriority1, newPriority2)
        ' Find the index in the list where the new item should be inserted, based on its priorities
        Dim index As Integer

        For i = 0 To values.Count - 1
            ' Compare the new item's priorities with the priorities of the existing items in the list
            ' If the new item has higher or equal priorities, move to the next item in the list
            If newData.priority1 > values(i).priority1 Or (newData.priority1 = values(i).priority1 And newData.priority2 > values(i).priority2) Then
                index += 1
            Else Exit For
            End If
        Next

        ' Insert the new item into the list at the calculated index
        values.Insert(index, newData)
    End Sub

    ' Function that removes and returns the item with the highest priorities in the priority queue
    Public Function Dequeue()
        ' Get the data item at the front of the list (with the highest priorities)
        Dim dequeueData As Data = values(0)

        ' Remove the data item from the list
        values.RemoveAt(0)

        ' Return the item value
        Return dequeueData.item
    End Function
End Class