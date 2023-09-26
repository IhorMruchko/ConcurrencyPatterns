using ConcurrencyPatterns.WPF.Models.BarrierModel;
using System.Windows.Threading;

namespace ConcurrencyPatterns.WPF.ViewModels;

public class BarrierObjectThreadExampleViewModel : ThreadExampleViewModel
{
    private BarrierObjectModel _model = new BarrierObjectModelBadExample();
    
    public BarrierObjectThreadExampleViewModel(Dispatcher dispatcher) : base(dispatcher)
    {
        _model.OnStagePassed += OnStagePassed;
    }

    private void OnStagePassed(string obj)
    {
        UpdateText(obj);
        RandomThreadSleepIfEnabled();
    }

    protected override void ThreadTask()
    {
        if (TryGetIndex(out var index) == false)
            return;
        
        _model.GetAndStoreData(index);    
    }

    protected override void Execute(object? parameter)
    {
        _model = UseBadExample ? new BarrierObjectModelBadExample() : new BarrierObjectModelGoodExample();
        _model.OnStagePassed += OnStagePassed;
        base.Execute(parameter);
    }
}
