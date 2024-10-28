using Pro8Tasker.MVVM.ViewModels;
using Pro8Tasker.MVVM.Views;

namespace Pro8Tasker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainView());
        }
    }
}
