using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class TipoUsuarioDTO
    {
        private int id;
        private string descricao;
        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
    }
}
