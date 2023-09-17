namespace ConcurrencyPatterns.Console;

public class MultyThreadSingleton
{
    private static volatile MultyThreadSingleton? _instance;

    private static readonly object _instanceLock = new();

    private MultyThreadSingleton() { }

    public static MultyThreadSingleton Instance
    {
        get
        {
            System.Console.WriteLine($"{Environment.CurrentManagedThreadId}: try verify");
            if (_instance is null)
            {
                System.Console.WriteLine($"{Environment.CurrentManagedThreadId}: instance is null");
                lock (_instanceLock)
                {
                    if (_instance is null)
                    {
                        System.Console.WriteLine($"{Environment.CurrentManagedThreadId}: instance set");
                        _instance = new MultyThreadSingleton();
                    }

                }
            }
            System.Console.WriteLine($"{Environment.CurrentManagedThreadId}: instance returned");
            return _instance;
        }
    }
}
