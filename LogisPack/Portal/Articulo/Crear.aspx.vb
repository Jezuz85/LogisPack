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

            CargarCoefVol(ddlAlmacen.SelectedValue)
        Else
            For Each ctlID In Page.Request.Form.AllKeys
                If ctlID IsNot Nothing Then

                    Dim c As Control = Page.FindControl(ctlID)

                    If c IsNot Nothing Then
                        If c.GetType() Is GetType(Button) Then

                            If c.ClientID.Contains("btnAddFilaUbicacion") Then
                                crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi") + 1))
                            End If

                            If c.ClientID.Contains("btnEliminarFila") Then
                                crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi") - 1))
                            End If

                            If c.ClientID.Contains("btnAddArticuloRow") Then
                                crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi")))
                            End If

                            If c.ClientID.Contains("btnDeleteArticuloRow") Then
                                crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi")))
                            End If

                            If c.ClientID.Contains("btnGuardar") Then
                                crearCamposListaUbicacion(Convert.ToInt32(ViewState("contadorUbi")))
                            End If

                        End If
                    End If

                End If
            Next
        End If

    End Sub

    Public Sub CargarListas()
        Listas.Almacen(ddlAlmacen)
        Listas.TipoFacturacion(ddlTipoFacturacion)
        Listas.TipoUnidad(ddlTipoUnidad)
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
            Dim unidadesSolicitadas As Integer = 0
            Dim unidadesDisponibles As Integer = 0
            Dim M3 As Double = 0
            Dim PesoVol As Double = 0


            Dim Stock_Picking As Integer = If(txtStockFisico.Text = String.Empty, 0, Convert.ToInt32(txtStockFisico.Text))

#Region "Guardar Articulo nuevo"

            If (txtAlto.Text IsNot String.Empty And txtAncho.Text IsNot String.Empty And txtLargo.Text IsNot String.Empty) Then
                M3 = ((Convert.ToDouble(txtAlto.Text) * Convert.ToDouble(txtAncho.Text) * Convert.ToDouble(txtLargo.Text)) / 1000)
            End If

            If (txtAlto.Text IsNot String.Empty And txtAncho.Text IsNot String.Empty And txtLargo.Text IsNot String.Empty And txtCoefVol.Text IsNot String.Empty) Then
                PesoVol = ((Convert.ToDouble(txtAlto.Text) * Convert.ToDouble(txtAncho.Text) * Convert.ToDouble(txtLargo.Text) * Convert.ToDouble(txtCoefVol.Text)) / 1000)
            End If

            Dim _Nuevo As New Articulo With
                {
                .codigo = If(txtCodigo.Text = String.Empty, "", txtCodigo.Text),
                .nombre = If(txtNombre.Text = String.Empty, "", txtNombre.Text),
                .referencia_picking = If(txtRefPick.Text = String.Empty, "", txtRefPick.Text),
                .referencia1 = If(txtRef1.Text = String.Empty, "", txtRef1.Text),
                .referencia2 = If(txtRef2.Text = String.Empty, "", txtRef2.Text),
                .referencia3 = If(txtRef3.Text = String.Empty, "", txtRef3.Text),
                .identificacion = If(ddlIdentificacion.SelectedValue = String.Empty, "", ddlIdentificacion.SelectedValue),
                .valor_articulo = If(txtValArticulo.Text = String.Empty, "", Convert.ToDouble(txtValArticulo.Text)),
                .valor_asegurado = If(txtValAsegurado.Text = String.Empty, "", Convert.ToDouble(txtValAsegurado.Text)),
                .valoracion_stock = If((txtValArticulo.Text = String.Empty And txtStockFisico.Text = String.Empty), "", (Convert.ToDouble(txtValArticulo.Text) * Convert.ToDouble(txtStockFisico.Text))),
                .valoracion_seguro = If((txtValAsegurado.Text = String.Empty And txtStockFisico.Text = String.Empty), "", (Convert.ToDouble(txtValAsegurado.Text) * Convert.ToDouble(txtStockFisico.Text))),
                .peso = If(txtPeso.Text = String.Empty, "", Convert.ToDouble(txtPeso.Text)),
                .alto = If(txtAlto.Text = String.Empty, "", Convert.ToDouble(txtAlto.Text)),
                .largo = If(txtLargo.Text = String.Empty, "", Convert.ToDouble(txtLargo.Text)),
                .ancho = If(txtAncho.Text = String.Empty, "", Convert.ToDouble(txtAncho.Text)),
                .coeficiente_volumetrico = If(txtCoefVol.Text = String.Empty, "", Convert.ToDouble(txtCoefVol.Text)),
                .cubicaje = M3,
                .peso_volumen = PesoVol,
                .observaciones_articulo = If(txtObsArt.Text = String.Empty, "", txtObsArt.Text),
                .observaciones_generales = If(txtObsGen.Text = String.Empty, "", txtObsGen.Text),
                .stock_fisico = If(txtStockFisico.Text = String.Empty, "", txtStockFisico.Text),
                .stock_minimo = If(txtStockMinimo.Text = String.Empty, "", txtStockMinimo.Text),
                .id_almacen = If(ddlAlmacen.SelectedValue = String.Empty, 0, Convert.ToInt32(ddlAlmacen.SelectedValue)),
                .id_tipo_facturacion = If(ddlTipoFacturacion.SelectedValue = String.Empty, 0, Convert.ToInt32(ddlTipoFacturacion.SelectedValue)),
                .id_tipo_unidad = If(ddlTipoUnidad.SelectedValue = String.Empty, 0, Convert.ToInt32(ddlTipoUnidad.SelectedValue)),
                .tipoArticulo = If(ddlTipoArticulo.SelectedValue = String.Empty, "", ddlTipoArticulo.SelectedValue)
            }

            bError = Create.Articulo(_Nuevo)
#End Region

            If bError Then

                Dim articuloView = Getter.Articulo_Ultimo()

#Region "Guardar imagenes"
                For Each _imagen In fuImagenes.PostedFiles

                    contadorControl += 1

                    If _imagen.ContentLength > 0 And _imagen IsNot Nothing Then

                        Dim urlImagen As String = Utilidades_Fileupload.Subir_Archivos(_imagen, "~/Archivos/Articulos/", "Img_" & articuloView.id_articulo & "_" & contadorControl)

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
                    zona = If((miTextbox IsNot Nothing And miTextbox.Text IsNot String.Empty), miTextbox.Text, "")

                    miTextbox = CType(pTabla.FindControl("txtEstante" & contadorControl), TextBox)
                    estante = If(miTextbox IsNot Nothing And miTextbox.Text IsNot String.Empty, miTextbox.Text, "")

                    miTextbox = CType(pTabla.FindControl("txtFila" & contadorControl), TextBox)
                    fila = If(miTextbox IsNot Nothing And miTextbox.Text IsNot String.Empty, miTextbox.Text, "")

                    miTextbox = CType(pTabla.FindControl("txtColumna" & contadorControl), TextBox)
                    columna = If(miTextbox IsNot Nothing And miTextbox.Text IsNot String.Empty, miTextbox.Text.PadLeft(4, "0"), "")

                    miTextbox = CType(pTabla.FindControl("txtPanel" & contadorControl), TextBox)
                    panel = If(miTextbox IsNot Nothing And miTextbox.Text IsNot String.Empty, miTextbox.Text, "")

                    miTextbox = CType(pTabla.FindControl("txtRefUbi" & contadorControl), TextBox)
                    referencia_ubicacion = If(miTextbox IsNot Nothing And miTextbox.Text IsNot String.Empty, miTextbox.Text, "")

                    If referencia_ubicacion IsNot Nothing Then
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
                        Dim itemUni As Double = Convert.ToDouble(lineas(1))

                        Dim Listarticulo = contexto.Articulo.Where(Function(model) model.id_articulo = itemArt).SingleOrDefault()

                        unidadesSolicitadas = (Stock_Picking * itemUni)
                        unidadesDisponibles = (Listarticulo.stock_fisico)

                        Dim _NuevoPic_Art As New Picking_Articulo With {
                            .unidades = itemUni,
                            .id_articulo = itemArt,
                            .id_picking = articuloView.id_articulo
                        }
                        bError = Create.Picking_Articulo(_NuevoPic_Art)

                        If bError Then

                            Dim Edit As Articulo = contexto.Articulo.SingleOrDefault(Function(b) b.id_articulo = Listarticulo.id_articulo)

                            If Edit IsNot Nothing Then
                                Edit.stock_fisico = (Edit.stock_fisico - unidadesSolicitadas)
                            End If

                            Try
                                contexto.SaveChanges()
                            Catch ex As Exception

                            End Try

                        End If


                    Next
                End If
#End Region

            End If

            Modal.CerrarModal("addModal", "AddModalScript", Me)
            Modal.Validacion(Me, bError, "Add")

            If bError Then
                Utilidades_UpdatePanel.LimpiarControles(upAdd_Articulo)
            End If

        End If

    End Sub

    Protected Sub CambiarTipoArticulo(sender As Object, e As EventArgs) Handles ddlTipoArticulo.SelectedIndexChanged

        If ddlTipoArticulo.SelectedValue = "Picking" Then
            phListaArticulos.Visible = True
            Listas.Articulo(ddlListaArticulos)
        Else
            phListaArticulos.Visible = False
        End If

    End Sub

    Protected Sub Añadir_ArticuloLista(sender As Object, e As EventArgs) Handles btnAddArticuloRow.Click

        If Page.IsValid Then
            Dim Stock_Picking As Double = Convert.ToDouble(txtStockFisico.Text)
            Dim unidadesSolicitadas As Double = Convert.ToDouble(txtUnidad.Text)

            If ddlListaArticulos.Items.Count > 0 Then

                Dim _IdArticulo As Integer = Convert.ToInt32(ddlListaArticulos.SelectedValue)
                Dim Listarticulo = contexto.Articulo.Where(Function(model) model.id_articulo = _IdArticulo).SingleOrDefault()
                Dim unidadesDisponibles As Double = Convert.ToDouble(Listarticulo.stock_fisico)

                If unidadesDisponibles >= (unidadesSolicitadas * Stock_Picking) And unidadesSolicitadas > 0 Then

                    Dim textoArt1 = txtArticulos1.Text
                    Dim textoArt2 = txtArticulos2.Text

                    Dim textArea1 As New StringBuilder
                    textArea1.AppendLine("Articulo: " & ddlListaArticulos.SelectedItem.Text + " Unidades=" + txtUnidad.Text)
                    txtArticulos1.Text = textoArt1 & textArea1.ToString()


                    Dim textArea2 As New StringBuilder
                    textArea2.AppendLine(ddlListaArticulos.SelectedValue + "-" + txtUnidad.Text)
                    txtArticulos2.Text = textoArt2 & textArea2.ToString()


                    ddlListaArticulos.Items.Remove(ddlListaArticulos.Items.FindByValue(ddlListaArticulos.SelectedValue))

                Else
                    Modal.MostrarMsjModal("Las unidades del Articulo no Deben superar al stock actual y deben ser mayor a cero", "ERR", Me)
                End If

            End If
        End If

    End Sub

    Protected Sub SetCoefVolumétrico(sender As Object, e As EventArgs) Handles ddlAlmacen.SelectedIndexChanged
        CargarCoefVol(ddlAlmacen.SelectedValue)
    End Sub

End Class