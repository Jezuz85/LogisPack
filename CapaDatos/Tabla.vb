﻿Imports System.Web.UI.WebControls

Public Class Tabla

    Public Shared Sub Almacen(ByRef GridView1 As GridView)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Almacen
                     Select
                         AL.id_almacen,
                         AL.nombre,
                         AL.id_cliente,
                         AL.coeficiente_volumetrico
                    ).ToList()

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    Public Shared Sub Articulo(ByRef GridView1 As GridView)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Articulo
                     Select
                         AL.id_articulo,
                         AL.nombre
                    ).ToList()

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    Public Shared Sub Cliente(ByRef GridView1 As GridView)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Cliente
                     Select
                         AL.id_cliente,
                         AL.codigo,
                         AL.nombre
                    ).ToList()

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    Public Shared Sub TipoFacturacion(ByRef GridView1 As GridView)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Tipo_Facturacion
                     Select
                         AL.id_tipo_facturacion,
                         AL.nombre
                    ).ToList()

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    Public Shared Sub TipoUnidad(ByRef GridView1 As GridView)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Tipo_Unidad
                     Select
                         AL.id_tipo_unidad,
                         AL.nombre
                    ).ToList()

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub

    Public Shared Sub Imagen(ByRef GridView1 As GridView, id As Integer)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Dim query = (From AL In contexto.Imagen
                     Where AL.id_articulo = id
                     Select
                         AL.id_imagen,
                         AL.nombre,
                         AL.url_imagen
                    ).ToList()

        GridView1.DataSource = query
        GridView1.DataBind()
    End Sub
End Class
