<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Detalles.aspx.vb" Inherits="LogisPack.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
	<br />
	<ol class="breadcrumb">
		<li><a href="../../Default.aspx">Menú Principal</a></li>
		<li><a href="index.aspx">Artículos</a></li>
		<li><a href="#">Crear Artículo</a></li>
	</ol>
	
	<div class="page-header">
		<h1 class="text-center">Artículo</h1>
	</div>
	
	<div class="row"> 

		<div class="col-md-3">
			<h4><strong>Tipo de Artículo</strong></h4>
			<asp:Label id="lbTipoArticulo" runat="server"></asp:Label>
		</div>

		<div class="col-md-3">
			<h4><strong>Almacén</strong></h4>
			<asp:Label id="lbAlmacen" runat="server"></asp:Label>
		</div>

		<div class="col-md-6">
			<asp:PlaceHolder runat="server" id="phListaArticulos" Visible="false">
				<h4><strong>Lista de Artículos</strong></h4>
				<div class="col-md-12" style="overflow:auto;height:100px;">
					<asp:Panel ID="pArticulos" runat="server"></asp:Panel>
				</div>
			</asp:PlaceHolder>
		</div>

	</div>
			
	<hr />

	<div class="row">  
		<div class="col-md-3">
			<h4><strong>Código</strong></h4>
			
			<asp:Label runat="server" id="lbCodigo" ></asp:Label>
		</div>				
	</div>

	<div class="row">	
		<div class="col-md-8">
			<h4><strong>Nombre</strong></h4>
			<asp:Label runat="server" id="lbNombre" ></asp:Label>
		</div>
		
		<div class="col-md-4">
			<h4><strong>Referencia Picking</strong></h4>
			<asp:Label runat="server" id="lbRefPick"></asp:Label>
		</div>
	</div>

	<div class="row">
		<h3 class="text-center"><strong>Referencias Asociadas</strong></h3>
		<br />

		<div class="col-md-4">
			<h4><strong>Referencia 1</strong></h4>
			<asp:Label runat="server" id="lbRef1"></asp:Label>
		</div>                            
										  
		<div class="col-md-4">            
			<h4><strong>Referencia 2</strong></h4>                
			<asp:Label runat="server" id="lbRef2"></asp:Label>
		</div>                            
										  
		<div class="col-md-4">            
			<h4><strong>Referencia 3</strong></h4>                
			<asp:Label runat="server" id="lbRef3"></asp:Label>
		</div>
	</div>
	
	<hr />

	<div class="row">
		<div class="col-md-3">
			<h4><strong>Tipo de Unidad</strong></h4>
			<asp:Label id="lbTipoUnidad" runat="server"></asp:Label>
		</div>
	</div>

	<div class="row">
		<div class="col-md-12">
			<h4><strong>Ubicación</strong></h4>
			<table class="table table-bordered table-hover">
				<tbody>
					<tr class="bg-aqua color-palette">
						<th class="col-md-1 text-center">Zona</th>
						<th class="col-md-1 text-center">Estante</th>
						<th class="col-md-1 text-center">Fila</th>
						<th class="col-md-2 text-center">Columna</th>
						<th class="col-md-1 text-center">Panel</th>
						<th class="col-md-6 text-center">Referencia Ubicación</th>
					</tr>

					<asp:panel id="pTabla" runat="server"></asp:panel>
				</tbody>
			</table>
		</div>

	</div>
	
	<hr />

	<div class="row">				
		<div class="col-md-2">
			<h4><strong>Peso</strong></h4>
			<asp:Label runat="server" id="lbPeso"></asp:Label> cm(s)
		</div>                            
										  
		<div class="col-md-2">            
			<h4><strong>Alto</strong></h4>                 
			<asp:Label runat="server" id="lbAlto" ></asp:Label> cm(s)
		</div>                            
										  
		<div class="col-md-2">            
			<h4><strong>Largo</strong></h4>                
			<asp:Label runat="server" id="lbLargo"></asp:Label> cm(s)
		</div>                            
										  
		<div class="col-md-2">            
			<h4><strong>Ancho</strong></h4>                
			<asp:Label runat="server" id="lbAncho"></asp:Label> cm(s)
		</div>                            
										 
		<div class="col-md-2">            
			<h4><strong>M<sup>3</sup></strong></h4>                   
			<asp:Label runat="server" id="lbCubicaje"></asp:Label> cm(s)
		</div>
	</div>

	<div class="row">  
		<div class="col-md-3">            
			<h4><strong>Coef. Volumétrico</strong></h4>             
			<asp:Label runat="server" id="lbCoefVol" ></asp:Label> cm(s)
		</div>
		
		<div class="col-md-3">
			<h4><strong>Peso Volumétrico</strong></h4>
			<asp:Label runat="server" id="txtPesoVol" ></asp:Label> cm(s)
		</div>
	</div>

	<hr />

	<div class="row">		
		<div class="col-md-3">
			<h4><strong>Tipo de Facturación</strong></h4>
			<asp:Label runat="server" id="lbTipoFacturacion"></asp:Label>
		</div>
		
		<div class="col-md-2">
			<h4><strong>Identificación</strong></h4>
			<asp:Label runat="server" id="lbIdentificacion"></asp:Label>
		</div>
	</div>

	<div class="row">
		<div class="col-md-3">  
			<h4><strong>Valor Artículo</strong></h4>
			<asp:Label runat="server" id="lbValArticulo"></asp:Label>
		</div>

		<div class="col-md-3">  
			<h4><strong>Valoración Stock</strong></h4>
			<asp:Label runat="server" id="lbValSotck"></asp:Label>
		</div>
		
		<div class="col-md-3">  
			<h4><strong>Valoración Seguro</strong></h4>
			<asp:Label runat="server" id="txtValSeguro"></asp:Label>
		</div>
		
		<div class="col-md-3">  
			<h4><strong>Valor Asegurado</strong></h4>
			<asp:Label runat="server" id="txtValAsegurado"></asp:Label>
		</div>
	</div>
	
	<hr />

	<div class="row">
		<div class="col-md-6">
			<h4><strong>Observaciones Generales</strong></h4>
			<asp:Label runat="server" id="txtObsGen"></asp:Label>
		</div>
		
		<div class="col-md-6">
			<h4><strong>Observaciones Artículo</strong></h4>
			<asp:Label runat="server" id="txtObsArt"></asp:Label>
		</div>
	</div>

	<hr />

	<div class="row">				
		<div class="col-md-3">
			<h4><strong>Stock Mínimo</strong></h4>
			<asp:Label runat="server" id="lbStockMinimo"></asp:Label>

		</div>
		
		<div class="col-md-3">
			<h4><strong>Stock Físico</strong></h4>
			<asp:Label runat="server" id="lbStockFisico"></asp:Label>
		</div>
	</div>
	
	<hr />

	<div class="row">
		<div class="col-md-6 col-md-offset-3">
			<h4><strong>Imágenes</strong></h4>
			<asp:Panel ID="pImagenes" runat="server"></asp:Panel>
		</div>
		</div>

</asp:Content>
