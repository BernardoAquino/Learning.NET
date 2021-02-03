<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCliente.aspx.cs" Inherits="ProjetoWEB_3A2_44.UI.FrmCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Manutenção de Clientes</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3>Clientes</h3>

            <p></p>
            <asp:Label ID="lblPesquisa" runat="server" Text="Digite o nome do Cliente que deseja pesquisar"></asp:Label>
            <asp:TextBox ID="txtPesquisar" runat="server" Class="form-control" Width="293px"></asp:TextBox>
            <p></p>
            <asp:Button ID="btnPesquisar" runat="server" CssClass="btn btn-lg btn-primary" Text="Pesquisar" OnClick="btnPesquisar_Click"/>
            <p></p>

            <asp:GridView ID="gridClientes" CssClass="table table-dark" runat="server" AllowPaging="True"
                OnPageIndexChanging="gridClientes_PageIndexChanging" 
                PageSize="4" 
                OnRowCancelingEdit="gridClientes_RowCancelingEdit" 
                OnRowEditing="gridClientes_RowEditing" 
                OnRowDeleting="gridClientes_RowDeleting" 
                OnRowUpdating="gridClientes_RowUpdating">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnNovoCliente" runat="server" CssClass="btn btn-lg btn-primary" Text="Novo Cliente" OnClick="btnNovoCliente_Click"/>
            <asp:Button ID="btnVoltar" runat="server" CssClass="btn btn-lg btn-primary" Text="Voltar" OnClick="btnVoltar_Click"/>
        </div>
    </form>
</body>
</html>
