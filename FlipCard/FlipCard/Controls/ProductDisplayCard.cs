using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlipCard.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:FlipCard.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:FlipCard.Controls;assembly=FlipCard.Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ProductDisplayCard/>
    ///
    /// </summary>
    public class ProductDisplayCard : Control
    {
        static ProductDisplayCard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProductDisplayCard), new FrameworkPropertyMetadata(typeof(ProductDisplayCard)));
        }

        public string ProductName
        {
            get;
            set;
        }

        public string ImageSource
        {
            get;
            set;
        }

        public double OfferedPrice
        {
            get;
            set;
        }

        public double OriginalPrice
        {
            get;
            set;
        }

        public int DiscountPercentage
        {
            get
            {
                if (OriginalPrice <= 0 || OfferedPrice <= 0)
                    return 0;

                if (OfferedPrice >= OriginalPrice)
                    return 0;

                return (int)Math.Round(
                    (OriginalPrice - OfferedPrice) / OriginalPrice * 100);
            }
        }

        public Visibility IsDiscountPercentageVisible
        {
            get
            {
                if (DiscountPercentage <= 0)
                {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }
        }

        public int RatingCount
        {
            get;
            set;
        }

        public bool IsPriceIncreased
        {
            get => (bool)GetValue(IsPriceIncreasedProperty);
            set => SetValue(IsPriceIncreasedProperty, value);
        }

        public static readonly DependencyProperty IsPriceIncreasedProperty =
            DependencyProperty.Register(
                nameof(IsPriceIncreased),
                typeof(bool),
                typeof(ProductDisplayCard),
                new PropertyMetadata(false));
   
        public bool IsOutOfStock
        {
            get => (bool)GetValue(IsOutOfStockProperty);
            set => SetValue(IsOutOfStockProperty, value);
        }

        public static readonly DependencyProperty IsOutOfStockProperty =
    DependencyProperty.Register(
        nameof(IsOutOfStock),
        typeof(bool),
        typeof(ProductDisplayCard),
        new PropertyMetadata(false));


    }
}
