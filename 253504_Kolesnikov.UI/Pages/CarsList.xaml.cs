using _253504_Kolesnikov.UI.ViewModels;

namespace _253504_Kolesnikov.UI.Pages;

public partial class CarsList : ContentPage
{
	public CarsList(CarsListViewModel carsListViewModel)
	{
		InitializeComponent();

		BindingContext = carsListViewModel;
	}
}