Imports CapaDatos

Public Class index1
    Inherits Page

    Dim bError As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LlenarGridView()

    End Sub

    Public Sub LlenarGridView()

        Tabla.TipoFacturacion(GridView1)

    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()

    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals("Editar") Then

        ElseIf e.CommandName.Equals("Eliminar") Then
            hdfIDDel.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Modal.AbrirModal("deleteModal", "DeleteModalScript", Me)
        End If


    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _Nuevo As New Tipo_Facturacion With {
            .nombre = txtNombre.Text
        }

        bError = Create.TipoFacturacion(_Nuevo)

        Modal.CerrarModal("addModal", "AddModalScript", Me)

        Modal.Validacion(Me, bError, "Add")

        LlenarGridView()

        Utilidades_UpdatePanel.LimpiarControles(up_Add)

    End Sub


    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        Dim tabla As New Tipo_Facturacion()

        bError = Delete.TipoFacturacion(tabla, Convert.ToInt32(hdfIDDel.Value))

        Modal.CerrarModal("deleteModal", "DeleteModalScript", Me)

        Modal.Validacion(Me, bError, "Delete")

        LlenarGridView()

    End Sub

End Class