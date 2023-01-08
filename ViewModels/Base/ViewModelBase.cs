using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TwoWindowsMVVM.ViewModels;

internal abstract class ViewModelBase : INotifyPropertyChanged
{
    private readonly Lazy<Dictionary<string, object?>> _values =
        new(() => new Dictionary<string, object?>(), System.Threading.LazyThreadSafetyMode.PublicationOnly);


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    protected virtual bool Set<T>(ref T fild, T value, [CallerMemberName] string propertyName = null!)
    {
        if (Equals(fild, value))
            return false;

        fild = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    protected virtual bool Set<T>(T value, [CallerMemberName] string propertyName = null!)
    {
        if (propertyName is null)
            throw new ArgumentNullException(nameof(propertyName));

        var values = _values.Value;
        if (values.TryGetValue(propertyName, out var old_value) && Equals(old_value, value))
            return false;

        values[propertyName] = value;
        OnPropertyChanged(propertyName);

        return true;

    }

    protected virtual T? Get<T>([CallerMemberName] string propertyName = null!)
    {
        if (propertyName is null) throw new ArgumentNullException(nameof(propertyName));
        if (!_values.IsValueCreated) return default;
        if (_values.Value is not { Count: > 0 } values) return default;
        return values.TryGetValue(propertyName, out var value) ? (T?)value : default;
    }



}
