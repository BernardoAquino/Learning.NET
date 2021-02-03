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
    public partial class FrmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        ClienteDTO dtoCliente = new ClienteDTO(); //objeto para verificcação de usuário

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                dtoCliente.Email = txtEmail.Text;
                dtoCliente.Senha = txtSenha.Text; //com validação de preenchimento obrigatóriio realizada na DTO

                if (!new ClienteBLL().ValidarLogin(dtoCliente.Email))
                    lblErrorMessage.Text = "Usuário não existe.";
                else if (!new ClienteBLL().ValidarLogin(dtoCliente.Email, dtoCliente.Senha))
                    lblErrorMessage.Text = "Senha não existe.";
                else
                {
                    Session["usuarioLogado"] = dtoCliente.Email;
                    Response.Redirect("Default.aspx"); //Faz o redirecionamento para uma nova página
                }
                    
            }
            catch(Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}