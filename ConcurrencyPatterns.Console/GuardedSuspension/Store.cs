using System.Diagnostics;

namespace ConcurrencyPatterns.Console.GuardedSuspension;

public class Store
{
    private int _productsAmount = 0;

    private readonly int _upperLimit;

    public Store(int upperLimit = 3)
    {
        _upperLimit = upperLimit;
    }

    public void Buy()
    {
        lock (this)
        {
            BuyLocked();  
        }
    }

    public void Sell()
    {
        lock (this)
        {
            SellLocked();
        }
    }

    private void SellLocked()
    {
        while (_productsAmount >= _upperLimit)
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
        ++_productsAmount;
        System.Console.WriteLine($"{Environment.CurrentManagedThreadId}: sell 1 product. Left {_productsAmount}");
        Monitor.PulseAll(this);
    }

    private void BuyLocked()
    {
        while (_productsAmount < 1)
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

        --_productsAmount;
        System.Console.WriteLine($"{Environment.CurrentManagedThreadId}: buy 1 product. Left {_productsAmount}");
        Monitor.PulseAll(this);
    }
}
