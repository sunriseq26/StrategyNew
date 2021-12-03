﻿using System;
using UnityEngine;
using UserControlSystem.UI.Model;
using Utils;

namespace UserControlSystem
{
    public class ScriptableObjectValueBase<T> : ScriptableObject, IAwaitable<T>
    {
        

        public T CurrentValue { get; private set; }
        public Action<T> OnNewValue;

        public virtual void SetValue(T value)
        {
            CurrentValue = value;
            OnNewValue?.Invoke(value);
        }

        public IAwaiter<T> GetAwaiter()
        {
            return new NewValueNotifier<T>(this);
        }
    }
}