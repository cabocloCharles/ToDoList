class Program
{
    static void Main()
    {
        List<Task> taskList = new List<Task>();
        bool resume = true;

        while (resume)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1 - Add Task");
            Console.WriteLine("2 - List task");
            Console.WriteLine("3 - Mark task as completed");
            Console.WriteLine("4 - Remove task");
            Console.WriteLine("5 - Exit");
            Console.Write("Option: ");
            String? option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    Console.WriteLine("Enter Description");
                    String? description = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(description))
                    {
                        Console.WriteLine($"Invalid text format, you wrote {description}");
                        break;
                    }

                    Task newTask = new Task();
                    newTask.Description = description;
                    newTask.isCompleted = false;

                    taskList.Add(newTask);
                    Console.WriteLine($"new task {newTask} created successfully");
                    break;
                
                
                case "2":
                    if (taskList.Count == 0)
                    {
                        Console.WriteLine("\tThere's no tasks");

                    }
                    else
                    { 
                        for (int i = 0; i < taskList.Count; i++)
                        {
                            Console.Write($"\t{i + 1}. ");
                            taskList[i].ShowTaskState();
                        }
                    }
                    break;


                case "3":
                    Console.Write("Enter taks number to mark as completed: ");
                    string? inputCompletTask = Console.ReadLine(); 
                    int numberCompletTask;

                    if (int.TryParse(inputCompletTask, out numberCompletTask) && numberCompletTask > 0 && numberCompletTask <= taskList.Count)
                    {
                        taskList[numberCompletTask - 1].MarkAsCompleted();
                        Console.WriteLine("Task marked as completed");
                    }
                    else
                    {
                        Console.WriteLine("invalid number!");
                    }
                    break;

                case "4":
                    Console.Write("Enter task number to remove: ");
                    string? inputRemoveTask = Console.ReadLine();
                    int numberRemoveTask;
                    
                    if(string.IsNullOrWhiteSpace(inputRemoveTask))
                    {
                        Console.WriteLine($"Invalid text format, you wrote {inputRemoveTask}");
                        break;
                    }
                    

                    if (int.TryParse(inputRemoveTask, out numberRemoveTask) && numberRemoveTask > 0 && numberRemoveTask <= taskList.Count)
                    {
                        string? removedDescription = taskList[numberRemoveTask - 1].Description;
                        taskList.RemoveAt(numberRemoveTask - 1);
                        Console.WriteLine($"Task '{removedDescription}' removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("Invalid task number");
                    }
                        break;

                case "5":
                    resume = false;
                    Console.WriteLine("Goodbye");
                    break;


            }

        }
    }

}

class Task
{
    public string? Description;
    public bool isCompleted;


    public void MarkAsCompleted()
    {
        isCompleted = true;
    }


    public void ShowTaskState()
    {
        Console.WriteLine($"Task: {Description} - {(isCompleted ? "Task completed" : "Task pending")}");
    }
}