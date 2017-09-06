<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="index.aspx.vb" Inherits="LogisPack.index4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<asp:updatepanel id="updatePanelPrinicpal" runat="server">
		<ContentTemplate>
			
			<br />
			
			<ol class="breadcrumb">
				<li><a href="../../Default.aspx">Menu Principal</a></li>
				<li><a href="#">Entrada/Salida de Artículos</a></li>
			</ol>
			
			<div class="page-header">
				<h1 class="text-center">Entrada/Salida de Artículos</h1>
			</div>

			<div class="row">

				<div class="col-md-3">
					<h4>Tipo de Operación</h4>
				
					<asp:DropDownList runat="server" id="ddlTipoOperacion" CssClass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Seleccione el tipo de Operación">
						<asp:ListItem Text="Entrada" Value="Ent"></asp:ListItem>
						<asp:ListItem Text="Salida" Value="Sal"></asp:ListItem>
					</asp:DropDownList>
				
					<asp:requiredfieldvalidator errormessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" display="Dynamic" 
						forecolor="#B50128" font-size="10" font-bold="true" controltovalidate="ddlTipoOperacion" runat="server"
						validationgroup="ValidationAdd"/>
				</div>

				<div class="col-md-3">
					<h4>Fecha de Operación</h4>
					
					<asp:TextBox runat="server" type="date" id="txtFechaOperacion" CssClass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Ingrese la fecha de la operación"></asp:TextBox>
					
					<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" Display="Dynamic" 
						ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtFechaOperacion" runat="server" 
						ValidationGroup="ValidationAdd"/>
				</div>
			
				<div class="col-md-3">
					<h4>Referencia</h4>
					<asp:TextBox runat="server" MaxLength="25" id="txtRef" CssClass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Ingrese la referencia de la operacion"></asp:TextBox>

					<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" Display="Dynamic" 
						ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtRef" runat="server" 
						validationgroup="ValidationAdd"/>
				</div>

				<div class="col-md-3">
					<h4>Cantidad de la operacion</h4>
					
					<asp:TextBox runat="server" type="number" min="0" ID="txtCantidad" CssClass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Ingrese la cantidad del articulo"></asp:TextBox>
					
					<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" Display="Dynamic" 
						ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="txtCantidad" runat="server" 
						ValidationGroup="ValidationAdd"/>

				</div>

			</div>

			<div class="row">
				
				<div class="col-md-3">
					<h4>Lista de Articulos</h4>
					<asp:dropdownlist id="ddlListaArticulos" runat="server" cssclass="form-control" data-toggle="tooltip" 
						data-placement="bottom" title="Seleccione el Artículo"></asp:dropdownlist>
					
					<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" Display="Dynamic" 
						ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="ddlListaArticulos" runat="server" 
						ValidationGroup="ValidationAdd"/>
				</div>
				
				<div class="col-md-3">
					<h4>Documento Transacción</h4>
					
					<asp:FileUpload runat="server" id="fuDocumento" data-toggle="tooltip" data-placement="bottom"
						class="form-control" title="Seleccione el documento de la transaccion"/>
					
					<asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" Display="Dynamic" 
						ForeColor="#B50128" Font-Size="10" Font-Bold="true" ControlToValidate="fuDocumento" runat="server" 
						ValidationGroup="ValidationAdd"/>
				</div>

				
			</div>
			
			<hr />

			<div class="row">
				<div class="col-md-3">
					<asp:button id="btnGuardar" runat="server" cssclass="btn btn-default" text="Guardar" 
						validationgroup="ValidationAdd"/>
				</div>
			</div>

		
		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger Controlid="btnGuardar"/></Triggers>
	</asp:updatepanel>
	
</asp:Content>
