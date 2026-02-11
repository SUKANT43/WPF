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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StylesTemplatesAndAnimations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AnimateAll_Click(object sender, RoutedEventArgs e)
{
    // 1️⃣ DoubleAnimation (Opacity)
    DoubleAnimation fade = new DoubleAnimation(1, 0.3, TimeSpan.FromSeconds(2));
    DemoText.BeginAnimation(TextBlock.OpacityProperty, fade);

    // 2️⃣ Transform Animation (Move)
    DoubleAnimation move = new DoubleAnimation(0, 200, TimeSpan.FromSeconds(2));
    translate.BeginAnimation(TranslateTransform.XProperty, move);

    // 3️⃣ Transform Animation (Scale / Zoom)
    DoubleAnimation zoom = new DoubleAnimation(1, 1.5, TimeSpan.FromSeconds(2));
    scale.BeginAnimation(ScaleTransform.ScaleXProperty, zoom);
    scale.BeginAnimation(ScaleTransform.ScaleYProperty, zoom);

    // 4️⃣ Transform Animation (Rotate)
    DoubleAnimation rotateAnim = new DoubleAnimation(0, 360, TimeSpan.FromSeconds(2));
    rotate.BeginAnimation(RotateTransform.AngleProperty, rotateAnim);

    // 5️⃣ ColorAnimation (Background)
    SolidColorBrush brush = new SolidColorBrush(Colors.LightGray);
    DemoText.Background = brush;

    ColorAnimation color = new ColorAnimation(Colors.LightGray, Colors.Orange, TimeSpan.FromSeconds(2));
    brush.BeginAnimation(SolidColorBrush.ColorProperty, color);

    // 6️⃣ ThicknessAnimation (Margin)
    ThicknessAnimation margin = new ThicknessAnimation(
        new Thickness(0),
        new Thickness(50),
        TimeSpan.FromSeconds(2));

    DemoText.BeginAnimation(TextBlock.MarginProperty, margin);

    // 7️⃣ KeyFrame Animation (Shake)
    DoubleAnimationUsingKeyFrames shake = new DoubleAnimationUsingKeyFrames();
    shake.Duration = TimeSpan.FromSeconds(0.5);

    shake.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.Zero)));
    shake.KeyFrames.Add(new LinearDoubleKeyFrame(-10, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(100))));
    shake.KeyFrames.Add(new LinearDoubleKeyFrame(10, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
    shake.KeyFrames.Add(new LinearDoubleKeyFrame(-10, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300))));
    shake.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(400))));

    translate.BeginAnimation(TranslateTransform.XProperty, shake);
}

    }
}
