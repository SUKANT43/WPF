using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ICommandExamples
{
    public class ButtonVm:INotifyPropertyChanged
    {
        public ICommand SayHelloCommand { get; }

        public ButtonVm()
        {
            SayHelloCommand = new RelayCommand(SayHello);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SayHello()
        {
            MessageBox.Show("hi from ICommand");
        }


    }
}
