namespace produto;

public class App {
    List<Produto> produtos = new List<Produto>();
    public void AddProduto()
    {
        string resposta = "s";

        do 
        {

            Console.WriteLine("Digite o nome do produto: ");
            string nome = Console.ReadLine()!;

            try
            {
                Console.WriteLine("Informe a quantidade em estoque: ");
                string qtdString = Console.ReadLine()!;
                int quantidade = int.Parse(qtdString);  
                Console.WriteLine("Digite o preço unitário: ");
                string precoString = Console.ReadLine()!;
                double preco = double.Parse(precoString);
                Produto produto = new Produto(nome,quantidade,preco);
                produtos.Add(produto);             
                
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
                resposta = Console.ReadLine()!;
            }

        }while(resposta.ToLower() == "s");

        
    }

    public void buscarProduto() 
    {       
        Console.WriteLine("Digite o código do produto: ");
        string codigoString = Console.ReadLine()!;
        int codigo = int.Parse(codigoString);
        for (int i = 0; i < produtos.Count(); i++)
        {
            try
            {
                var produto = produtos.FirstOrDefault(p => p.Codigo == codigo);
                if(produto != null)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine($"Código: {produto.Codigo}");
                    Console.WriteLine($"Nome: {produto.Nome}");
                    Console.WriteLine($"Quantidade: {produto.Quantidade}");
                    Console.WriteLine($"Preço: {produto.Preco}");
                }else 
                {
                    Console.WriteLine("Produto não localizado");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }
    }

    



}
