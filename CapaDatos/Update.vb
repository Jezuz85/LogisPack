
Public Class Update

    Public Shared Function Almacen(_Edit As Almacen, ByRef contexto As LogisPackEntities) As Boolean

        Try
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Public Shared Function Cliente(_Edit As Cliente, ByRef contexto As LogisPackEntities) As Boolean

        Try
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Public Shared Function Tipo_Facturacion(_Edit As Tipo_Facturacion, ByRef contexto As LogisPackEntities) As Boolean

        Try
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Public Shared Function Tipo_Unidad(_Edit As Tipo_Unidad, ByRef contexto As LogisPackEntities) As Boolean

        Try
            contexto.SaveChanges()
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

End Class
