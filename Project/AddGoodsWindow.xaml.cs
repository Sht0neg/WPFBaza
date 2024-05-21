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
