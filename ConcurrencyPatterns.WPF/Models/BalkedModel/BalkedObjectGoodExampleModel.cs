using System;
using System.Threading;

namespace ConcurrencyPatterns.WPF.Models.BalkedModel;

public class BalkedObjectGoodExampleModel : BalkedObjectModel
{
    public BalkedObjectGoodExampleModel(Action job) : base(job) { }
    
    public override void DoJob()
    {
        lock (this)
        {
            if (IsInProgress)
                return;
            Thread.Sleep(TimeSpan.FromSeconds(1));
            IsInProgress = true;
        }
        Job();
        Complete();
    }

    private void Complete()
    {
        lock (this)
        {
            IsInProgress = false;
        }
    }
}
