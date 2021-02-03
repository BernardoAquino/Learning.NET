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
    public partial class FrmDetalhesProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CarregaDados();
                //Request.QueryString() permite que seja acessado o valor de uma chave passado via GET (URL)
                int idRecebido = Convert.ToInt32(Request.QueryString["idProduto"]);
            }
        }

        private void CarregaDados()
        {
            drpCategoria.DataSource = new CategoriaBLL().ListarCategorias();
            drpCategoria.DataTextField = "descricao";
            drpCategoria.DataValueField = "id";
            drpCategoria.DataBind();

            drpFornecedor.DataSource = new FornecedorBLL().ListarFornecedores();
            drpFornecedor.DataTextField = "nome";
            drpFornecedor.DataValueField = "id";
            drpFornecedor.DataBind();
        }
    }
}