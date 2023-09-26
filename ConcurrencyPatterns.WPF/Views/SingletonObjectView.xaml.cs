using ConcurrencyPatterns.WPF.ViewModels;
using System.Windows.Controls;

namespace ConcurrencyPatterns.WPF.Views;

public partial class SingletonObjectView : UserControl
{
    public SingletonObjectView()
    {
        InitializeComponent();
        DataContext = new SingletonObjectThreadExampleViewModel(Dispatcher);
    }
}
