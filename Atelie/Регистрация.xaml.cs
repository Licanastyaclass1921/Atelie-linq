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
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;


namespace Atelie
{
    /// <summary>
    /// Логика взаимодействия для Регистрация.xaml
    /// </summary>
    public partial class Регистрация : Window
    {
        //string connectionString;
        public Регистрация()
        {
            InitializeComponent();
            //connectionString = ConfigurationManager.ConnectionStrings
            //     ["Atelie.Properties.Settings.AtelieConnectionString"].ConnectionString;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //проверка пароля
                string s = Password.Text;
                char[] array = s.ToCharArray(); // раскладываем строку парля на знаки
                int d = s.Length;
                int k = 0;
                int u = 0;
                int b = 0;
                char p = '$';
                char j = '!';
                char f = '@';
                char h = '%';
                char z = '^';
                char x = '#';

                // проверка на Верхний регистр
                for (int i = 0; i < d; i++)
                {
                    if (char.IsUpper(array[i]))//вычисляем регистр
                        k++;
                }

                // проверка на число
                for (int i = 0; i < d; i++)
                {
                    if (char.IsNumber(array[i]))//вычисляем числа
                        u++;
                }

                // проверка на знак
                for (int i = 0; i < d; i++)
                {//вычисляем знак
                    if (Convert.ToChar(p) == (array[i]) || Convert.ToChar(j) ==
                    (array[i]) || Convert.ToChar(h) == (array[i]) || Convert.ToChar(z) == (array[i]) ||
                    Convert.ToChar(f) == (array[i]) || Convert.ToChar(x) == (array[i]))
                        b++;
                }



                if ((k >= 1) && (Password.Text.Length >= 6) && (u >= 1) && (b >= 1))
                {
                    //using (SqlConnection connection = new SqlConnection(connectionString))
                    //{
                    //    connection.Open();
                    //    SqlCommand command = new SqlCommand("insert into [avtoriz] ([avtoriz].[login], [avtoriz].[Password],[avtoriz].[Roly] ,[avtoriz]. [FIO]) values ('"+ login.Text + "','" + Password.Text + "','" + Roly.Text + "','" + FIO.Text + "')", connection);
                    //    SqlDataReader reader = command.ExecuteReader();
                    //    MessageBox.Show("Пользователь добавлен");
                    //     Close();
                    //}
                    using (DataContext db = new DataContext(Properties.Settings.Default.AtelieConnectionString))
                    {
                        string fio = FIO.Text;
                        string log = login.Text; 
                        string pas = Password.Text;
                        string rol = Roly.Text;
                        avtoriz user = new avtoriz();
                        user.FIO = fio;
                        user.login = log;
                        user.Password = pas;
                        user.Roly = rol;
                        db.GetTable<avtoriz>().InsertOnSubmit(user);
                        db.SubmitChanges();
                        MessageBox.Show("Пользователь добавлен");
                    }

                }
                else
                {
                    MessageBox.Show("Пароль должен содержать $ ! @ # ^ %, как минимум 1 цифру, как минимум одну заглавную букву");
                }
            }

            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }
    }
}
        