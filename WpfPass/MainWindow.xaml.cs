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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Key> list1;
        private List<Key> list2;
        private List<(string login, string pass, List<Key> keys)> passwords;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBoxPass_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if(list1 == null)
            {
                list1 = new List<Key>();
            }
            list1.Add(e.Key);
        }

        private void TextBoxPassTest_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (list2 == null)
            {
                list2 = new List<Key>();
            }
            list2.Add(e.Key);
        }

        private void ButtonPass_Click(object sender, RoutedEventArgs e)
        {
            if (list1 == null)
            {
                list1 = new List<Key>();
            }

            if (passwords == null)
            {
                passwords = new List<(string login, string pass, List<Key> keys)>();
            }

            passwords.Add((TextBoxLogin.Text, TextBoxPass.Text, list1));            
            TextBoxPass.Text = "";
            list1 = null;
        }

        private void ButtonPassTest_Click(object sender, RoutedEventArgs e)
        {
            TextBoxLoginTest.Text = "";
            if (list2 == null)
            {
                list2 = new List<Key>();
            }

            if (passwords == null)
            {
                passwords = new List<(string login, string pass, List<Key> keys)>();
            }

            foreach (var item in passwords)
            {
                if(item.pass == TextBoxPassTest.Text && item.keys.SequenceEqual(list2))
                {
                    TextBoxLoginTest.Text = item.login;
                }
            }
            TextBoxPassTest.Text = "";
            list2 = null;
        }
    }
}
