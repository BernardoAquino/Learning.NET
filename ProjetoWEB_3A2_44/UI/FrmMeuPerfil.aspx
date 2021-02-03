<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmMeuPerfil.aspx.cs" Inherits="ProjetoWEB_3A2_44.UI.FrmMeuPerfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>3A2 nº44 - Projeto WEB</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3>Meu Perfil</h3>

            <asp:Label ID="lblID" runat="server" Text="ID:"></asp:Label>
            <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>

            <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label ID="lblEndereco" runat="server" Text="Endereço:"></asp:Label>
            <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control"></asp:TextBox>

            <div>
                <asp:Label ID="lblUF" runat="server" Text="UF:"></asp:Label>
            </div>
            <div>
                <asp:DropDownList ID="drpUF" runat="server">
                    <asp:ListItem>MG</asp:ListItem>
                    <asp:ListItem>RJ</asp:ListItem>
                    <asp:ListItem>ES</asp:ListItem>
                    <asp:ListItem>SP</asp:ListItem>
                    <asp:ListItem>SC</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="lblTelefone" runat="server" Text="Telefone:"></asp:Label>
            </div>
            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>

            <asp:Label ID="lblSenha" runat="server" Text="Nova Senha:"></asp:Label>
            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

            <asp:Label ID="lblConfirmaSenha" runat="server" Text="Confirmar Senha:"></asp:Label>
            <div>
                <asp:TextBox ID="txtConfirmaSenha" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnGravar" runat="server" Text="Gravar" CssClass="btn btn-lg btn-primary" OnClick="btnGravar_Click"/>
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn btn-lg btn-secondary" OnClick="btnVoltar_Click"/>
            </div>

            <asp:Label ID="lblMensagemErro" runat="server" ForeColor="Purple"></asp:Label>
        </div>

    </form>
</body>
</html>
