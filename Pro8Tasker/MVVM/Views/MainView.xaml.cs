using Pro8Tasker.MVVM.ViewModels;

namespace Pro8Tasker.MVVM.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}
}