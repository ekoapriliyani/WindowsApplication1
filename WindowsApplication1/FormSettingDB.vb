Imports MySql.Data.MySqlClient
Imports System.IO

Public Class FormSettingDB

    Private iniPath As String = "setting.ini"

    Private Sub FormSettingDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(iniPath) Then
            Dim lines() As String = File.ReadAllLines(iniPath)
            For Each line In lines
                If line.StartsWith("Server=") Then txtServer.Text = line.Replace("Server=", "")
                If line.StartsWith("Database=") Then txtDatabase.Text = line.Replace("Database=", "")
                If line.StartsWith("User=") Then txtUser.Text = line.Replace("User=", "")
                If line.StartsWith("Password=") Then txtPassword.Text = line.Replace("Password=", "")
            Next
        End If
    End Sub

    Private Function GetConnectionString() As String
        Return $"server={txtServer.Text};user id={txtUser.Text};password={txtPassword.Text};database={txtDatabase.Text};"
    End Function

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Try
            Using conn As New MySqlConnection(GetConnectionString())
                conn.Open()
                MessageBox.Show("Koneksi berhasil!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal koneksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim data As String() = {
            "Server=" & txtServer.Text,
            "Database=" & txtDatabase.Text,
            "User=" & txtUser.Text,
            "Password=" & txtPassword.Text
        }

        File.WriteAllLines(iniPath, data)
        MessageBox.Show("Setting database disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

End Class
