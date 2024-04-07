using _253504_Kolesnikov.Application.AdvertisementUseCases.Queries;
using _253504_Kolesnikov.Application.CarUseCases.Queries;
using _253504_Kolesnikov.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kolesnikov.UI.ViewModels
{
    public partial class AddAdvertisementViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public AddAdvertisementViewModel(IMediator mediator)
        {
            _mediator = mediator;
            Cost = 20000;
        }
        public ObservableCollection<Car> Cars { get; set; } = new();

        [ObservableProperty]
        string name;

        [ObservableProperty]
        decimal cost;

        [ObservableProperty]
        string description;

        [ObservableProperty]
        DateTime createdAt;

        [ObservableProperty]
        int carId;

        [ObservableProperty]
        string imagePath;

        [ObservableProperty]
        Car? selectedCar;

        [RelayCommand]
        async Task Enter() => await AddAdvertisement();

        [RelayCommand]
        async Task UpdateCarsList() => await GetCars();

        [RelayCommand]
        async Task SelectFile() => await SelectImage();
        private async Task AddAdvertisement()
        {
            if(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(ImagePath) || SelectedCar == null)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Вы не заполнили все поля", "Ок");
                return;
            }
            CarId = SelectedCar.Id;
            await _mediator.Send(new AddAdvertisementQuery(Name.Trim(), CreatedAt, Description, Cost, ImagePath, CarId));
            await Shell.Current.GoToAsync(nameof(CarsList));
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
        private async Task SelectImage()
        {
            var images = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Pick Barcode/QR Code Image",
                FileTypes = FilePickerFileType.Images
            });
            ImagePath = images.FullPath.ToString();
        }
    }
}
