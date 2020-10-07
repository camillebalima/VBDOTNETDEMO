Public Class User
    Inherits Base

    Public Property Id() As Integer
    Public Property FirstName() As String
    Public Property LastName() As String
    Public Property Age() As Integer

    Public Sub New()
    End Sub

    Public Sub New(ByVal Id As Integer)
        Me.Id = Id
    End Sub

    Public Sub New(ByVal Id As Integer, ByVal FirstName As String, ByVal LastName As String, ByVal Age As Integer)
        Me.Id = Id
        Me.FirstName = FirstName
        Me.LastName = LastName
        Me.Age = Age
    End Sub
End Class
