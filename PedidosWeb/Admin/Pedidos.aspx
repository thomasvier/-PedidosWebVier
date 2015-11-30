<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="PedidosWeb.Admin.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function (){        
            $("#MainContent_txtPrecoProduto").maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });
            $("#MainContent_txtQuantidadeProduto").mask("###0,0000", { reverse: true });
            $("#MainContent_txtDataEmissao").mask('00/00/0000');
            $("#MainContent_txtDataEntrega").mask('00/00/0000');
            $("#MainContent_txtDataEntrega").datepicker();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $(document).ready(function () {
                $("#MainContent_txtPrecoProduto").maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });
                $("#MainContent_txtQuantidadeProduto").mask("###0,0000", { reverse: true });
                $("#MainContent_txtDataEmissao").mask('00/00/0000');
                $("#MainContent_txtDataEntrega").mask('00/00/0000');
            });
        });
    </script>    
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
                            <div class="col-sm-4">
                                <label for="ddlCliente">Cliente</label>
                                <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Selecione" Value="selecione" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Teste" Value="Teste"></asp:ListItem>
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
                                        <asp:DropDownList ID="ddlProdutos" runat="server" CssClass="form-control">
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
                                        <asp:Button ID="btnProduto" runat="server" Text="Inserir" CssClass="btn btn-primary"  />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:GridView ID="gvProdutos" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" GridLines="None"
                                            AllowSorting="true"
                                            AllowPaging="true"
                                            PageSize="20">
                                            <Columns>               
                                                <asp:BoundField DataField="cliente" HeaderText="Cliente" SortExpression="cliente" />                                                         
                                                <asp:TemplateField HeaderText="Alterar" HeaderStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btn" runat="server" CssClass="glyphicon glyphicon-pencil" CommandName="Alterar"
                                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>       
                                                <asp:TemplateField HeaderText="Remover" HeaderStyle-Width="50px">
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
                        <nav class="navbar navbar-default">
                            <div class="container-fluid">
                                <div class="navbar-header">
                                    <p class="navbar-brand">Filtro</p>
                                </div>
                                <div class="navbar-form navbar-left">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtFiltro" runat="server" CausesValidation="false" CssClass="form-control" placeholder="Pesquisar"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="btnPesquisar" runat="server" Text="Enviar" ClientIDMode="Static" CssClass="btn btn-default" OnClick="btnPesquisar_Click" />
                                </div>
                            </div>
                        </nav>
                        <div class="form-group">
                            <asp:GridView ID="gvPedidos" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" GridLines="None"
                                AllowSorting="true"
                                AllowPaging="true"
                                PageSize="20"
                                OnSorting="gvPedidos_Sorting"
                                OnPageIndexChanging="gvPedidos_PageIndexChanging"
                                OnRowCommand="gvPedidos_RowCommand">
                                <Columns>               
                                    <asp:BoundField DataField="ID" HeaderText="Código" SortExpression="ID" DataFormatString="{0:000000}" />
                                    <asp:BoundField DataField="documento" HeaderText="Nº Doc." SortExpression="documento" />               
                                    <asp:BoundField DataField="cliente" HeaderText="Cliente" SortExpression="cliente" />                                                         
                                    <asp:BoundField DataField="dataemissao" HeaderText="Emissão" SortExpression="dataemissao" DataFormatString="{0:dd/MM/yyyy}" />                                    
                                    <asp:TemplateField HeaderText="Alterar" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btn" runat="server" CssClass="glyphicon glyphicon-pencil" CommandName="Alterar"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>       
                                    <asp:TemplateField HeaderText="Visualizar" HeaderStyle-Width="50px">
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
