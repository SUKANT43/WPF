using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static ConnectorDataTable.DataProvider;

namespace ConnectorDataTable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataProvider.CalibrationMeasurement _data;
        public ObservableCollection<CalibrationRow> Rows { get; set; }=new ObservableCollection<CalibrationRow>();
        private Dictionary<int, int> _chamberPinMap;
        public MainWindow()
        {
            InitializeComponent();
            _data = DataProvider.CalibrationMeasurement.GetData();
            BuildChamberPinMap();
            GenertateColumns();
            LoadData("X");
            DataContext = this;
        }

        private void LoadData(string axis)
        {
            Rows.Clear();
            var result = DataProvider.BuilRows(_data, axis, _chamberPinMap);
            foreach (var row in result)
            {
                Rows.Add(row);
            }
        }

        private void GenertateColumns()
        {
            dataGrid.Columns.Clear();
            dataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Image Id",
                Binding = new Binding("ImageId")
            });

            dataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Parameter",
                Binding = new Binding("Parameter")
            });

            int columnIndex = 0;
            foreach (var chamber in _chamberPinMap.OrderBy(x => x.Key))
            {
                int chamberId = chamber.Key;
                int maxPins = chamber.Value;

                for (int pinId = 1; pinId <= maxPins; pinId++)
                {
                    dataGrid.Columns.Add(new DataGridTextColumn
                    {
                        Header = $"Ch{chamberId}({pinId})",
                        Binding = new Binding($"Values[{columnIndex}]")
                    });

                    columnIndex++;
                }
            }
        }

        private void BuildChamberPinMap()
        {
            _chamberPinMap = new Dictionary<int, int>();
            foreach(var image in _data.CalibrationMeasurementCollection.Values)
            {
                foreach(var chamber in image)
                {
                    int chamberId = chamber.Key;
                    int pinCount = chamber.Value.CalibrationMeasurements.Count;

                    if (!_chamberPinMap.ContainsKey(chamberId))
                        _chamberPinMap[chamberId] = pinCount;
                    else
                        _chamberPinMap[chamberId] =
                            Math.Max(_chamberPinMap[chamberId], pinCount);
                }
            }
        }

        private void XAxisClick(object sender, RoutedEventArgs e)
        {
            LoadData("X");
            xButton.Background = new SolidColorBrush(Color.FromArgb(255, 59, 130, 246));
            xButton.Foreground = Brushes.White;
            yButton.Background=Brushes.White;
            yButton.Foreground = Brushes.Black;
            zButton.Background = Brushes.White;
            zButton.Foreground = Brushes.Black;

        }
        private void YAxisClick(object sender, RoutedEventArgs e)
        {
            LoadData("Y");
            yButton.Background = new SolidColorBrush(Color.FromArgb(255, 59, 130, 246));
            yButton.Foreground = Brushes.White;
            xButton.Background = Brushes.White;
            xButton.Foreground = Brushes.Black;
            zButton.Background = Brushes.White;
            zButton.Foreground = Brushes.Black;

        }
        private void ZAxisClick(object sender, RoutedEventArgs e)
        {
            LoadData("Z");
            zButton.Background = new SolidColorBrush(Color.FromArgb(255, 59, 130, 246));
            zButton.Foreground = Brushes.White;
            xButton.Background = Brushes.White;
            xButton.Foreground = Brushes.Black;
            yButton.Background = Brushes.White;
            yButton.Foreground = Brushes.Black;

        }
    }

}
