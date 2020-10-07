Imports System.Data.SqlClient

Public Class Form1

    Dim connection As New SqlConnection("Server=localhost; Database=VBDB; Integrated Security=true ")

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim sql As String = "INSERT INTO [User] (FirstName,LastName,Age) VALUES('" & txtFirstName.Text & "', '" & txtLastName.Text & "', '" & txtAge.Text & "')"

        ExecuteQuery(sql)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim sql As String = "UPDATE [User] SET FirstName = '" & txtFirstName.Text & "',LastName = '" & txtLastName.Text & "', Age = '" & txtAge.Text & "' WHERE ID = '" & txtID.Text & "'"

        ExecuteQuery(sql)
    End Sub


#Region "Methods"
    Public Sub ExecuteQuery(query As String)
        Dim command As New SqlCommand(query, connection)
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub


#End Region

End Class
