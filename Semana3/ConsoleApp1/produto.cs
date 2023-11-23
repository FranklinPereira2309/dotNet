using System;
using System.Collections.Generic;
using System.Linq;

namespace produto
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }

        public Produto(int codigo, string nome, int quantidade, double preco)
        {
            Codigo = codigo;
            Nome = nome;
            Quantidade = quantidade;
            Preco = preco;
        }
    }
}