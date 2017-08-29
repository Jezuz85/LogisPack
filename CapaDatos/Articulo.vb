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
    Public Property valor_articulo As Double
    Public Property valoracion_stock As Double
    Public Property valoracion_seguro As Double
    Public Property peso As Double
    Public Property alto As Double
    Public Property largo As Double
    Public Property ancho As Double
    Public Property coeficiente_volumetrico As Double
    Public Property cubicaje As Double
    Public Property peso_volumen As Double
    Public Property observaciones_articulo As String
    Public Property observaciones_generales As String
    Public Property stock_fisico As Double
    Public Property stock_minimo As Double
    Public Property id_almacen As Integer
    Public Property id_tipo_facturacion As Integer
    Public Property id_tipo_unidad As Integer
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
