﻿using Xamarin.Forms;

namespace SGSApp.Extensions
{
    public static class BindableObjectExtensions
    {
        public static T GetValue<T>(this BindableObject bindableObject, BindableProperty property)
        {
            return (T) bindableObject.GetValue(property);
        }
    }
}