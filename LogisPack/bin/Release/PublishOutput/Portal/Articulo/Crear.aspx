<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Crear.aspx.vb" Inherits="LogisPack.Crear" %>
<%@ Register Src="~/Portal/WebUserControl/MsjModal.ascx" TagPrefix="ucm" TagName="ucMsjModal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<asp:updatepanel id="upAdd_Articulo" runat="server">
		<ContentTemplate >

			<br />
			<ol class="breadcrumb">
				<li><a href="../../Default.aspx">Menu Principal</a></li>
				<li><a href="index.aspx">Artículos</a></li>
				<li><a href="#">Crear Artículo</a></li>
			</ol>
	
			<div class="page-header">
				<h1 class="text-center">Artículo</h1>
			</div>

			<div class="row"> 
				<div class="col-md-2">
					<h4>Tipo de Artículo</h4>
				
					<asp:DropDownList runat="server" id="ddlTipoArticulo" CssClass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Seleccione el tipo de Artículo" AutoPostBack="true">
						<asp:ListItem Text="Normal" Value="Normal"></asp:ListItem>
						<asp:ListItem Text="Picking" Value="Picking"></asp:ListItem>
					</asp:DropDownList>
				</div>

				<div class="col-md-2">
					<h4>Cliente:</h4>
					<asp:dropdownlist id="ddlCliente" runat="server" cssclass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Seleccione el cliente" AutoPostBack="true"></asp:dropdownlist>

					<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" Display="Dynamic" 
						ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="ddlCliente" runat="server" 
						validationgroup="ValidationAdd"/>
				</div>

				<div class="col-md-2">
					<h4>Almacén</h4>
					<asp:dropdownlist id="ddlAlmacen" runat="server" cssclass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Seleccione el almacén" AutoPostBack="true"></asp:dropdownlist>

					<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" Display="Dynamic" 
						ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="ddlAlmacen" runat="server" 
						validationgroup="ValidationAdd"/>
				</div>

				<div class="col-md-8">
					<asp:PlaceHolder runat="server" id="phListaArticulos" Visible="false">

						<div class="col-md-12">
							<h4>Lista de Articulos</h4>

							<asp:textbox id="txtArticulos1" CssClass="form-control" runat="server" rows="5" textmode="multiline"></asp:textbox>
							<asp:textbox id="txtArticulos2" CssClass="form-control" runat="server" rows="5" textmode="multiline" Visible="false"></asp:textbox>

							<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" Display="Dynamic" 
								ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtArticulos1" runat="server" 
								validationgroup="ValidationAdd"/>

						</div>

						<div class="col-md-6">                            
							<h4>Articulos</h4>
							<asp:dropdownlist id="ddlListaArticulos" runat="server" cssclass="form-control" data-toggle="tooltip" 
								data-placement="bottom" title="Seleccione el Artículo" ></asp:dropdownlist>

						</div>

						<div class="col-md-6" onkeydown = "return (event.keyCode!=13)">
							<h4>Unidades del Articulos</h4>
							<asp:textbox id="txtUnidad" CssClass="form-control" runat="server" type="number" min=0></asp:textbox>
							
							<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" Display="Dynamic" 
								ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtUnidad" runat="server" 
								validationgroup="Val_AddArticulo"/>
						</div>
					
						<div class="col-md-4">
							<br />
							<asp:button id="btnAddArticuloRow" runat="server" cssclass="btn btn-default" text="Añadir Articulo"
								validationgroup="Val_AddArticulo" causesvalidation="true"/>
						</div>
					</asp:PlaceHolder>
				</div>

			</div>
			
			<hr />

			<div class="row" onkeydown = "return (event.keyCode!=13)">  
				<div class="col-md-3">
					<h4>Código</h4>
					
					<asp:TextBox runat="server" MaxLength="25" id="txtCodigo" CssClass="form-control"
						data-toggle="tooltip" data-placement="bottom" title="Ingrese el codigo del articulo"></asp:TextBox>
				</div>				
			</div>

			<div class="row" onkeydown = "return (event.keyCode!=13)">	
				<div class="col-md-8">
					<h4>Nombre</h4>
					<asp:TextBox runat="server" MaxLength="40" id="txtNombre" CssClass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Ingrese el nombre del artículo"></asp:TextBox>
				</div>
				
				<div class="col-md-4">
					<h4>Referencia picking</h4>
					<asp:TextBox runat="server" MaxLength="25" id="txtRefPick" CssClass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Ingrese la referencia picking del artículo"></asp:TextBox>
				</div>
			</div>

			<div class="row" onkeydown = "return (event.keyCode!=13)">
				<h3>Referencias Asociadas</h3>

				<div class="col-md-4">
					<h4>Referencia 1</h4>
					<asp:TextBox runat="server" MaxLength="25" id="txtRef1" CssClass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Ingrese la referencia 1 del artículo"></asp:TextBox>
				</div>

				<div class="col-md-4">
					<h4>Referencia 2</h4>
					<asp:TextBox runat="server" MaxLength="25" id="txtRef2" CssClass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Ingrese la referencia 2 del artículo"></asp:TextBox>
				</div>

				<div class="col-md-4">
					<h4>Referencia 3</h4>
					<asp:TextBox runat="server" MaxLength="25" id="txtRef3" CssClass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Ingrese la referencia 3 del artículo"></asp:TextBox>
				</div>
			</div>
			
			<hr />

			<div class="row">
				<div class="col-md-3">
					<h4>Tipo de Unidad</h4>
					<asp:dropdownlist id="ddlTipoUnidad" runat="server" cssclass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Seleccione el Tipo de Unidad"></asp:dropdownlist>
				</div>
			</div>

			<div class="row" onkeydown = "return (event.keyCode!=13)">
				<div class="col-md-12">
					<h4>Ubicación</h4>
					<table class="table table-condensed">
						<tbody>
							<tr class="bg-aqua color-palette">
								<th class="col-md-1 text-center">Zona</th>
								<th class="col-md-1 text-center">Estante</th>
								<th class="col-md-1 text-center">Fila</th>
								<th class="col-md-1 text-center">Columna</th>
								<th class="col-md-1 text-center">Panel</th>
								<th class="col-md-7 text-center">Referencia Ubicación</th>
							</tr>

							<asp:panel id="pTabla" runat="server">
								<tr>
									<td>
										<asp:textbox id="txtZona0" CssClass="form-control" runat="server" MaxLength="4"></asp:textbox>
									</td>
									<td>
										<asp:textbox id="txtEstante0" CssClass="form-control" runat="server" MaxLength="4"></asp:textbox>
									</td>
									<td>
										<asp:textbox id="txtFila0" CssClass="form-control" runat="server" MaxLength="4"></asp:textbox>
									</td>
									<td>
										<asp:textbox id="txtColumna0" CssClass="form-control" runat="server" MaxLength="4"></asp:textbox>
									</td>
									<td>
										<asp:textbox id="txtPanel0" CssClass="form-control" runat="server" MaxLength="4"></asp:textbox>
									</td>
									<td>                                        
										<asp:textbox id="txtRefUbi0" CssClass="form-control" runat="server" MaxLength="40"></asp:textbox>
									</td>
								</tr>
							</asp:panel>
						</tbody>
					</table>
					
					<div class="col-md-6">
						<asp:button id="btnAddFilaUbicacion" runat="server" cssclass="btn btn-default" text="Agregar Otra Ubicación" />
						<asp:button id="btnEliminarFila" runat="server" cssclass="btn btn-default" text="Eliminar Ubicación" 
							validationgroup="ValidationAddRow"/>
					</div>
				</div>
			</div>
			
			<hr />

			<div class="row" onkeydown = "return (event.keyCode!=13)">				
				<div class="col-md-2">
					<h4>Peso (Kgs)</h4>
					<asp:TextBox runat="server" min="0" max="9999,999" id="txtPeso" CssClass="form-control" data-toggle="tooltip" type="number"
						step=0.001 data-placement="bottom" title="Ingrese el peso del artículo"></asp:TextBox>
				</div>
				
				<div class="col-md-2">
					<h4>Alto(cm)</h4>
					<asp:TextBox runat="server" min="0" max="9999,9" id="txtAlto" CssClass="form-control" data-toggle="tooltip" type="number"
						step=0.1 data-placement="bottom" title="Ingrese la altura del artículo"></asp:TextBox>
				</div>
				
				<div class="col-md-2">
					<h4>Largo (cm)</h4>
					<asp:TextBox runat="server" min="0" max="9999,9" id="txtLargo" CssClass="form-control" data-toggle="tooltip" type="number"
						step=0.1 data-placement="bottom" title="Ingrese el largo del artículo"></asp:TextBox>
				</div>
				
				<div class="col-md-2">
					<h4>Ancho(cm)</h4>
					<asp:TextBox runat="server" min="0" max="9999,9" id="txtAncho" CssClass="form-control" data-toggle="tooltip" type="number"
						step=0.1 data-placement="bottom" title="Ingrese el ancho del artículo"></asp:TextBox>
				</div>
				
				<div class="col-md-3">
					<h4>Coef. Volumétrico</h4>
					<asp:TextBox runat="server" min="0" max="9999,9" id="txtCoefVol" CssClass="form-control" data-toggle="tooltip" type="number"
						step=0.1 data-placement="bottom" title="Ingrese el coeficiente volumétrico del artículo"></asp:TextBox>
				</div>

			</div>

			<hr />

			<div class="row" onkeydown = "return (event.keyCode!=13)">
				<div class="col-md-3">
					<h4>Tipo de Facturación</h4>
					<asp:dropdownlist id="ddlTipoFacturacion" runat="server" cssclass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Seleccione el Tipo de Facturación"></asp:dropdownlist>
				</div>
				
				<div class="col-md-3">
					<h4>Identificación</h4>
					
					<asp:DropDownList runat="server" id="ddlIdentificacion" CssClass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Seleccione el tipo de Artículo">
						<asp:ListItem Text="CB" Value="CB"></asp:ListItem>
						<asp:ListItem Text="RF" Value="RF"></asp:ListItem>
					</asp:DropDownList>
				</div>

				<div class="col-md-3">  
					<h4>Valor artículo</h4>
					<asp:TextBox runat="server" min=0  id="txtValArticulo" CssClass="form-control" data-toggle="tooltip" type="number"
						step=0.01 data-placement="bottom" title="Ingrese el valor del artículo"></asp:TextBox>

					<%--<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" Display="Dynamic" 
						ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtValArticulo" runat="server" 
						validationgroup="ValidationAdd"/>--%>
				</div>

				<div class="col-md-3">  
					<h4>Valor Asegurado</h4>
					<asp:TextBox runat="server" id="txtValAsegurado"  CssClass="form-control" type="number" step=0.01 
						data-placement="bottom" title="Ingrese el valor asegurado"></asp:TextBox>
				</div>				
			</div>
			
			<hr />

			<div class="row">
				<div class="col-md-6">
					<h4>Observaciones Generales</h4>
					<asp:TextBox runat="server" id="txtObsGen" CssClass="form-control" data-toggle="tooltip" rows="3" 
						textmode="multiline" data-placement="bottom" title="Ingrese las observaciones generales"></asp:TextBox>
					<div id="count1">0</div>
					<div id="alert1" class="hidden">Has alcanzado el limite!</div>

				</div>
				
				<div class="col-md-6">
					<h4>Observaciones Artículo</h4>
					<asp:TextBox runat="server" MaxLength="300" id="txtObsArt" CssClass="form-control" data-toggle="tooltip" rows="3" 
						textmode="multiline" data-placement="bottom" title="Ingrese las observaciones del artículo"></asp:TextBox>
					<div id="count2">0</div>
					<div id="alert2" class="hidden">Has alcanzado el limite!</div>
				</div>

			</div>


			<hr />

			<div class="row" onkeydown = "return (event.keyCode!=13)">				
				<div class="col-md-3">
					<h4>Stock mínimo</h4>
					<asp:TextBox runat="server" min=0 id="txtStockMinimo" CssClass="form-control" data-toggle="tooltip" 
						type="number" step=0.01 data-placement="bottom" title="Ingrese el stock mínimo del artículo"></asp:TextBox>
				</div>
				
				<div class="col-md-3">
					<h4>Stock físico</h4>
					<asp:TextBox runat="server" min=0 id="txtStockFisico" CssClass="form-control" data-toggle="tooltip" type="number"
						step=0.01 data-placement="bottom" title="Ingrese el stock fisico del artículo"></asp:TextBox>
				</div>
			</div>
			
			<hr />

			<div class="row">
				<div class="col-md-3">
					<h4>Imagenes</h4>
					
					<asp:FileUpload runat="server" id="fuImagenes" data-toggle="tooltip" data-placement="bottom" AllowMultiple="true" 
						class="multiple form-control" title="Seleccione las imagenes del articulo" accept=".png,.jpg,.jpeg,.gif"/> 
				</div>
			</div>

			<hr />

			<div class="row">
				<div class="col-md-3">
					<asp:button id="btnGuardar" runat="server" cssclass="btn btn-default" text="Guardar" validationgroup="ValidationAdd"/>
				</div>
			</div>

		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger Controlid="btnGuardar"/>
		</Triggers>
	</asp:updatepanel>
	
	<!-- Msj Modal -->
	<ucm:ucMsjModal runat="server" id="ucMsjModal"/>

</asp:Content>