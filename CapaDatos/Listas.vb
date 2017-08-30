Imports System.Web.UI.WebControls

Public Class Listas

    Public Shared Sub Almacen(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Almacen
                     Select
                         AL.id_almacen,
                         AL.nombre
                    ).ToList()

        DropDownList1.DataValueField = "id_almacen"
        DropDownList1.DataTextField = "nombre"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()
        DropDownList1.Items.Insert(0, New ListItem("Seleccione...", ""))
    End Sub

    Public Shared Sub TipoFacturacion(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Tipo_Facturacion
                     Select
                         AL.id_tipo_facturacion,
                         AL.nombre
                    ).ToList()

        DropDownList1.DataValueField = "id_tipo_facturacion"
        DropDownList1.DataTextField = "nombre"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()
        DropDownList1.Items.Insert(0, New ListItem("Seleccione...", ""))
    End Sub

    Public Shared Sub TipoUnidad(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Tipo_Unidad
                     Select
                         AL.id_tipo_unidad,
                         AL.nombre
                    ).ToList()

        DropDownList1.DataValueField = "id_tipo_unidad"
        DropDownList1.DataTextField = "nombre"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()
        DropDownList1.Items.Insert(0, New ListItem("Seleccione...", ""))
    End Sub

    Public Shared Sub Articulo(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Articulo
                     Where AL.tipoArticulo = "Normal"
                     Select
                         AL.id_articulo,
                         NombreStock = AL.nombre & " - Stock:" & AL.stock_fisico
                    ).ToList()

        DropDownList1.DataValueField = "id_articulo"
        DropDownList1.DataTextField = "NombreStock"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()
        DropDownList1.Items.Insert(0, New ListItem("Seleccione...", ""))
    End Sub

    Public Shared Sub ArticuloTodos(ByRef DropDownList1 As DropDownList)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Articulo
                     Select
                         AL.id_articulo,
                         NombreStock = AL.nombre & " - Stock:" & AL.stock_fisico
                    ).ToList()

        DropDownList1.DataValueField = "id_articulo"
        DropDownList1.DataTextField = "NombreStock"
        DropDownList1.DataSource = query
        DropDownList1.DataBind()
        DropDownList1.Items.Insert(0, New ListItem("Seleccione...", ""))
    End Sub

End Class
