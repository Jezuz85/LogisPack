<%@ Page Title="Tipo de Facturación" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="index.aspx.vb" Inherits="LogisPack.index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:updatepanel id="updatePanelPrinicpal" runat="server">
        <ContentTemplate>

            <br />
            <ol class="breadcrumb">
                <li><a href="../../Default.aspx">Menu Principal</a></li>
                <li><a href="#">Tipo de Facturación</a></li>
            </ol>
    
            <div class="page-header">
                <h1 class="text-center">Tipo de Facturación</h1>
            </div>

            <div class="row">
                <div class="box-body">
                    <div class="dataTables_wrapper form-inline dt-bootstrap">
                
                        <asp:GridView id="GridView1" class="table table-bordered table-hover dataTable" runat="server" 
                            AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowCommand="GridView1_RowCommand" 
                            onpageindexchanging="GridView1_PageIndexChanging" EmptyDataText="No existen Registros">
                    
                            <Columns>
                                <asp:TemplateField HeaderText="Id Categoria" Visible="false" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate><asp:Label id="id" runat="server" Text='<%# Eval("id_tipo_facturacion") %>'/></ItemTemplate>
                                </asp:TemplateField>
                        
                                <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate><asp:Label id="nombre" runat="server" Text='<%# Eval("nombre") %>'/></ItemTemplate>
                                </asp:TemplateField>

                                <asp:ButtonField   CommandName="Edit" ButtonType="Image" Text ="Editar"
                                    HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-default">
                                </asp:ButtonField>

                                <asp:ButtonField   CommandName="Delete" ButtonType="Image" Text ="Eliminar"
                                    HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-default">
                                </asp:ButtonField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
    
            <div class="row">
                <div class="col-md-12">
                    <asp:ImageButton AlternateText="Registrar" id="btnCrear" runat="server" CssClass="btn btn-default" data-toggle="modal" data-target="#AddModal"/>
                </div>
            </div>

        </ContentTemplate>
        <Triggers></Triggers>
    </asp:updatepanel>

    <!-- Add Modal -->
    <div id="AddModal"class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                
                <div class="modal-header">
                    <button id="btnAddCerrar" type="button" class="close" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                    <h3><strong>Agregar Registro</strong></h3>
                </div>

                <asp:updatepanel id="up_Add" runat="server">
                    <ContentTemplate>
                        <div class="modal-body form-group">

                            <div class="row">
                                <div class="col-md-8 col-md-offset-2">
                                    <h4><strong>Nombre</strong></h4>

                                    <asp:TextBox id="txtNombre" MaxLength="40" runat="server" ClientIDMode="Static" 
                                        CssClass="form-control" data-toggle="tooltip" data-placement="bottom" 
                                        title="Ingrese el nombre del Almacén"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" 
                                        Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true" 
                                        ControlToValidate="txtNombre" runat="server" ValidationGroup="ValidationAdd"/>
                                </div>
                            </div>
                        </div>
                        
                        <div class="modal-footer">
                            <div class="row">

                                <div class="col-md-4 col-md-offset-4">
                                    <asp:Button id="btnAdd" runat="server" Text="Registrar" class="btn btn-block btn-default" ValidationGroup="ValidationAdd"/>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger Controlid="btnAdd" EventName="Click"/></Triggers>
                </asp:updatepanel>
            </div>
        </div>
    </div>
    
    <!-- Edit Modal -->
    <div id="EditModal"class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                
                <div class="modal-header">
                    <button id="btnEditCerrar" type="button" class="close" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                    <h3><strong>Editar Registro</strong></h3>
                </div>

                <asp:updatepanel id="up_Edit" runat="server">
                    <ContentTemplate>

                        <div class="modal-body form-group">
                            
                            <asp:HiddenField id="hdfEdit" runat="server"/>

                            <div class="row">
                                <div class="col-md-8 col-md-offset-2">
                                    <h4><strong>Nombre</strong></h4>

                                    <asp:TextBox id="txtNombre_Edit" MaxLength="40" runat="server" ClientIDMode="Static" 
                                        CssClass="form-control" data-toggle="tooltip" data-placement="bottom" 
                                        title="Ingrese el nombre del Almacén"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ErrorMessage="<p>Campo Obligatorio!</p>" setfocusonerror="true" 
                                        Display="Dynamic" ForeColor="#B50128" Font-Size="10" Font-Bold="true" 
                                        ControlToValidate="txtNombre_Edit" runat="server" ValidationGroup="VG_Edit"/>
                                </div>
                            </div>
                        </div>
                        
                        <div class="modal-footer">
                            <div class="row">

                                <div class="col-md-4 col-md-offset-4">
                                    <asp:Button id="btnEdit" runat="server" Text="Editar" class="btn btn-block btn-default" ValidationGroup="VG_Edit"/>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger Controlid="btnEdit" EventName="Click"/></Triggers>
                </asp:updatepanel>
            </div>
        </div>
    </div>    
    
    <!-- Delete Modal -->
    <div id="DeleteModal"class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                    <h3><strong>Eliminar Registro</strong></h3>
                </div>

                <asp:updatepanel id="upDel" runat="server">
                    <ContentTemplate>
                        
                        <div class="modal-body form-group">
                            <asp:HiddenField id="hdfIDDel" runat="server"/>
                            
                            <div class="row">
                                <h4 class="text-center">¿Seguro desea eliminar este registro?</h4>
                            </div>
                        </div>
                        
                        <div class="modal-footer">
                            <div class="row">                                
                                <div class="col-md-4 col-md-offset-2">
                                    <asp:Button id="btnDelete" runat="server" Text="Eliminar" class="btn btn-block btn-info" 
                                        OnClick="EliminarRegistro"/>
                                </div>
                                
                                <div class="col-md-4">
                                    <button class="btn btn-block btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger Controlid="btnDelete" EventName="Click"/>
                    </Triggers>
                </asp:updatepanel>

            </div>
        </div>
    </div>
</asp:Content>
