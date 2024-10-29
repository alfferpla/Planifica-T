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

    private async void AddCategoryClicked(object sender, EventArgs e)
    {
		var vm = BindingContext as NewTaskViewModel;


		/* Cambio no fusionado mediante combinación del proyecto 'Pro8Tasker (net8.0-windows10.0.19041.0)'
		Antes:
				string category = await DisplayPromptAsync("Nueva Categoría", "Introduce el nombre de la nueva categoría",
					maxLength: 15,
		Después:
				string category = await DisplayPrompt("Nueva Categoría", "Introduce el nombre de la nueva categoría",
					maxLength: 15,
		*/
		string category =
			await DisplayPromptAsync("Nueva Categoría",
			"Introduce el nombre de la nueva categoría",
			maxLength: 15,
			keyboard: Keyboard.Text);

		var r = new Random();

		if (!string.IsNullOrEmpty(category))
		{
			vm?.Categories?.Add(new Category
			{
				Id = vm.Categories.Max( x => x.Id ) +1,
				Color = Color.FromRgb(
					r.Next(0,255),
					r.Next(0,255),
					r.Next(0,255)).ToHex(),
				CategoryName = category
			});
		}
    }

    

}