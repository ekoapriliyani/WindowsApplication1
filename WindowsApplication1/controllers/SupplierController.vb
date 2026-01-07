Public Class SupplierController

    ' READ ALL
    Public Function LoadSuppliers() As DataTable
        Return SupplierModel.GetAll()
    End Function

    ' READ BY ID
    Public Function GetSupplierById(id As Integer) As SupplierModel
        Return SupplierModel.GetSupplierById(id)
    End Function

    ' CREATE
    Public Function Create(supplier As SupplierModel) As Boolean
        If Not ValidateSupplier(supplier) Then Return False
        Return supplier.CreateSupplier(supplier)
    End Function

    ' UPDATE
    Public Function Update(supplier As SupplierModel) As Boolean
        If Not ValidateSupplier(supplier) Then Return False
        Return supplier.UpdateSupplier(supplier)
    End Function

    ' DELETE
    Public Function Delete(id As Integer) As Boolean
        Return New SupplierModel().DeleteSupplier(id)
    End Function

    ' VALIDATION
    Private Function ValidateSupplier(supplier As SupplierModel) As Boolean
        If String.IsNullOrWhiteSpace(supplier.namaSupplier) Then
            MessageBox.Show("Nama Supplier tidak boleh kosong")
            Return False
        End If

        If String.IsNullOrWhiteSpace(supplier.alamatSupplier) Then
            MessageBox.Show("Alamat Supplier tidak boleh kosong")
            Return False
        End If

        Return True
    End Function

End Class
