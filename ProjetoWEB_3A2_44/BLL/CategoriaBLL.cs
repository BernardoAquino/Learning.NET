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
    class CategoriaBLL
    {
        private DALProjeto dao;
        private string tabela = "tbl_categoria";

        public CategoriaBLL()
        {
            dao = new DALProjeto("localhost", "bd_produto", "root", "root");
        }

        public void InserirCategoria(CategoriaDTO dtoCategoria)
        {
            dao.Insert(tabela, dtoCategoria);
        }
        public DataTable ListarCategorias()
        {
            return dao.Select(tabela);
        }

        public void AlterarCategoria(CategoriaDTO dtoCategoria)
        {
            dao.Update(tabela, dtoCategoria, 0);
        }

        public void ExcluirCategoria(CategoriaDTO dtoCategoria)
        {
            dao.Delete(tabela, dtoCategoria, 0);
        }
    }
}
