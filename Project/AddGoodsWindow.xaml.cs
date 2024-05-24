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
            DataBeginBox.DisplayDate = good.DataBegin;
            DataEndBox.DisplayDate = good.DataEnd;
            YesBox.IsChecked = good.Availability;
            NumberBox.Text = good.RF;

        }

        public bool CheckGood(string name, string international, string rf, string price, string total) {
            if (name == "" || double.TryParse(name, out double numericValue)) { MessageBox.Show("Неправильно введено название!"); return false; };
            if (double.TryParse(international, out double numericValue1)) { MessageBox.Show("Неправильно введено международное название!"); return false; };
            if (double.TryParse(rf, out double num)) { MessageBox.Show("Неправильно введен регистрационный номер!"); return false; };
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
            
            Close();
            MessageBox.Show("Товар успешно добавлен!");
        }
    }
}
