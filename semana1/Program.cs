
        Console.WriteLine();
        Console.WriteLine("Parte 2:");

        Console.WriteLine();

        Console.WriteLine("Valores mínimos e máximos dos tipos de dados numéricos inteiros em C#:");

        Console.WriteLine($"sbyte: {sbyte.MinValue} a {sbyte.MaxValue}");
        Console.WriteLine($"byte: {byte.MinValue} a {byte.MaxValue}");
        Console.WriteLine($"short: {short.MinValue} a {short.MaxValue}");
        Console.WriteLine($"ushort: {ushort.MinValue} a {ushort.MaxValue}");
        Console.WriteLine($"int: {int.MinValue} a {int.MaxValue}");
        Console.WriteLine($"uint: {uint.MinValue} a {uint.MaxValue}");
        Console.WriteLine($"long: {long.MinValue} a {long.MaxValue}");
        Console.WriteLine($"ulong: {ulong.MinValue} a {ulong.MaxValue}");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine();

        Console.WriteLine("Parte 3:");
        
        Console.WriteLine();

        double numeroDouble = 10.9;
        int numeroCasting = (int)numeroDouble; // Convertido sem a parte fracionária
        int numeroCastingArred = (int)Math.Round(numeroDouble); // Solução com arredondamento

        Console.WriteLine($"Número double: {numeroDouble}");
        Console.WriteLine($"Número double convertido sem a parte fracionária: {numeroCasting}");
        Console.WriteLine($"Número inteiro convertido com arredondamento: {numeroCastingArred}");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine();

        Console.WriteLine("Parte 4:");
        
        Console.WriteLine();

        int x = 10;
        int y = 2;
        int resultado;

        Console.WriteLine($"Soma: {resultado = x + y}");
        Console.WriteLine($"Subtração: {resultado = x - y}");
        Console.WriteLine($"Divisão: {resultado = x / y}");
        Console.WriteLine($"Multiplicação: {resultado = x * y}");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine();

        Console.WriteLine("Parte 5:");
        
        Console.WriteLine();

        int a = 5;
        int b = 8;

        if (a > b)
        {
            Console.WriteLine("a é maior que b");
        }
        else if (a < b)
        {
            Console.WriteLine("a é menor que b");
        }
        else if (a == b)
        {
            Console.WriteLine("a é igual a b");
        }
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine();

        Console.WriteLine("Parte 6:");
        
        Console.WriteLine();

        string str1 = "Hello";
        string str2 = "World";

        if (str1.Equals(str2))
        {
            Console.WriteLine("As strings SÃO iguais");
        }
        else
        {
            Console.WriteLine("As strings NÃO são iguais");
        }
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine();

        Console.WriteLine("Parte 7:");
        
        Console.WriteLine();

        bool condicao1 = true;
        bool condicao2 = false;

        if (condicao1 && condicao2)
        {
            Console.WriteLine("Ambas as condições são verdadeiras.");
        }
        else
        {
            Console.WriteLine("Pelo menos uma das condições não é verdadeira.");
        }
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine();

        Console.WriteLine("Parte 8:");
        
        Console.WriteLine();

        int num1 = 7, num2 = 3, num3 = 10;

        if (num1 > num2 && num3 == num1 + num2)
        {
            Console.WriteLine("Sim - As condições satisfazem o problema!");
        }
        else
        {
            Console.WriteLine("Não - As condições NÃO satisfazem o problema!");
        }

