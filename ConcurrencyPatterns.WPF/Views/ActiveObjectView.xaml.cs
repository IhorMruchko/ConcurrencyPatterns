using ConcurrencyPatterns.WPF.ViewModels;
using System.Windows.Controls;

namespace ConcurrencyPatterns.WPF.Views
{
    public partial class ActiveObjectView : UserControl
    {
        public ActiveObjectView()
        {
            InitializeComponent();
            DataContext = new ActiveObjectThreadExampleViewModel(Dispatcher);
        }
    }
}
