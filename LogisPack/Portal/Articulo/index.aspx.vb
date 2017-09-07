Imports CapaDatos

Public Class index3
    Inherits Page

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
            Dim id As String = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Response.Redirect("Editar.aspx?id=" & Cifrar.cifrarCadena(id))

        End If
        If e.CommandName.Equals("Detalle") Then
            Dim id As String = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Response.Redirect("Detalles.aspx?id=" & Cifrar.cifrarCadena(id))

        End If
        If e.CommandName.Equals("Eliminar") Then
            hdfIDDel.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)

        End If


    End Sub

    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Delete.Articulo(Convert.ToInt32(hdfIDDel.Value))
        Modal.CerrarModal("DeleteModal", "DeleteModalScript", Me)
        Modal.Validacion(Me, bError, "Delete")
        LlenarGridView()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Response.Redirect("Crear.aspx")
    End Sub


End Class