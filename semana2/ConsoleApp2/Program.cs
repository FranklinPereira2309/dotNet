using System;
using System.ComponentModel;

public class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}

public class TaskManager
{
    private List<Task> tasks;

    public TaskManager()
    {
        tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void RemoveTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

    public void UpdateTask(int index, Task updatedTask)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index] = updatedTask;
        }
        else
        {
            Console.WriteLine("Índice inválido!");
        }
    }

    public void ListTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Nenhuma Tarefa encontrada.");
            Console.WriteLine("---------------------------------");
        }
        else
        {
            Console.WriteLine("---------------------------------");
            for (int i = 0; i < tasks.Count; i++)
            {
                if(tasks[i].IsCompleted){
                    Console.WriteLine($"{i + 1}. Título: {tasks[i].Title}");
                    Console.WriteLine($"*. Descrição: {tasks[i].Description}");
                    Console.WriteLine($"*. Data: {tasks[i].DueDate.ToString("MM/dd/yyyy")}");
                    Console.WriteLine($"*. Tarefa Completada [X]");
                    Console.WriteLine(" ");
                }else {
                    Console.WriteLine($"{i + 1}. Título: {tasks[i].Title}");
                    Console.WriteLine($"*. Descrição: {tasks[i].Description}");
                    Console.WriteLine($"*. Data: {tasks[i].DueDate.ToString("MM/dd/yyyy")}");
                    Console.WriteLine($"*. Tarefa Completada [ ]");
                    Console.WriteLine(" ");
                }
            }
            Console.WriteLine("----------------------------------");
        }
    }

    public void MarkTaskAsCompleted(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].IsCompleted = true;
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }
    public void SearchTasks(string keyword)
    {
        List<Task> matchingTasks = tasks
            .Where(task => task.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                           task.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (matchingTasks.Count == 0)
        {
            Console.WriteLine($"Nenhuma busca encontrada para: '{keyword}'.");
        }
        else
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"Palavra-chave digitada: '{keyword}':");
            Console.WriteLine("----------------------------------------------------------------------");

            foreach (Task matchingTask in matchingTasks)
            {
                Console.WriteLine($"Título: {matchingTask.Title}, Descrição: {matchingTask.Description}, Data: {matchingTask.DueDate.ToString("MM/dd/yyyy")}");
                Console.WriteLine(" ");
            }

            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
    public void ShowStatistics()
    {
        int totalTasks = tasks.Count;
        int completedTasks = tasks.Count(task => task.IsCompleted);
        int pendingTasks = totalTasks - completedTasks;

        Console.WriteLine("-------- Estatísticas --------");
        Console.WriteLine($"Total de Tarefas: {totalTasks}");
        Console.WriteLine($"Tarefas Concluídas: {completedTasks}");
        Console.WriteLine($"Tarefas Pendentes: {pendingTasks}");

        if (completedTasks > 0)
        {
            DateTime oldestDueDate = tasks.Where(task => task.IsCompleted).Min(task => task.DueDate);
            DateTime newestDueDate = tasks.Where(task => task.IsCompleted).Max(task => task.DueDate);

            Console.WriteLine($"Tarefa Mais Antiga Concluída: {oldestDueDate.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"Tarefa Mais Recente Concluída: {newestDueDate.ToString("MM/dd/yyyy")}");
        }

        Console.WriteLine("-----------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();
        int option;

        do
        {
            Console.WriteLine("Menu de Opções");
            Console.WriteLine("1. Adicionar Tarefas");
            Console.WriteLine("2. Remover Tarefas");
            Console.WriteLine("3. Atualizar Tarefas");
            Console.WriteLine("4. Listar Tarefas");
            Console.WriteLine("5. Marcar Tarefas Completadas");
            Console.WriteLine("6. Buscar Tarefas");
            Console.WriteLine("7. Mostrar Estatísticas");
            Console.WriteLine("8. Sair");
            Console.Write("Digite sua opção: ");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    {
                        Console.Write("Digite o Título: ");
                        string title = Console.ReadLine();
                        Console.Write("Digite a Descrição: ");
                        string description = Console.ReadLine();
                        Console.Write("Digita a data (MM/dd/yyyy): ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());

                        Task task = new Task { Title = title, Description = description, DueDate = dueDate };
                        taskManager.AddTask(task);
                        Console.WriteLine("Tarefa adicionada com Sucesso!");
                    }
                    break;

                case 2:
                    {
                        Console.Write("REMOVER - Digite o índice: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        taskManager.RemoveTask(index);
                        Console.WriteLine("Tarefa removida com Sucesso!");
                    }
                    break;

                case 3:
                    {
                        Console.Write("ATUALIZAR - Digite o índice: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Digite o título: ");
                        string title = Console.ReadLine();
                        Console.Write("digite a descrição: ");
                        string description = Console.ReadLine();
                        Console.Write("Digite a nova data (MM/dd/yyyy): ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());

                        Task updatedTask = new Task { Title = title, Description = description, DueDate = dueDate };
                        taskManager.UpdateTask(index, updatedTask);
                        Console.WriteLine("Tarefa atulizada com Sucesso!");
                    }
                    break;

                case 4:
                    {
                        taskManager.ListTasks();
                    }
                    break;
                case 5:
                    {
                        Console.Write("TAREFAS COMPLETADAS - Digite o índice: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        taskManager.MarkTaskAsCompleted(index);
                        Console.WriteLine("Tarefa completada com Sucesso!");
                    }
                    break;
                case 6:
                    {
                        Console.Write("BUSCAR - Digite a palavra-chave: ");
                        string keyword = Console.ReadLine();
                        taskManager.SearchTasks(keyword);
                    }
                    break;

                case 7:
                    {
                        taskManager.ShowStatistics();
                    }
                    break;
                case 8:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        } while (option != 8);
    }
}