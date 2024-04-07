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
    public partial class AddCarViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public AddCarViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public ObservableCollection<Car> Cars { get; set; } = new();

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string description;

        [ObservableProperty]
        string country;

        [ObservableProperty]
        int year;

        [RelayCommand]
        async Task Enter() => await AddCarToDb();

        private async Task AddCarToDb()
        {

            Name ??= string.Empty;
            Description ??= string.Empty;
            Country ??= string.Empty;
            await _mediator.Send(new AddCarQuery(Name.Trim(),Country.Trim(), Description.Trim(), Year));

            await Shell.Current.GoToAsync(nameof(CarsList));
        }
    }
}
