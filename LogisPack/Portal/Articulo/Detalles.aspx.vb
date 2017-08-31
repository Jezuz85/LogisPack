Imports CapaDatos

Public Class Detalles
    Inherits Page

    Dim contexto As LogisPackEntities = New LogisPackEntities()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Dim IdArticulo = Cifrar.descifrarCadena_Num(Request.QueryString("id"))

        Dim _Articulo As List(Of Articulo) = Getter.Articulo_list(IdArticulo)

        For Each itemArticulos In _Articulo

#Region "articulo"
            lbTipoArticulo.Text = itemArticulos.tipoArticulo
            lbAlmacen.Text = itemArticulos.Almacen.nombre
            lbCodigo.Text = itemArticulos.codigo
            lbNombre.Text = itemArticulos.nombre
            lbRefPick.Text = itemArticulos.referencia_picking
            lbRef1.Text = itemArticulos.referencia1
            lbRef2.Text = itemArticulos.referencia2
            lbRef3.Text = itemArticulos.referencia3
            lbTipoUnidad.Text = itemArticulos.Tipo_Unidad.nombre
            lbPeso.Text = itemArticulos.peso
            lbAlto.Text = itemArticulos.alto
            lbLargo.Text = itemArticulos.largo
            lbAncho.Text = itemArticulos.ancho
            lbCoefVol.Text = itemArticulos.coeficiente_volumetrico
            lbCubicaje.Text = itemArticulos.cubicaje
            txtPesoVol.Text = itemArticulos.peso_volumen
            lbTipoFacturacion.Text = itemArticulos.Tipo_Facturacion.nombre
            lbIdentificacion.Text = itemArticulos.identificacion
            lbValArticulo.Text = itemArticulos.valor_articulo
            lbValSotck.Text = itemArticulos.valoracion_stock
            txtValSeguro.Text = itemArticulos.valoracion_seguro
            txtObsGen.Text = itemArticulos.observaciones_generales
            txtObsArt.Text = itemArticulos.observaciones_articulo
            lbStockMinimo.Text = itemArticulos.stock_minimo
            lbStockFisico.Text = itemArticulos.stock_fisico
#End Region

#Region "lista articulos picking"

            If itemArticulos.tipoArticulo = "Picking" Then
                phListaArticulos.Visible = True

                ControlesDinamicos.CrearLiteral("<ul class='list-group'>", pArticulos)
                For Each itemPickArticulos In itemArticulos.Picking_Articulo1

                    Dim _ArticuloPick = contexto.Articulo.Where(Function(model) model.id_articulo = itemPickArticulos.id_articulo).SingleOrDefault()
                    ControlesDinamicos.CrearLiteral("<li class='list-group-item'>" & _ArticuloPick.nombre & "</li>", pArticulos)
                Next
                ControlesDinamicos.CrearLiteral("</ul>", pArticulos)

            End If
#End Region

#Region "imagenes"
            ControlesDinamicos.CrearLiteral("
                <div id='ImagenesArticulo' class='carousel slide' data-ride='carousel'>
                    <div class='carousel-inner'>", pImagenes)
            Dim contadorImagenes As Integer = 0

            For Each itemImagen In itemArticulos.Imagen

                If contadorImagenes = 0 Then

                    ControlesDinamicos.CrearLiteral("<div class='item active'>", pImagenes)
                Else

                    ControlesDinamicos.CrearLiteral("<div class='item'>", pImagenes)
                End If


                ControlesDinamicos.CrearLiteral("<img src='" & itemImagen.url_imagen & "' style='width:100%;'>", pImagenes)
                ControlesDinamicos.CrearLiteral("</div>", pImagenes)

                contadorImagenes += 1
            Next

            ControlesDinamicos.CrearLiteral("</div>
                <a class='left carousel-control' href='#ImagenesArticulo' data-slide='prev'>
                    <span class='glyphicon glyphicon-chevron-left'></span>
                    <span class='sr-only'>Previous</span>
                </a>
                <a class='right carousel-control' href='#ImagenesArticulo' data-slide='next'>
                    <span class='glyphicon glyphicon-chevron-right'>
                    </span><span class='sr-only'>Next</span>
                </a>
            </div>", pImagenes)
#End Region

        Next

    End Sub

End Class