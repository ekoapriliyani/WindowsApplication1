Public Class frmLogin

    Dim auth As New AuthController()

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Password akan disembunyikan (muncul bintang/titik) saat pertama buka
        txtPassword.UseSystemPasswordChar = True

        ' Cek koneksi database saat form pertama kali dibuka
        CekKoneksiDatabase()
    End Sub

    ' Fungsi tambahan agar kode lebih rapi
    Private Sub CekKoneksiDatabase()
        If Not IO.File.Exists("setting.ini") Then
            MessageBox.Show("Database belum disetting, silakan atur koneksi terlebih dahulu.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Membuka form setting database
            Using f As New FormSettingDB
                f.ShowDialog()
            End Using

            ' Setelah setting ditutup, cek lagi apakah file sudah dibuat
            If Not IO.File.Exists("setting.ini") Then
                MessageBox.Show("Aplikasi akan ditutup karena database belum diatur.", "Peringatan")
                Application.Exit()
            End If
        End If
    End Sub

    ' =========================
    ' TOMBOL LOGIN (Sudah Digabung)
    ' =========================
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        ' 1. Validasi Input (Pastikan tidak kosong)
        If txtUsername.Text.Trim() = "" OrElse txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Username dan password wajib diisi!", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. Proses Login melalui Controller
        Try
            ' Mencoba login
            Dim user = auth.Login(txtUsername.Text.Trim(), txtPassword.Text.Trim())

            If user IsNot Nothing Then
                ' Jika user ditemukan, simpan ke variabel global (Session)
                LoggedUser = user

                MessageBox.Show("Login berhasil! Selamat datang.", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Buka Form Utama dan sembunyikan Form Login
                Dim main As New frmUtama
                main.Show()
                Me.Hide()
            Else
                ' Jika user tidak ditemukan
                MessageBox.Show("Username atau password salah!", "Login Gagal",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Clear()
                txtPassword.Focus()
            End If

        Catch ex As Exception
            ' Jika ada error pada database/sistem
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================
    ' SHOW / HIDE PASSWORD
    ' =========================
    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) _
        Handles chkShowPassword.CheckedChanged

        ' Jika checkbox dicentang, maka sembunyikan karakter (UseSystemPasswordChar = False)
        txtPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
    End Sub

End Class