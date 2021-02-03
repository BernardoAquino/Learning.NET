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
    class FornecedorBLL
    {
        private DALProjeto dao;
        private string tabela = "tbl_fornecedor";

        public FornecedorBLL()
        {
            dao = new DALProjeto("localhost", "bd_produto", "root", "root");
        }

        public void InserirFornecedor(FornecedorDTO dtoFornecedor)
        {
            dao.Insert(tabela, dtoFornecedor);
        }
        public DataTable ListarFornecedores()
        {
            return dao.Select(tabela);
        }

        public void AlterarFornecedor(FornecedorDTO dtoFornecedor)
        {
            dao.Update(tabela, dtoFornecedor, 0);
        }

        public void ExcluirFornecedor(FornecedorDTO dtoFornecedor)
        {
            dao.Delete(tabela, dtoFornecedor, 0);
        }
    }
}
