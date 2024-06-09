using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindableProperty<T>
{
    public delegate void ValueChangedHandler(T oldValue, T newValue);

    public event ValueChangedHandler OnValueChanged;

    private T _value;
    public T Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (!object.Equals(_value, value))
            {
                T oldValue = _value;
                _value = value;
                OnValueChanged?.Invoke(oldValue, _value);
            }
        }
    }

    public override string ToString()
    {
        return (Value != null ? Value.ToString() : "null");
    }
}