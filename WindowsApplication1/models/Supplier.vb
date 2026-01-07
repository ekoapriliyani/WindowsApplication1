Imports MySql.Data.MySqlClient

Public Class SupplierModel

    Public Property id As Integer
    Public Property namaSupplier As String
    Public Property alamatSupplier As String
    Public Property telSupplier As String

    ' READ ALL
    Public Shared Function GetAll() As DataTable
        Dim dt As New DataTable
        Dim query As String = "SELECT * FROM supplier"

        Using conn = Koneksi.OpenConnection()
            Using cmd As New MySqlCommand(query, conn)
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using

        Return dt
    End Function

    ' READ BY ID
    Public Shared Function GetSupplierById(id As Integer) As SupplierModel
        Dim dt As New DataTable()
        Dim query As String = "SELECT * FROM supplier WHERE id=@id"

        Using conn = Koneksi.OpenConnection()
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", id)
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using

        If dt.Rows.Count = 0 Then Return Nothing

        Dim row = dt.Rows(0)

        Return New SupplierModel With {
            .id = Convert.ToInt32(row("id")),
            .namaSupplier = row("namaSupplier").ToString(),
            .alamatSupplier = row("alamatSupplier").ToString(),
            .telSupplier = row("telSupplier").ToString()
        }
    End Function

    ' CREATE
    Public Function CreateSupplier(supplier As SupplierModel) As Boolean
        Using conn = Koneksi.OpenConnection()
            Dim query As String = "INSERT INTO supplier (namaSupplier, alamatSupplier, telSupplier) VALUES (@namaSupplier, @alamatSupplier, @telSupplier)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@namaSupplier", supplier.namaSupplier)
                cmd.Parameters.AddWithValue("@alamatSupplier", supplier.alamatSupplier)
                cmd.Parameters.AddWithValue("@telSupplier", supplier.telSupplier)

                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    ' UPDATE
    Public Function UpdateSupplier(supplier As SupplierModel) As Boolean
        Using conn = Koneksi.OpenConnection()
            Dim query As String = "UPDATE supplier SET namaSupplier=@namaSupplier, alamatSupplier=@alamatSupplier, telSupplier=@telSupplier WHERE id=@id"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@namaSupplier", supplier.namaSupplier)
                cmd.Parameters.AddWithValue("@alamatSupplier", supplier.alamatSupplier)
                cmd.Parameters.AddWithValue("@telSupplier", supplier.telSupplier)
                cmd.Parameters.AddWithValue("@id", supplier.id)

                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    ' DELETE
    Public Function DeleteSupplier(id As Integer) As Boolean
        Using conn = Koneksi.OpenConnection()
            Dim query As String = "DELETE FROM supplier WHERE id=@id"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", id)

                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

End Class

