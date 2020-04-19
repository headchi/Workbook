using System;

namespace EventEx1
{
    /// <summary>
    /// 出版社クラス
    /// </summary>
    class Publisher
    {
        // 1.1 デリゲートを作成する
        /*
         * デリゲートの名前は
         * 「実装しようとしているイベントの名前」 + EventHandler
         * という形にする
         */
        public delegate void JobDoneEventHandler(object sender, EventArgs args);

        // 1.2 デリゲートに基づいてイベントを作成する
        public event JobDoneEventHandler JobDone;

        public void ProcessOneJob()
        {
            Console.WriteLine("出版社：ジョブを１つこなします");

            // 1.3 イベントを発生させる
            OnJobDone();
        }

        /*
         * 標準の形式では、メソッドを protected virtual でタグ付け。
         * また、メソッド名をイベントの名前と揃えて、先頭に On を付ける。
         */
        protected virtual void OnJobDone()
        {
            if (JobDone != null) JobDone(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// 購読者クラス
    /// </summary>
    class Subscriber
    {
        // イベント処理
        public void OnJobDoneEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine("購読者が通知を受けました");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** 簡単なイベントのデモ ***");
            Publisher sender = new Publisher();
            Subscriber receiver = new Subscriber();
            sender.JobDone += receiver.OnJobDoneEventHandler;
            sender.ProcessOneJob();

            Console.ReadKey();
        }
    }
}
