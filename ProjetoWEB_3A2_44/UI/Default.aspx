<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjetoWEB_3A2_44.UI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>3A2 nº44 - Projeto WEB</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="form-signin">
        <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
            <a class="navbar-brand" href="default.aspx">Projeto WEB</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarCollapse">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="FrmMeuPerfil.aspx">Meu Perfil</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="FrmCliente.aspx">Clientes</a>
                    </li>
                </ul>

                <asp:Label ID="lblUsuarioLogado" runat="server" ForeColor="White" Text=""></asp:Label>
                <asp:Button ID="btnSair" runat="server" Text="Sair" OnClick="btnSair_Click" CssClass="btn btn-outline-success" />
            </div>
        </nav>

        <div class="jumbotron">
            <asp:Label ID="lblPesquisa" runat="server" Text="Digite o Produto que deseja Pesquisar:"></asp:Label>
            <p>
                <asp:TextBox ID="txtPesquisar" runat="server" class="form-control" Width="293px"></asp:TextBox>
                <asp:Button ID="btnPesquisar" runat="server" Class="btn btn-lg btn-primary" OnClick="btnPesquisar_Click" Text="Pesquisar" Width="136px" />
            </p>

            <asp:GridView ID="GridProdutos" CssClass="table table-dark" runat="server" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridProdutos_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Selecione">
                        <ItemTemplate>
                            <a href="FrmDetalhesProduto.aspx?idProduto=<%# Eval("id") %>">Detalhes</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Position="TopAndBottom" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
