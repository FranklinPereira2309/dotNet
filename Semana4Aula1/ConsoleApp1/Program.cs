using System;

class Veiculo
{
    
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }

    public Veiculo(string modelo, int ano, string cor)
    {
        Modelo = modelo;
        Ano = ano;
        Cor = cor;
    }
    
    
}

class Program
{
    
    static void Main()
    {
        
        Console.WriteLine("Digite o Modelo: ");
        string modelo = Console.ReadLine()!;
        Console.WriteLine("Digite o Ano: ");
        int ano = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Digite a Cor: ");
        string cor = Console.ReadLine()!;

        Veiculo meuVeiculo = new Veiculo(modelo, ano, cor);

        
       
        Console.WriteLine("Informações do Veículo:");
        Console.WriteLine($"Modelo: {meuVeiculo.Modelo}");
        Console.WriteLine($"Ano: {meuVeiculo.Ano}");
        Console.WriteLine($"Cor: {meuVeiculo.Cor}");
    }
}
