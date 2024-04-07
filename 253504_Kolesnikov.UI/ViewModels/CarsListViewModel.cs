using _253504_Kolesnikov.Application.CarUseCases.Queries;
using _253504_Kolesnikov.Application.AdvertisementUseCases.Queries;
using _253504_Kolesnikov.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;


namespace _253504_Kolesnikov.UI.ViewModels;

public partial class CarsListViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public CarsListViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    public ObservableCollection<Car> Cars { get; set; } = new();
    public ObservableCollection<Advertisement> Advertisements { get; set; } = new();

    //Выбранный в списке курс
    [ObservableProperty]
    Car selectedCar;

    //Команда обновления списка курсов
    [RelayCommand]
    async Task UpdateCarsList() => await GetCars();

    [RelayCommand]
    async Task UpdateAdvertisementsList() => await GetAdvertisements();

    [RelayCommand]
    async Task ShowDetails(Advertisement advertisement) => await GotoDetailsPage(advertisement);

    [RelayCommand]
    async Task AddCarPage() => await GoToAddCarPage();

    [RelayCommand]
    async Task AddAdvertisementPage() => await GoToAddAddvertisementPage();

    private async Task GoToAddCarPage()
    {
        await Shell.Current.GoToAsync(nameof(AddCar));
    }
    private async Task GoToAddAddvertisementPage()
    {
        await Shell.Current.GoToAsync(nameof(AddAdvertisement));
    }
    private async Task GotoDetailsPage(Advertisement advertisement)
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"advertisement", advertisement}
        };
        await Shell.Current.GoToAsync(nameof(AdvertisementDetails), parameters);
    }
    public async Task GetCars()
    {
        var cars = await _mediator.Send(new GetAllCarsQuery());
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Cars.Clear();
            foreach (var car in cars)
            {
                Cars.Add(car);
            }
        });
    }
    public async Task GetAdvertisements()
    {
        var advertisements = await _mediator.Send(new GetAdvertisementsByCarQuery(selectedCar.Id));
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Advertisements.Clear();
            foreach(var advertisement in advertisements)
            {
                Advertisements.Add(advertisement);
            }
        });
    }
}
