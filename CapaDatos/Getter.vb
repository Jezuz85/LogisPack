
Public Class Getter

    ''' <summary>
    ''' Metodo que recibe un id del Almacen y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Almacen si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Almacen(id As Integer) As Almacen

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Almacen.Where(Function(model) model.id_almacen = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Almacen y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Almacen a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Almacen si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Almacen(id As Integer, ByRef contexto As LogisPackEntities) As Almacen
        Return contexto.Almacen.Where(Function(model) model.id_almacen = id).SingleOrDefault()
    End Function

    ''' <summary>
    ''' Metodo que devuelve el ultimo Articulo registrado en la base de datos
    ''' </summary>
    Public Shared Function Articulo_Ultimo() As Articulo

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Articulo.ToList().LastOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, 
    ''' devuelve una lista de objetos de tipo Articulo si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Articulo_list(id As Integer) As List(Of Articulo)

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Articulo.Where(Function(model) model.id_articulo = id).ToList()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Articulo si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Articulo(id As Integer) As Articulo

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Articulo.Where(Function(model) model.id_articulo = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Articulo y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Articulo a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Articulo si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Articulo(id As Integer, ByRef contexto As LogisPackEntities) As Articulo
        Return contexto.Articulo.Where(Function(model) model.id_articulo = id).SingleOrDefault()
    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Cliente y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Cliente si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Cliente(id As Integer) As Cliente

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Cliente.Where(Function(model) model.id_cliente = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Cliente y lo consulta desde la Base de datos, recibe un objeto contexto
    ''' para devolver el Cliente a editar con su respectivo contexto usado
    ''' devuelve un objeto tipo Cliente si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Cliente(id As Integer, ByRef contexto As LogisPackEntities) As Cliente

        Return contexto.Cliente.Where(Function(model) model.id_cliente = id).SingleOrDefault()

    End Function

    ''' <summary>
    ''' Metodo que recibe un id del Tipo_Facturacion y lo consulta desde la Base de datos, 
    ''' devuelve un objeto tipo Tipo_Facturacion si fue exitoso, de lo contrario no devuelve nothing
    ''' </summary>
    Public Shared Function Tipo_Facturacion(id As Integer) As Tipo_Facturacion

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Facturacion.Where(Function(model) model.id_tipo_facturacion = id).SingleOrDefault()

    End Function
    Public Shared Function Tipo_Facturacion(id As Integer, ByRef contexto As LogisPackEntities) As Tipo_Facturacion

        Return contexto.Tipo_Facturacion.Where(Function(model) model.id_tipo_facturacion = id).SingleOrDefault()

    End Function

    Public Shared Function Tipo_Unidad(id As Integer) As Tipo_Unidad

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Return contexto.Tipo_Unidad.Where(Function(model) model.id_tipo_unidad = id).SingleOrDefault()

    End Function
    Public Shared Function Tipo_Unidad(id As Integer, ByRef contexto As LogisPackEntities) As Tipo_Unidad

        Return contexto.Tipo_Unidad.Where(Function(model) model.id_tipo_unidad = id).SingleOrDefault()

    End Function

    Public Shared Function Imagen_list(id As String) As List(Of Imagen)
        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Return contexto.Imagen.Where(Function(model) model.id_articulo = id).ToList()
    End Function

End Class
