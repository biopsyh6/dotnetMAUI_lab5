using _253504_Kolesnikov.UI.ViewModels;

namespace _253504_Kolesnikov.UI.Pages;

public partial class AddAdvertisement : ContentPage
{
	public AddAdvertisement(AddAdvertisementViewModel addAdvertisementViewModel)
	{
		InitializeComponent();

		BindingContext = addAdvertisementViewModel;
	}
}