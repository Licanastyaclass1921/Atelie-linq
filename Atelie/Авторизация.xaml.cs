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
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;


namespace Atelie
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext(Properties.Settings.Default.AtelieConnectionString))

                {
                    Table<avtoriz> uslugis = db.GetTable<avtoriz>();
                    var userLogin = (from u in uslugis
                                     where u.login == Логин.Text
                                     select u).ToArray();
                    var userPass = (from u in uslugis
                                    where u.Password == Пароль.Text
                                    select u).ToArray();
                    if (Логин.Text == userLogin[0].login)
                    {
                        if (Пароль.Text == userPass[0].Password)
                        {
                            Ателье w1 = new Ателье(); w1.Show(); this.Close();
                           
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

    

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Регистрация w2 = new Регистрация();
            w2.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
    }

