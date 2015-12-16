using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace FrameMeasure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Ballpark60HzSleepTimeMs = 1000 / 60;

        private readonly Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;

        public MainWindow()
        {
            InitializeComponent();


            var t = new Thread(DoStuff);
            t.IsBackground = true;
            t.Start();
        }

        void DoStuff()
        {
            int counter = 0;
            while (true)
            {
                _dispatcher.BeginInvoke(new Action(() =>
                {
                    label.Content = counter++;

                    if (counter == 60)
                    {
                        counter = 0;
                    }
                }));       

                Thread.Sleep(Ballpark60HzSleepTimeMs);
            }
        }

    }
}
