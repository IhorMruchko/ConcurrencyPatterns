using ConcurrencyPatterns.WPF.Models.GuardedSuspensionModel;
using System;
using System.Windows.Threading;

namespace ConcurrencyPatterns.WPF.ViewModels;

public class GuardedSuspensionThreadExampleViewModel : ThreadExampleViewModel
{
    private GuardedSuspensionObjectModel _model;

    public GuardedSuspensionThreadExampleViewModel(Dispatcher dispatcher) : base(dispatcher)
    {
        _model = new GuardedSuspensionBadExampleModel(ThreadsAmount * Random.Shared.Next(1, 5));
    }

    protected override void Execute(object? parameter)
    {
        _model = UseBadExample 
            ? new GuardedSuspensionBadExampleModel(ThreadsAmount)
            : new GuardedSuspensionGoodExampleModel(ThreadsAmount);
        _model.OnAmountChanged += Model_OnAmountChanged;
        base.Execute(parameter);
    }

    protected override void ThreadTask()
    {
        if (TryGetIndex(out var index) == false)
            return;
        
        if (index % 2 == 0)
        {
            for (var i = 0; i < ThreadsAmount; ++i)
                _model.Add();
            return;
        }

        for (var i = 0; i < ThreadsAmount; ++i)
            _model.Remove();
    }

    private void Model_OnAmountChanged(string obj)
    {
        UpdateText(obj);
        RandomThreadSleepIfEnabled();
    }
}
