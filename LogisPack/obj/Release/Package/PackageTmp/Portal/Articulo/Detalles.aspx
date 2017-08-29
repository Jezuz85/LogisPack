<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Detalles.aspx.vb" Inherits="LogisPack.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
				
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
					<asp:Label id="lbTipoArticulo" runat="server"></asp:Label>
				</div>

				<div class="col-md-2">
					<h4>Almacén</h4>
					<asp:Label id="lbAlmacen" runat="server"></asp:Label>
				</div>

				<div class="col-md-8">
					<asp:PlaceHolder runat="server" id="phListaArticulos" Visible="false">

						<div class="col-md-12">
							<h4>Lista de Articulos</h4>
							<asp:Panel ID="pArticulos" runat="server"></asp:Panel>
						</div>
					</asp:PlaceHolder>
				</div>

			</div>
			
			<hr />

			<div class="row">  
				<div class="col-md-3">
					<h4>Código</h4>
					
					<asp:Label runat="server" id="lbCodigo" ></asp:Label>
				</div>				
			</div>

			<div class="row">	
				<div class="col-md-8">
					<h4>Nombre</h4>
					<asp:Label runat="server" id="lbNombre" ></asp:Label>
				</div>
				
				<div class="col-md-4">
					<h4>referencia picking</h4>
					<asp:Label runat="server" id="lbRefPick"></asp:Label>
				</div>
			</div>

			<div class="row">
				<h3>Referencias Asociadas</h3>

				<div class="col-md-4">
					<h4>RF 1</h4>
					<asp:Label runat="server" id="lbRef1"></asp:Label>
				</div>                            
												  
				<div class="col-md-4">            
					<h4>REF 2</h4>                
					<asp:Label runat="server" id="lbRef2"></asp:Label>
				</div>                            
												  
				<div class="col-md-4">            
					<h4>Ref 3</h4>                
					<asp:Label runat="server" id="lbRef3"></asp:Label>
				</div>
			</div>
			
			<hr />

			<div class="row">
				<div class="col-md-3">
					<h4>Tipo de Unidad</h4>
					<asp:Label id="lbTipoUnidad" runat="server"></asp:Label>
				</div>

				<div class="col-md-9">
					<h4>Ubicación</h4>
					<table class="table table-condensed">
						<tbody>
							<tr class="bg-aqua color-palette">
								<th class="col-md-1 text-center">Zona</th>
								<th class="col-md-1 text-center">Estante</th>
								<th class="col-md-1 text-center">Fila</th>
								<th class="col-md-1 text-center">columna</th>
								<th class="col-md-1 text-center">Panel</th>
								<th class="col-md-7 text-center">Referencia ubicación</th>
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
				</div>

			</div>
			
			<hr />

			<div class="row">				
				<div class="col-md-1">
					<h4>Peso</h4>
					<asp:Label runat="server" id="lbPeso"></asp:Label>
				</div>                            
												  
				<div class="col-md-1">            
					<h4>Alto</h4>                 
					<asp:Label runat="server" id="lbAlto" ></asp:Label>
				</div>                            
												  
				<div class="col-md-1">            
					<h4>Largo</h4>                
					<asp:Label runat="server" id="lbLargo"></asp:Label>
				</div>                            
												  
				<div class="col-md-1">            
					<h4>Ancho</h4>                
					<asp:Label runat="server" id="lbAncho"></asp:Label>
				</div>                            
												  
				<div class="col-md-2">            
					<h4>Coef Vol</h4>             
					<asp:Label runat="server" id="lbCoefVol" ></asp:Label>
				</div>                            
												  
				<div class="col-md-1">            
					<h4>M3</h4>                   
					<asp:Label runat="server" id="lbCubicaje"></asp:Label>
				</div>
				
				<div class="col-md-2">
					<h4>peso Volum</h4>
					<asp:Label runat="server" id="txtPesoVol" ></asp:Label>
				</div>
			</div>

			<hr />

			<div class="row">
				
				<div class="col-md-2">
					<h4>Tipo de Facturación</h4>
					<asp:Label runat="server" id="lbTipoFacturacion"></asp:Label>
				</div>
				
				<div class="col-md-2">
					<h4>Identificación</h4>
					<asp:Label runat="server" id="lbIdentificacion"></asp:Label>
				</div>

				<div class="col-md-2">  
					<h4>valor artículo</h4>
					<asp:Label runat="server" id="lbValArticulo"></asp:Label>
				</div>

				<div class="col-md-2">  
					<h4>Valoración stock</h4>
					<asp:Label runat="server" id="lbValSotck"></asp:Label>
				</div>
				
				<div class="col-md-2">  
					<h4>Valoración seguro</h4>
					<asp:Label runat="server" id="txtValSeguro"></asp:Label>
				</div>
				
			</div>
			
			<hr />

			<div class="row">
				<div class="col-md-6">
					<h4>Observaciones generales</h4>
					<asp:Label runat="server" id="txtObsGen"></asp:Label>
				</div>
				
				<div class="col-md-6">
					<h4>Observaciones articulo</h4>
					<asp:Label runat="server" id="txtObsArt"></asp:Label>
				</div>
			</div>

			<hr />

			<div class="row">				
				<div class="col-md-3">
					<h4>stock mínimo</h4>
					<asp:Label runat="server" id="lbStockMinimo"></asp:Label>

				</div>
				
				<div class="col-md-3">
					<h4>stock físico</h4>
					<asp:Label runat="server" id="lbStockFisico"></asp:Label>
				</div>
			</div>


			
			<hr />

			<div class="row">
				<div class="col-md-6">
					<h4>Imagenes</h4>
					
						   <asp:Panel ID="pImagenes" runat="server"></asp:Panel>
					 
					</div>
				</div>

			</div>
</asp:Content>
