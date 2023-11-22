using System.Reflection;

namespace produto;

public class App {
    public static List<Produto> AddProduto()
    {
        List<Produto> produto = new List<Produto>();
        string resposta = "s";

        do 
        {

            Console.WriteLine("Digite o nome do produto");
            string nome = Console.ReadLine()!;
            
            try
            {
                
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }while(resposta.ToLower() == "s");

        return produto;
    }

}
