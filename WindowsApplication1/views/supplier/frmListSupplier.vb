Public Class frmListSupplier

    Dim controller As New SupplierController

    Private Sub frmListSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGrid()
    End Sub

    Sub LoadGrid()
        DataGridView1.AutoGenerateColumns = False
        Dim dt As DataTable = controller.LoadSuppliers()
        DataGridView1.DataSource = dt
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim dv As DataView = CType(DataGridView1.DataSource, DataTable).DefaultView
        dv.RowFilter = "namaSupplier LIKE '%" & txtSearch.Text & "%' OR alamatSupplier LIKE '%" & txtSearch.Text & "%'"
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New frmSupplierInput
        If frm.ShowDialog() = DialogResult.OK Then
            LoadGrid()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count = 0 Then Return

        Dim id = DataGridView1.SelectedRows(0).Cells("id").Value

        If MessageBox.Show("Hapus supplier ini?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            controller.Delete(id)
            LoadGrid()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih data supplier terlebih dahulu")
            Return
        End If

        Dim id As Integer = CInt(DataGridView1.SelectedRows(0).Cells("id").Value)

        Dim supplier As SupplierModel = controller.GetSupplierById(id)
        If supplier Is Nothing Then
            MessageBox.Show("Data supplier tidak ditemukan")
            Return
        End If

        Dim frm As New frmSupplierInput(supplier)
        If frm.ShowDialog() = DialogResult.OK Then
            LoadGrid()
        End If
    End Sub

End Class
