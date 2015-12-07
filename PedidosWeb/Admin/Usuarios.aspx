<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="PedidosWeb.Admin.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Administracao.js"></script>
    <asp:Panel ID="pnCadastro" runat="server" CssClass="panel panel-default" DefaultButton="btnSalvar">
        <div class="panel-heading" role="tab" id="headingOne">
            <h4 class="panel-title">
                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#cadastro" aria-expanded="true" aria-controls="cadastro">Cadastro
                </a>
            </h4>
        </div>
        <div id="cadastro" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
            <div class="panel-body">
                <asp:UpdatePanel ID="ipCadastro" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="form-group">
                            <label for="txtID">Código</label>
                            <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtNome">Nome</label>
                            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="500"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome" CssClass="erro" Display="Dynamic"
                                ErrorMessage="Campo obrigatório." SetFocusOnError="true" ValidationGroup="vgUsuario"></asp:RequiredFieldValidator>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label for="txtLogin">Login</label>
                                <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ControlToValidate="txtLogin" CssClass="erro" Display="Dynamic"
                                    ErrorMessage="Campo obrigatório." SetFocusOnError="true" ValidationGroup="vgUsuario"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvLogin"  runat="server" controltovalidate="txtLogin" ErrorMessage="O nome de usuário deve ter mais que 6 caractéres" />
                            </div>                                                        
                            <div class="col-md-4">
                                <label for="txtSenha">Senha</label>
                                <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ControlToValidate="txtSenha" CssClass="erro" Display="Dynamic"
                                    ErrorMessage="Campo obrigatório." SetFocusOnError="true" ValidationGroup="vgUsuario"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtEmail">E-mail</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" MaxLength="400"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="ddlPerfil">Tipo</label>
                            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:CheckBox ID="cbAtivo" runat="server" Text="Ativo" Checked="true" ToolTip="Desmarque esta opção para desativar o usuário." CssClass="checkbox" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" ValidationGroup="vgUsuario" OnClientClick="ScrollTop();" OnClick="btnSalvar_Click" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                        </div>
                        <asp:HiddenField ID="hfTipoOperacao" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnUsuarios" runat="server" CssClass="panel panel-default" DefaultButton="btnPesquisar">
        <div class="panel-heading" role="tab" id="headingTwo">
            <h4 class="panel-title">
                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#usuarios" aria-expanded="true" aria-controls="usuarios">Páginas
                </a>
            </h4>
        </div>
        <div id="usuarios" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingTwo">
            <div class="panel-body">
                <asp:UpdatePanel ID="upUsuarios" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <nav class="navbar navbar-default">
                            <div class="container-fluid">
                                <div class="navbar-header">
                                    <p class="navbar-brand">Filtro</p>
                                </div>
                                <div class="navbar-form navbar-left">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" placeholder="Pesquisar"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlAtivoFiltro" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Todos" Value="2"></asp:ListItem>
                                            <asp:ListItem Selected="True" Text="Ativos" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Inativos" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:Button ID="btnPesquisar" runat="server" Text="Enviar" CssClass="btn btn-default" OnClick="btnPesquisar_Click" />
                                </div>
                            </div>
                        </nav>
                        <div class="form-group pull-right">
                            <asp:Button ID="btnExcluir" runat="server" CssClass="btn btn-danger" Text="Excluir" OnClientClick="ScrollTop();" OnClick="btnExcluir_Click" />
                        </div>
                        <div class="form-group">
                            <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" GridLines="None"
                                AllowSorting="true"
                                AllowPaging="true"
                                PageSize="20"
                                OnSorting="gvUsuarios_Sorting"
                                OnPageIndexChanging="gvUsuarios_PageIndexChanging"
                                OnRowCommand="gvUsuarios_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelecionar" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ID" HeaderText="Código" SortExpression="ID" DataFormatString="{0:000000}" />
                                    <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome" />
                                    <asp:BoundField DataField="login" HeaderText="Login" SortExpression="login" />
                                    <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                                    <asp:TemplateField HeaderText="Alterar" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btn" runat="server" CssClass="glyphicon glyphicon-pencil" CommandName="Alterar" OnClientClick="Alterar();"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
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
