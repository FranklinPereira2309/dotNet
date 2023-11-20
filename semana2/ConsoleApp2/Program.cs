using System;
using System.ComponentModel;

public class Tarefa
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime dData { get; set; }
    public bool ehCompleta { get; set; }
}

public class GerenciarTarefas
{
    private List<Tarefa> tarefas;

    public GerenciarTarefas()
    {
        tarefas = new List<Tarefa>();
    }

    public void AdicionarTarefa(Tarefa tarefa)
    {
        tarefas.Add(tarefa);
    }

    public void RemoverTarefa(int indice)
    {
        if (indice >= 0 && indice < tarefas.Count)
        {
            tarefas.RemoveAt(indice);
        }
        else
        {
            Console.WriteLine("Índice Inválido!");
        }
    }

    public void AtualizarTarefa(int indice, Tarefa tarefaAtualizada)
    {
        if (indice >= 0 && indice < tarefas.Count)
        {
            tarefas[indice] = tarefaAtualizada;
        }
        else
        {
            Console.WriteLine("Índice Inválido!");
        }
    }

    public void ListarTarefa()
    {
        if (tarefas.Count == 0)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Nenhuma Tarefa encontrada.");
            Console.WriteLine("---------------------------------");
        }
        else
        {
            Console.WriteLine("---------------------------------");
            for (int i = 0; i < tarefas.Count; i++)
            {
                if(tarefas[i].ehCompleta){
                    Console.WriteLine($"{i + 1}. Título: {tarefas[i].Titulo}");
                    Console.WriteLine($"-> Descrição: {tarefas[i].Descricao}");
                    Console.WriteLine($"-> Data: {tarefas[i].dData.ToString("MM/dd/yyyy")}");
                    Console.WriteLine($"-> Tarefa Completada [X]");
                    Console.WriteLine(" ");
                }else {
                    Console.WriteLine($"{i + 1}. Título: {tarefas[i].Titulo}");
                    Console.WriteLine($"-> Descrição: {tarefas[i].Descricao}");
                    Console.WriteLine($"-> Data: {tarefas[i].dData.ToString("MM/dd/yyyy")}");
                    Console.WriteLine($"-> Tarefa Completada [ ]");
                    Console.WriteLine(" ");
                }
            }
            Console.WriteLine("----------------------------------");
        }
    }

    public void MarcarCompleta(int indice)
    {
        if (indice >= 0 && indice < tarefas.Count)
        {
            tarefas[indice].ehCompleta = true;
        }
        else
        {
            Console.WriteLine("Índice Inválido!");
        }
    }
    public void BuscarTarefa(string palavra)
    {
        List<Tarefa> tarefaEncontradas = tarefas
            .Where(tarefa => tarefa.Titulo.Contains(palavra, StringComparison.OrdinalIgnoreCase) ||
                            tarefa.Descricao.Contains(palavra, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (tarefaEncontradas.Count == 0)
        {
            Console.WriteLine($"Nenhuma busca encontrada para: '{palavra}'.");
        }
        else
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"Palavra-chave digitada: '{palavra}':");
            Console.WriteLine("----------------------------------------------------------------------");

            foreach (Tarefa tarefaEncontrada in tarefaEncontradas)
            {
                Console.WriteLine($"Título: {tarefaEncontrada.Titulo}, Descrição: {tarefaEncontrada.Descricao}, Data: {tarefaEncontrada.dData.ToString("MM/dd/yyyy")}");
                Console.WriteLine(" ");
            }

            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
    public void MostrarEstatistica()
    {
        int totalTarefas = tarefas.Count;
        int tarefasCompletadas = tarefas.Count(tarefas => tarefas.ehCompleta);
        int tarefasPendentes = totalTarefas - tarefasCompletadas;

        Console.WriteLine("* --------> Estatísticas <-------- *");
        Console.WriteLine($"Total de Tarefas: {totalTarefas}");
        Console.WriteLine($"Tarefas Concluídas: {tarefasCompletadas}");
        Console.WriteLine($"Tarefas Pendentes: {tarefasPendentes}");

        if (tarefasCompletadas > 0)
        {
            DateTime datasAntigas = tarefas.Where(tarefas => tarefas.ehCompleta).Min(tarefas => tarefas.dData);
            DateTime novasDatas = tarefas.Where(tarefas => tarefas.ehCompleta).Max(tarefas => tarefas.dData);

            Console.WriteLine($"Tarefa Mais Antiga Concluída: {datasAntigas.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"Tarefa Mais Recente Concluída: {novasDatas.ToString("MM/dd/yyyy")}");
        }

        Console.WriteLine("----------------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        GerenciarTarefas gerenciaTarefa = new GerenciarTarefas();
        int opcao;

        do
        {
            Console.WriteLine("* ------> Menu de Opções <------ *");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1. Adicionar Tarefas");
            Console.WriteLine("2. Remover Tarefas");
            Console.WriteLine("3. Atualizar Tarefas");
            Console.WriteLine("4. Listar Tarefas");
            Console.WriteLine("5. Marcar Tarefas Completadas");
            Console.WriteLine("6. Buscar Tarefas");
            Console.WriteLine("7. Mostrar Estatísticas");
            Console.WriteLine("8. Sair");
            Console.Write("Digite sua opção: ");
            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    {
                        Console.Write("Digite o Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Digite a Descrição: ");
                        string descricao = Console.ReadLine();
                        Console.Write("Digita a data (MM/dd/yyyy): ");
                        DateTime dData = DateTime.Parse(Console.ReadLine());

                        Tarefa tarefa = new Tarefa { Titulo = titulo, Descricao = descricao, dData = dData };
                        gerenciaTarefa.AdicionarTarefa(tarefa);
                        Console.WriteLine("Tarefa adicionada com Sucesso!");
                    }
                    break;

                case 2:
                    {
                        Console.Write("REMOVER - Digite o índice: ");
                        int indice = Convert.ToInt32(Console.ReadLine());
                        gerenciaTarefa.RemoverTarefa(indice);
                        Console.WriteLine("Tarefa removida com Sucesso!");
                    }
                    break;

                case 3:
                    {
                        Console.Write("ATUALIZAR - Digite o índice: ");
                        int indice = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Digite o título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("digite a descrição: ");
                        string descricao = Console.ReadLine();
                        Console.Write("Digite a nova data (MM/dd/yyyy): ");
                        DateTime dData = DateTime.Parse(Console.ReadLine());

                        Tarefa tarefaAtualizada = new Tarefa { Titulo = titulo, Descricao = descricao, dData = dData };
                        gerenciaTarefa.AtualizarTarefa(indice, tarefaAtualizada);
                        Console.WriteLine("Tarefa atulizada com Sucesso!");
                    }
                    break;

                case 4:
                    {
                        gerenciaTarefa.ListarTarefa();
                    }
                    break;
                case 5:
                    {
                        Console.Write("TAREFAS COMPLETADAS - Digite o índice: ");
                        int indice = Convert.ToInt32(Console.ReadLine());
                        gerenciaTarefa.MarcarCompleta(indice);
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Tarefa completada com Sucesso!");
                        Console.WriteLine("------------------------------");
                    }
                    break;
                case 6:
                    {
                        Console.Write("BUSCAR - Digite a palavra-chave: ");
                        string palavra = Console.ReadLine();
                        gerenciaTarefa.BuscarTarefa(palavra);
                    }
                    break;

                case 7:
                    {
                        gerenciaTarefa.MostrarEstatistica();
                    }
                    break;
                case 8:
                    Console.WriteLine("Até mais...Bye bye!");
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        } while (opcao != 8);
    }
}