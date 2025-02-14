namespace MobileUI;

public class AppKeys : IAppKeys
{
    public ValueTask<T> Get<T>(KeyName appKeys)
    {
        if (typeof(T) == typeof(DateTime?) || typeof(T) == typeof(DateTime))
            return ValueTask.FromResult((T)Convert.ChangeType(DateTime.FromBinary(Preferences.Default.Get<long>($"{appKeys}_{AppConsts.Environment}", DateTime.MinValue.ToBinary())), typeof(T)));
        else
            return ValueTask.FromResult(Preferences.Default.Get<T>($"{appKeys}_{AppConsts.Environment}", default!));
    }

    public ValueTask Set<T>(KeyName appKeys, T value)
    {
        Preferences.Default.Set<T>($"{appKeys}_{AppConsts.Environment}", value);
        return ValueTask.CompletedTask;
    }

    public ValueTask Remove(KeyName appKeys)
    {
        Preferences.Default.Remove($"{appKeys}_{AppConsts.Environment}");
        return ValueTask.CompletedTask;
    }

    public ValueTask Clear()
    {
        Preferences.Default.Clear();
        return ValueTask.CompletedTask;
    }
}
