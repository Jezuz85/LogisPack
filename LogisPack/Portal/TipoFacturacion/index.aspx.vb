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

        For Each c As Control In UpdatePanel1.Controls
            FindAndInvoke(c)
        Next

    End Sub

    Private Shared Sub FindAndInvoke(control As Control)

        'If c IsNot Nothing Then
        '    If c.GetType() Is GetType(Button) Then


        '    End If
        'End If

    End Sub

    'Private Shared controldefaults As Dictionary(Of Type, Action(Of Control)) = New Dictionary(Of Type, Action(Of Control))() With {
    '.GetType(Function(, c) (CType(c, TextBox)).Clear(), TextBox),
    '.GetTypeCType(Function(, c) (CType(c, CheckBox)).Checked = False, CheckBox),
    '.GetTypeCType(Function(, c) (CType(c, ListBox)).Items.Clear(), ListBox),
    '.GetTypeCType(Function(, c) (CType(c, RadioButton)).Checked = False, RadioButton),
    '.GetTypeCType(Function(, c) (CType(c, GroupBox)).Controls.ClearControls(), GroupBox),
    '.GetTypeCType(Function(, c) (CType(c, Panel)).Controls.ClearControls(), Panel)
    '}




    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        Dim tabla As New Tipo_Facturacion()

        bError = Delete.TipoFacturacion(tabla, Convert.ToInt32(hdfIDDel.Value))

        Modal.CerrarModal("deleteModal", "DeleteModalScript", Me)

        Modal.Validacion(Me, bError, "Delete")

        LlenarGridView()

    End Sub

End Class