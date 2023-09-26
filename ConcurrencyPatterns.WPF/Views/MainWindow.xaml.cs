using Common.WPF.ViewModels;
using ConcurrencyPatterns.WPF.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace ConcurrencyPatterns.WPF.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new SlidebarViewModel().AddNext(new ActiveObjectThreadExampleViewModel(Dispatcher))
                                                 .AddNext(new BalkingObjectThreadExampleViewModel(Dispatcher))
                                                 .AddNext(new SingletonObjectThreadExampleViewModel(Dispatcher))
                                                 .AddNext(new GuardedSuspensionThreadExampleViewModel(Dispatcher))
                                                 .AddNext(new BarrierObjectThreadExampleViewModel(Dispatcher));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
