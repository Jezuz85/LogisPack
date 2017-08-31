
Public Class Delete

    Public Shared Function Almacen(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Try
            Dim Eliminar As New Almacen With {
                .id_almacen = _id
            }
            contexto.Almacen.Attach(Eliminar)
            contexto.Almacen.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Public Shared Function TipoFacturacion(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Try
            Dim Eliminar As New Tipo_Facturacion With {
                .id_tipo_facturacion = _id
            }
            contexto.Tipo_Facturacion.Attach(Eliminar)
            contexto.Tipo_Facturacion.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Public Shared Function TipoUnidad(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()
        Try
            Dim Eliminar As New Tipo_Unidad With {
                .id_tipo_unidad = _id
            }
            contexto.Tipo_Unidad.Attach(Eliminar)
            contexto.Tipo_Unidad.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Public Shared Function Articulo(ByVal _id As Integer) As Boolean

        Dim contexto As LogisPackEntities = New LogisPackEntities()

        Try
            Dim Eliminar As New Articulo With {
                .id_articulo = _id
            }
            contexto.Articulo.Attach(Eliminar)
            contexto.Articulo.Remove(Eliminar)
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function
End Class
