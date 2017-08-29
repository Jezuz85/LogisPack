Imports System.Data.SqlClient
Imports CapaDatos

Public Class index
    Inherits Page

    Dim contexto As LogisPackEntities = New LogisPackEntities()
    Dim bError As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            MyTreeView.Nodes.Clear()
            Dim dt As DataTable = Me.GetData("SELECT Count(id_almacen), id_cliente ID , 'Cliente:' + cast(id_cliente as varchar)  Name FROM Almacen Group By id_cliente")
            Me.PopulateTreeView(dt, 0, Nothing)

            LlenarGridView()

        End If

    End Sub

    Private Sub PopulateTreeView(dtParent As DataTable, parentId As Integer, treeNode As TreeNode)
        For Each row As DataRow In dtParent.Rows

            Dim child As New TreeNode() With {
                .Text = row("Name").ToString(),
                .Value = row("ID").ToString()
                }

            If parentId = 0 Then
                MyTreeView.Nodes.Add(child)
                Dim dtChild As DataTable = Me.GetData("SELECT (codigo +' '+ nombre) Name, id_almacen ID FROM Almacen WHERE id_cliente = " + child.Value)
                PopulateTreeView(dtChild, 1, child)
            ElseIf parentId = 1 Then
                treeNode.ChildNodes.Add(child)
                Dim dtChild As DataTable = Me.GetData("SELECT 'Articulo: '+nombre Name, id_articulo ID FROM Articulo WHERE id_almacen =" + child.Value)
                PopulateTreeView(dtChild, 2, child)
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

    Public Sub LlenarGridView()

        Tabla.Almacen(GridView1)

    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        LlenarGridView()

    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName.Equals("Editar") Then
            Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
            Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
            hdfEdit.Value = TryCast(gvrow.FindControl("id"), Label).Text
            Dim IdAlmacen = Convert.ToInt32(hdfEdit.Value)

            Dim _Almacen = contexto.Almacen.Where(Function(model) model.id_almacen = IdAlmacen).SingleOrDefault()

            txtEditCliente.Text = _Almacen.id_cliente
            txtEditCodigo.Text = _Almacen.codigo
            txtEditNombre.Text = _Almacen.nombre
            txtEditCoefVol.Text = _Almacen.coeficiente_volumetrico

            Modal.AbrirModal("EditModal", "EditModalScript", Me)
        End If
        If e.CommandName.Equals("Eliminar") Then

            Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
            Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
            hdfIDDel.Value = TryCast(gvrow.FindControl("id"), Label).Text

            Modal.AbrirModal("deleteModal", "DeleteModalScript", Me)

        End If
        If e.CommandName.Equals("Detalles") Then
            Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
            Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
            hdfView.Value = TryCast(gvrow.FindControl("id"), Label).Text
            Dim IdAlmacen = Convert.ToInt32(hdfView.Value)

            Dim _Almacen = contexto.Almacen.Where(Function(model) model.id_almacen = IdAlmacen).SingleOrDefault()

            lbViewCliente.Text = _Almacen.id_cliente
            lbViewCodigo.Text = _Almacen.codigo
            lbViewNombre.Text = _Almacen.nombre
            lbViewCoefVol.Text = _Almacen.coeficiente_volumetrico

            Modal.AbrirModal("ViewModal", "ViewModalScript", Me)
        End If

    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim _Nuevo As New Almacen With {
            .nombre = txtNombre.Text,
            .codigo = txtCodigo.Text,
            .coeficiente_volumetrico = txtCoefVol.Text,
            .id_cliente = txtcliente.Text
        }

        bError = Create.Almacen(_Nuevo)

        Modal.CerrarModal("addModal", "AddModalScript", Me)
        Modal.Validacion(Me, bError, "Add")
        LlenarGridView()
    End Sub

    Protected Sub Editar(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim IdAlmacen = Convert.ToInt32(hdfEdit.Value)

        Dim Edit As Almacen = contexto.Almacen.SingleOrDefault(Function(b) b.id_almacen = IdAlmacen)

        If Edit IsNot Nothing Then
            Edit.id_cliente = Convert.ToInt32(txtEditCliente.Text)
            Edit.codigo = txtEditCodigo.Text
            Edit.nombre = txtEditNombre.Text
            Edit.coeficiente_volumetrico = Convert.ToDouble(txtEditCoefVol.Text)
        End If

        Try
            contexto.SaveChanges()
            bError = True
        Catch ex As Exception
            bError = False
        End Try

        Modal.CerrarModal("EditModal", "EditModallScript", Me)
        Modal.Validacion(Me, bError, "Edit")
        LlenarGridView()
    End Sub

    Protected Sub EliminarRegistro(sender As Object, e As EventArgs)

        Dim tabla As New Almacen()

        bError = Delete.Almacen(tabla, Convert.ToInt32(hdfIDDel.Value))

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

        'Label1.Text = "Valor: " & MyTreeView.SelectedNode.Text


        'Label2.Text = "Nivel: " & MyTreeView.SelectedNode.Depth + 1
    End Sub



End Class