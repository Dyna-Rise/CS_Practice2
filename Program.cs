using System;

class Program
{
    //個別のタスクを表現するクラス
    class Task
    {
        //自動実装プロパティ
        public int Id { get; set; } //識別ID
        public string TaskName { get; set; } //やること
        public string LimitTime { get; set; } //期限
        public string Priority { get; set; } //優先度
    }

    class TaskManager
    {
        private Task[] tasks; //タスクの配列
        private int taskCount; //登録されているタスクの合計数
        private int nextId; //タスク番号の連番

        //TaskManagerのコンストラクタ（実体化メソッド）を改造
        public TaskManager(int maxTasks)
        {
            tasks = new Task[maxTasks]; //実体化する際に引数に与えた数だけタスクを管理できるマネージャーとして生成されるようにする
            //taskCount = 0;
            nextId = 1;
        }

        //配列にタスクを追加するメソッド
        public void AddTask(string taskName, string limitTime, string priority)
        {
            //タスクの登録数(taskCount)が配列の要素数(tasks.Length)を下回っていたら追加が可能
            if (taskCount < tasks.Length)
            {
                //タスクを配列に追加してtaskCountとnextIdを引き上げる
                //新しいTaskクラスの生成を右辺で行い、左辺（配列）に代入
                tasks[taskCount] = new Task { Id = nextId, TaskName = taskName, LimitTime = limitTime, Priority = priority };

                taskCount++;
                nextId++;

            }
            else
            {
                Console.WriteLine("タスクの登録上限に達しています");
            }
        }

    }


    static void Main(string[] args)
    {

    }
}