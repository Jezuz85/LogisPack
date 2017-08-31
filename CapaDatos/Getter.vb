
Public Class Getter

    Public Shared Function Tipo_Facturacion(id As Integer) As Tipo_Facturacion

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Facturacion.Where(Function(model) model.id_tipo_facturacion = id).SingleOrDefault()

    End Function
    Public Shared Function Tipo_Facturacion(id As Integer, ByRef contexto As LogisPackEntities) As Tipo_Facturacion

        Return contexto.Tipo_Facturacion.Where(Function(model) model.id_tipo_facturacion = id).SingleOrDefault()

    End Function

    Public Shared Function Almacen(id As Integer) As Almacen

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Almacen.Where(Function(model) model.id_almacen = id).SingleOrDefault()

    End Function
    Public Shared Function Almacen(id As Integer, ByRef contexto As LogisPackEntities) As Almacen
        Return contexto.Almacen.Where(Function(model) model.id_almacen = id).SingleOrDefault()

    End Function


    Public Shared Function Articulo_Ultimo() As Articulo

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Articulo.ToList().LastOrDefault()

    End Function
    Public Shared Function Articulo_list(id As Integer) As List(Of Articulo)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Articulo.Where(Function(model) model.id_articulo = id).ToList()

    End Function
    Public Shared Function Articulo(id As Integer) As Articulo

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Articulo.Where(Function(model) model.id_articulo = id).SingleOrDefault()

    End Function

End Class
