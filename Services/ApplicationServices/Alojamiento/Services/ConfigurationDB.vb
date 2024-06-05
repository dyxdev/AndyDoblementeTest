Imports System.Data.SqlClient
Public Class ConfigurationDB
    Implements IConfigurationDB

    Public Function connect(server As String, user As String, pass As String, dbName As String) As Object Implements IConfigurationDB.connect

        If String.IsNullOrEmpty(server) And
            Not StringValidations.HasNoWhitespace(server) Then
            Throw New ArgumentException("Debe proporcionar un nombre de servidor válido.")
        End If

        If String.IsNullOrEmpty(dbName) And
            Not StringValidations.HasNoWhitespace(dbName) Then
            Throw New ArgumentException("Debe proporcionar un nombre de base de datos válido.")
        End If

        If String.IsNullOrEmpty(user) And
            Not StringValidations.HasNoWhitespace(user) Then
            Throw New ArgumentException("Debe proporcionar un nombre de usuario válido.")
        End If

        If String.IsNullOrEmpty(pass) And
            Not StringValidations.HasNoWhitespace(pass) Then
            Throw New ArgumentException("Debe proporcionar una contraseña válida.")
        End If

        Try
            Dim builder As New SqlConnectionStringBuilder()
            builder.DataSource = server
            builder.InitialCatalog = dbName
            builder.UserID = user
            builder.Password = pass
            Dim connectionString As String = builder.ConnectionString
            Return connectionString
        Catch ex As Exception
            Throw New ArgumentException("Cadena de conexión invalida")
        End Try

    End Function
End Class
