namespace Dsa
{
    public class Threads
    {
        public static void MainThreads()
        {
            Locks();
        }

        public static void Locks()
        {
            Counter counter = new Counter();
            Thread thread1 = new Thread(counter.Increment);
            Thread thread2 = new Thread(counter.Increment);

            Console.WriteLine("thread1.Start()");
            thread1.Start();
            Console.WriteLine("thread2.Start()");
            thread2.Start();

            Console.WriteLine("Thread1 State: " + thread1.ThreadState.ToString());
            Console.WriteLine("Thread2 State: " + thread2.ThreadState.ToString());

            Console.WriteLine("thread1.Join()");
            thread1.Join();
            Console.WriteLine("Thread1 State: " + thread1.ThreadState.ToString());
            Console.WriteLine("thread2.Join()");
            thread2.Join();
            Console.WriteLine("Thread2 State: " + thread2.ThreadState.ToString());
            Console.WriteLine(counter.GetCount());
        }

        class Counter
        {
            private int _count = 0;
            private readonly object locker = new object();

            public void Increment()
            {
                var thread = Thread.CurrentThread;

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Outside lock -------------- " +
                            string.Format("   Background: {0}\n", thread.IsBackground) +
                            string.Format("   Thread Pool: {0}\n", thread.IsThreadPoolThread) +
                            string.Format("   Thread ID: {0}\n", thread.ManagedThreadId) +
                            string.Format("   Thread State: {0}\n", thread.ThreadState.ToString()) +
                            "-------------- "
                        );
                    lock (locker)
                    {
                        Console.WriteLine("Inside lock -------------- " +
                            string.Format("   Background: {0}\n", thread.IsBackground) +
                            string.Format("   Thread Pool: {0}\n", thread.IsThreadPoolThread) +
                            string.Format("   Thread ID: {0}\n", thread.ManagedThreadId) +
                            string.Format("   Thread State: {0}\n", thread.ThreadState.ToString()) +
                            string.Format("   Thread is sleeping...\n") +
                            "-------------- "
                        );
                        // _count++;
                        Thread.Sleep(1000);
                    }
                }
            }

            public int GetCount()
            {
                return _count;
            }
        }
    }
}