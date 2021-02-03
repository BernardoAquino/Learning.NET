using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using BLL;

namespace ProjetoWEB_3A2_44.UI
{
    public partial class FrmNovoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmCliente.aspx");
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteDTO dtoCliente = new ClienteDTO();
                if(txtSenha.Text != txtConfirmaSenha.Text)
                {
                    lblMensagemErro.Text = "As senhas não conferem";
                }else
                {
                    dtoCliente.Nome = txtNome.Text;
                    dtoCliente.Endereco = txtEndereco.Text;
                    dtoCliente.Telefone = txtTelefone.Text;
                    dtoCliente.Uf = drpUF.Text;
                    dtoCliente.Email = txtEmail.Text;
                    dtoCliente.Senha = txtSenha.Text;
                    dtoCliente.TipoUsuario = 2;

                    new ClienteBLL().InserirCliente(dtoCliente);
                    lblMensagemErro.Text = "Dados cadastrados com sucesso.";
                }
            }catch(Exception ex)
            {
                lblMensagemErro.Text = ex.Message;
            }
        }
    }
}