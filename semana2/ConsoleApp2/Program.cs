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
                Console.WriteLine($"{i + 1}. Título: {tasks[i].Title}");
                Console.WriteLine($"*. Descrição: {tasks[i].Description}");
                Console.WriteLine($"*. Data: {tasks[i].DueDate.ToString("MM/dd/yyyy")}");
                Console.WriteLine(" ");
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

    public void ListTasksCompleted()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            Console.WriteLine("---------------------------------");
            /*for (int i = 0; i < tasks.Count; i++)
            {
                string completedIndicator = tasks[i].IsCompleted ? "[Concluído] " : "";
                Console.WriteLine($"{i + 1}. {completedIndicator}{tasks[i].Title}. DueDate = {tasks[i].DueDate.ToString("MM/dd/yyyy")}");
            }*/
            List<Task> completedTasks = tasks.Where(task => task.IsCompleted).ToList();

                foreach (Task completedTask in completedTasks)
                {
                    Console.WriteLine($" Título: {completedTask.Title}, Data: {completedTask.DueDate.ToString("MM/dd/yyyy")}");
                }            
            Console.WriteLine("----------------------------------");
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
            Console.WriteLine($"No tasks found with the keyword '{keyword}'.");
        }
        else
        {
            Console.WriteLine($"Tasks matching the keyword '{keyword}':");
            Console.WriteLine("---------------------------------");

            foreach (Task matchingTask in matchingTasks)
            {
                Console.WriteLine($"Título: {matchingTask.Title}, Descrição: {matchingTask.Description}, Data: {matchingTask.DueDate.ToString("MM/dd/yyyy")}");
                Console.WriteLine(" ");
            }

            Console.WriteLine("---------------------------------");
        }
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
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Remove Task");
            Console.WriteLine("3. Update Task");
            Console.WriteLine("4. List Task");
            Console.WriteLine("5. Mark Task as Completed");
            Console.WriteLine("6. List Completed Tasks");
            Console.WriteLine("7. Search Tasks");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your option: ");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    {
                        Console.Write("Enter Task Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Task Description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter Task Due Date (MM/dd/yyyy): ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());

                        Task task = new Task { Title = title, Description = description, DueDate = dueDate };
                        taskManager.AddTask(task);
                        Console.WriteLine("Task added successfully.");
                    }
                    break;

                case 2:
                    {
                        Console.Write("Enter index of task to remove: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        taskManager.RemoveTask(index);
                        Console.WriteLine("Task removed successfully.");
                    }
                    break;

                case 3:
                    {
                        Console.Write("Enter index of task to update: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new Task Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter new Task Description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter new Task Due Date (MM/dd/yyyy): ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());

                        Task updatedTask = new Task { Title = title, Description = description, DueDate = dueDate };
                        taskManager.UpdateTask(index, updatedTask);
                        Console.WriteLine("Task updated successfully.");
                    }
                    break;

                case 4:
                    {
                        taskManager.ListTasks();
                    }
                    break;
                case 5:
                    {
                        Console.Write("Enter index of task to mark as completed: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        taskManager.MarkTaskAsCompleted(index);
                        Console.WriteLine("Task marked as completed successfully.");
                    }
                    break;
                case 6:
                    {
                        taskManager.ListTasksCompleted();
                    }
                    break;
                case 7:
                    {
                        Console.Write("Enter keyword to search for tasks: ");
                        string keyword = Console.ReadLine();
                        taskManager.SearchTasks(keyword);
                    }
                    break;

                case 8:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        } while (option != 7);
    }
}