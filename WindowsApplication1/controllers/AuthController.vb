Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class AuthController

    ' =========================
    ' AMBIL CONNECTION STRING DARI setting.ini
    ' =========================
    Private Function GetConnectionString() As String
        Dim server As String = ""
        Dim database As String = ""
        Dim user As String = ""
        Dim password As String = ""

        If Not File.Exists("setting.ini") Then
            Throw New Exception("File setting.ini tidak ditemukan")
        End If

        For Each line In File.ReadAllLines("setting.ini")
            If line.StartsWith("Server=") Then server = line.Replace("Server=", "")
            If line.StartsWith("Database=") Then database = line.Replace("Database=", "")
            If line.StartsWith("User=") Then user = line.Replace("User=", "")
            If line.StartsWith("Password=") Then password = line.Replace("Password=", "")
        Next

        Return $"server={server};database={database};uid={user};pwd={password};"
    End Function

    ' =========================
    ' LOGIN
    ' =========================
    Public Function Login(username As String, password As String) As User

        Dim sql As String = "SELECT id, username, password, role
                             FROM users
                             WHERE username=@u
                             LIMIT 1"

        Using conn As New MySqlConnection(GetConnectionString())
            conn.Open()

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@u", username)

                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        Dim hashDb As String = rd("password").ToString()
                        Dim hashInput As String = GetMD5(password)

                        If hashInput = hashDb Then
                            Return New User With {
                                .Id = rd("id"),
                                .Username = rd("username"),
                                .Role = rd("role")
                            }
                        End If
                    End If
                End Using
            End Using
        End Using

        Return Nothing
    End Function

    ' =========================
    ' HASH MD5
    ' =========================
    Private Function GetMD5(text As String) As String
        Using md5 As MD5 = MD5.Create()
            Dim bytes = Encoding.UTF8.GetBytes(text)
            Dim hash = md5.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function

End Class
