﻿using System.Windows.Input;
using Xamarin.Forms;

namespace SGSApp.Behaviors
{
    public class ItempedAttached
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.CreateAttached(
                "Command",
                typeof(ICommand),
                typeof(ListView),
                null,
                BindingMode.OneWay,
                null,
                OnItemTappedChanged);

        #region Métodos

        public static ICommand GetItemTapped(BindableObject bindable)
        {
            return (ICommand) bindable.GetValue(CommandProperty);
        }

        public static void SetItemTapped(BindableObject bindable, ICommand value)
        {
            bindable.SetValue(CommandProperty, value);
        }

        public static void OnItemTappedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as ListView;
            if (control != null) control.ItemTapped += OnItemTapped;
        }

        private static void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var control = sender as ListView;
            var command = GetItemTapped(control);
            if (command != null && command.CanExecute(e.Item)) command.Execute(e.Item);
        }

        #endregion
    }
}