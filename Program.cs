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

                //次回に備える
                taskCount++; //タスクの登録数を1件プラス
                nextId++; //タスクのID番号も1プラス
            }
            else
            {
                Console.WriteLine("タスクの登録上限に達しています");
            }
        }

        //配列からタスクを削除するメソッド
        public void DeleteTask(int id)
        {
            //自作メソッドであるFindTaskIndexByIdを呼び出し
            //配列の各Idに一致するものがないかチェックして
            //あれば該当の配列番号、なければ-1を取得
            int index = FindTaskIndexById(id);
        }

        //配列の各Idに引数と一致するものがないかチェックして
        //あれば該当の配列番号、なければ-1を取得
        private int FindTaskIndexById(int id)
        {
            for (int i = 0; i < taskCount; i++)
            {
                if (tasks[i].Id == id)
                {
                    //一致するものがあれば
                    //その時点でreturnしてメソッド終了
                    return i;
                }
            }
            return -1;
        }





    }


    static void Main(string[] args)
    {

    }
}