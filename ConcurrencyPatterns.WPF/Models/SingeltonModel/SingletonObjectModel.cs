using System;

namespace ConcurrencyPatterns.WPF.Models.SingeltonModel;

public abstract class SingletonObjectModel
{
    protected SingletonObjectModel? _instance;

    public event Action<string>? OnInstanceAccess;
    
    public abstract SingletonObjectModel Instance { get; }

    protected void RaiseEvent(string message) 
        => OnInstanceAccess?.Invoke(message);
}
