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
            if (index != -1) //indexが-1でなければ削除
            {
                //該当の配列を「なし」にする nullは「ないを明示するデータ」
                tasks[index] = null;

                //nullになった分だけデータを詰める作業
                for (int i = index; i < taskCount - 1; i++)
                {
                    tasks[i] = tasks[i + 1];
                }
                //最後尾のデータをnullにする
                tasks[taskCount - 1] = null;

                //削除が完了したので登録件数を1件マイナス
                taskCount--;
                Console.WriteLine("タスクが削除されました");
            }
            else //indexが-1だったら該当なし
            {
                Console.WriteLine("該当のIDはありません");
            }

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
            //for文をループし終わっても該当するものがなければ-1を返す
            return -1;
        }

        //該当するIDの中身を更新・再設定
        public void UpdateTask(int id, string taskName, string limitTime, string priority)
        {
            //該当IDが配列の中にあればその番号、なければ-1を返す
            int index = FindTaskIndexById(id);
            if (index != -1) //該当IDが見つかった
            {
                //それぞれのプロパティを引数の内容で更新
                tasks[index].TaskName = taskName;
                tasks[index].LimitTime = limitTime;
                tasks[index].Priority = priority;
                Console.WriteLine("タスクが更新されました");
            }
            else //indexが-1だった場合、該当なし
            {
                Console.WriteLine("該当IDが見つかりません");
            }
        }

        //管理しているタスクを列挙するメソッド
        public void DisplayTask()
        {
            Console.WriteLine("タスク一覧");
            for (int i = 0; i < taskCount; i++)
            {
                Console.Write("ID:" + tasks[i].Id + " ");
                Console.Write("内容:" + tasks[i].TaskName + " ");
                Console.Write("期限:" + tasks[i].LimitTime + " ");
                Console.WriteLine("優先度:" + tasks[i].Priority);
            }
        }

    }


    static void Main(string[] args)
    {
        int maxTask = 10; //実体化されるTaskManagerの配列の上限数
        bool exit = false; //アプリを終了するためのステータス（trueで終了）
        int choice; //プレイヤーが選んだ番号

        TaskManager tm = new TaskManager(maxTask);

        //変数exit（終了ステータス）がfalseの間はずっとループ
        while (exit == false)
        {
            Console.WriteLine("行動を数字で選択してください");
            Console.WriteLine("1:タスクを追加");
            Console.WriteLine("2:タスクを削除");
            Console.WriteLine("3:タスクを再設定");
            Console.WriteLine("4:タスクの一覧を表示");
            Console.WriteLine("5:アプリ終了");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    //追加のメソッド処理
                    break;
                case 2:
                    //削除のメソッド処理
                    break;
                case 3:
                    //再設定のメソッド処理
                    break;
                case 4:
                    //一覧表示のメソッド処理
                    tm.DisplayTask();
                    break;
                case 5:
                    //終了処理
                    exit = true;
                    break;
                default:
                    Console.WriteLine("数字が無効です");
                    break;
            }
        }
    }
}