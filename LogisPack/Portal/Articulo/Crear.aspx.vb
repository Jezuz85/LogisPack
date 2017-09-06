Imports System.Globalization
Imports CapaDatos

Public Class Crear
    Inherits Page

    Dim contexto As LogisPackEntities = New LogisPackEntities()
    Dim ContFilas As Integer = 0
    Dim bError As Boolean
    Dim miTextbox As TextBox
    Dim miDropDownList As DropDownList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Page.Form.Attributes.Add("enctype", "multipart/form-data")


        If Not IsPostBack Then
            ViewState("contadorUbi") = "0"
            CargarListas()
        Else
            ObtenerControl_Postback(Me)

            For Each ctlID In Page.Request.Form.AllKeys
                If ctlID IsNot Nothing Then

                    Dim c As Control = Page.FindControl(ctlID)

                    If c IsNot Nothing Then
                        If c.GetType() Is GetType(Button) Then

                            If c.ClientID.Contains("btnAddFilaUbicacion") Then
                                crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi") + 1))
                            ElseIf c.ClientID.Contains("btnEliminarFila") Then
                                crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi") - 1))
                            Else
                                crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi")))
                            End If

                        End If
                    End If

                End If
            Next

        End If

    End Sub

    Private Sub ObtenerControl_Postback(page As Page)

        Dim ctrl As Control = Utilidades_UpdatePanel.ObtenerControl_PostBack(page)

        If ctrl IsNot Nothing Then
            If ctrl.ClientID.Contains("ddlTipoArticulo") Or ctrl.ClientID.Contains("ddlCliente") Or ctrl.ClientID.Contains("ddlAlmacen") Then
                crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi")))
            End If
        End If

    End Sub

    Public Sub CargarListas()
        Listas.TipoFacturacion(ddlTipoFacturacion)
        Listas.TipoUnidad(ddlTipoUnidad)
        Listas.Cliente(ddlCliente)
    End Sub

    Public Sub CargarCoefVol(idAlmacen As Integer)
        Dim _Almacen = Getter.Almacen(idAlmacen)
        txtCoefVol.Text = _Almacen.coeficiente_volumetrico
    End Sub

    Public Sub crearCamposListaUbicacion(valor As Integer)

        If valor < 0 Then
            ContFilas = 0
        Else
            ContFilas = valor
        End If

        For i As Integer = 1 To ContFilas

            ControlesDinamicos.CrearLiteral("<tr><td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtZona" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtEstante" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtFila" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtColumna" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtPanel" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtRefUbi" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearLiteral("</td></tr>", pTabla)


        Next

        ViewState("contadorUbi") = Convert.ToString(ContFilas)

    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Page.IsValid Then

            Dim contadorControl As Integer = 0
            Dim zona As String = Nothing
            Dim estante As String = Nothing
            Dim fila As String = Nothing
            Dim columna As String = Nothing
            Dim panel As String = Nothing
            Dim referencia_ubicacion As String = Nothing
            Dim _NuevoUbicaion As Ubicacion
            'Dim unidadesSolicitadas As Integer = 0
            'Dim unidadesDisponibles As Integer = 0
            Dim M3 As Double = Nothing
            Dim PesoVol As Double = Nothing


            Dim Stock_Picking As Integer = If(txtStockFisico.Text = String.Empty, 0, Convert.ToInt32(txtStockFisico.Text))

#Region "Guardar Articulo nuevo"

            If (txtAlto.Text IsNot String.Empty And txtAncho.Text IsNot String.Empty And txtLargo.Text IsNot String.Empty) Then
                M3 = ((Convert.ToDouble(txtAlto.Text) * Convert.ToDouble(txtAncho.Text) * Convert.ToDouble(txtLargo.Text)) / 1000)
            End If

            If (txtAlto.Text IsNot String.Empty And txtAncho.Text IsNot String.Empty And txtLargo.Text IsNot String.Empty And txtCoefVol.Text IsNot String.Empty) Then
                PesoVol = ((Convert.ToDouble(txtAlto.Text) * Convert.ToDouble(txtAncho.Text) * Convert.ToDouble(txtLargo.Text) * Convert.ToDouble(txtCoefVol.Text)) / 1000)
            End If


            Dim valoracionStock As Decimal
            If (txtValAsegurado.Text <> String.Empty And txtStockFisico.Text <> String.Empty) Then
                valoracionStock = Double.Parse(txtValArticulo.Text, CultureInfo.InvariantCulture) * Double.Parse(txtStockFisico.Text, CultureInfo.InvariantCulture)
            Else
                valoracionStock = Nothing
            End If

            Dim valoracionSeguro As Decimal
            If (txtValAsegurado.Text <> String.Empty And txtStockFisico.Text <> String.Empty) Then
                valoracionSeguro = Double.Parse(txtValAsegurado.Text, CultureInfo.InvariantCulture) * Double.Parse(txtStockFisico.Text, CultureInfo.InvariantCulture)
            Else
                valoracionSeguro = Nothing
            End If


            Dim _Nuevo As New Articulo With
            {
            .codigo = If(txtCodigo.Text = String.Empty, String.Empty, txtCodigo.Text),
            .nombre = If(txtNombre.Text = String.Empty, String.Empty, txtNombre.Text),
            .referencia_picking = If(txtRefPick.Text = String.Empty, String.Empty, txtRefPick.Text),
            .referencia1 = If(txtRef1.Text = String.Empty, String.Empty, txtRef1.Text),
            .referencia2 = If(txtRef2.Text = String.Empty, String.Empty, txtRef2.Text),
            .referencia3 = If(txtRef3.Text = String.Empty, String.Empty, txtRef3.Text),
            .identificacion = If(ddlIdentificacion.SelectedValue = String.Empty, String.Empty, ddlIdentificacion.SelectedValue),
            .valor_articulo = If(txtValArticulo.Text = String.Empty, Nothing, Double.Parse(txtValArticulo.Text, CultureInfo.InvariantCulture)),
            .valor_asegurado = If(txtValAsegurado.Text = String.Empty, Nothing, Double.Parse(txtValAsegurado.Text, CultureInfo.InvariantCulture)),
            .valoracion_stock = valoracionStock,
            .valoracion_seguro = valoracionSeguro,
            .peso = If(txtPeso.Text = String.Empty, Nothing, Double.Parse(txtPeso.Text, CultureInfo.InvariantCulture)),
            .alto = If(txtAlto.Text = String.Empty, Nothing, Double.Parse(txtAlto.Text, CultureInfo.InvariantCulture)),
            .largo = If(txtLargo.Text = String.Empty, Nothing, Double.Parse(txtLargo.Text, CultureInfo.InvariantCulture)),
            .ancho = If(txtAncho.Text = String.Empty, Nothing, Double.Parse(txtAncho.Text, CultureInfo.InvariantCulture)),
            .coeficiente_volumetrico = If(txtCoefVol.Text = String.Empty, Nothing, Double.Parse(txtCoefVol.Text, CultureInfo.InvariantCulture)),
            .cubicaje = M3,
            .peso_volumen = PesoVol,
            .observaciones_articulo = If(txtObsArt.Text = String.Empty, Nothing, txtObsArt.Text),
            .observaciones_generales = If(txtObsGen.Text = String.Empty, Nothing, txtObsGen.Text),
            .stock_fisico = If(txtStockFisico.Text = String.Empty, Nothing, Double.Parse(txtStockFisico.Text, CultureInfo.InvariantCulture)),
            .stock_minimo = If(txtStockMinimo.Text = String.Empty, Nothing, Double.Parse(txtStockMinimo.Text, CultureInfo.InvariantCulture)),
            .id_almacen = If(ddlAlmacen.SelectedValue = String.Empty, Nothing, Convert.ToInt32(ddlAlmacen.SelectedValue)),
            .id_tipo_facturacion = If(ddlTipoFacturacion.SelectedValue = String.Empty, 0, Convert.ToInt32(ddlTipoFacturacion.SelectedValue)),
            .id_tipo_unidad = If(ddlTipoUnidad.SelectedValue = String.Empty, 0, Convert.ToInt32(ddlTipoUnidad.SelectedValue)),
            .tipoArticulo = If(ddlTipoArticulo.SelectedValue = String.Empty, Nothing, ddlTipoArticulo.SelectedValue)
        }
            bError = Create.Articulo(_Nuevo)
#End Region

            If bError Then

                Dim articuloView = Getter.Articulo_Ultimo()

#Region "Guardar imagenes"
                For Each _imagen In fuImagenes.PostedFiles

                    contadorControl += 1

                    If _imagen.ContentLength > 0 And _imagen IsNot Nothing Then

                        Dim urlImagen As String = Utilidades_Fileupload.Subir_Archivos(_imagen, "../../Archivos/Articulos/", "Img_" & articuloView.id_articulo & "_" & contadorControl)

                        Dim _imagenes As New Imagen With
                            {
                            .nombre = "Imagen_" & contadorControl,
                            .id_articulo = articuloView.id_articulo,
                            .url_imagen = urlImagen
                        }
                        Create.Imagen(_imagenes)
                    End If

                Next
#End Region

#Region "Guardar ubicaciones"
                contadorControl = 0

                For Each micontrol As Control In pTabla.Controls

                    miTextbox = CType(pTabla.FindControl("txtZona" & contadorControl), TextBox)
                    If miTextbox IsNot Nothing Then
                        zona = If(miTextbox.Text = String.Empty, "", miTextbox.Text)
                    End If

                    miTextbox = CType(pTabla.FindControl("txtEstante" & contadorControl), TextBox)
                    If miTextbox IsNot Nothing Then
                        estante = If(miTextbox.Text = String.Empty, "", miTextbox.Text)
                    End If

                    miTextbox = CType(pTabla.FindControl("txtFila" & contadorControl), TextBox)
                    If miTextbox IsNot Nothing Then
                        fila = If(miTextbox.Text = String.Empty, "", miTextbox.Text)
                    End If

                    miTextbox = CType(pTabla.FindControl("txtColumna" & contadorControl), TextBox)
                    If miTextbox IsNot Nothing Then
                        Dim valor As String = miTextbox.Text.PadLeft(4, "0")
                        columna = If(miTextbox.Text = String.Empty, "", miTextbox.Text.PadLeft(4, "0"))
                    End If

                    miTextbox = CType(pTabla.FindControl("txtPanel" & contadorControl), TextBox)
                    If miTextbox IsNot Nothing Then
                        panel = If(miTextbox.Text = String.Empty, "", miTextbox.Text)
                    End If

                    miTextbox = CType(pTabla.FindControl("txtRefUbi" & contadorControl), TextBox)
                    If miTextbox IsNot Nothing Then
                        referencia_ubicacion = If(miTextbox.Text = String.Empty, "", miTextbox.Text)
                    End If

                    If referencia_ubicacion IsNot Nothing Then

                        If (zona <> String.Empty) Or
                            (estante <> String.Empty) Or
                            (columna <> String.Empty) Or
                            (panel <> String.Empty) Or
                            (referencia_ubicacion <> String.Empty) Then

                            _NuevoUbicaion = New Ubicacion With {
                                .zona = zona,
                                .estante = estante,
                                .fila = fila,
                                .columna = columna,
                                .panel = panel,
                                .referencia_ubicacion = referencia_ubicacion,
                                .id_articulo = articuloView.id_articulo
                            }

                            Create.Ubicacion(_NuevoUbicaion)
                            referencia_ubicacion = Nothing

                        End If
                    End If

                    contadorControl += 1
                Next
#End Region

#Region "Guardar picking"
                If ddlTipoArticulo.SelectedValue = "Picking" Then

                    contadorControl = 0

                    Dim lineaArt As String() = txtArticulos2.Text.Split("" & vbLf & "")

                    For i As Integer = 1 To (lineaArt.Length - 1)

                        Dim lineas As String() = lineaArt(i - 1).Split(New Char() {"-"c})
                        Dim itemArt As Integer = Convert.ToInt32(lineas(0))
                        Dim itemUni As Double = Double.Parse(lineas(1), CultureInfo.InvariantCulture)

                        Dim Listarticulo = contexto.Articulo.Where(Function(model) model.id_articulo = itemArt).SingleOrDefault()

                        'unidadesSolicitadas = (Stock_Picking * itemUni)
                        ' unidadesDisponibles = (Listarticulo.stock_fisico)

                        Dim _NuevoPic_Art As New Picking_Articulo With {
                            .unidades = itemUni,
                            .id_articulo = itemArt,
                            .id_picking = articuloView.id_articulo
                        }
                        bError = Create.Picking_Articulo(_NuevoPic_Art)

                        'If bError Then

                        '    Dim Edit As Articulo = contexto.Articulo.SingleOrDefault(Function(b) b.id_articulo = Listarticulo.id_articulo)

                        '    If Edit IsNot Nothing Then
                        '        Edit.stock_fisico = (Edit.stock_fisico - unidadesSolicitadas)
                        '    End If

                        '    Try
                        '        contexto.SaveChanges()
                        '    Catch ex As Exception

                        '    End Try

                        'End If

                    Next
                End If
#End Region

            End If

            Modal.Validacion(Me, bError, "Add")

            If bError Then
                If ddlTipoArticulo.SelectedValue = "Picking" Then

                    Utilidades_UpdatePanel.LimpiarControles(upAdd_Articulo)
                    Listas.Articulo(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))
                    phListaArticulos.Visible = False
                    txtUnidad.Text = Nothing
                    txtArticulos1.Text = Nothing
                End If
                ddlAlmacen.SelectedValue = ""
                ddlCliente.SelectedValue = ""
            End If

        End If
    End Sub

    Protected Sub CambiarCliente(sender As Object, e As EventArgs) Handles ddlCliente.SelectedIndexChanged

        If ddlCliente.SelectedValue = "" Then
            txtCoefVol.Text = String.Empty
            ddlAlmacen.SelectedValue = ""
        Else
            Listas.Almacen(ddlAlmacen, Convert.ToInt32(ddlCliente.SelectedValue))
        End If

    End Sub

    Protected Sub Añadir_ArticuloLista(sender As Object, e As EventArgs) Handles btnAddArticuloRow.Click

        If Page.IsValid Then
            Dim unidadesSolicitadas As Double = Double.Parse(txtUnidad.Text, CultureInfo.InvariantCulture)
            Dim _IdArticulo As Integer = Convert.ToInt32(ddlListaArticulos.SelectedValue)
            Dim Listarticulo = contexto.Articulo.Where(Function(model) model.id_articulo = _IdArticulo).SingleOrDefault()

            Dim textoArt1 = txtArticulos1.Text
            Dim textoArt2 = txtArticulos2.Text

            Dim textArea1 As New StringBuilder
            textArea1.AppendLine("Articulo: " & ddlListaArticulos.SelectedItem.Text + " Unidades=" + txtUnidad.Text)
            txtArticulos1.Text = textoArt1 & textArea1.ToString()


            Dim textArea2 As New StringBuilder
            textArea2.AppendLine(ddlListaArticulos.SelectedValue + "-" + txtUnidad.Text)
            txtArticulos2.Text = textoArt2 & textArea2.ToString()


            ddlListaArticulos.Items.Remove(ddlListaArticulos.Items.FindByValue(ddlListaArticulos.SelectedValue))

            If ddlListaArticulos.Items.Count = 0 Then
                btnAddArticuloRow.Visible = False
            End If

        End If

    End Sub

    Protected Sub SetCoefVolumétrico(sender As Object, e As EventArgs) Handles ddlAlmacen.SelectedIndexChanged

        If ddlAlmacen.SelectedValue = "" Then
            txtCoefVol.Text = String.Empty
            phListaArticulos.Visible = False
        Else
            CargarCoefVol(Convert.ToInt32(ddlAlmacen.SelectedValue))
            Listas.Articulo(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))
            phListaArticulos.Visible = True
        End If

    End Sub

    Protected Sub Reset_ArticuloLista(sender As Object, e As EventArgs) Handles btnReset.Click

        btnAddArticuloRow.Visible = True
        Listas.Articulo(ddlListaArticulos, Convert.ToInt32(ddlAlmacen.SelectedValue))
        txtArticulos1.Text = String.Empty
        txtArticulos2.Text = String.Empty

    End Sub
End Class