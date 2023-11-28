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

    // Outros membros e métodos da classe podem ser adicionados conforme necessário
}

class Program
{
    static void Main()
    {
        ContaBancaria minhaConta = new ContaBancaria();

        // Testando a definição de saldo positivo
        minhaConta.Saldo = 1000.00;
        Console.WriteLine($"Saldo atual: {minhaConta.Saldo}");

        // Tentando definir um saldo negativo (deve lançar uma exceção)
        try
        {
            minhaConta.Saldo = -500.00;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
