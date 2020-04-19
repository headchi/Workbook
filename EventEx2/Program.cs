using System;

namespace EventEx2
{
    // 手順A System.EventArgs のサブクラスを作成
    public class JobNoEventArgs : EventArgs
    {
        // 手順B 目的のデータをイベントと一緒にカプセル化。プロパティを用いる。
        private int jobNo;
        public int JobNo
        {
            get
            {
                return jobNo;
            }
            set
            {
                JobNo = value;
            }
        }

        public JobNoEventArgs(int jobNo)
        {
            this.jobNo = jobNo;
        }
    }

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
        //public delegate void JobDoneEventHandler(object sender, EventArgs args);
        public delegate void JobDoneEventHandler(object sender, JobNoEventArgs args);

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
            // 手順C 最終的にイベント生成クラスのインスタンスを作成してイベントに渡す
            //if (JobDone != null) JobDone(this, EventArgs.Empty);
            if (JobDone != null) JobDone(this, new JobNoEventArgs(1));
        }
    }

    /// <summary>
    /// 購読者クラス
    /// </summary>
    class Subscriber
    {
        // イベント処理
        //public void OnJobDoneEventHandler(object sender, EventArgs args)
        public void OnJobDoneEventHandler(object sender, JobNoEventArgs args)
        {
            //Console.WriteLine("購読者が通知を受けました");
            Console.WriteLine("購読者が通知を受けました。処理されたジョブの数は{0}", args.JobNo);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** イベントの例　その２：データをイベントとともに渡す ***");
            Publisher sender = new Publisher();
            Subscriber receiver = new Subscriber();
            sender.JobDone += receiver.OnJobDoneEventHandler;
            sender.ProcessOneJob();

            Console.ReadKey();
        }
    }
}
