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
    class TipoUsuarioBLL
    {
        private DALProjeto dao;
        private string tabela = "tbl_tipousuario";

        public TipoUsuarioBLL()
        {
            dao = new DALProjeto("localhost", "bd_produto", "root", "root");
        }

        public void InserirTipoUsuario(TipoUsuarioDTO dtoTipoUsuario)
        {
            dao.Insert(tabela, dtoTipoUsuario);
        }
        public DataTable ListarTipoUsuario()
        {
            return dao.Select(tabela);
        }

        public void AlterarTipoUsuario(TipoUsuarioDTO dtoTipoUsuario)
        {
            dao.Update(tabela, dtoTipoUsuario, 0);
        }

        public void ExcluirTipoUsuario(TipoUsuarioDTO dtoTipoUsuario)
        {
            dao.Delete(tabela, dtoTipoUsuario, 0);
        }
    }
}
