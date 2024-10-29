using Pro8Tasker.MVVM.Models;
using Pro8Tasker.MVVM.ViewModels;

namespace Pro8Tasker.MVVM.Views;

public partial class NewTaskView : ContentPage
{
	public NewTaskView()
	{
		InitializeComponent();
	}

    private async void AddTaskClicked(object sender, EventArgs e)
    {
		var vm = BindingContext as NewTaskViewModel;
		var selectedCategory = vm?.Categories?.Where( x=>x.IsSelected == true ).FirstOrDefault();

		if (selectedCategory != null)
		{
			var task = new MyTask
			{
				TaskName = vm?.Task,
				CategoryId = selectedCategory.Id,
			};
			vm?.Tasks?.Add(task);
			await Navigation.PopAsync();
		}
		else
		{
			await DisplayAlert("Selección inválida", "Debes seleccionar una categoría", "Aceptar");
		}
    }
}