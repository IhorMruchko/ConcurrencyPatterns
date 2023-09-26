using System;
using System.Threading;

namespace ConcurrencyPatterns.WPF.Models.BarrierModel;

public class BarrierObjectModelBadExample : BarrierObjectModel
{
    public override void GetAndStoreData(int threadIndex)
    {
        Thread.Sleep(TimeSpan.FromSeconds(RandomSleepTime));
        RaiseEvent($"Get data from server: {threadIndex}.");
        Thread.Sleep(TimeSpan.FromSeconds(RandomSleepTime));
        RaiseEvent($"Store data from server {threadIndex}.");
    }
}
