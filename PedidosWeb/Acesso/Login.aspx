<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PedidosWeb.Acesso.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />

    <style type="text/css">
        body {
            padding-top: 40px;
            padding-bottom: 40px;
            background-color: #f5f5f5;
        }

        .form-signin {
            max-width: 300px;
            padding: 19px 29px 29px;
            margin: 0 auto 20px;
            background-color: #fff;
            border: 1px solid #e5e5e5;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.05);
            -moz-box-shadow: 0 1px 2px rgba(0,0,0,.05);
            box-shadow: 0 1px 2px rgba(0,0,0,.05);
        }

            .form-signin .form-signin-heading,
            .form-signin .checkbox {
                margin-bottom: 10px;
            }

            .form-signin input[type="text"],
            .form-signin input[type="password"] {
                font-size: 16px;
                height: auto;
                margin-bottom: 15px;
                padding: 7px 9px;
            }

        .erro {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" class="form-signin" runat="server">
        
        <div class="container">
            <h2 class="form-signin-heading">Acesso</h2>
            <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" placeholder="Login"></asp:TextBox>
            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" placeholder="Senha" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvLogin" runat="server" CssClass="erro" Text="- Preencha o Login <br />" ControlToValidate="txtLogin"
                SetFocusOnError="true" Display="Dynamic" ValidationGroup="vgLogin"></asp:RequiredFieldValidator>  
            <asp:RequiredFieldValidator ID="rfvSenha" runat="server" CssClass="erro" Text="- Preencha o Senha <br /><br />" ControlToValidate="txtSenha"
                SetFocusOnError="true" Display="Dynamic" ValidationGroup="vgLogin"></asp:RequiredFieldValidator>            
            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-large btn-primary" Text="Login" OnClick="btnLogin_Click" ValidationGroup="vgLogin" />
        </div>
        <!-- /container -->
    </form>
    <!-- /container -->
</body>
</html>