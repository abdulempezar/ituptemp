using Empezar.Models;

namespace MobileUI;

public class Display : IDisplay
{
    public async Task Alert(string message, DisplayTitle title = DisplayTitle.Error) =>
        await Application.Current!.MainPage!.DisplayAlert(title.Description(), message, "OK");
}
