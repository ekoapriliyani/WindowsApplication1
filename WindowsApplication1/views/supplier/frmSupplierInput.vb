Public Class frmSupplierInput

    Dim controller As New SupplierController
    Dim editedID As Integer = -1

    ' MODE ADD
    Sub New()
        InitializeComponent()
    End Sub

    ' MODE EDIT
    Sub New(supplier As SupplierModel)
        InitializeComponent()

        With supplier
            editedID = .id
            txtNamaSupplier.Text = .namaSupplier
            txtAlamatSupplier.Text = .alamatSupplier
            txtTelSupplier.Text = .telSupplier
        End With
    End Sub

    ' =========================
    ' SAVE BUTTON
    ' =========================
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim supplier As New SupplierModel With {
            .namaSupplier = txtNamaSupplier.Text,
            .alamatSupplier = txtAlamatSupplier.Text,
            .telSupplier = txtTelSupplier.Text
        }

        If editedID = -1 Then
            controller.Create(supplier)
        Else
            supplier.id = editedID
            controller.Update(supplier)
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

End Class
