using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ProdutoDTO
    {
        private int id;
        private string descricao;
        private double preco;
        private int quantidade;
        private double peso;
        private int fornecedor_id;
        private int categoria_id;

        public int Id { get => id; set => id = value; }
        public int Categoria_id { get => categoria_id; set => categoria_id = value; }
        public int Fornecedor_id { get => fornecedor_id; set => fornecedor_id = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public double Preco { get => preco; set => preco = value; }
        public double Peso { get => peso; set => peso = value; }
        public string Descricao { get => descricao; set => descricao = value; }
    }
}
