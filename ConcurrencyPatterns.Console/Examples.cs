using ConcurrencyPatterns.Console.GuardedSuspension;

namespace ConcurrencyPatterns.Console;

public static class Examples
{
    public static void NonActveObjectExample(int threadsAmount = 4)
    {
        var nonActiveObject = new NonActiveObject();
        var threads = new List<Thread>();

        for (var i = 0; i < threadsAmount; i++)
            threads.Add(new Thread(ThreadTasks));

        threads.ForEach(thread => thread.Start());

        void ThreadTasks()
        {
            System.Console.WriteLine($"Start: {nonActiveObject}");
            nonActiveObject.Increase();
            System.Console.WriteLine($"Increase: {nonActiveObject}");
            nonActiveObject.Decrease();
            System.Console.WriteLine($"Decrease: {nonActiveObject}");
        }
    }

    public static void ActiveObjectExample(int threadsAmount = 4)
    {
        var activeObject = new ActiveObject();
        var threads = new List<Thread>();

        for (var i = 0; i < threadsAmount; i++)
            threads.Add(new Thread(ThreadTasks));

        threads.ForEach(thread => thread.Start());

        void ThreadTasks()
        {
            System.Console.WriteLine($"Current Start: {activeObject}");
            activeObject.Increase();
            System.Console.WriteLine($"Current Increase: {activeObject}");
            activeObject.Decrease();
            System.Console.WriteLine($"Current Decrease: {activeObject}");
        }
    }

    public static void BalkingObjectExcample(int threadsAmount = 4)
    {
        var balkedObject = new BalkedObject(Job);
        var threads = new List<Thread>();

        for (var i = 0; i < threadsAmount; i++)
            threads.Add(new Thread(ThreadTasks));

        threads.ForEach(thread => thread.Start());

        void Job()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            System.Console.WriteLine($"{Environment.CurrentManagedThreadId}: Job is done");
        }

        void ThreadTasks()
        {
            System.Console.WriteLine($"{Environment.CurrentManagedThreadId}: Try start job");
            balkedObject.DoJob();
        }
    }

    public static void DoubleLockExample(int threadsAmount = 4)
    {
        var threads = new List<Thread>();

        for (var i = 0; i < threadsAmount; i++)
            threads.Add(new Thread(ThreadTasks));

        threads.ForEach(thread => thread.Start());

        static void ThreadTasks()
        {
            System.Console.WriteLine($"{Environment.CurrentManagedThreadId}: getting instance");
            var item = MultyThreadSingleton.Instance;
        }
    }

    public static void GuardedSuspension(int threadAmount = 4, int upperLimit = 3)
    {
        var store = new Store(upperLimit);
        var consumers = new List<Thread>();
        var producers = new List<Thread>();

        for(var i = 0; i < threadAmount; ++i)
        {
            consumers.Add(new Thread(() => new Consumer(store).Run(upperLimit + threadAmount)));
            producers.Add(new Thread(() => new Producer(store).Run(upperLimit + threadAmount)));
        }

        consumers.ForEach(thread => thread.Start());
        producers.ForEach(thread => thread.Start());
    }
}
