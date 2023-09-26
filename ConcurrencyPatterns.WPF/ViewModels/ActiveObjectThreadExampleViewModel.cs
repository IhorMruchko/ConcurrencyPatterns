using ConcurrencyPatterns.WPF.Models.ActiveModel;
using System.Windows.Threading;

namespace ConcurrencyPatterns.WPF.ViewModels;

public class ActiveObjectThreadExampleViewModel : ThreadExampleViewModel
{   
    private ActiveObjectModel _target = new ActiveObjectBadExampleModel();

    public ActiveObjectThreadExampleViewModel(Dispatcher dispatcher) : base(dispatcher) { }

    protected override void ThreadTask()
    {
        UpdateText($"Increase request");
        _target.Increase();
        RandomThreadSleepIfEnabled();
        UpdateText($"Decrease request");
        _target.Decrease();
        RandomThreadSleepIfEnabled();
    }

    protected override void Execute(object? parameter)
    {
        if (_target is ActiveObjectGoodExampleModel obj)
            obj.Stop();


        _target = UseBadExample ? new ActiveObjectBadExampleModel() : new ActiveObjectGoodExampleModel();
        _target.ValueChanged += Target_ValueChanged;
        
        base.Execute(parameter);
    }

    private void Target_ValueChanged(string obj)
    {
        foreach(var textBox in TextBoxes)
            UpdateText($"Value updated:{obj}", textBox);
    }
}
