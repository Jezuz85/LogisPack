﻿Imports CapaDatos

Public Class index2
    Inherits Page

    Private bError As Boolean
    Private contexto As LogisPackEntities = New LogisPackEntities()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LlenarGridView()
        Modal.OcultarAlerta(updatePanelPrinicpal)

    End Sub
    Private Sub LlenarGridView()

        Tabla.TipoUnidad(GridView1)

    End Sub

    ''' <summary>
    ''' Metodos del Gridview
    ''' </summary>
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()

    End Sub
    Protected Sub GridView1_onRowEditing(sender As Object, e As GridViewEditEventArgs)

        hdfEdit.Value = Utilidades_Grid.Get_IdRow_Editing(GridView1, e, "id")
        Dim _TipoUnidad = Getter.Tipo_Unidad(Convert.ToInt32(hdfEdit.Value))
        txtNombre_Edit.Text = _TipoUnidad.nombre
        Modal.AbrirModal("EditModal", "EditModalScript", Me)

    End Sub
    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        hdfIDDel.Value = Utilidades_Grid.Get_IdRow_Deleting(GridView1, e, "id")
        Modal.AbrirModal("DeleteModal", "DeleteModalScript", Me)

    End Sub

    ''' <summary>
    ''' Metodo que registra un tipo de unidad en la base de datos
    ''' </summary>
    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _Nuevo As New Tipo_Unidad With {
            .nombre = txtNombre.Text
        }

        bError = Create.TipoUnidad(_Nuevo)

        Modal.CerrarModal("AddModal", "AddModalScript", Me)
        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Registrar.ToString, bError, Me, updatePanelPrinicpal, up_Add)
        LlenarGridView()
    End Sub

    ''' <summary>
    ''' Metodo que Actualiza un tipo de unidad en la base de datos
    ''' </summary>
    Protected Sub Editar(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim Edit = Getter.Tipo_Unidad(Convert.ToInt32(hdfEdit.Value), contexto)

        If Edit IsNot Nothing Then
            Edit.nombre = txtNombre_Edit.Text
        End If

        bError = Update.Tipo_Unidad(Edit, contexto)

        Modal.CerrarModal("EditModal", "EditModallScript", Me)
        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Editar.ToString, bError, Me, updatePanelPrinicpal, up_Edit)
        LlenarGridView()
    End Sub

    ''' <summary>
    ''' Metodo que Elimina un tipo de unidad en la base de datos
    ''' </summary>
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Delete.TipoUnidad(Convert.ToInt32(hdfIDDel.Value))

        Modal.CerrarModal("DeleteModal", "DeleteModalScript", Me)

        Utilidades_UpdatePanel.CerrarOperacion(Mensajes.Eliminar.ToString, bError, Me, updatePanelPrinicpal, Nothing)
        LlenarGridView()
    End Sub

End Class