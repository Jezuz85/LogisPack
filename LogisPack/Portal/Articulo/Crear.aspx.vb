Imports System.Drawing
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

    Public Sub crearCamposListaUbicacion(valor As Integer)

        If valor < 0 Then
            ContFilas = 0
        Else
            ContFilas = valor
        End If

        For i As Integer = 1 To ContFilas

            ControlesDinamicos.CrearLiteral("<tr><td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtZona" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearRequiredFieldValidator("txtZona" & i, pTabla, "ValidationAdd")
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtEstante" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearRequiredFieldValidator("txtEstante" & i, pTabla, "ValidationAdd")
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtFila" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearRequiredFieldValidator("txtFila" & i, pTabla, "ValidationAdd")
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtColumna" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearRequiredFieldValidator("txtColumna" & i, pTabla, "ValidationAdd")
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtPanel" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearRequiredFieldValidator("txtPanel" & i, pTabla, "ValidationAdd")
            ControlesDinamicos.CrearLiteral("</td>", pTabla)


            ControlesDinamicos.CrearLiteral("<td>", pTabla)
            ControlesDinamicos.CrearTextbox("txtRefUbi" & i, pTabla, TextBoxMode.SingleLine)
            ControlesDinamicos.CrearRequiredFieldValidator("txtRefUbi" & i, pTabla, "ValidationAdd")
            ControlesDinamicos.CrearLiteral("</td></tr>", pTabla)


        Next

        ViewState("contadorUbi") = Convert.ToString(ContFilas)

    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Page.IsValid Then

            Dim Stock_Picking As Integer = Convert.ToInt32(txtStockFisico.Text)
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

#Region "Guardar Articulo nuevo"
            Dim _Nuevo As New Articulo With
                {
                .codigo = txtCodigo.Text,
                .nombre = txtNombre.Text,
                .referencia_picking = txtRefPick.Text,
                .referencia1 = txtRef1.Text,
                .referencia2 = txtRef2.Text,
                .referencia3 = txtRef3.Text,
                .identificacion = ddlIdentificacion.SelectedValue,
                .valor_articulo = txtValArticulo.Text,
                .valoracion_stock = txtValSotck.Text,
                .valoracion_seguro = txtValSeguro.Text,
                .peso = txtPeso.Text,
                .alto = txtAlto.Text,
                .largo = txtLargo.Text,
                .ancho = txtAncho.Text,
                .coeficiente_volumetrico = txtCoefVol.Text,
                .cubicaje = txtCubicaje.Text,
                .peso_volumen = txtPesoVol.Text,
                .observaciones_articulo = txtObsArt.Text,
                .observaciones_generales = txtObsGen.Text,
                .stock_fisico = txtStockFisico.Text,
                .stock_minimo = txtStockMinimo.Text,
                .id_almacen = Convert.ToInt32(ddlAlmacen.SelectedValue),
                .id_tipo_facturacion = Convert.ToInt32(ddlTipoFacturacion.SelectedValue),
                .id_tipo_unidad = Convert.ToInt32(ddlTipoUnidad.SelectedValue),
                .tipoArticulo = ddlTipoArticulo.SelectedValue
            }
            bError = Create.Articulo(_Nuevo)
#End Region

            If bError Then

                Dim articuloView = contexto.Articulo.ToList().LastOrDefault()

#Region "Guardar imagenes"
                For Each _imagen In fuImagenes.PostedFiles

                    contadorControl += 1

                    If _imagen.ContentLength > 0 And _imagen IsNot Nothing Then

                        Dim fileExtension As String = "." + _imagen.FileName.Substring(_imagen.FileName.LastIndexOf(".") + 1).ToLower()
                        Dim rutaImagen As String = Server.MapPath("~/Archivos/Articulos/") & "Img_" & articuloView.id_articulo & "_" & contadorControl & fileExtension

                        _imagen.SaveAs(rutaImagen)


                        Dim _imagenes As New Imagen With
                            {
                            .nombre = "Imagen_" & contadorControl,
                            .id_articulo = articuloView.id_articulo,
                            .url_imagen = "/Archivos/Articulos/Img_" & articuloView.id_articulo & "_" & contadorControl & fileExtension
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
                        zona = miTextbox.Text
                    End If

                    miTextbox = CType(pTabla.FindControl("txtEstante" & contadorControl), TextBox)
                    If miTextbox IsNot Nothing Then
                        estante = miTextbox.Text
                    End If

                    miTextbox = CType(pTabla.FindControl("txtFila" & contadorControl), TextBox)
                    If miTextbox IsNot Nothing Then
                        fila = miTextbox.Text
                    End If

                    miTextbox = CType(pTabla.FindControl("txtColumna" & contadorControl), TextBox)
                    If miTextbox IsNot Nothing Then
                        columna = miTextbox.Text
                    End If

                    miTextbox = CType(pTabla.FindControl("txtPanel" & contadorControl), TextBox)
                    If miTextbox IsNot Nothing Then
                        panel = miTextbox.Text
                    End If

                    miTextbox = CType(pTabla.FindControl("txtRefUbi" & contadorControl), TextBox)
                    If miTextbox IsNot Nothing Then
                        referencia_ubicacion = miTextbox.Text
                    End If

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



End Class