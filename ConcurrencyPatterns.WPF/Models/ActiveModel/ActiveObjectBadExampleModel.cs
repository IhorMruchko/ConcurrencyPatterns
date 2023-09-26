using System;
using System.Threading;

namespace ConcurrencyPatterns.WPF.Models.ActiveModel;

public class ActiveObjectBadExampleModel : ActiveObjectModel
{
    public override void Decrease()
    {
        Thread.Sleep(TimeSpan.FromSeconds(2));
        Value -= 1;
        RaiseEvent(ToString());
    }

    public override void Increase()
    {
        Thread.Sleep(TimeSpan.FromSeconds(2));
        Value += 1;
        RaiseEvent(ToString());
    }
}
