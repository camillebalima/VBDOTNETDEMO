Imports System.Data
Imports VBDemo.DAL
Imports VBDemo.Model
Imports VBDemo.Types

Public Class UserRepository
    Public Function GetUsers() As List(Of User)
        Dim db As DataAccess = New DataAccess()
        Dim dt As DataTable = db.Execute("GetDepartmentLookups", CommandType.StoredProcedure)
        Dim users As List(Of User) = New List(Of User)()

        For Each row As DataRow In dt.Rows
            Dim user As User = New User() With {
                .Id = Convert.ToInt32(row("ID")),
                .FirstName = row("FirstName").ToString(),
                .LastName = row("LastName").ToString(),
                .Age = Convert.ToInt32(row("Age"))
            }
            users.Add(user)
        Next

        Return users
    End Function

    Public Function Insert(ByVal user As User) As Boolean
        Dim parms As List(Of ParmStruct) = New List(Of ParmStruct)()
        parms.Add(New ParmStruct("@DepartmentId", user.FirstName, SqlDbType.Int, ParameterDirection.InputOutput))
        parms.Add(New ParmStruct("@Name", user.LastName, SqlDbType.NVarChar, ParameterDirection.Input, 30))
        parms.Add(New ParmStruct("@Description", user.Age, SqlDbType.NVarChar, ParameterDirection.Input, 255))
        Dim db As DataAccess = New DataAccess()

        If db.ExecuteNonQuery("InsertUser", CommandType.StoredProcedure, parms) > 0 Then
            user.Id = CInt(parms(0).Value)
            Return True
        End If

        Return False
    End Function


End Class
