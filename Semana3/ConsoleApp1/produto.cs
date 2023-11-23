namespace produto
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public double PrecoUnitario { get; set; }

        public Produto(int codigo, string nome, int quantidade, double preco)
        {
            Codigo = codigo;
            Nome = nome;
            QuantidadeEmEstoque = quantidade;
            PrecoUnitario = preco;
        }
    }
}
