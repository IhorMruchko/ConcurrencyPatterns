using ConcurrencyPatterns.WPF.ViewModels;
using System.Windows.Controls;

namespace ConcurrencyPatterns.WPF.Views;

public partial class BarrierObjectView : UserControl
{
    public BarrierObjectView()
    {
        InitializeComponent();
        DataContext = new BarrierObjectThreadExampleViewModel(Dispatcher);
    }
}
