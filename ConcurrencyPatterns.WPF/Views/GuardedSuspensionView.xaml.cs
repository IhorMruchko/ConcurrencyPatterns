using ConcurrencyPatterns.WPF.ViewModels;
using System.Windows.Controls;

namespace ConcurrencyPatterns.WPF.Views;

public partial class GuardedSuspensionView : UserControl
{
    public GuardedSuspensionView()
    {
        InitializeComponent();
        DataContext = new GuardedSuspensionThreadExampleViewModel(Dispatcher);
    }
}
