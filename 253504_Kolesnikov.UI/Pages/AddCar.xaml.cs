using _253504_Kolesnikov.UI.ViewModels;

namespace _253504_Kolesnikov.UI.Pages;

public partial class AddCar : ContentPage
{
	public AddCar(AddCarViewModel addCarViewModel)
	{
		InitializeComponent();

		BindingContext = addCarViewModel;
	}
}