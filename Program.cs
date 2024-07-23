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
        private int taskCount; //タスクの合計数
        private int nextId; //タスクのリストの余りを探るフィールド

        //TaskManagerのコンストラクタ（実体化メソッド）を改造
        public TaskManager(int maxTasks)
        {
            tasks = new Task[maxTasks]; //実体化する際に引数に与えた数だけタスクを管理できるマネージャーとして生成されるようにする
            taskCount = 0;
            nextId = 1;
        }

        //リストにタスクを追加するメソッド
        public void AddTask(string taskName, string limitTime, string priority)
        {
            if (taskCount < tasks.Length)
            {
                //タスクを配列に追加してtaskCountを引き上げる

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