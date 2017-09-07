Imports CapaDatos

Public Class index2
    Inherits Page

    Dim bError As Boolean
    Dim contexto As LogisPackEntities = New LogisPackEntities()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LlenarGridView()

    End Sub
    Public Sub LlenarGridView()

        Tabla.TipoUnidad(GridView1)

    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()

    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals("Editar") Then

            hdfEdit.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Dim _TipoUnidad = Getter.Tipo_Unidad(Convert.ToInt32(hdfEdit.Value))
            txtNombre_Edit.Text = _TipoUnidad.nombre
            Modal.AbrirModal("EditModal", "EditModalScript", Me)
        End If
        If e.CommandName.Equals("Eliminar") Then

            hdfIDDel.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)

        End If

    End Sub


    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _Nuevo As New Tipo_Unidad With {
            .nombre = txtNombre.Text
        }

        bError = Create.TipoUnidad(_Nuevo)

        Modal.CerrarModal("AddModal", "AddModalScript", Me)
        Modal.Validacion(Me, bError, "Add")
        LlenarGridView()
        Utilidades_UpdatePanel.LimpiarControles(up_Add)
    End Sub
    Protected Sub Editar(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim Edit = Getter.Tipo_Unidad(Convert.ToInt32(hdfEdit.Value), contexto)

        If Edit IsNot Nothing Then
            Edit.nombre = txtNombre_Edit.Text
        End If

        bError = Update.Tipo_Unidad(Edit, contexto)

        Modal.CerrarModal("EditModal", "EditModallScript", Me)
        Modal.Validacion(Me, bError, "Edit")
        Utilidades_UpdatePanel.LimpiarControles(up_Edit)
        LlenarGridView()
    End Sub
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Delete.TipoUnidad(Convert.ToInt32(hdfIDDel.Value))

        Modal.CerrarModal("DeleteModal", "DeleteModalScript", Me)
        Modal.Validacion(Me, bError, "Delete")
        LlenarGridView()
    End Sub

End Class