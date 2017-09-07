<%@ Page Title="Artículo" Language="vb" MasterPageFile="~/Site.Master"  AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="LogisPack.index3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:updatepanel id="updatePanelPrinicpal" runat="server">
        <ContentTemplate>

            <br />
            <ol class="breadcrumb">
                <li><a href="../../Default.aspx">Menu Principal</a></li>
                <li><a href="#">Artículo</a></li>
            </ol>
    
            <div class="page-header">
                <h1 class="text-center">Artículo</h1>
            </div>

            <div class="row">
                <div class="box-body">
                    <div class="dataTables_wrapper form-inline dt-bootstrap">
                
                        <asp:GridView id="GridView1" class="table table-bordered table-hover dataTable" runat="server" 
                            AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowCommand="GridView1_RowCommand" 
                            onpageindexchanging="GridView1_PageIndexChanging" EmptyDataText="No existen Registros">
                    
                            <Columns>
                                <asp:TemplateField HeaderText="Id Categoria" Visible="false" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate><asp:Label id="id" runat="server" Text='<%# Eval("id_articulo") %>'/></ItemTemplate>
                                </asp:TemplateField>
                        
                                <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate><asp:Label id="nombre" runat="server" Text='<%# Eval("nombre") %>'/></ItemTemplate>
                                </asp:TemplateField>

                                <asp:ButtonField   CommandName="Editar" ButtonType="Image" Text ="Editar"
                                    HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-default">
                                </asp:ButtonField>
                                <asp:ButtonField   CommandName="Detalle" ButtonType="Image" Text ="Detalle"
                                    HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-default">
                                </asp:ButtonField>
                                <asp:ButtonField   CommandName="Eliminar" ButtonType="Image" Text ="Eliminar"
                                    HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-default">
                                </asp:ButtonField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
    
            <div class="row">
                <div class="col-md-12">
                    <asp:button id="btnGuardar" runat="server" cssclass="btn btn-default" text="Crear Nuevo"/>

                </div>
            </div>

        </ContentTemplate>
        <Triggers></Triggers>
    </asp:updatepanel>

    <!-- Delete Modal -->
    <div id="DeleteModal" class="modal">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                    <h3>Eliminar Registro</h3>
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