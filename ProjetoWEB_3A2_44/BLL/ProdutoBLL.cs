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
    class ProdutoBLL
    {
        private DALProjeto dao;
        private string tabela = "tbl_produto";

        //Criação do método construtor da classe

        public ProdutoBLL() //Criação é padrão, não retorna nunca
        {
            dao = new DALProjeto("localhost", "bd_produto", "root", "root"); //Possibilidade de usar mais de um banco
        }

        public void InserirProduto(ProdutoDTO dtoProduto) //Recebe objeto já existente
        {
            dao.Insert(tabela, dtoProduto);
        }
        public DataTable ListarProdutos()
        {
            return dao.Select(tabela);
        }

        public DataTable ListarProdutos(string valor)
        {
            return dao.Select(tabela, $"descricao like '%{valor}%' ORDER BY descricao;");
        }

        public void AlterarProduto(ProdutoDTO dtoProduto)
        {
            dao.Update(tabela, dtoProduto, 0);
        }

        public void ExcluirProduto(ProdutoDTO dtoProduto)
        {
            dao.Delete(tabela, dtoProduto, 0);
        }
    }
}
