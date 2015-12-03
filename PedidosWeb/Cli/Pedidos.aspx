<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="PedidosWeb.Cli.Pedidos" %>

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
                            <asp:HiddenField ID="hfID" runat="server" />
                            <div class="row">
                                <div class="col-sm-4">
                                    <label for="txtDockumento">Documento</label>
                                    <asp:TextBox ID="txtDocumento" runat="server" Enabled="false" CssClass="form-control" MaxLenght="300"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label for="txtDataEntrega">Data de Entrega Desejada</label>
                                    <asp:TextBox ID="txtDataEntrega" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <label for="ddlStatus">Status</label>
                                    <asp:DropDownList ID="ddlStatus" runat="server" Enabled="false" CssClass="form-control">
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
                                                <asp:TextBox ID="txtPrecoProduto" runat="server" Text="0,00" Enabled="false" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:Button ID="btnProduto" runat="server" Text="Inserir" CssClass="btn btn-primary" OnClick="btnProduto_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <asp:GridView ID="gvProdutos" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" GridLines="None"
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
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnRemover" runat="server" CssClass="glyphicon glyphicon-remove" CommandName="Remover"
                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings Position="TopAndBottom" />
                                    </asp:GridView>
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
                    <a role="button" data-toggle="collapse" data-parent="#accordion" href="#pedidos" aria-expanded="true" aria-controls="pedidos">Meus Pedidos
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
                                            <label for="txtFiltro">Código/Documento</label>
                                            <asp:TextBox ID="txtFiltro" runat="server" CausesValidation="false" CssClass="form-control input-sm" placeholder="Código/Documento"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:GridView ID="gvPedidos" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" GridLines="None"
                    AllowSorting="true"
                    AllowPaging="true"
                    PageSize="10"
                    OnPageIndexChanging="gvPedidos_PageIndexChanging"
                    OnRowCommand="gvPedidos_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Código" SortExpression="ID" DataFormatString="{0:000000}" />
                        <asp:BoundField DataField="documento" HeaderText="Nº Doc." SortExpression="documento" />
                        <asp:BoundField DataField="cliente" HeaderText="Cliente" SortExpression="cliente" />
                        <asp:BoundField DataField="dataemissao" HeaderText="Emissão" SortExpression="dataemissao" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                        <asp:TemplateField HeaderText="Alterar">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn" runat="server" CssClass="glyphicon glyphicon-pencil" CommandName="Alterar"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Visualizar">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnVisualizar" runat="server" CssClass="glyphicon glyphicon-print" CommandName="Visualizar"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" />
                    <PagerSettings Position="TopAndBottom" />
                </asp:GridView>
            </div>
        </asp:Panel>


    </asp:Content>
