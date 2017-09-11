﻿Imports CapaDatos

Public Class index3
    Inherits Page

    Dim bError As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LlenarGridView()

    End Sub

    ''' <summary>
    ''' Metodo que llena El Gridview con datos de la Base de Datos
    ''' </summary>
    Public Sub LlenarGridView()

        Tabla.Articulo(GridView1)

    End Sub

    ''' <summary>
    ''' Metodos del gridview
    ''' </summary>
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals(Mensajes.Editar.ToString) Then
            Dim id As String = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Response.Redirect("Editar.aspx?id=" & Cifrar.cifrarCadena(id))

        End If
        If e.CommandName.Equals("Detalle") Then
            Dim id As String = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Response.Redirect("Detalles.aspx?id=" & Cifrar.cifrarCadena(id))

        End If
        If e.CommandName.Equals(Mensajes.Eliminar.ToString) Then
            hdfIDDel.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)

        End If


    End Sub

    ''' <summary>
    ''' Metodo que elimina un articulo de la base de datos
    ''' </summary>
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Delete.Articulo(Convert.ToInt32(hdfIDDel.Value))
        Modal.CerrarModal("DeleteModal", "DeleteModalScript", Me)
        LlenarGridView()
    End Sub

    ''' <summary>
    ''' Metodo que se invoca cuando se presiona el boton "guardar" y redirecciona la pagina a "Crear"
    ''' </summary>
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Response.Redirect("Crear.aspx")
    End Sub

End Class