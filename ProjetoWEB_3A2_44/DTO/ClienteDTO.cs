using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ClienteDTO
    {
        //Criar os atributos com o mesmo nome e ordem dos campos da tabela tbl_cliente
        private int id;
        private string nome;
        private string endereco;
        private string uf;
        private string telefone;
        private string email;
        private string senha;
        private int tipoUsuario;

        //A geração do Encapsulamento pode ser realizada através do atalho CTRL + R + E

        public int Id { get => id; set => id = value; }
        public int TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Uf { get => uf; set => uf = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { 
            get => senha; 
            set 
            {   
                senha = (value != "") ? value : throw new Exception("Informe uma senha.");
                /*if (value != "")
                    senha = value;
                else
                    throw new Exception("Informe uma senha.");*/
            }
        }

        //Ou apenas criando direto os métodos encapsulados da seguinte maneira:

        /*public int Id { get; set; }
        public int TipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Uf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }*/
    }
}
