
Public Class Delete

    Public Shared Function Almacen(ByVal _nuevo As Almacen, ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            Dim Eliminar As New Almacen With {
                .id_almacen = _id
            }
            contexto.Almacen.Attach(Eliminar)
            contexto.Almacen.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    Public Shared Function TipoFacturacion(ByVal _nuevo As Tipo_Facturacion, ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            Dim Eliminar As New Tipo_Facturacion With {
                .id_tipo_facturacion = _id
            }
            contexto.Tipo_Facturacion.Attach(Eliminar)
            contexto.Tipo_Facturacion.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    Public Shared Function TipoUnidad(ByVal _nuevo As Tipo_Unidad, ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            Dim Eliminar As New Tipo_Unidad With {
                .id_tipo_unidad = _id
            }
            contexto.Tipo_Unidad.Attach(Eliminar)
            contexto.Tipo_Unidad.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function

    Public Shared Function Articulo(ByVal _nuevo As Articulo, ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Dim bError As Boolean = True

        Try
            Dim Eliminar As New Articulo With {
                .id_articulo = _id
            }
            contexto.Articulo.Attach(Eliminar)
            contexto.Articulo.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            bError = False
        End Try

        Return bError

    End Function
End Class
