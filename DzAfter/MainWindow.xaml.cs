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
using System.Collections;

namespace DzAfter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> namephone;
        Dictionary<string, string> nameoper;
        public MainWindow()
        {
            InitializeComponent();
            namephone = new();
            nameoper = new();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indEl = listBox.SelectedIndex;
            if (indEl == -1) return;
            string name = listBox.Items[indEl].ToString()!;
            string phone = namephone[name];
            string oper = nameoper[name];

            phoneCurrentLabel.Content = phone;
            nameBox.Text = name;
            phoneBox.Text = phone;
            operBox.Text = oper;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameBox.Text;
            string phone = phoneBox.Text;
            string oper = operBox.Text;

            namephone[name] = phone;
            nameoper[name] = oper;
            updateListBox();
        }

        private void updateListBox() {
            listBox.Items.Clear();
            foreach (var item in namephone) {
            listBox.Items.Add(item.Key);
            }
            nameBox.Clear();
            phoneBox.Clear();
            operBox.Clear();
            phoneCurrentLabel.Content = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = nameBox.Text;
            string phone = phoneBox.Text;
            string oper = operBox.Text;

            namephone.Remove(name);
            nameoper.Remove(name);
            namephone[name] = phone;
            nameoper[name] = oper;
            updateListBox();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex == -1) return;
            namephone.Remove(nameBox.Text);
            nameoper.Remove(nameBox.Text);
            updateListBox();
        }
    }
}