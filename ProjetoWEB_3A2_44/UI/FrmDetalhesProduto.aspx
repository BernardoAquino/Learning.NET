<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDetalhesProduto.aspx.cs" Inherits="ProjetoWEB_3A2_44.UI.FrmDetalhesProduto" %>

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
            <h3>Produtos</h3>
            <asp:Label ID="lblID" runat="server" Text="ID:"></asp:Label>
            <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

            <asp:Label ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label>
            <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

            <asp:Label ID="lblPreco" runat="server" Text="Preço:"></asp:Label>
            <asp:TextBox ID="txtPreco" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

            <asp:Label ID="lblQuantidade" runat="server" Text="Quantidade:"></asp:Label>
            <asp:TextBox ID="txtQuantidade" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

            <asp:Label ID="lblPeso" runat="server" Text="Peso:"></asp:Label>
            <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

            <asp:Label ID="lblCategoria" runat="server" Text="Categoria:"></asp:Label>
            <div>
                <asp:DropDownList ID="drpCategoria" runat="server"></asp:DropDownList>
            </div>

            <asp:Label ID="lblFornecedor" runat="server" Text="Fornecedor:"></asp:Label>
            <div>
                <asp:DropDownList ID="drpFornecedor" runat="server"></asp:DropDownList>
            </div>

            <asp:Button ID="btnGravar" runat="server" Class="btn btn-lg btn-primary" Text="Gravar" Width="136px"/>
            <asp:Button ID="btnVoltar" runat="server" Class="btn btn-lg btn-primary" Text="Voltar" Width="136px"/>
            <p></p>
            <asp:Label ID="lblMensagem" runat="server" ForeColor="Tomato"></asp:Label>
        </div>
    </form>
</body>
</html>
