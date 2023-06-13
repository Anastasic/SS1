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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string strP = "";
        private void ChechClick(object sender, RoutedEventArgs e)
        {
            if (ch.IsChecked == true)
            {
                password.Text = passwordBox.Password;
                passwordBox.Visibility = Visibility.Hidden;
                password.Visibility = Visibility.Visible;
                strP = password.Text;
            }
            else
            {
                passwordBox.Password = password.Text;
                passwordBox.Visibility = Visibility.Visible;
                password.Visibility = Visibility.Hidden;
                strP = passwordBox.Password;

            }
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            if(strP.Trim() != "") { strP = passwordBox.Password; }
            if (login.Text.Trim() != ""  && strP.Trim() != "")
            {
                var Au = App.DB.user.Where(p => p.login == login.Text && p.parol == strP).FirstOrDefault();
                if (Au != null)
                {
                    App.USES = Au;
                    Window1 window = new Window1();
                    window.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("пользователь не найден");
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля");
            }
        }
    }
}
