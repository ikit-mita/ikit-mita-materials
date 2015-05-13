using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WpfClient.ServiceReference1;

namespace WpfClient
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

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            TestButton.IsEnabled = false;

            var sb = new StringBuilder();
            StockServiceClient proxy = new StockServiceClient();

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 5; i++)
            {
                sb.AppendFormat("{0}: Calling GetPrice", System.DateTime.Now);
                sb.AppendLine();

                var task = proxy.GetPriceAsync("MSFT")
                    .ContinueWith(
                        (prevTask) => sb.AppendFormat("{0}: Price:{1}\n", DateTime.Now, prevTask.Result));

                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

            ResTextBox.Text = sb.ToString();

            TestButton.IsEnabled = true;
        }
    }
}
