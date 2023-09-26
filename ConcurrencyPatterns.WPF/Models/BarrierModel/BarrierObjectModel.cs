using System;

namespace ConcurrencyPatterns.WPF.Models.BarrierModel;

public abstract class BarrierObjectModel
{
    public event Action<string>? OnStagePassed;

    public abstract void GetAndStoreData(int threadIndex);

    protected virtual void RaiseEvent(string message)
        => OnStagePassed?.Invoke(message);

    protected virtual double RandomSleepTime => 1 +
        (Random.Shared.NextInt64() % 2 == 1
        ? Random.Shared.NextDouble()
        : -Random.Shared.NextDouble());
}
