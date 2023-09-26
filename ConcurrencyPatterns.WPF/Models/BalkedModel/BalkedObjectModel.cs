using System;

namespace ConcurrencyPatterns.WPF.Models.BalkedModel;

public abstract class BalkedObjectModel
{
    protected Action Job { get; set; }

    protected bool IsInProgress { get; set; } = false;

    public BalkedObjectModel(Action job) 
    { 
        Job = job;
    }

    public abstract void DoJob();
}
