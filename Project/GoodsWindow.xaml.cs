using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для GoodsWindow.xaml
    /// </summary>
    public partial class GoodsWindow : Window
    {
        public Context? context;
        MainWindow? parent;
        public GoodsWindow(MainWindow? parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context = new Context();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Goods.Load();

            GoodsDataGridView.ItemsSource = context.Goods.Local.ToBindingList();
        }

        private void ReButton_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsDataGridView.SelectedItems.Count == 0) return;
            Goods? selectedItem = GoodsDataGridView.SelectedItem as Goods;

            AddGoodsWindow re = new AddGoodsWindow(selectedItem);
            bool? result = re.ShowDialog();

            Goods good = context.Goods.Find(selectedItem.Id);

            if (good == null) return;

            Goods modif = re.CurrentGood;

            context.Goods.Update(selectedItem);
        }
    }
}
