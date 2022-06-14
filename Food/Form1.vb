Public Class Form1

    Dim daysOfWeek() As String = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"}
    Dim curDay As Integer = 0
    Class meal
        Public name As String
        Public id As Integer
        Public used As Boolean
    End Class
    Public Shared Function FisherYatesShuffle(data As Integer()) As Integer()
        Dim retVal As Integer() = New Integer(data.Length - 1) {}
        Dim ind As Integer() = New Integer(data.Length - 1) {}
        Dim index As Integer
        Dim rand As New Random()

        For i As Integer = 0 To data.Length - 1
            ind(i) = 0
        Next
        For i As Integer = 0 To data.Length - 1
            Do
                index = rand.[Next](data.Length)
            Loop While ind(index) <> 0

            ind(index) = 1
            retVal(i) = data(index)
        Next
        Return retVal
    End Function
    Private Sub Day_Click(sender As Object, e As EventArgs) Handles Day.Click

    End Sub

    Private Sub changeDay(direction As Boolean)
        Try
            If (direction) Then
                curDay += 1
                Day.Text = daysOfWeek(curDay)
            Else
                curDay -= 1
                If (curDay = -1) Then
                    curDay = 6
                    Day.Text = daysOfWeek(curDay)
                Else
                    Day.Text = daysOfWeek(curDay)
                End If
            End If
        Catch ex As Exception
            curDay = 0
            Day.Text = daysOfWeek(curDay)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        changeDay(True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        changeDay(False)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim numOfMeal As Integer

        Try
            numOfMeal = InputBox("How many many meals would u like to input?")
            numOfMeal -= 1
        Catch ex As Exception
            MsgBox("Please Enter A Valid Response!")
        End Try

        Dim meals(numOfMeal) As meal
        Dim data(numOfMeal) As Integer

        For counter = 0 To numOfMeal
            data(counter) = counter
        Next

        Dim retVal As Integer() = FisherYatesShuffle(data)

        For counter = 0 To numOfMeal
            meals(counter) = New meal

            meals(counter).name = InputBox("Please Enter The name of the meal")
            meals(counter).id = retVal(counter)
        Next

        For counter = 0 To numOfMeal
            ListBox1.Items.Add(meals(counter).name)
        Next


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim data() As Integer = {0, 1, 2, 3, 4, 5, 6}
        Dim retVal As Integer() = FisherYatesShuffle(data)

        For counter = 0 To 6
            ListBox1.Items.Add(retVal(counter))
        Next
    End Sub
End Class
