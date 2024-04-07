using _253504_Kolesnikov.UI.ViewModels;

namespace _253504_Kolesnikov.UI.Pages;

public partial class EditAdvertisement : ContentPage
{
	public EditAdvertisement(EditAdvertisementViewModel editAdvertisementViewModel)
	{
		InitializeComponent();

		BindingContext = editAdvertisementViewModel;
	}
}