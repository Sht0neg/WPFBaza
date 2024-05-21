using Microsoft.EntityFrameworkCore;
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
        Context? context;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddGoodButton_Click(object sender, RoutedEventArgs e)
        {
            AddGoodsWindow add = new AddGoodsWindow(this);
            bool? result = add.ShowDialog();
        }

        private void AddProdButton_Click(object sender, RoutedEventArgs e)
        {
            AddProducerWindow add = new AddProducerWindow(this);
            bool? result = add.ShowDialog();
        }

        private void InfGoodButton_Click(object sender, RoutedEventArgs e)
        {
            GoodsWindow inf = new GoodsWindow(this);
            bool? result = inf.ShowDialog();
        }

        private void InfProdButton_Click(object sender, RoutedEventArgs e)
        {
            InfProducerWinsow inf = new InfProducerWinsow(this);
            bool? result = inf.ShowDialog();
        }

        public void addProducer(string name, string adress, string phone, string inn)
        {
            context = new Context();
            context.Producers.Load();
            context.Producers.Add(new Producer
            {
                Name = name,
                Phone = phone,
                Address = adress,
                INN = inn
            });
            context.SaveChanges();
        }
    }
}