using ConcurrencyPatterns.WPF.ViewModels;
using System.Windows.Controls;

namespace ConcurrencyPatterns.WPF.Views;

public partial class BalkingObjectView : UserControl
{
    public BalkingObjectView()
    {
        InitializeComponent();
        DataContext = new BalkingObjectThreadExampleViewModel(Dispatcher);
    }
}
