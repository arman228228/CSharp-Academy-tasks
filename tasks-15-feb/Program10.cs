using System;

namespace ConsoleApp3
{
    class Program10
    {
        static void Main()
        {
            TaskItem[] tasks = new TaskItem[100];

            int totalTask = 0;

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine(
                    "Enter option:\n1. Add task\n2. Remove task\n3. Mark task as complete\n4. Mark task as in complete\n5. Task list\n6. Exit program");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        if (totalTask >= tasks.Length)
                        {
                            Console.WriteLine("Tasks limit.");
                            break;
                        }

                        Console.WriteLine("Enter description for task:");
                        
                        tasks[totalTask] = new TaskItem();
                        
                        tasks[totalTask++].Description = Console.ReadLine();

                        Console.WriteLine("Task added.");

                        break;
                    case 2:
                        bool nestedExit = false;

                        while (!nestedExit)
                        {
                            Console.WriteLine($"Enter task number to remove it. (1 to {totalTask} or 0 to back)");

                            int taskID = int.Parse(Console.ReadLine());

                            if (taskID == 0)
                            {
                                nestedExit = true;

                                Console.WriteLine("Back.");

                                break;
                            }

                            if (taskID < 0 || taskID > totalTask)
                            {
                                Console.WriteLine("Invalid option.");

                                break;
                            }

                            tasks[taskID - 1].RemoveTask(taskID, ref totalTask, tasks);
                            
                            Console.WriteLine("Task removed.");

                            nestedExit = true;
                        }

                        break;
                    case 3:
                        nestedExit = false;

                        while (!nestedExit)
                        {
                            Console.WriteLine($"Enter task number to mark it. (1 to {totalTask} or 0 to back)");

                            int taskID = int.Parse(Console.ReadLine());

                            if (taskID == 0)
                            {
                                nestedExit = true;

                                Console.WriteLine("Back.");

                                break;
                            }

                            if (taskID < 0 || taskID > totalTask)
                            {
                                Console.WriteLine("Invalid option.");

                                break;
                            }

                            Console.WriteLine(tasks[taskID - 1].MarkComplete() ? "Task marked" : "Task mark error");

                            break;
                        }

                        break;
                    case 4:
                        nestedExit = false;

                        while (!nestedExit)
                        {
                            Console.WriteLine($"Enter task number to unmark it. (1 to {totalTask} or 0 to back)");

                            int taskID = int.Parse(Console.ReadLine());

                            if (taskID == 0)
                            {
                                nestedExit = true;

                                Console.WriteLine("Back.");

                                break;
                            }

                            if (taskID < 0 || taskID > totalTask)
                            {
                                Console.WriteLine("Invalid option.");

                                break;
                            }

                            Console.WriteLine(tasks[taskID - 1].MarkInComplete() ? "Task unmarked" : "Task unmark error");

                            break;
                        }

                        break;
                    case 5:
                        TaskItem.TaskList(tasks, totalTask);
                        break;
                    case 6:
                        exit = true;

                        Console.WriteLine("Exit program");

                        break;
                    default:
                        Console.WriteLine("Invalid option.");

                        break;
                }
            }
        }
    }
    class TaskItem
    {
        public string Description { get; set; }
		public bool IsCompleted { get; set; }

        public bool MarkComplete()
        {
            if (IsCompleted) return false;
            
            IsCompleted = true;

            return true;
        }

        public bool MarkInComplete()
        {
            if (!IsCompleted) return false;
            
            IsCompleted = false;

            return true;
        }

        public bool RemoveTask(int taskID, ref int totalTask, object[] Object)
        {
            for (int i = taskID - 1; i < totalTask - 1; i++)
            {
                Object[i] = Object[i + 1];
            }

            Object[--totalTask] = null;

            return true;
        }

        public static void TaskList(TaskItem[] tasks, int totalTask)
        {
            for (int i = 0; i < totalTask; i++)
            {
                Console.WriteLine($"Task {i + 1}. Description: {tasks[i].Description}. Status: {tasks[i].IsCompleted}");
            }
        }
    }
}