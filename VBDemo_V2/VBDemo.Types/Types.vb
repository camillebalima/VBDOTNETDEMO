Imports System.Data


Public Structure ParmStruct
        Public Sub New(ByVal name As String, ByVal value As Object, ByVal dataType As SqlDbType, ByVal Optional direction As ParameterDirection = ParameterDirection.Input, ByVal Optional size As Integer = 0)
            name = name
            value = value
            size = size
            dataType = dataType
            direction = direction
        End Sub

        Public Name As String
        Public Value As Object
        Public Size As Integer
        Public DataType As SqlDbType
        Public Direction As ParameterDirection
    End Structure

