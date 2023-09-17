using System.Collections.Concurrent;
using System.Diagnostics;

namespace ConcurrencyPatterns.Console;

public class ActiveObject
{
    private int _value;

    private readonly BlockingCollection<Thread> _proxy = new();

    public override string ToString()
       => $"{Environment.CurrentManagedThreadId} has value: {_value}";

    public ActiveObject()
    {
        new Thread(StartExecution).Start();
    }

    private void StartExecution()
    {
        try
        {
            while (true)
                _proxy.Take().Start();
        }
        catch(ThreadInterruptedException exception)
        {
            Debug.WriteLine(exception);
        }
    }

    public void Increase() => _proxy.Add(new Thread(() =>
    {
        ++_value;
        System.Console.WriteLine($"Increase: {this}");
    }));

    public void Decrease() => _proxy.Add(new Thread(() =>
    {
        --_value;
        System.Console.WriteLine($"Decrease: {this}");
    }));
}
