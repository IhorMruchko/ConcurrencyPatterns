using System;
using System.Diagnostics;
using System.Threading;

namespace ConcurrencyPatterns.WPF.Models.GuardedSuspensionModel;

public class GuardedSuspensionGoodExampleModel : GuardedSuspensionObjectModel
{
    public GuardedSuspensionGoodExampleModel(int upperLimit) : base(upperLimit)
    {
    }

    public override void Add()
    {
        lock (this)
        {
            AddLocked();
        }
    }

    public override void Remove()
    {
        lock (this)
        {
            RemoveLocked();
        }
    }

    private void AddLocked()
    {
        while (CurrentAmount >= UpperLimit)
        {
            try
            {
                Monitor.Wait(this);
            }
            catch(ThreadInterruptedException exception)
            {
                Debug.WriteLine(exception.ToString());
            }
        }

        CurrentAmount += 1;
        Monitor.PulseAll(this);
        RaiseEvent($"Added. Current amount = {CurrentAmount}");
    }

    private void RemoveLocked()
    {
        while (CurrentAmount <= 0)
        {
            try
            {
                Monitor.Wait(this);
            }
            catch (ThreadInterruptedException exception)
            {
                Debug.WriteLine(exception.ToString());
            }
        }

        CurrentAmount -= 1;
        Monitor.PulseAll(this);
        RaiseEvent($"Removed. Current amount = {CurrentAmount}");
    }
}
