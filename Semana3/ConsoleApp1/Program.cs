using produto;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

App app = new App();

int opcao = 1;

do{
    Console.WriteLine("Escolha uma opção");
    Console.WriteLine("1- Adicionar Produto");
    Console.WriteLine("2- Buscar Produto");
    Console.WriteLine("3- Adicionar Estoque");
    Console.WriteLine("4- Remover Estoque");
    Console.WriteLine("5- Relatórios");
    Console.WriteLine("10- Sair");
    opcao = int.Parse(Console.ReadLine()!);

    if (opcao == 1) 
    {
        app.AddProduto();

    }
    else if(opcao == 2)
    {
        app.BuscarProduto();
    }
    else if(opcao == 3)
    {
        Console.WriteLine("ADICIONAR - Digite o código: ");
        int codigo = int.Parse(Console.ReadLine()!);
        Console.WriteLine("ADICIONAR - Digite o estoque: ");
        int estoque = int.Parse(Console.ReadLine()!);
        app.AdicionarEstoque(codigo,estoque);
    }
    else if(opcao == 4)
    {
        Console.WriteLine("REMOVER - Digite o código: ");
        int codigo = int.Parse(Console.ReadLine()!);
        Console.WriteLine("REMOVER - Digite o estoque: ");
        int estoque = int.Parse(Console.ReadLine()!);
        app.RemoverEstoque(codigo,estoque);
    }
    else if(opcao == 5)
    {

    }
    else if(opcao == 10)
    {
        Console.WriteLine("Até log... bye bye!!");
    }

}while(opcao != 10);



/*foreach (Produto produto in produtos)

{
    Console.WriteLine($"Código: {produto.CodId}");
    Console.WriteLine($"Produto: {produto.Nome}");
    Console.WriteLine($"Quantidade: {produto.Quantidade}");
    Console.WriteLine($"Preço: {produto.Preco}"); 
}*/

