namespace produto;

public class App {
    public static List<Produto> AddProduto()
    {
        List<Produto> produtos = new List<Produto>();
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

        return produtos;
    }

}
