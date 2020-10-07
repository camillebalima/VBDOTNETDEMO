Public Class [Error]
    Public Property code() As Integer
    Public Property description() As String
    Public Property type() As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal code As Integer, ByVal description As String, ByVal type As String)
        Me.code = code
        Me.description = description
        Me.type = type
    End Sub
End Class
