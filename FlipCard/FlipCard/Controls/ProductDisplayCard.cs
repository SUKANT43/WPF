using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


       

        public string ProductDescription
        {
            get;
            set;
        }


        public ProductDisplayCard()
        {
            ProductFeatures = new ObservableCollection<string>();
            IsLiked = false;
        }

        public ObservableCollection<string> ProductFeatures
        {
            get => (ObservableCollection<string>)GetValue(ProductFeaturesProperty);
            set => SetValue(ProductFeaturesProperty, value);
        }

        public static readonly DependencyProperty ProductFeaturesProperty =
            DependencyProperty.Register(
                nameof(ProductFeatures),
                typeof(ObservableCollection<string>),
                typeof(ProductDisplayCard),
                new PropertyMetadata(null));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("likeButton") is Button likeButton)
            {
                likeButton.Click -= LikeButton_Click;
                likeButton.Click += LikeButton_Click;
            }


            this.MouseLeftButtonUp -= Card_MouseLeftButtonUp;
            this.MouseLeftButtonUp += Card_MouseLeftButtonUp;

        }

        private void Card_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsFlipped = !IsFlipped;
        }

        private void LikeButton_Click(object sender, RoutedEventArgs e)
        {
            IsLiked = !IsLiked;
        }

        public static readonly DependencyProperty IsLikedProperty =
            DependencyProperty.Register(
                nameof(IsLiked),
                typeof(bool),
                typeof(ProductDisplayCard),
                new PropertyMetadata(false, OnIsLikedChanged));

        public bool IsLiked
        {
            get => (bool)GetValue(IsLikedProperty);
            set => SetValue(IsLikedProperty, value);
        }

        private static void OnIsLikedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ProductDisplayCard)d;

            control.HeartPngSource = (bool)e.NewValue
                ? "pack://application:,,,/FlipCard;component/Image/heart-filled.png"
                : "pack://application:,,,/FlipCard;component/Image/heart-raw.png";
        }

        public static readonly DependencyProperty HeartPngSourceProperty =
            DependencyProperty.Register(
                nameof(HeartPngSource),
                typeof(string),
                typeof(ProductDisplayCard),
                new PropertyMetadata("pack://application:,,,/FlipCard;component/Image/heart-raw.png"));

        public string HeartPngSource
        {
            get => (string)GetValue(HeartPngSourceProperty);
            set => SetValue(HeartPngSourceProperty, value);
        }

        public static readonly DependencyProperty IsFlippedProperty =
            DependencyProperty.Register(
                nameof(IsFlipped),
                typeof(bool),
                typeof(ProductDisplayCard),
                new PropertyMetadata(false));

        public bool IsFlipped
        {
            get => (bool)GetValue(IsFlippedProperty);
            set => SetValue(IsFlippedProperty, value);
        }

    }
}

