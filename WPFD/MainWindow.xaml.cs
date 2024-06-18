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

namespace WPFD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context context;
        public MainWindow()
        {
            InitializeComponent();
            context = new Context();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Database.EnsureCreated();
            context.Posts.Load();
            datagrid.ItemsSource = context.Posts.Local.ToObservableCollection();
        }
    }
}