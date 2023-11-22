using produto;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

App app = new App();


app.buscarProduto();

/*foreach (Produto produto in produtos)

{
    Console.WriteLine($"Código: {produto.CodId}");
    Console.WriteLine($"Produto: {produto.Nome}");
    Console.WriteLine($"Quantidade: {produto.Quantidade}");
    Console.WriteLine($"Preço: {produto.Preco}"); 
}*/

