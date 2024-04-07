using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253504_Kolesnikov.UI.Pages;
using CommunityToolkit.Mvvm.Input;
using _253504_Kolesnikov.Application.AdvertisementUseCases.Handlers;

namespace _253504_Kolesnikov.UI.ViewModels;

[QueryProperty(nameof(Advertisement), "advertisement")]  // Передача объекта advertisement на страницу
public partial class AdvertisementDetailsViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public AdvertisementDetailsViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty]
    Advertisement advertisement;

    [RelayCommand]
    async Task EditAdvertisementItem() => await GoToEditAdvertisementPage();

    [RelayCommand]
    async Task DeleteAdvertisementItem() => await DeleteAdvertisement();

    [RelayCommand]
    async Task SetImage() => await SelectImageFromDevice();

    private async Task GoToEditAdvertisementPage()
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"advertisement", Advertisement }
        };
        await Shell.Current.GoToAsync(nameof(EditAdvertisement), parameters);
    }
    private async Task SelectImageFromDevice()
    {
        var pickedImage = await FilePicker.Default.PickAsync(PickOptions.Images);
        if (pickedImage is null) return;

        var fileType = pickedImage.ContentType.Split('/')[1];
        if (fileType is null || Advertisement is null)
        {
            return;
        }
        var dirPath = "C:\\2kurs_2sem\\ISP\\LR5\\253504_Kolesnikov\\253504_Kolesnikov.UI\\Images\\";
        var pathToImage = Path.Combine(dirPath, $"{(int)Advertisement.Id}.{fileType}");
        pathToImage = Path.Combine(FileSystem.Current.AppDataDirectory, pathToImage);
        using Stream inputStream = await pickedImage.OpenReadAsync();
        if (File.Exists(pathToImage))
        {
            File.Delete(pathToImage);
        }
        using Stream outputStream = File.Create(pathToImage);

        await inputStream.CopyToAsync(outputStream);
        this.OnPropertyChanged(nameof(Advertisement));
    }
    private async Task DeleteAdvertisement()
    {
        var deleteQuery = new DeleteAdvertisementQuery(Advertisement);
        await _mediator.Send(deleteQuery);
        await Shell.Current.GoToAsync(nameof(CarsList));
    }
}
