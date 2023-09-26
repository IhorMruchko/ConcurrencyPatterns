using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyPatterns.WPF.Models.ActiveModel;

public class ActiveObjectGoodExampleModel : ActiveObjectModel
{
    protected BlockingCollection<Task> _queue = new();
    
    public ActiveObjectGoodExampleModel() 
    {
        new Thread(StartExecution).Start();
    }

    public override void Decrease() 
        => _queue.Add(new Task(DecreaseDelayed));

    public override void Increase() 
        => _queue.Add(new Task(IncreaseDelayed));

    public void Stop() => _queue.Add(new Task(() => throw new ThreadInterruptedException()));

    private void StartExecution()
    {
        try
        {
            while (true)
            {
                _queue.Take().Start();
            }
        }
        catch (ThreadInterruptedException exception)
        {
            Debug.WriteLine(exception);
        }
    }

    private void DecreaseDelayed()
    {
        Thread.Sleep(TimeSpan.FromSeconds(2));
        Value -= 1;
        RaiseEvent(ToString());
    }

    private void IncreaseDelayed()
    {
        Thread.Sleep(TimeSpan.FromSeconds(2));
        Value += 1;
        RaiseEvent(ToString());
    }
}
