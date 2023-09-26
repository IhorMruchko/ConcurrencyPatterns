using ConcurrencyPatterns.WPF.Models.SingeltonModel;
using System.Windows.Threading;

namespace ConcurrencyPatterns.WPF.ViewModels;

public class SingletonObjectThreadExampleViewModel : ThreadExampleViewModel
{
    private SingletonObjectModel _model = new SingletonObjectBadExampleModel();

    public SingletonObjectThreadExampleViewModel(Dispatcher dispatcher) : base(dispatcher)
    {
    }

    protected override void Execute(object? parameter)
    {
        _model = UseBadExample ? new SingletonObjectBadExampleModel() : new SingletonObjectGoodExampleModel();
        _model.OnInstanceAccess += Model_OnInstanceAccess;
        base.Execute(parameter);
    }

    protected override void ThreadTask()
    {
        UpdateText("Try get instance");
        var instance = _model.Instance;
    }

    private void Model_OnInstanceAccess(string obj)
    {
        UpdateText(obj);
        RandomThreadSleepIfEnabled();
    }
}
