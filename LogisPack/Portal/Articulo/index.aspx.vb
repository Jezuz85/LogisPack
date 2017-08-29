Imports CapaDatos

Public Class index3
    Inherits System.Web.UI.Page

    Dim bError As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LlenarGridView()

    End Sub

    Public Sub LlenarGridView()

        Tabla.Articulo(GridView1)

    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()

    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals("Editar") Then

        End If
        If e.CommandName.Equals("Detalle") Then
            Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
            Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
            Dim id As String = TryCast(gvrow.FindControl("id"), Label).Text

            Response.Redirect("Detalles.aspx?id=" & Cifrar.cifrarCadena(id))

        End If
        If e.CommandName.Equals("Eliminar") Then

            Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
            Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
            hdfIDDel.Value = TryCast(gvrow.FindControl("id"), Label).Text

            Modal.AbrirModal("deleteModal", "DeleteModalScript", Me)

        End If


    End Sub


    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        Dim tabla As New Articulo()

        bError = Delete.Articulo(tabla, Convert.ToInt32(hdfIDDel.Value))

        Modal.CerrarModal("deleteModal", "DeleteModalScript", Me)

        Modal.Validacion(Me, bError, "Delete")

        LlenarGridView()

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Response.Redirect("Crear.aspx")
    End Sub
End Class