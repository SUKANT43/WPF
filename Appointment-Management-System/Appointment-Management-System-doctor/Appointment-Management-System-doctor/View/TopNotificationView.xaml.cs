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

namespace Appointment_Management_System_doctor.View
{
    /// <summary>
    /// Interaction logic for TopNotificationView.xaml
    /// </summary>
    public partial class TopNotificationView : UserControl
    {
        private DispatcherTimer _timer;
        private Double _progress;
        public TopNotificationView()
        {
            InitializeComponent();
            Visibility = Visibility.Collapsed;
        }
        public void ShowNotification(string message, int durationSeconds = 5)
        {
            MessageText.Text = message;
            Visibility = Visibility.Visible;

            _progress = 100;
            TimerProgressBar.Value = 100;

            _timer?.Stop();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(50);

            double step = 100.0 / (durationSeconds * 20);

            _timer.Tick += (s, e) =>
            {
                _progress -= step;
                TimerProgressBar.Value = _progress;

                if (_progress <= 0)
                {
                    _timer.Stop();
                    Visibility = Visibility.Collapsed;
                }
            };

            _timer.Start();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            _timer?.Stop();
            Visibility = Visibility.Collapsed;
        }
    }
}
