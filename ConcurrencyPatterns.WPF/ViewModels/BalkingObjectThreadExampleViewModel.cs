using ConcurrencyPatterns.WPF.Models.BalkedModel;
using System.Windows.Threading;

namespace ConcurrencyPatterns.WPF.ViewModels;

public class BalkingObjectThreadExampleViewModel : ThreadExampleViewModel
{
    private BalkedObjectModel _model;
    
    public BalkingObjectThreadExampleViewModel(Dispatcher dispatcher) : base(dispatcher)
    {
        _model = new BalkedObjectBadExampleModel(Job);
    }

    protected override void Execute(object? parameter)
    {
        _model = UseBadExample ? new BalkedObjectBadExampleModel(Job) : new BalkedObjectGoodExampleModel(Job);
        base.Execute(parameter);
    }

    protected override void ThreadTask()
    {
        UpdateText("Try start job");
        RandomThreadSleepIfEnabled();
        _model.DoJob();
    }

    private void Job()
    {
        UpdateText("Start doing job");
        RandomThreadSleepIfEnabled();
        UpdateText("Done doing job");
    }
}
