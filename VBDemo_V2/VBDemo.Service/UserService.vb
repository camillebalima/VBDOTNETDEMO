Imports System.ComponentModel.DataAnnotations
Imports VBDemo.Model
Imports VBDemo.Repository

Public Class UserService
    Private userRepository As UserRepository = New UserRepository()

    Public Function GetUsers() As List(Of User)
        Return userRepository.GetUsers()
    End Function

    Private Function IsValidEntity(ByVal user As User) As Boolean
        Dim context As ValidationContext = New ValidationContext(user)
        Dim results As List(Of ValidationResult) = New List(Of ValidationResult)()
        Dim isValid As Boolean = Validator.TryValidateObject(user, context, results, True)

        For Each r As ValidationResult In results
            user.AddError(New [Error](user.Errors.Count + 1, r.ErrorMessage, "Model"))
        Next

        Return isValid
    End Function
End Class
