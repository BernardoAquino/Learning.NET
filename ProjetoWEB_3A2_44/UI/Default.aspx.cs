using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ProjetoWEB_3A2_44.UI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioLogado"] == null)
            {
                Response.Redirect("FrmLogin.aspx");
            }else
            {
                lblUsuarioLogado.Text = Session["usuarioLogado"].ToString();
                if (!IsPostBack) //Se a página estiver sendo carregada pela primeira vez
                {
                    CarregarGridProdutos();
                }
            }
        }

        private void CarregarGridProdutos()
        {
            GridProdutos.DataSource = new ProdutoBLL().ListarProdutos();
            GridProdutos.DataBind(); //Vincula os dados para serem exibidos no browser.
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            GridProdutos.DataSource = new ProdutoBLL().ListarProdutos(txtPesquisar.Text);
            GridProdutos.DataBind();
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session["usuarioLogado"] = null;
            Response.Redirect("FrmLogin.aspx");
        }

        protected void GridProdutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridProdutos.PageIndex = e.NewPageIndex;
            CarregarGridProdutos();
        }
    }
}