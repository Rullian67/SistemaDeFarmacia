using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
     class Remedio
    {
        string nome;
        int quantidade;
        float preco;
        int categoria;

        public string Nome { get => nome; set => nome = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public float Preco { get => preco; set => preco = value; }
        public int Categoria { get => categoria; set => categoria = value; }
    }
}
