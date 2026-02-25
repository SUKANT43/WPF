using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FlipCard.Helper
{
    public static class StockHelper
    {
        public static readonly DependencyProperty IsOutOfStockProperty =
            DependencyProperty.RegisterAttached(
                "IsOutOfStock",
                typeof(bool),
                typeof(StockHelper),
                new PropertyMetadata(false, OnIsOutOfStockChanged));

        public static void SetIsOutOfStock(DependencyObject obj, bool value)
        {
            obj.SetValue(IsOutOfStockProperty, value);
        }

        public static bool GetIsOutOfStock(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsOutOfStockProperty);
        }

        private static void OnIsOutOfStockChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            bool isOut = (bool)e.NewValue;

            if (d is TextBlock textBlock)
            {
                textBlock.SetCurrentValue(
                    TextBlock.ForegroundProperty,
                    isOut ? Brushes.Red : Brushes.Green);
                textBlock.Text = isOut ? "Out of Stock" : "In Stock";
            }

            if (d is Border border)
            {
                border.SetCurrentValue(
                    Border.BackgroundProperty,
                    isOut ? Brushes.Red : Brushes.Green);
            }

            if(d is Button button)
            {
                button.Visibility = isOut
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            }
        }
    }
}