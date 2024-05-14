using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddGoodsWindow add = new AddGoodsWindow(this);
            bool? result = add.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddProducerWindow add = new AddProducerWindow(this);
            bool? result = add.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GoodsWindow inf = new GoodsWindow(this);
            bool? result = inf.ShowDialog();
        }
    }
}