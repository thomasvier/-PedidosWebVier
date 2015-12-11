<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="PedidosWeb.Admin.Produtos" %>
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
                            <label for="txtID">Código</label>
                            <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>                
                        <div class="row">
                            <div class="col-md-4">
                                <label for="txtDescricao">Descrição</label>
                                <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" MaxLength="500"></asp:TextBox>                        
                            </div>                  
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="ddlFornecedor">Fornecedor</label>
                                <asp:DropDownList ID="ddlFornecedor" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Selecione" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>         
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="txtPrecoUnitario">Preço Unitário</label>
                                <asp:TextBox ID="txtPrecoUnitario" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label for="txtPrecoQuantidade">Preço Quantidade</label>
                                <asp:TextBox ID="txtPrecoQuantidade" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="txtQuantidadeReposicao">Quantidade Reposição</label>
                                <asp:TextBox ID="txtQuantidadeReposicao" runat="server" MaxLenght="8"></asp:TextBox>
                            </div>                    
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <asp:CheckBox ID="cbAtivo" runat="server" checked="true" Text="Ativo" ToolTip="Selecione para inativar o produto" />
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
            <a role="button" data-toggle="collapse" data-parent="#accordion" href="#produtos" aria-expanded="true" aria-controls="produtos">
                Produtos
            </a>
            </h4>
        </div>
        <div id="produtos" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingTwo">
            <div class="panel-body">
                <asp:UpdatePanel ID="upProdutos" runat="server" UpdateMode="Always">
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
                                    <asp:Button ID="btnPesquisar" runat="server" Text="Enviar" ClientIDMode="Static" OnClick="btnPesquisar_Click" CssClass="btn btn-default" />
                                </div>
                            </div>
                        </nav>
                        <div class="form-group pull-right">
                            <asp:Button ID="btnExcluir" runat="server" CssClass="btn btn-danger" Text="Excluir" />
                        </div>
                        <div class="form-group">
                            <asp:GridView ID="gvProdutos" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" GridLines="None"
                                AllowSorting="true"
                                OnSorting="gvProdutos_Sorting"
                                OnPageIndexChanging="gvProdutos_PageIndexChanging"
                                OnRowCommand="gvProdutos_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="Código" SortExpression="ID" DataFormatString="{0:000000}" />
                                    <asp:BoundField DataField="descricao" HeaderText="Descrição" SortExpression="descricao" />                     
                                    <asp:BoundField DataField="precounitario" HeaderText="Preço Unt." SortExpression="precounitario" />                     
                                    <asp:BoundField DataField="precoquantidade" HeaderText="Preço Qtd." SortExpression="precoquantidade" />                     
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
