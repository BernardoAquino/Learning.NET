<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="ProjetoWEB_3A2_44.UI.FrmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/signin.css" rel="stylesheet" />
</head>
<body class="text-center">
    <form id="form1" runat="server" class="form-signin">
        <div>
            <h2>Bem-vindo</h2>
        </div>
        <div>
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="ReqEmail" 
                ControlToValidate="txtEmail" 
                ForeColor="RoyalBlue"
                SetFocusOnError="true"
                ErrorMessage="Digite o e-mail"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnEntrar" runat="server" Text="ENTRAR" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnEntrar_Click"/>
        </div>
        <div>
            <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Magenta"></asp:Label>
        </div>
    </form>
</body>
</html>
