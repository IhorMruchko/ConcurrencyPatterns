using System;

namespace ConcurrencyPatterns.WPF.Models.ActiveModel;

public abstract class ActiveObjectModel
{
    public event Action<string>? ValueChanged;
    
    protected int Value { get; set; }

    protected string DisplayValueFormat => "Value is {0}.";

    public abstract void Increase();

    public abstract void Decrease();

    public override string ToString() 
        => $"{Environment.CurrentManagedThreadId}: has value {Value}";

    protected virtual void RaiseEvent(string message)
        => ValueChanged?.Invoke(message);
}
