namespace ConcurrencyPatterns.Console.GuardedSuspension;

public class Producer
{
    private readonly Store _store;
    
    public Producer(Store store)
    {
        _store = store;
    }

    public void Run(int times = 5)
    {
        for(var i = 0; i < times; ++i)
            _store.Sell();
    }
}
