using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.WriteLine("Digite o nome do produto: ");
                string nome = Console.ReadLine();

                try
                {
                    Console.WriteLine("Informe a quantidade em estoque: ");
                    int quantidade = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o preço unitário: ");
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
                    Console.WriteLine("Deseja continuar? (s/n): ");
                    resposta = Console.ReadLine()?.ToLower();
                }

            } while (resposta == "s");
        }

        public void BuscarProduto()
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
    }
}
