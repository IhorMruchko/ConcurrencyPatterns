using System;
using System.Threading;

namespace ConcurrencyPatterns.WPF.Models.BarrierModel;

internal class BarrierObjectModelGoodExample : BarrierObjectModel
{
    private readonly Barrier _barrier = new(0);
    
    public override void GetAndStoreData(int threadIndex)
    {
        _barrier.AddParticipant();
        Thread.Sleep(TimeSpan.FromSeconds(RandomSleepTime));
        _barrier.SignalAndWait();
        RaiseEvent($"Get data from server: {threadIndex}.");
        Thread.Sleep(TimeSpan.FromSeconds(RandomSleepTime));
        _barrier.SignalAndWait();
        RaiseEvent($"Store data from server {threadIndex}.");
        _barrier.SignalAndWait();
    }
}
