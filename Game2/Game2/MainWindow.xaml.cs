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
using System.Windows.Threading;

namespace Game2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer diceTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            diceTimer.Interval = TimeSpan.FromMilliseconds(80);

            LoadImage();
        }

        private void LoadImage()
        {
            int number = 0;
            int size = 10; 

            for (int row = size - 1; row >= 0; row--) 
            {
                bool leftToRight = ((size - 1 - row) % 2 == 0);

                if (leftToRight)
                {
                    for (int col = 0; col < size; col++)
                    {
                        AddCellImage(row, col, number++);
                    }
                }
                else
                {
                    for (int col = size - 1; col >= 0; col--)
                    {
                        AddCellImage(row, col, number++);
                    }
                }
            }
        }

        private void AddCellImage(int row, int col, int number)
        {
            BitmapImage src = new BitmapImage(
                new Uri($"pack://application:,,,/images/{number}.jpg", UriKind.Absolute));

            Image img = new Image
            {
                Source = src,
                Stretch = Stretch.Fill
            };

            Grid.SetRow(img, row);
            Grid.SetColumn(img, col);

            myGrid.Children.Add(img);
        }

        private void Dice_MouseDown(object sender, MouseButtonEventArgs e)
        {
            for(int i = 1; i <= 6; i++)
            {
                BitmapImage src = new BitmapImage(new Uri($"pack://application:,,,/images/{i}dice.png", UriKind.Absolute));
                diceImage.Source = src;
            }
        }
    }
}
