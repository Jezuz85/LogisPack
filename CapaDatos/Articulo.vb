'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Articulo
    Public Property id_articulo As Integer
    Public Property codigo As String
    Public Property nombre As String
    Public Property referencia_picking As String
    Public Property referencia1 As String
    Public Property referencia2 As String
    Public Property referencia3 As String
    Public Property identificacion As String
    Public Property valor_articulo As Nullable(Of Double)
    Public Property valoracion_stock As Nullable(Of Double)
    Public Property valoracion_seguro As Nullable(Of Double)
    Public Property valor_asegurado As Nullable(Of Double)
    Public Property peso As Nullable(Of Double)
    Public Property alto As Nullable(Of Double)
    Public Property largo As Nullable(Of Double)
    Public Property ancho As Nullable(Of Double)
    Public Property coeficiente_volumetrico As Nullable(Of Double)
    Public Property cubicaje As Nullable(Of Double)
    Public Property peso_volumen As Nullable(Of Double)
    Public Property observaciones_articulo As String
    Public Property observaciones_generales As String
    Public Property stock_fisico As Nullable(Of Double)
    Public Property stock_minimo As Nullable(Of Double)
    Public Property id_almacen As Nullable(Of Integer)
    Public Property id_tipo_facturacion As Nullable(Of Integer)
    Public Property id_tipo_unidad As Nullable(Of Integer)
    Public Property tipoArticulo As String

    Public Overridable Property Almacen As Almacen
    Public Overridable Property Tipo_Facturacion As Tipo_Facturacion
    Public Overridable Property Tipo_Unidad As Tipo_Unidad
    Public Overridable Property Historico As ICollection(Of Historico) = New HashSet(Of Historico)
    Public Overridable Property Imagen As ICollection(Of Imagen) = New HashSet(Of Imagen)
    Public Overridable Property Picking_Articulo As ICollection(Of Picking_Articulo) = New HashSet(Of Picking_Articulo)
    Public Overridable Property Ubicacion As ICollection(Of Ubicacion) = New HashSet(Of Ubicacion)
    Public Overridable Property Picking_Articulo1 As ICollection(Of Picking_Articulo) = New HashSet(Of Picking_Articulo)

End Class
