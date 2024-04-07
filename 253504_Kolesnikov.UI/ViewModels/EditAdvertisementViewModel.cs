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
    [QueryProperty(nameof(Advertisement), "advertisement")]
    public partial class EditAdvertisementViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public EditAdvertisementViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public ObservableCollection<Car> Cars { get; set; } = new();

        [ObservableProperty]
        Advertisement advertisement;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        decimal cost;

        [ObservableProperty]
        string description;

        [ObservableProperty]
        DateTime createdAt;

        [ObservableProperty]
        string imagePath;

        [ObservableProperty]
        int? carId;

        [ObservableProperty]
        Car? selectedCar;

        [RelayCommand]
        async Task Enter() => await EditAdvertisement();

        [RelayCommand]
        async Task SelectFile() => await SelectImage();

        [RelayCommand]
        async Task UpdateCarsList() => await GetCars();

        private async Task EditAdvertisement()
        {
            if(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(ImagePath) || SelectedCar == null)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Вы не заполнили все поля", "Ок");
                return;
            }
            await _mediator.Send(new EditAdvertisementQuery(Advertisement.Id, Name.Trim(), CreatedAt, Description, Cost, ImagePath, SelectedCar.Id));
            await Shell.Current.GoToAsync(nameof(CarsList));
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
        private async Task GetCars()
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
            Name = Advertisement.Name;
            Cost = Advertisement.Cost;
            Description = Advertisement.Description;
            CreatedAt = Advertisement.CreatedAt;
            ImagePath = Advertisement.ImagePath;
            CarId = Advertisement.CarId;

            foreach(var item in Cars)
            {
                if(item.Id == CarId)
                {
                    SelectedCar = item;
                }
            }
        }

    }
}
