Imports System.Data.SqlClient
Imports CapaDatos

Public Class index
    Inherits Page

    Dim contexto As LogisPackEntities = New LogisPackEntities()
    Dim _comando As Comandos = New Comandos()
    Dim bError As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If IsPostBack = False Then

            MyTreeView.Nodes.Clear()

            Dim dt As DataTable = GetData(_comando.Arbol_Almacen_Nivel0)

            LlenarTreeView(dt, 0, Nothing)

            LlenarGridView()
            CargarListas()

        End If

    End Sub
    Public Sub LlenarGridView()

        Tabla.Almacen(GridView1)

    End Sub
    Public Sub CargarListas()
        Listas.Cliente(ddlClienteAdd)
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()

    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals("Editar") Then

            hdfEdit.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Dim _Almacen = Getter.Almacen(Convert.ToInt32(hdfEdit.Value))


            Listas.Cliente(ddlClienteEdit)
            ddlClienteEdit.SelectedValue = _Almacen.id_cliente
            txtEditCodigo.Text = _Almacen.codigo
            txtEditNombre.Text = _Almacen.nombre
            txtEditCoefVol.Text = _Almacen.coeficiente_volumetrico

            Modal.AbrirModal("editModal", "EditModalScript", Me)
        End If
        If e.CommandName.Equals("Eliminar") Then
            hdfIDDel.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Modal.AbrirModal("deleteModal", "DeleteModalScript", Me)
        End If
        If e.CommandName.Equals("Detalles") Then

            hdfView.Value = Utilidades_Grid.Get_IdRow(GridView1, e, "id")
            Dim _Almacen = Getter.Almacen(Convert.ToInt32(hdfView.Value))

            lbViewCliente.Text = _Almacen.Cliente.nombre
            lbViewCodigo.Text = _Almacen.codigo
            lbViewNombre.Text = _Almacen.nombre
            lbViewCoefVol.Text = _Almacen.coeficiente_volumetrico

            Modal.AbrirModal("viewModal", "ViewModalScript", Me)
        End If

    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _Nuevo As New Almacen With {
            .nombre = txtNombre.Text,
            .codigo = txtCodigo.Text,
            .coeficiente_volumetrico = txtCoefVol.Text,
            .id_cliente = Convert.ToInt32(ddlClienteAdd.SelectedValue)
        }

        bError = Create.Almacen(_Nuevo)

        Modal.CerrarModal("addModal", "AddModalScript", Me)
        Modal.Validacion(Me, bError, "Add")
        LlenarGridView()
        Utilidades_UpdatePanel.LimpiarControles(up_Add)
    End Sub
    Protected Sub Editar(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim Edit = Getter.Almacen(Convert.ToInt32(hdfEdit.Value), contexto)

        If Edit IsNot Nothing Then
            Edit.id_cliente = Convert.ToInt32(ddlClienteEdit.SelectedValue)
            Edit.codigo = txtEditCodigo.Text
            Edit.nombre = txtEditNombre.Text
            Edit.coeficiente_volumetrico = Convert.ToDouble(txtEditCoefVol.Text)
        End If

        bError = Update.Almacen(Edit, contexto)

        Modal.CerrarModal("EditModal", "EditModallScript", Me)
        Modal.Validacion(Me, bError, "Edit")
        Utilidades_UpdatePanel.LimpiarControles(up_Edit)
        LlenarGridView()
    End Sub
    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        bError = Delete.Almacen(Convert.ToInt32(hdfIDDel.Value))
        Modal.CerrarModal("deleteModal", "DeleteModalScript", Me)
        Modal.Validacion(Me, bError, "Delete")
        LlenarGridView()

    End Sub

    Protected Sub MyTreeView_SelectedNodeChanged(sender As Object, e As EventArgs) Handles MyTreeView.SelectedNodeChanged

        If MyTreeView.SelectedNode.Depth = 1 Then

            Dim IdAlmacen = Convert.ToInt32(MyTreeView.SelectedNode.Value)
            Dim Listarticulo = contexto.Almacen.Where(Function(model) model.id_almacen = IdAlmacen).SingleOrDefault()

            txtNomAlmacen.Text = Listarticulo.nombre
            CodAlmacen.Text = Listarticulo.codigo
            CoefVol.Text = Listarticulo.coeficiente_volumetrico

            CodCliente.Text = MyTreeView.SelectedNode.Parent.Text
            NomCliente.Text = "Cliente: " & MyTreeView.SelectedNode.Parent.Text
        End If
    End Sub
    Private Sub LlenarTreeView(dtParent As DataTable, parentId As Integer, treeNode As TreeNode)

        For Each row As DataRow In dtParent.Rows

            Dim child As New TreeNode() With {
                .Text = row("Name").ToString(),
                .Value = row("ID").ToString()
                }

            If parentId = 0 Then
                MyTreeView.Nodes.Add(child)
                Dim dtChild As DataTable = Me.GetData(_comando.Arbol_Almacen_Nivel1 + child.Value)
                LlenarTreeView(dtChild, 1, child)
            ElseIf parentId = 1 Then
                treeNode.ChildNodes.Add(child)
                Dim dtChild As DataTable = Me.GetData(_comando.Arbol_Almacen_Nivel2 + child.Value)
                LlenarTreeView(dtChild, 2, child)
            Else
                treeNode.ChildNodes.Add(child)
            End If
        Next

        MyTreeView.CollapseAll()

    End Sub
    Private Function GetData(query As String) As DataTable
        Dim dt As New DataTable()
        Dim constr As String = ConfigurationManager.ConnectionStrings("DLAlmacen").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    sda.Fill(dt)
                End Using
            End Using
            Return dt
        End Using
    End Function

End Class