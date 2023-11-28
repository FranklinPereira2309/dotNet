using System;

class ContaBancaria
{
    private double _saldo;

    public double Saldo
    {
        get { return _saldo; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Saldo não pode ser negativo");
            }

            _saldo = value;
        }
    }

    
}

class Program
{
    static void Main()
    {
        ContaBancaria minhaConta = new ContaBancaria();
        
        try
        {
            Console.WriteLine("Digite Saldo: ");
            minhaConta.Saldo = Double.Parse(Console.ReadLine()!);
            Console.WriteLine($"Saldo atual: {minhaConta.Saldo}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
