using System.Security.Cryptography.X509Certificates;

public class Produto {
    public int Codigo {get; set;}
    public string Nome {get; set;}
    public int Quantidade {get; set;}

    public Produto(int _codigo, string _nome, int _quantidade) {
        Codigo = _codigo;
        Nome = _nome;
        Quantidade = _quantidade;
    }
    
}

public class CadastrarProdutos {
    public List<Produto> Produtos {get; set;}
}


