using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;
using System.Data;

namespace ProjetoWEB_3A2_44.UI
{
    public partial class FrmMeuPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ExibirDados();
            }
        }

        private void ExibirDados()
        {
            //Busca dos dados do usuário logado (armazenado na sessão)
            DataTable dados = new ClienteBLL().ListarCliente(Session["usuarioLogado"].ToString());

            txtID.Text = dados.Rows[0]["id"].ToString();
            txtNome.Text = dados.Rows[0]["nome"].ToString();
            txtEndereco.Text = dados.Rows[0]["endereco"].ToString();
            drpUF.Text = dados.Rows[0]["uf"].ToString();
            txtTelefone.Text = dados.Rows[0]["telefone"].ToString();
            txtEmail.Text = dados.Rows[0]["email"].ToString();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtSenha.Text != txtConfirmaSenha.Text)
                {
                    lblMensagemErro.Text = "As senhas não conferem.";
                }else
                {
                    ClienteDTO dtoCliente = new ClienteDTO();
                    //Armazenar os dados fornecidos da página na classe DTO.
                    dtoCliente.Id = Convert.ToInt32(txtID.Text);
                    dtoCliente.Nome = txtNome.Text;
                    dtoCliente.Endereco = txtEndereco.Text;
                    dtoCliente.Uf = drpUF.Text;
                    dtoCliente.Telefone = txtTelefone.Text;
                    dtoCliente.Email = txtEmail.Text;
                    dtoCliente.Senha = txtSenha.Text;
                    dtoCliente.TipoUsuario = 2;

                    //Chamar o método de update atraés da BLL;
                    new ClienteBLL().AlterarCliente(dtoCliente);

                    lblMensagemErro.Text = "Dados atualizados com sucesso.";
                }
            }catch(Exception ex)
            {
                lblMensagemErro.Text = ex.Message;
            }
        }
    }
}