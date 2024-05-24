using Microsoft.VisualBasic;
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
    /// Логика взаимодействия для AddGoodsWindow.xaml
    /// </summary>
    public partial class AddGoodsWindow : Window
    {
        MainWindow? parent;
        GoodsWindow? sparent;
        public Goods? CurrentGood;
        List<Producer> producers;

        public AddGoodsWindow(MainWindow? parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.Title = "Добавление товара";
        }

        public AddGoodsWindow(GoodsWindow? parent)
        {
            InitializeComponent();
            this.sparent = parent;
            this.Title = "Изменение товара";
        }

        public AddGoodsWindow(Goods good)
        {
            InitializeComponent();
            this.CurrentGood = good;

            NameBox.Text = good.Name;
            InterNameBox.Text = good.Intenational;
            DataBeginBox.DisplayDate = (DateTime)good.DataBegin;
            DataEndBox.DisplayDate = (DateTime)good.DataEnd;
            YesBox.IsChecked = good.Availability;
            NumberBox.Text = good.RF;

        }

        public bool CheckGood(string name, string international, string rf, string price, string total) {
            if (name == "" || double.TryParse(name, out double numericValue)) { MessageBox.Show("Неправильно введено название!"); return false; };
            if (double.TryParse(international, out double numericValue1)) { MessageBox.Show("Неправильно введено международное название!"); return false; };
            if (rf == "") { MessageBox.Show("Неправильно введен регистрационный номер!"); return false; };
            if (!double.TryParse(price, out double numer)) { MessageBox.Show("Неправильно введена цена товара!"); return false; }
            if (!int.TryParse(total, out int numeric)) { MessageBox.Show("Неправильно введено количество товара!"); return false; }
            return true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckGood(NameBox.Text, InterNameBox.Text, NumberBox.Text, PriceBox.Text, CountBox.Text))
            {
                Producer current = new Producer();
                if (InterNameBox.Text == "") { InterNameBox.Text = NameBox.Text; }
                foreach (Producer p in producers) {
                if (p.Name == ProducerBox.SelectedItem) {
                        current = p; 
                    }
                }
                if (!(bool)YesBox.IsChecked) {
                    CountBox.Text = "0";
                }
                parent.addGood(
                    NameBox.Text,
                    InterNameBox.Text,
                    DataBeginBox.SelectedDate,
                    DataEndBox.SelectedDate,
                    YesBox.IsChecked,
                    NumberBox.Text,
                    current,
                    PackBox.Text,
                    Convert.ToDouble(PriceBox.Text),
                    Convert.ToInt32(CountBox.Text)
                ) ;
                Close();
                MessageBox.Show("Товар успешно добавлен!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            producers = parent.ProducerList();
            foreach (Producer producer in producers)
            {
                ProducerBox.Items.Add(producer.Name);
            }
            List<string> batches = new List<string>() { "Ампулы", "Саше", "Флакон", "Блистер", "Туба" };
            foreach (string batch in batches) {
                PackBox.Items.Add(batch);
            }
            DataBeginBox.SelectedDate = DateTime.Today;
            DataEndBox.SelectedDate = DateTime.Today;
        }
    }
}
