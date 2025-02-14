using Microsoft.JSInterop;

namespace WasmUI;

public class Display : IDisplay
{
    private IJSRuntime JS { get; set; }
    public Display(IJSRuntime _JS) => JS = _JS;

    public async Task Alert(string message, DisplayTitle title = DisplayTitle.Error) =>
        await JS.InvokeVoidAsync("alert", message);
}
