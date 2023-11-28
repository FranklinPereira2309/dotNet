namespace pessoa{}
public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }

    public int Idade => DateTime.Now.Year - DataNascimento.Year;

    public Pessoa(string nome, DateTime dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
    }
}

public class Treinador : Pessoa
{
    public string CPF { get; set; }
    public string CREF { get; set; }

    public Treinador(string nome, DateTime dataNascimento, string cpf, string cref)
        : base(nome, dataNascimento)
    {
        
        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            throw new ArgumentException("CPF deve conter 11 dígitos numéricos.");
        }

        CPF = cpf;
        CREF = cref;
    }
}

public class Cliente : Pessoa
{
    public string CPF { get; set; }
    public double Altura { get; set; }
    public double Peso { get; set; }

    public double CalcularIMC()
    {
        if (Altura <= 0 || Peso <= 0)
        {
            throw new InvalidOperationException("Altura e peso devem ser positivos.");
        }

        return Peso / (Altura * Altura);
    }

    public Cliente(string nome, DateTime dataNascimento, string cpf, double altura, double peso)
        : base(nome, dataNascimento)
    {
        // Validar CPF com 11 dígitos
        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            throw new ArgumentException("CPF deve conter 11 dígitos numéricos.");
        }

        CPF = cpf;
        Altura = altura;
        Peso = peso;
    }
}
