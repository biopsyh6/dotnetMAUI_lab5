using _253504_Kolesnikov.UI.ViewModels;

namespace _253504_Kolesnikov.UI.Pages;

public partial class AdvertisementDetails : ContentPage
{
	public AdvertisementDetails(AdvertisementDetailsViewModel advertisementDetailsViewModel)
	{
		InitializeComponent();

		BindingContext = advertisementDetailsViewModel;
	}
}