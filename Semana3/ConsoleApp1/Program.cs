using produto;
using System.Globalization;
using System.Runtime.InteropServices.Marshalling;

CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

App app = new App();

int opcao = 1;

do{
    Console.WriteLine(" ");
    Console.WriteLine("*******> MENU <********");
    Console.WriteLine("-----------------------");
    Console.WriteLine("1- Adicionar Produto");
    Console.WriteLine("2- Buscar Por código");
    Console.WriteLine("3- Buscar Produtos(Todos)");
    Console.WriteLine("4- Adicionar Estoque");
    Console.WriteLine("5- Remover Estoque");
    Console.WriteLine("6- Rel. Qtd Abaixo Limite");
    Console.WriteLine("7- Rel. Máx e Mín");
    Console.WriteLine("8- Rel. Valores(R$) em Estoque");
    Console.WriteLine("9- Sair");
    Console.WriteLine("-----------------------");
    Console.Write("Escolha um opção: ");
    opcao = int.Parse(Console.ReadLine()!);

    if (opcao == 1) 
    {
        app.AdicionarProduto();

    }
    else if(opcao == 2)
    {
        app.BuscarPorCodigo();
    }
     else if(opcao == 3)
    {
        app.BuscarTodos();
    }
    else if(opcao == 4)
    {
        Console.WriteLine("ADICIONAR - Digite o código: ");
        int codigo = int.Parse(Console.ReadLine()!);
        Console.WriteLine("ADICIONAR - Digite a quantidade a ser ADICIONADA ao estoque: ");
        int estoque = int.Parse(Console.ReadLine()!);
        app.AdicionarEstoque(codigo,estoque);
    }
    else if(opcao == 5)
    {
        Console.WriteLine("REMOVER - Digite o código: ");
        int codigo = int.Parse(Console.ReadLine()!);
        Console.WriteLine("REMOVER - Digite a quantidade a ser REMOVIDA do estoque: ");
        int estoque = int.Parse(Console.ReadLine()!);
        app.RemoverEstoque(codigo,estoque);
    }
    else if(opcao == 6)
    {
        app.RelatorioQuantidadeAbaixoLimite();
    }
    else if(opcao == 7)
    {
        app.RelatorioValorEntreMinMax();
    }
    else if(opcao == 8)
    {
        app.RelatorioValorTotalEstoque();
    }
    else if(opcao == 9)
    {
        Console.WriteLine("Programa Concluído com sucesso!!");
    }

}while(opcao != 9);