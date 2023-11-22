using produto;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

List<Produto> produtos = App.AddProduto();

foreach (Produto produto in produtos)

{
    Console.WriteLine($"Código: {produto.CodId}");
    Console.WriteLine($"Produto: {produto.Nome}");
    Console.WriteLine($"Quantidade: {produto.Quantidade}");
    Console.WriteLine($"Preço: {produto.Preco}"); 
}