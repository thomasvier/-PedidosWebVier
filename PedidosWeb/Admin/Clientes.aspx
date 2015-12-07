<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="PedidosWeb.Admin.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading" role="tab" id="headingOne">
            <h4 class="panel-title">
            <a role="button" data-toggle="collapse" data-parent="#accordion" href="#cadastro" aria-expanded="true" aria-controls="cadastro">
                Cadastro
            </a>
            </h4>
        </div>
        <div id="cadastro" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
            <div class="panel-body">
                <asp:UpdatePanel ID="upCadastro" runat="server" UpdateMode="Always">                    
                    <ContentTemplate>   
                        <div class="row">
                            <div class="col-md-4">
                                <label for="txtID">Código</label>
                                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>                
                        <div class="row">
                            <div class="col-md-4">
                                <label for="txtRazaoSocial">Razão Social</label>
                                <asp:TextBox ID="txtRazaoSocial" runat="server" CssClass="form-control" MaxLenght="500"></asp:TextBox>                        
                            </div>
                            <div class="col-md-4">
                                <label for="txtNomeFantasia">Nome Fantasia</label>
                                <asp:TextBox ID="txtNomeFantasia" runat="server" CssClass="form-control" MaxLenght="500"></asp:TextBox>
                            </div>                                        
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="txtCPFCNPJ">CNPJ</label>
                                <asp:TextBox ID="txtCPFCNPJ" runat="server" CssClass="form-control" MaxLenght="14"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label for="txtInscricaoEstadual">Inscrição Estadual</label>
                                <asp:TextBox ID="txtInscricaoEstadual" runat="server" CssClass="form-control" MaxLenght="10"></asp:TextBox>
                            </div>                    
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="txtTelefone">Telefone</label>
                                <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" MaxLenght="11"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label for="txtCelular">Celular</label>
                                <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" MaxLenght="11"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label for="txtEmail">E-mail</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="txtCep">CEP</label>
                                <asp:TextBox ID="txtCep" runat="server" MaxLenght="8" CssClass="form-control"></asp:TextBox>
                            </div>                    
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="txtEndereco">Endereço</label>
                                <asp:TextBox ID="txtEndereco" runat="server" MaxLenght="500" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label for="txtComplemento">Complemento</label>
                                <asp:TextBox ID="txtComplemento" runat="server" MaxLenght="500" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label for="txtNumero">Número</label>
                                <asp:TextBox ID="txtNumero" runat="server" MaxLenght="10" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="txtCidade">Cidade</label>
                                <asp:TextBox ID="txtCidade" runat="server" MaxLenght="500" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label for="txtBairro">Bairro</label>
                                <asp:TextBox ID="txtBairro" runat="server" MaxLenght="500" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <asp:CheckBox ID="cbAtivo" runat="server" checked="true" Text="Ativo" ToolTip="Selecione para inativar o cliente/fornecedor" />
                            </div>                        
                        </div>
                        <div class="row">
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                        </div>
                        <asp:HiddenField ID="hfTipoOperacao" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading" role="tab" id="headingTwo">
            <h4 class="panel-title">
            <a role="button" data-toggle="collapse" data-parent="#accordion" href="#Cliente" aria-expanded="true" aria-controls="Cliente">
                Clientes/Fornecedores
            </a>
            </h4>
        </div>
        <div id="paginas" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingTwo">
            <div class="panel-body">
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
                <asp:GridView ID="gvClientes" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" GridLines="None"
                    AllowSorting="true"
                    OnSorting="gvClientes_Sorting"
                    OnPageIndexChanging="gvClientes_PageIndexChanging"
                    OnRowCommand="gvClientes_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Código" SortExpression="ID" />
                        <asp:BoundField DataField="razaosocial" HeaderText="Razão Social" SortExpression="razaosocial" />                                                
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
