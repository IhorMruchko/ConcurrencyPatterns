using System;
using System.Threading;

namespace ConcurrencyPatterns.WPF.Models.BalkedModel;

internal class BalkedObjectBadExampleModel : BalkedObjectModel
{
    public BalkedObjectBadExampleModel(Action job) : base(job) { }
    
    public override void DoJob()
    {
        if (IsInProgress)
            return;
        Thread.Sleep(TimeSpan.FromSeconds(1));
        IsInProgress = true;
        Job();
        IsInProgress = false;
    }
}
