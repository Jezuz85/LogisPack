Imports CapaDatos

Public Class index5
    Inherits Page

    Dim contexto As LogisPackEntities = New LogisPackEntities()
    Dim bError As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LlenarGridView()

    End Sub

    Public Sub LlenarGridView()

        Tabla.Cliente(GridView1)

    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals("Editar") Then

            hdfEdit.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Dim _Cliente = Getter.Cliente(Convert.ToInt32(hdfEdit.Value))

            txtCodigo_Edit.Text = _Cliente.codigo
            txtNombre_Edit.Text = _Cliente.nombre

            Modal.AbrirModal("editModal", "editModalScript", Me)

        ElseIf e.CommandName.Equals("Eliminar") Then

            hdfIDDel.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Modal.AbrirModal("deleteModal", "DeleteModalScript", Me)

        End If

    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _Nuevo As New Cliente With {
            .codigo = txtCodigo_Add.Text,
            .nombre = txtNombre_Add.Text
        }

        bError = Create.Cliente(_Nuevo)

        Modal.CerrarModal("addModal", "AddModalScript", Me)
        Modal.Validacion(Me, bError, "Add")
        LlenarGridView()
        Utilidades_UpdatePanel.LimpiarControles(up_Add)

    End Sub

    Protected Sub Editar(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim Edit = Getter.Cliente(Convert.ToInt32(hdfEdit.Value), contexto)

        If Edit IsNot Nothing Then
            Edit.codigo = txtCodigo_Edit.Text
            Edit.nombre = txtNombre_Edit.Text
        End If

        bError = Update.Cliente(Edit, contexto)

        Modal.CerrarModal("editModal", "EditModallScript", Me)
        Modal.Validacion(Me, bError, "Edit")
        Utilidades_UpdatePanel.LimpiarControles(up_Edit)
        LlenarGridView()
    End Sub

    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Delete.Cliente(Convert.ToInt32(hdfIDDel.Value))
        Modal.CerrarModal("deleteModal", "DeleteModalScript", Me)
        Modal.Validacion(Me, bError, "Delete")
        LlenarGridView()

    End Sub

End Class