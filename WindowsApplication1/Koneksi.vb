Imports MySql.Data.MySqlClient
Imports System.IO

Module Koneksi

    Private conn As MySqlConnection

    Private Function GetConnectionString() As String
        Dim configFile As String = "setting.ini"

        ' DEFAULT (biar login tetap bisa)
        Dim server As String = "localhost"
        Dim database As String = "dbpenjualan"
        Dim username As String = "root"
        Dim password As String = "Eko123$"

        ' Kalau setting.ini ada → baca
        If File.Exists(configFile) Then
            Dim lines() As String = File.ReadAllLines(configFile)
            For Each line In lines
                If line.StartsWith("Server=") Then server = line.Replace("Server=", "")
                If line.StartsWith("Database=") Then database = line.Replace("Database=", "")
                If line.StartsWith("User=") Then username = line.Replace("User=", "")
                If line.StartsWith("Password=") Then password = line.Replace("Password=", "")
            Next
        End If

        Return $"server={server};user id={username};password={password};database={database};"
    End Function

    Public Function OpenConnection() As MySqlConnection
        Try
            If conn Is Nothing Then
                conn = New MySqlConnection(GetConnectionString())
            End If

            If conn.State = ConnectionState.Closed OrElse conn.State = ConnectionState.Broken Then
                conn.Open()
            End If

            Return conn
        Catch ex As Exception
            MessageBox.Show("Koneksi gagal: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Sub CloseConnection()
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

End Module
