using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    class ClienteBLL
    {
        private DALProjeto dao;
        private string tabela = "tbl_cliente";

        public ClienteBLL() //Primeira coisa que irá ser executada quando a classe for instanciada(Método contrutor)
        {
            dao = new DALProjeto("localhost", "bd_produto", "root", "root");
        }

        public void InserirCliente(ClienteDTO dtoCliente)
        {
            dao.Insert(tabela, dtoCliente);
        }

        public void AlterarCliente(ClienteDTO dtoCliente)
        {
            dao.Update(tabela, dtoCliente, 0); //Na posição [0] encontra-se o id (PK)
        }

        public void ExcluirCliente(ClienteDTO dtoCliente)
        {
            dao.Delete(tabela, dtoCliente, 0);
        }

        public DataTable ListarCliente()
        {
            return dao.Select(tabela);
        }

        public  DataTable ListarCliente(string email_usuario)
        {
            return dao.Select(tabela, $"email = '{email_usuario}'");
        }

        public DataTable ListarCliente(string campo, string valor)
        {
            return dao.Select(tabela, $"{campo} like '%{valor}%'");
        }

        //-- Métodos para validação de usuários:

        public bool ValidarLogin(string user, string password) => dao.Select(tabela, $@"email = '{user}' AND
                                                                             senha = '{password}';").Rows.Count == 1;
        public bool ValidarLogin(string user)
        {
            DataTable resultado = dao.Select(tabela, $"email = '{user}';");
            return resultado.Rows.Count == 1 ? true : false;
        }

        //Para comentar ctrl + k + c para descomentar ctrl + k + u
        public int ValidarAcesso(string user, string password)
        {
            DataTable resultado = dao.Select(tabela, $"email = '{user}' AND senha = '{password}';");
            return resultado.Rows.Count == 1 ? Convert.ToInt32(resultado.Rows[0]["TipoUsuario"]) : -1;
        }
    }
}
