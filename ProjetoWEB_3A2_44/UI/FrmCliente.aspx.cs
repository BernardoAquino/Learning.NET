using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;

namespace ProjetoWEB_3A2_44.UI
{
    public partial class FrmCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ExibirClientes();
            }
        }

        ClienteDTO dtoCliente = new ClienteDTO();

        private void ExibirClientes()
        {
            gridClientes.DataSource = new ClienteBLL().ListarCliente();
            gridClientes.DataBind();
        }

        protected void gridClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridClientes.PageIndex = e.NewPageIndex;
            ExibirClientes();
        }

        protected void gridClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridClientes.EditIndex = e.NewEditIndex;
            ExibirClientes();
        }

        protected void gridClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridClientes.EditIndex = -1;
            ExibirClientes();
        }

        protected void gridClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dtoCliente.Id = Convert.ToInt32(e.Values["id"]); //Ou ainda e.Values[0]
            new ClienteBLL().ExcluirCliente(dtoCliente);
            ExibirClientes();
        }

        protected void gridClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                dtoCliente.Id = Convert.ToInt32(e.NewValues["id"]);
                dtoCliente.Nome = e.NewValues["nome"].ToString();
                dtoCliente.Endereco = e.NewValues["endereco"].ToString();
                dtoCliente.Uf = e.NewValues["uf"].ToString();
                dtoCliente.Telefone = e.NewValues["telefone"].ToString();
                dtoCliente.Email = e.NewValues["email"].ToString();
                dtoCliente.Senha = e.NewValues["senha"].ToString();
                dtoCliente.TipoUsuario = 2;

                new ClienteBLL().AlterarCliente(dtoCliente);
                gridClientes.EditIndex = -1;
                ExibirClientes();
            }catch(Exception)
            {
                throw;
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            gridClientes.DataSource = new ClienteBLL().ListarCliente("nome", txtPesquisar.Text);
            gridClientes.DataBind();
            txtPesquisar.Text = "";
        }

        protected void btnNovoCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmNovoCliente.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}