Imports CapaDatos

Public Class index2
    Inherits System.Web.UI.Page

    Dim bError As Boolean

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

        End If
        If e.CommandName.Equals("Eliminar") Then

            Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
            Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
            hdfIDDel.Value = TryCast(gvrow.FindControl("id"), Label).Text

            Modal.AbrirModal("deleteModal", "DeleteModalScript", Me)

        End If


    End Sub


    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _Nuevo As New Tipo_Unidad With {
            .nombre = txtNombre.Text
        }

        bError = Create.TipoUnidad(_Nuevo)

        Modal.CerrarModal("addModal", "AddModalScript", Me)
        Modal.Validacion(Me, bError, "Add")
        LlenarGridView()
    End Sub

    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        Dim tabla As New Tipo_Unidad()

        bError = Delete.TipoUnidad(tabla, Convert.ToInt32(hdfIDDel.Value))

        Modal.CerrarModal("deleteModal", "DeleteModalScript", Me)

        Modal.Validacion(Me, bError, "Delete")

        LlenarGridView()

    End Sub

End Class