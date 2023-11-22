namespace produto 
{

public class Produto {
    public int Codigo {get;}
    public int CodId {get; set;} = 1;
    public string Nome {get; set;}
    public int Quantidade {get; set;}
    public double Preco {get; set;}

    public Produto(string _nome, int _quantidade, double _preco) {
        Codigo = ++CodId;
        Nome = _nome;
        Quantidade = _quantidade;
        Preco = _preco;
    }
}
    
}




