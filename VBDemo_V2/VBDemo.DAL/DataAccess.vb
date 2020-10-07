Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports VBDemo.Types
Imports System.Configuration
'Imports VBDemo.Types

Public Class DataAccess
    Public Function Execute(ByVal cmdText As String, ByVal cmdType As CommandType, ByVal Optional parms As List(Of ParmStruct) = Nothing) As DataTable
        Dim cmd As SqlCommand = CreateCommand(cmdText, cmdType, parms)
        Dim dt As DataTable = New DataTable()
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        da.Fill(dt)
        Return dt
    End Function

    Public Function ExecuteNonQuery(ByVal cmdText As String, ByVal cmdType As CommandType, ByVal Optional parms As List(Of ParmStruct) = Nothing) As Integer
        Dim cmd As SqlCommand = CreateCommand(cmdText, cmdType, parms)
        Dim retVal As Integer

        Using cmd.Connection
            cmd.Connection.Open()
            retVal = cmd.ExecuteNonQuery()
            UnloadParms(parms, cmd)
        End Using

        Return retVal
    End Function

    Private Shared Sub UnloadParms(ByVal parms As List(Of ParmStruct), ByVal cmd As SqlCommand)
        If parms IsNot Nothing Then

            For i As Integer = 0 To parms.Count - 1
                Dim p As ParmStruct = parms(i)
                p.Value = cmd.Parameters(i).Value
                parms(i) = p
            Next
        End If
    End Sub

    Public Function ExecuteScaler(ByVal sql As String, ByVal cmdType As CommandType, ByVal Optional parms As List(Of ParmStruct) = Nothing) As Object
        Dim cmd As SqlCommand = CreateCommand(sql, cmdType, parms)
        Dim retVal As Object

        Using cmd.Connection
            cmd.Connection.Open()
            retVal = cmd.ExecuteScalar()
        End Using

        Return retVal
    End Function

    Private Function CreateCommand(ByVal cmdText As String, ByVal cmdType As CommandType, ByVal parms As List(Of ParmStruct)) As SqlCommand
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("VBDemo").ConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(cmdText, conn)
        cmd.CommandType = cmdType

        If parms IsNot Nothing Then

            For Each p As ParmStruct In parms
                cmd.Parameters.Add(p.Name, p.DataType, p.Size).Value = p.Value
                cmd.Parameters(0).Direction = parms(0).Direction
            Next
        End If

        Return cmd
    End Function
End Class
