using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FlipCard.Helper
{
    public static class HighLightHelper
    {
        public static readonly DependencyProperty IsHighlightedProperty =
            DependencyProperty.RegisterAttached(
                "IsHighlighted",
                typeof(bool),
                typeof(HighLightHelper),
                new PropertyMetadata(false, OnIsHighlightedChanged));

        public static void SetIsHighlighted(DependencyObject obj, bool value)
        {
            obj.SetValue(IsHighlightedProperty, value);
        }

        public static bool GetIsHighlighted(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsHighlightedProperty);
        }

        private static void OnIsHighlightedChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBlock textBlock)
            {
                bool isHighlighted = (bool)e.NewValue;

                textBlock.SetCurrentValue(
                    TextBlock.ForegroundProperty,
                    isHighlighted ? Brushes.Red : Brushes.Green);
            }
        }
    }
}