using System;

namespace ConcurrencyPatterns.WPF.Models.GuardedSuspensionModel;

public abstract class GuardedSuspensionObjectModel
{
    public event Action<string>? OnAmountChanged; 

    protected int UpperLimit { get; set; }
    
    protected int CurrentAmount { get; set; }

    public GuardedSuspensionObjectModel(int upperLimit) 
        => UpperLimit = upperLimit;

    public abstract void Add();

    public abstract void Remove();

    protected void RaiseEvent(string message) 
        => OnAmountChanged?.Invoke(message);
}
