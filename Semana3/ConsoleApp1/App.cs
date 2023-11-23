using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace produto
{
    public class App
    {
        private List<Produto> produtos = new List<Produto>();

        public void AddProduto()
        {
            string resposta = "s";

            do
            {
                Console.Write("Digite o nome do produto: ");
                string nome = Console.ReadLine();

                try
                {
                    Console.Write("Informe a quantidade em estoque: ");
                    int quantidade = int.Parse(Console.ReadLine());

                    Console.Write("Digite o preço unitário: ");
                    double preco = double.Parse(Console.ReadLine());

                    Produto novoProduto = new Produto(produtos.Count + 1, nome, quantidade, preco);
                    produtos.Add(novoProduto);
                }
                catch (FormatException)
                {
                    Console.WriteLine("A quantidade em estoque deve ser um número inteiro.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("A quantidade é muito grande ou muito pequena para ser armazenada.");
                }
                finally
                {
                    Console.Write("Deseja continuar? (s/n): ");
                    resposta = Console.ReadLine()?.ToLower();
                }

            } while (resposta == "s");
        }

        public void BuscarPorCodigo()
        {
            Console.WriteLine("Digite o código do produto: ");
            string codigoString = Console.ReadLine();

            if (int.TryParse(codigoString, out int codigo))
            {
                var produto = produtos.FirstOrDefault(p => p.Codigo == codigo);

                if (produto != null)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine($"Código: {produto.Codigo}");
                    Console.WriteLine($"Nome: {produto.Nome}");
                    Console.WriteLine($"Quantidade: {produto.QuantidadeEmEstoque}");
                    Console.WriteLine($"Preço: {produto.PrecoUnitario}");
                    Console.WriteLine("-----------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("Produto não localizado");
                    Console.WriteLine("-----------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Código inválido. Digite um número inteiro.");
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }

        public void BuscarTodos() {
            foreach (var produto in produtos)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Código: " + produto.Codigo);
                Console.WriteLine("Nome: " + produto.Nome);
                Console.WriteLine("Qauntidade: " + produto.QuantidadeEmEstoque);
                Console.WriteLine("Preço: " + produto.PrecoUnitario);
            }
        }

        public void AdicionarEstoque(int codigoProduto, int quantidade)
        {
            Produto produto = produtos.FirstOrDefault(p => p.Codigo == codigoProduto);

            if (produto != null)
            {
                produto.QuantidadeEmEstoque += quantidade;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"Estoque atualizado. Nova quantidade em estoque: {produto.QuantidadeEmEstoque}");
                Console.WriteLine("-----------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Produto não encontrado.");
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }

        public void RemoverEstoque(int codigoProduto, int quantidade)
        {
            Produto produto = produtos.FirstOrDefault(p => p.Codigo == codigoProduto);

            if (produto != null)
            {
                if (produto.QuantidadeEmEstoque >= quantidade)
                {
                    produto.QuantidadeEmEstoque -= quantidade;
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine($"Estoque atualizado. Nova quantidade em estoque: {produto.QuantidadeEmEstoque}");
                    Console.WriteLine("-----------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("Quantidade insuficiente em estoque para realizar a saída.");
                    Console.WriteLine("-----------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Produto não encontrado.");
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }

        public void RelatorioQuantidadeAbaixoLimite()
        {
            Console.Write("Digite o limite de quantidade em estoque: ");
            if (int.TryParse(Console.ReadLine(), out int limite))
            {
                var produtosAbaixoLimite = produtos.Where(p => p.QuantidadeEmEstoque < limite);

                Console.WriteLine("Produtos com quantidade em estoque abaixo do limite:");
                foreach (var produto in produtosAbaixoLimite)
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine($"Nome: {produto.Nome}, Quantidade: {produto.QuantidadeEmEstoque}");
                    
                }
            }
            else
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Limite inválido. Digite um número inteiro.");
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }
        
        public void RelatorioValorEntreMinMax()
        {
            Console.WriteLine("Digite o valor mínimo: ");
            if (int.TryParse(Console.ReadLine(), out int min))
            {
                Console.WriteLine("Digite o valor máximo: ");
                if (int.TryParse(Console.ReadLine(), out int max))
                {
                    var produtosEntreMinMax = produtos.Where(p => p.QuantidadeEmEstoque >= min && p.QuantidadeEmEstoque <= max);

                    if (produtosEntreMinMax.Any())
                    {
                        Console.WriteLine("Produtos com valor entre o mínimo e o máximo:");
                        foreach (var produto in produtosEntreMinMax)
                        {
                            Console.WriteLine("-----------------------------------------------------------------");
                            Console.WriteLine($"Nome: {produto.Nome}, Preço: {produto.PrecoUnitario}, Estoque: {produto.QuantidadeEmEstoque}");
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("Nenhum produto encontrado com valor entre o mínimo e o máximo.");
                        Console.WriteLine("-----------------------------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("Valor máximo inválido. Digite um número inteiro.");
                    Console.WriteLine("-----------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Valor mínimo inválido. Digite um número inteiro.");
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }

 

        public void RelatorioValorTotalEstoque()
        {
            double valorTotalEstoque = produtos.Sum(p => p.PrecoUnitario * p.QuantidadeEmEstoque);

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Valor total do estoque: {valorTotalEstoque}");
            Console.WriteLine("-----------------------------------------------------------------");

            Console.WriteLine("Valor total de cada produto de acordo com seu estoque:");
            foreach (var produto in produtos)
            {
                double valorTotalProduto = produto.PrecoUnitario * produto.QuantidadeEmEstoque;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"Nome: {produto.Nome}, Valor Total: {valorTotalProduto}");
            }
        }
    }
}
