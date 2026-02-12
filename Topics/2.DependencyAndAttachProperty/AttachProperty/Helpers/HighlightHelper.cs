using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AttachProperty.Helpers
{
    public static class HighlightHelper
    {
        public static readonly DependencyProperty IsHighlightedProperty =
            DependencyProperty.RegisterAttached(
                "IsHighlighted",
                typeof(bool),
                typeof(HighlightHelper),
                new PropertyMetadata(false, OnIsHighlightedChanged)
            );

        public static void SetIsHighlighted(DependencyObject e,bool value)
        {
            e.SetValue(IsHighlightedProperty, value);
        }



        public static bool GetIsHighlighted(DependencyObject e)
        {
            return (bool)e.GetValue(IsHighlightedProperty);
        }

        private static void OnIsHighlightedChanged(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)

        {
            if(d is Control control)
            {
                bool isHighlighted = (bool)e.NewValue;
                control.Background = isHighlighted ? Brushes.Gold : Brushes.Blue;
            }
            else if(d is Button button)
            {
                bool isHighlighted = (bool)e.NewValue;
                button.Background = isHighlighted ? Brushes.Gold : Brushes.Blue;
            }
            else if(d is ListView ls)
            {
                bool isHighlighted = (bool)e.NewValue;
                ls.Background = isHighlighted ? Brushes.Gold : Brushes.Blue;
            }
        }
    }
}
