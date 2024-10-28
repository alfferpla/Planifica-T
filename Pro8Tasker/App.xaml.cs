using Pro8Tasker.MVVM.Views;

namespace Pro8Tasker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainView();
        }
    }
}
