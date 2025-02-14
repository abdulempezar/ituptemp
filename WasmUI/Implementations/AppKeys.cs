using Blazored.LocalStorage;

namespace WasmUI;

public class AppKeys : IAppKeys
{
    private ILocalStorageService localStorage { get; set; }
    public AppKeys(ILocalStorageService _localStorage) => localStorage = _localStorage;

    public async ValueTask<T> Get<T>(KeyName appKeys) =>
        await localStorage.GetItemAsync<T>($"{appKeys}_{AppConsts.Environment}");

    public async ValueTask Set<T>(KeyName appKeys, T value) =>
        await localStorage.SetItemAsync<T>($"{appKeys}_{AppConsts.Environment}", value);

    public async ValueTask Remove(KeyName appKeys) =>
        await localStorage.RemoveItemAsync($"{appKeys}_{AppConsts.Environment}");

    public async ValueTask Clear() =>
        await localStorage.ClearAsync();
}
