Public MustInherit Class Base
    Public Property Errors As List(Of [Error]) = New List(Of [Error])()

    Public Function GetErrors() As List(Of [Error])
        Return errors
    End Function

    Public Sub AddError(ByVal [error] As [Error])
        errors.Add([error])
    End Sub
End Class
