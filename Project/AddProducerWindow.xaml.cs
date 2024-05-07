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
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для AddProducerWindow.xaml
    /// </summary>
    public partial class AddProducerWindow : Window
    {
        MainWindow? parent;
        public AddProducerWindow(MainWindow? parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
            MessageBox.Show("Поставщик успешно добавлен!");
        }
    }
}
