Imports System

Class Student
    Private studentName As String
    Private rollNo As Integer
    Private marks1 As Double
    Private marks2 As Double
    Private marks3 As Double

    Public Sub New(name As String, roll As Integer, m1 As Double, m2 As Double, m3 As Double)
        studentName = name
        rollNo = roll
        marks1 = m1
        marks2 = m2
        marks3 = m3
    End Sub

    Public Sub DisplayDetails()
        Console.WriteLine("Student Name: " & studentName)
        Console.WriteLine("Roll No: " & rollNo)
        Console.WriteLine("Marks 1: " & marks1)
        Console.WriteLine("Marks 2: " & marks2)
        Console.WriteLine("Marks 3: " & marks3)
        Console.WriteLine()
    End Sub

    Public Sub UpdateDetails(name As String, roll As Integer, m1 As Double, m2 As Double, m3 As Double)
        studentName = name
        rollNo = roll
        marks1 = m1
        marks2 = m2
        marks3 = m3
    End Sub

    Public Function GetRollNo() As Integer
        Return rollNo
    End Function
End Class

Module Program
    Dim students As New List(Of Student)

    Sub Main(args As String())
        Dim choice As Integer

        Do
            Console.WriteLine("1. Insert Student Details")
            Console.WriteLine("2. Display All Student Details")
            Console.WriteLine("3. Update Student Details")
            Console.WriteLine("4. Delete Student Details")
            Console.WriteLine("5. Exit")
            Console.WriteLine("Enter your choice:")
            choice = Convert.ToInt32(Console.ReadLine())

            Select Case choice
                Case 1
                    InsertStudentDetails()
                Case 2
                    DisplayAllStudentDetails()
                Case 3
                    UpdateStudentDetails()
                Case 4
                    DeleteStudentDetails()
                Case 5
                    Console.WriteLine("Exiting program...")
                Case Else
                    Console.WriteLine("Invalid choice. Please try again.")
            End Select
        Loop While choice <> 5
    End Sub

    Sub InsertStudentDetails()
        Console.WriteLine("Enter Student Name:")
        Dim name As String = Console.ReadLine()

        Console.WriteLine("Enter Roll No:")
        Dim roll As Integer = Convert.ToInt32(Console.ReadLine())

        Console.WriteLine("Enter Marks 1:")
        Dim m1 As Double = Convert.ToDouble(Console.ReadLine())

        Console.WriteLine("Enter Marks 2:")
        Dim m2 As Double = Convert.ToDouble(Console.ReadLine())

        Console.WriteLine("Enter Marks 3:")
        Dim m3 As Double = Convert.ToDouble(Console.ReadLine())

        Dim newStudent As New Student(name, roll, m1, m2, m3)
        students.Add(newStudent)

        Console.WriteLine("Student details inserted successfully.")
    End Sub

    Sub DisplayAllStudentDetails()
        If students.Count = 0 Then
            Console.WriteLine("No student details found.")
        Else
            Console.WriteLine("Displaying all student details:")
            For Each student As Student In students
                student.DisplayDetails()
            Next
        End If
    End Sub

    Sub UpdateStudentDetails()
        If students.Count = 0 Then
            Console.WriteLine("No student details found.")
        Else
            Console.WriteLine("Enter Roll No of student to update details:")
            Dim rollToUpdate As Integer = Convert.ToInt32(Console.ReadLine())

            Dim found As Boolean = False

            For Each student As Student In students
                If student.GetRollNo() = rollToUpdate Then
                    Console.WriteLine("Enter updated details:")
                    Console.WriteLine("Enter Student Name:")
                    Dim name As String = Console.ReadLine()

                    Console.WriteLine("Enter Roll No:")
                    Dim roll As Integer = Convert.ToInt32(Console.ReadLine())

                    Console.WriteLine("Enter Marks 1:")
                    Dim m1 As Double = Convert.ToDouble(Console.ReadLine())

                    Console.WriteLine("Enter Marks 2:")
                    Dim m2 As Double = Convert.ToDouble(Console.ReadLine())

                    Console.WriteLine("Enter Marks 3:")
                    Dim m3 As Double = Convert.ToDouble(Console.ReadLine())

                    student.UpdateDetails(name, roll, m1, m2, m3)
                    Console.WriteLine("Student details updated successfully.")
                    found = True
                    Exit For
                End If
            Next

            If Not found Then
                Console.WriteLine("Student with given Roll No not found.")
            End If
        End If
    End Sub

    Sub DeleteStudentDetails()
        If students.Count = 0 Then
            Console.WriteLine("No student details found.")
        Else
            Console.WriteLine("Enter Roll No of student to delete details:")
            Dim rollToDelete As Integer = Convert.ToInt32(Console.ReadLine())

            Dim foundIndex As Integer = -1

            For i As Integer = 0 To students.Count - 1
                If students(i).GetRollNo() = rollToDelete Then
                    foundIndex = i
                    Exit For
                End If
            Next

            If foundIndex <> -1 Then
                students.RemoveAt(foundIndex)
                Console.WriteLine("Student details deleted successfully.")
            Else
                Console.WriteLine("Student with given Roll No not found.")
            End If
        End If
    End Sub
End Module