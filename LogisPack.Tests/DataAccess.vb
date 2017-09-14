Imports CapaDatos

Public Class DataAccess

    Public Shared Sub Inicializar_Cliente(ByRef _Nuevo As Cliente)

        _Nuevo = New Cliente With {
            .codigo = "Codv1",
            .nombre = "Nombrev1"
        }
        Create.Cliente(_Nuevo)
    End Sub
    Public Shared Sub Finalizar_Cliente(ByRef _Nuevo As Cliente)
        Delete.Cliente(_Nuevo.id_cliente)
    End Sub

    Public Shared Sub Inicializar_Almacen(ByRef _Nuevo As Almacen, idCliente As Integer)

        _Nuevo = New Almacen With {
        .nombre = "Nombrev1",
        .codigo = "Codv1",
        .coeficiente_volumetrico = "10",
        .id_cliente = idCliente
        }
        Create.Almacen(_Nuevo)
    End Sub
    Public Shared Sub Finalizar_Almacen(ByRef _Nuevo As Almacen)
        Delete.Almacen(_Nuevo.id_almacen)
    End Sub

    Public Shared Sub Inicializar_TipoFacturacion(ByRef _Nuevo As Tipo_Facturacion)

        _Nuevo = New Tipo_Facturacion With {
            .nombre = "Nombrev1"
        }
        Create.TipoFacturacion(_Nuevo)
    End Sub
    Public Shared Sub Finalizar_TipoFacturacion(ByRef _Nuevo As Tipo_Facturacion)
        Delete.TipoFacturacion(_Nuevo.id_tipo_facturacion)
    End Sub

    Public Shared Sub Inicializar_TipoUnidad(ByRef _Nuevo As Tipo_Unidad)

        _Nuevo = New Tipo_Unidad With {
            .nombre = "Nombrev1"
        }
        Create.TipoUnidad(_Nuevo)
    End Sub
    Public Shared Sub Finalizar_TipoUnidad(ByRef _Nuevo As Tipo_Unidad)
        Delete.TipoUnidad(_Nuevo.id_tipo_unidad)
    End Sub

End Class
