using System;

class Program
{
    // タスクを表すクラス
    class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
    }

    // タスク管理を行うクラス
    class TaskManager
    {
        private Task[] tasks;
        private int taskCount;
        private int nextId;

        public TaskManager(int maxTasks)
        {
            tasks = new Task[maxTasks];
            taskCount = 0;
            nextId = 1;
        }

        public void AddTask(string description, DateTime dueDate, string priority)
        {
            if (taskCount < tasks.Length)
            {
                tasks[taskCount++] = new Task { Id = nextId++, Description = description, DueDate = dueDate, Priority = priority };
                Console.WriteLine("タスクが追加されました。");
            }
            else
            {
                Console.WriteLine("タスクの上限に達しました。");
            }
        }

        public void DeleteTask(int id)
        {
            int index = FindTaskIndexById(id);
            if (index != -1)
            {
                tasks[index] = null;
                // Shift tasks to remove gap
                for (int i = index; i < taskCount - 1; i++)
                {
                    tasks[i] = tasks[i + 1];
                }
                tasks[--taskCount] = null;
                Console.WriteLine("タスクが削除されました。");
            }
            else
            {
                Console.WriteLine("タスクが見つかりません。");
            }
        }

        public void UpdateTask(int id, string newDescription, DateTime newDueDate, string newPriority)
        {
            int index = FindTaskIndexById(id);
            if (index != -1)
            {
                tasks[index].Description = newDescription;
                tasks[index].DueDate = newDueDate;
                tasks[index].Priority = newPriority;
                Console.WriteLine("タスクが更新されました。");
            }
            else
            {
                Console.WriteLine("タスクが見つかりません。");
            }
        }

        public void DisplayTasks()
        {
            Console.WriteLine("タスク一覧:");
            for (int i = 0; i < taskCount; i++)
            {
                var task = tasks[i];
                if (task != null)
                {
                    Console.WriteLine($"ID: {task.Id}, 説明: {task.Description}, 締め切り: {task.DueDate}, 優先度: {task.Priority}");
                }
            }
        }

        private int FindTaskIndexById(int id)
        {
            for (int i = 0; i < taskCount; i++)
            {
                if (tasks[i] != null && tasks[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    static void Main(string[] args)
    {
        const int maxTasks = 10; // タスクの上限を設定
        TaskManager taskManager = new TaskManager(maxTasks);
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nタスク管理アプリ");
            Console.WriteLine("1. タスクを追加");
            Console.WriteLine("2. タスクを削除");
            Console.WriteLine("3. タスクを更新");
            Console.WriteLine("4. タスクを表示");
            Console.WriteLine("5. 終了");
            Console.Write("選択してください: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("無効な選択です。もう一度選んでください。");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("タスクの説明を入力してください: ");
                    string description = Console.ReadLine();
                    Console.Write("締め切り日を入力してください (yyyy-MM-dd): ");
                    DateTime dueDate;
                    if (!DateTime.TryParse(Console.ReadLine(), out dueDate))
                    {
                        Console.WriteLine("無効な日付です。もう一度選んでください。");
                        continue;
                    }
                    Console.Write("優先度を入力してください (低, 中, 高): ");
                    string priority = Console.ReadLine();
                    taskManager.AddTask(description, dueDate, priority);
                    break;
                case 2:
                    Console.Write("削除するタスクのIDを入力してください: ");
                    int deleteId;
                    if (!int.TryParse(Console.ReadLine(), out deleteId))
                    {
                        Console.WriteLine("無効なIDです。もう一度選んでください。");
                        continue;
                    }
                    taskManager.DeleteTask(deleteId);
                    break;
                case 3:
                    Console.Write("更新するタスクのIDを入力してください: ");
                    int updateId;
                    if (!int.TryParse(Console.ReadLine(), out updateId))
                    {
                        Console.WriteLine("無効なIDです。もう一度選んでください。");
                        continue;
                    }
                    Console.Write("新しいタスクの説明を入力してください: ");
                    string newDescription = Console.ReadLine();
                    Console.Write("新しい締め切り日を入力してください (yyyy-MM-dd): ");
                    DateTime newDueDate;
                    if (!DateTime.TryParse(Console.ReadLine(), out newDueDate))
                    {
                        Console.WriteLine("無効な日付です。もう一度選んでください。");
                        continue;
                    }
                    Console.Write("新しい優先度を入力してください (低, 中, 高): ");
                    string newPriority = Console.ReadLine();
                    taskManager.UpdateTask(updateId, newDescription, newDueDate, newPriority);
                    break;
                case 4:
                    taskManager.DisplayTasks();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("無効な選択です。もう一度選んでください。");
                    break;
            }
        }
    }
}