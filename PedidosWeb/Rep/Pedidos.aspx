﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="PedidosWeb.Rep.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Pedidos.js"></script>   
    <asp:Panel ID="pnCadastro" runat="server" CssClass="panel panel-default" DefaultButton="btnSalvar">
        <div class="panel-heading" role="tab" id="headingOne">
            <h4 class="panel-title">
                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#cadastro" aria-expanded="true" aria-controls="cadastro">Novo Pedido
                </a>
            </h4>
        </div>
        <div id="cadastro" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
            <div class="panel-body">                
                <asp:UpdatePanel ID="upCadastro" runat="server" UpdateMode="Always">                    
                    <ContentTemplate>   
                        <div class="row">
                            <div class="col-sm-4">
                                <label for="txtID">Código</label>
                                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <label for="txtDocumento">Documento</label>
                                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" MaxLenght="300"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNome" runat="server" Display="Dynamic" ControlToValidate="txtDocumento"
                                    SetFocusOnError="true" ValidationGroup="vgPedido" CssClass="erro" Text="Número do documento obrigatório"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-xs-4">
                                <label for="ddlCliente">Cliente</label>
                                <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <label for="txtDataEmissao">Data emissão</label>
                                <asp:TextBox ID="txtDataEmissao" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label for="txtDataEntrega">Data de Entrega</label>
                                <asp:TextBox ID="txtDataEntrega" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>     
                        <div class="row">
                            <div class="col-sm-4">
                                <label for="ddlStatus">Status</label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Selected="True" Value="0" Text="Pendente"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Confirmado"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Entregue"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Cancelado"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>             
                        <br />
                        <asp:Panel ID="pnProdutos" runat="server" CssClass="panel panel-primary" DefaultButton="btnProduto">
                            <div class="panel-heading" role="tab" id="headingProd">
                                <h4 class="panel-title">
                                    <a role="button" data-toggle="collapse" data-parent="#accordion" href="#produtos" aria-expanded="true" aria-controls="produtos">Produtos
                                    </a>
                                </h4>
                            </div>
                            <div id="produtos" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                            <div class="panel-body">
                                <div class="row">                                    
                                    <div class="col-md-3">
                                        <label for="ddlProdutos">Produto</label>
                                        <asp:DropDownList ID="ddlProdutos" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlProdutos_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>                                    
                                </div>                                        
                                <div class="row">                                    
                                    <div class="col-md-3">
                                        <label for="txtQuantidadeProduto">Quantidade</label>
                                        <asp:TextBox ID="txtQuantidadeProduto" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label for="txtPrecoProduto">Preço</label>
                                        <asp:TextBox ID="txtPrecoProduto" runat="server" Text="0,00" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Button ID="btnProduto" runat="server" Text="Inserir" CssClass="btn btn-primary" OnClick="btnProduto_Click"  />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:GridView ID="gvProdutos" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" GridLines="None"
                                            ShowHeaderWhenEmpty="true"                                            
                                            OnRowCommand="gvProdutos_RowCommand">
                                            <Columns>               
                                                <asp:BoundField DataField="ID" ItemStyle-CssClass="divHidden" HeaderStyle-CssClass="divHidden" />    
                                                <asp:BoundField DataField="produtoID" ItemStyle-CssClass="divHidden" HeaderStyle-CssClass="divHidden" />    
                                                <asp:BoundField DataField="descricao" HeaderText="Produto" SortExpression="descricao" />    
                                                <asp:BoundField DataField="quantidade" HeaderText="Qtd." DataFormatString="{0:N3}" SortExpression="quantidade" />    
                                                <asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:C}" SortExpression="total" />                                                         
                                                <asp:BoundField DataField="precounitario" HeaderStyle-CssClass="divHidden" ItemStyle-CssClass="divHidden" SortExpression="descricao" />    
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btn" runat="server" CssClass="glyphicon glyphicon-pencil" CommandName="Alterar"
                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>       
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnRemover" runat="server" CssClass="glyphicon glyphicon-remove" CommandName="Remover"
                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>         
                                            </Columns>
                                            <pagersettings position="TopAndBottom"/>
                                        </asp:GridView>
                                    </div>    
                                </div>                                  
                            </div>
                                </div>
                        </asp:Panel>
                        <div class="form-group">
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click" ValidationGroup="vgPedido" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                        </div>
                        <asp:HiddenField ID="hfTipoOperacao" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnPedidos" runat="server" DefaultButton="btnPesquisar" CssClass="panel panel-default">    
        <div class="panel-heading" role="tab" id="headingTwo">
            <h4 class="panel-title">
                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#pedidos" aria-expanded="true" aria-controls="pedidos">Pedidos
                </a>
            </h4>
        </div>
        <div id="pedidos" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingTwo">
            <div class="panel-body">                
                <asp:UpdatePanel ID="upPedidos" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-3">
                                        <label for="txtFiltro">Documento</label>
                                        <asp:TextBox ID="txtDocumentoFiltro" runat="server" CausesValidation="false" CssClass="form-control input-sm" placeholder="Documento"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label for="txtDataInicialFiltro">De: </label>
                                        <asp:TextBox ID="txtDataInicialFiltro" runat="server" CausesValidation="false" CssClass="form-control input-sm" placeholder="Data inicial"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label for="txtDataFinalFiltro">Até: </label>
                                        <asp:TextBox ID="txtDataFinalFiltro" runat="server" CausesValidation="false" CssClass="form-control input-sm" placeholder="Data final"></asp:TextBox>
                                    </div>
                                </div>                                
                                <div class="row">
                                    <div class="col-md-3">
                                        <label for="txtClienteFiltro">Cliente</label>
                                        <asp:TextBox ID="txtClienteFiltro" runat="server" CssClass="form-control input-sm" placeholder="Cliente"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label for="ddlStatusFiltro">Status</label>
                                        <asp:DropDownList ID="ddlStatusFiltro" runat="server" CssClass="form-control input-sm">
                                            <asp:ListItem Selected="True" Value="T" Text="Todos"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="Pendente"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Confirmado"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Entregue"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Cancelado"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>   
                                <br />
                                <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" ClientIDMode="Static" CssClass="btn btn-default" OnClick="btnPesquisar_Click" />                                                                               
                            </div>
                        </div>                        
                        <div class="form-group">
                            <asp:GridView ID="gvPedidos" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" GridLines="None"
                                AllowSorting="true"
                                AllowPaging="true"
                                PageSize="10"
                                OnSorting="gvPedidos_Sorting"
                                OnPageIndexChanging="gvPedidos_PageIndexChanging"
                                OnRowCommand="gvPedidos_RowCommand">
                                <Columns>               
                                    <asp:BoundField DataField="ID" HeaderText="Código" SortExpression="ID" DataFormatString="{0:000000}" />
                                    <asp:BoundField DataField="documento" HeaderText="Nº Doc." SortExpression="documento" />               
                                    <asp:BoundField DataField="cliente" HeaderText="Cliente" SortExpression="cliente" />                                                         
                                    <asp:BoundField DataField="dataemissao" HeaderText="Emissão" SortExpression="dataemissao" DataFormatString="{0:dd/MM/yyyy}" />                                    
                                    <asp:TemplateField HeaderText="Alterar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btn" runat="server" CssClass="glyphicon glyphicon-pencil" CommandName="Alterar"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>       
                                    <asp:TemplateField HeaderText="Visualizar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnVisualizar" runat="server" CssClass="glyphicon glyphicon-print" CommandName="Visualizar"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>         
                                </Columns>
                                <pagersettings position="TopAndBottom"/>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
