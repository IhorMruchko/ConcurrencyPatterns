using static System.Formats.Asn1.AsnWriter;

namespace ConcurrencyPatterns.Console.GuardedSuspension;

public class Consumer
{
    private readonly Store _store;

    public Consumer(Store store)
    {
        _store = store;
    }

    public void Run(int times = 5)
    {
        for (var i = 0; i < times; ++i)
            _store.Buy();        
    }
}
