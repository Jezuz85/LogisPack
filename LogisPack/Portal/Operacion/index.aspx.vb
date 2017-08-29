Imports CapaDatos

Public Class index4
    Inherits Page

    Dim contexto As LogisPackEntities = New LogisPackEntities()
    Dim bError As Boolean


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Form.Attributes.Add("enctype", "multipart/form-data")

        CargarListas()

    End Sub


    Public Sub CargarListas()

        Listas.ArticuloTodos(ddlListaArticulos)

    End Sub

    Protected Sub Guardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Page.IsValid Then

            Dim _IdArticulo As Integer = Convert.ToInt32(ddlListaArticulos.SelectedValue)
            Dim Listarticulo = contexto.Articulo.Where(Function(model) model.id_articulo = _IdArticulo).SingleOrDefault()

            Dim Stock_Picking As Double = Convert.ToDouble(Listarticulo.stock_fisico)
            Dim unidadesSolicitadas As Double = Convert.ToDouble(txtCantidad.Text)

            If (Stock_Picking > unidadesSolicitadas And ddlTipoOperacion.SelectedValue = "Sal") Or ddlTipoOperacion.SelectedValue = "Ent" Then

#Region "Guardar documento"

                If fuDocumento.FileName IsNot "" Then

                    Dim fileExtension As String = "." + fuDocumento.FileName.Substring(fuDocumento.FileName.LastIndexOf(".") + 1).ToLower()
                    Dim rutaImagen As String = Server.MapPath("~/Archivos/Operacion/") & "Doc_" & ddlTipoOperacion.SelectedValue & "_" & _IdArticulo & "_" & Convert.ToDateTime(txtFechaOperacion.Text).ToString("yyyy-MM-dd") & "_" & fileExtension
                    fuDocumento.SaveAs(rutaImagen)

#Region "Guardar operacion nuevo"
                    Dim _Nuevo As New Historico With
                    {
                    .fecha_transaccion = txtFechaOperacion.Text,
                    .tipo_transaccion = ddlTipoOperacion.SelectedValue,
                    .referencia_ubicacion = txtRef.Text,
                    .cantidad_transaccion = Convert.ToDouble(txtCantidad.Text),
                    .id_articulo = Convert.ToInt32(ddlListaArticulos.SelectedValue),
                    .documento_transaccion = "/Archivos/Operacion/Doc_" & ddlTipoOperacion.SelectedValue & "_" & _IdArticulo & "_" & Convert.ToDateTime(txtFechaOperacion.Text).ToString("yyyy-MM-dd") & "_" & fileExtension
                }
                    bError = Create.Historico(_Nuevo)
#End Region

                    If bError Then

                        If ddlTipoOperacion.SelectedValue = "Ent" Then
                            Listarticulo.stock_fisico = Listarticulo.stock_fisico + Convert.ToDouble(txtCantidad.Text)
                        Else
                            Listarticulo.stock_fisico = Listarticulo.stock_fisico - Convert.ToDouble(txtCantidad.Text)

                        End If

                        Try
                            contexto.SaveChanges()
                            Modal.MostrarMsjModal("Se Registro la operación satisfactoriamente", "EXI", Me)
                        Catch ex As Exception
                            Modal.MostrarMsjModal("Error al registrar operación", "ERR", Me)
                            Return
                        End Try


                    Else
                        Modal.MostrarMsjModal("Error al registrar operación", "ERR", Me)
                        Return
                    End If

                Else
                    Modal.MostrarMsjModal("Tiene que subir un documento", "ERR", Me)
                    Return
                End If
#End Region

            Else

                Modal.MostrarMsjModal("Las unidades del Articulo no Deben superar al stock actual y deben ser mayor a cero", "ERR", Me)

            End If

        End If
        Session("fuDocumento") = Nothing
        CargarListas()

    End Sub



End Class