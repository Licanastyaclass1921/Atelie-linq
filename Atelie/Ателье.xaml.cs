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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Atelie
{
    /// <summary>
    /// Логика взаимодействия для Ателье.xaml
    /// </summary>
    /// 

    

    public partial class Ателье : Window
    {
        bool redact = false;
        public Ателье()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            DB db2 = new DB();
            DB db3 = new DB();
            try
            {
                using (DataContext bae = new DataContext(db.getString()))
                {

                    Table<uslugi> uslugis = bae.GetTable<uslugi>();
                    var query = bae.GetTable<uslugi>().Where(u => u.Status == false);
                    uslygi.ItemsSource = query;

                }
                
                using (DataContext bae = new DataContext(db.getString()))
                {

                    Table<klient> uslugis = bae.GetTable<klient>(); 
                    var query = bae.GetTable<klient>().Where(u => u.Status == false);
                    klient.ItemsSource = query; 

                }
                
                using (DataContext bae = new DataContext(db.getString()))
                {
                    Table<View_1> uslugis = bae.GetTable<View_1>(); 
                    var query = bae.GetTable<View_1>().Where(u => u.Status == false); 
                    zakaza.ItemsSource = query; 
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
                
            }
        }


        private void Ok_Click_2(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            DB db2 = new DB();
            if (redact) 
            {
                using (DataContext bae = new DataContext(db.getString()))
                {
                    Table<uslugi> uslugis = bae.GetTable<uslugi>(); 
                    var query = bae.GetTable<uslugi>().Where(u => u.kod == ((uslugi)uslygi.SelectedItem).kod);
                    uslugi usluga = new uslugi(); 
                    usluga = query.FirstOrDefault(); 
                    if (usluga != null) 
                    {
                        usluga.Nazvanie = nazvUsl.Text; 
                        usluga.Hena = float.Parse(hena.Text); 
                    }
                    else
                    {
                        MessageBox.Show("Ошибка выбора услуги");
                    }
                    bae.SubmitChanges();

                }

                using (DataContext bae = new DataContext(db2.getString()))
                {

                    Table<uslugi> uslugis = bae.GetTable<uslugi>(); 
                    var query = bae.GetTable<uslugi>().Where(u => u.Status == false); 
                    uslygi.ItemsSource = query; 

                }
            }

            else
            { 
                using (DataContext bae = new DataContext(db.getString()))// создание контекста
                {
                    uslugi newUsl = new uslugi() // создание новой услуги
                    {
                        Nazvanie = nazvUsl.Text,
                        Hena = float.Parse(hena.Text),
                        Status = false
                    }; // и заполнение её данными с формы
                    bae.GetTable<uslugi>().InsertOnSubmit(newUsl); // вставка услуги
                    bae.SubmitChanges(); // сохранение
                }

                using (DataContext bae = new DataContext(db2.getString()))// создание контекста
                {

                    Table<uslugi> uslugis = bae.GetTable<uslugi>(); //создание таблицы
                    var query = bae.GetTable<uslugi>().Where(u => u.Status == false); // фильтрация только со статусом 0
                    uslygi.ItemsSource = query; //заполнение таблицы данными

                }
            }


            nazvUsl.IsEnabled = false; //отчистка и выключение текстбоксов и кнопок услуг
            nazvUsl.Text = "";
            hena.IsEnabled = false;
            hena.Text = "";
            Ok.IsEnabled = false;
            Otmena.IsEnabled = false;
            redact = false;
        }

        private void Novusl_Click(object sender, RoutedEventArgs e) //включение текстбоксов названия и цены услуги, включение режима для добавления (isEdit = false)
        {
            nazvUsl.IsEnabled = true;
            hena.IsEnabled = true;
            Ok.IsEnabled = true;
            Otmena.IsEnabled = true;
            redact = false;
        }

        private void Otmena_Click(object sender, RoutedEventArgs e) //отчистка и выключение текстбоксов и кнопок услуг
        {
            nazvUsl.IsEnabled = false;
            nazvUsl.Text = "";
            hena.IsEnabled = false;
            hena.Text = "";
            Ok.IsEnabled = false;
            Otmena.IsEnabled = false;
            redact = false;
        }

        private void red_Click(object sender, RoutedEventArgs e) // по нажатию редактировать включаются кнопки и в текстбоксы записывается 
        {
            nazvUsl.IsEnabled = true;
            hena.IsEnabled = true;
            Ok.IsEnabled = true;
            Otmena.IsEnabled = true;
            nazvUsl.Text = ((uslugi)uslygi.SelectedItem).Nazvanie;
            hena.Text = ((uslugi)uslygi.SelectedItem).Hena.ToString();
            redact = true;
        }

        private void udal_Click_1(object sender, RoutedEventArgs e) // кнопка удалить // тожесамое изменение только меняем статус
        {
            DB db = new DB();
            DB db2 = new DB();
            try
            {
                using (DataContext bae = new DataContext(db.getString())) 
                {
                    Table<uslugi> uslugis = bae.GetTable<uslugi>();
                    var query = bae.GetTable<uslugi>().Where(u => u.kod == ((uslugi)uslygi.SelectedItem).kod);
                    uslugi usluga = new uslugi();
                    usluga = query.FirstOrDefault();
                    if (usluga != null)
                    {
                        usluga.Status = true;
                    }
                    bae.SubmitChanges();
                }

                using (DataContext bae = new DataContext(db2.getString()))// создание контекста
                {

                    Table<uslugi> uslugis = bae.GetTable<uslugi>(); //создание таблицы
                    var query = bae.GetTable<uslugi>().Where(u => u.Status == false); // фильтрация только со статусом 0
                    uslygi.ItemsSource = query; //заполнение таблицы данными

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла ошибка"); //При ошибке выскакивает сообщение об ошибке 
                throw;
            }
        }

        bool redact2 = false;
        private void klien_Click(object sender, RoutedEventArgs e) //включение кнопок и текстбоксов клиента для добавления
        {
            FIO.IsEnabled = true;
            Adres.IsEnabled = true;
            Nomer.IsEnabled = true;
            OK.IsEnabled = true;
            Otm.IsEnabled = true;
            redact2 = false;
        }

        private void redak_Click(object sender, RoutedEventArgs e) //включение кнопок и текстбоксов клиента для редактирования
        {
           
            FIO.IsEnabled = true;
            Adr.IsEnabled = true;
            Nomer.IsEnabled = true;
            OK.IsEnabled = true;
            Otmena.IsEnabled = true;
            FIO.Text = ((klient)klient.SelectedItem).FIO;
            Adres.Text = ((klient)klient.SelectedItem).Adres.ToString();
            Nomer.Text = ((klient)klient.SelectedItem).TF.ToString();
            redact = true;



        }

        private void Otm_Click(object sender, RoutedEventArgs e) //отчистка и выключение кнопок и текстбоксов
        {
            FIO.IsEnabled = false;
            FIO.Text = "";
            Adres.IsEnabled = false;
            Adres.Text = "";
            Nomer.IsEnabled = false;
            Nomer.Text = "";
            OK.IsEnabled = false;
            Otm.IsEnabled = false;
            redact2 = false;
        }

        private void OK_Click(object sender, RoutedEventArgs e) //Нажатоие на ОК
        {
            DB db = new DB();
            DB db2 = new DB();
            if (redact2) //определение режима редактировать/добавить
            {
                using (db.GetConnect())
                {
                    db.ConnectOpen();
                    var command = new SqlCommand("Update klient set FIO='" + FIO.Text + "',Adres ='" + Adres.Text + "',TF = '" + Nomer.Text + "' where ID= " + ((DataRowView)klient.SelectedItem)[0].ToString(), db.GetConnect()); //запрос на редактирование ФИО, адреса и телефона по ИД указанному в таблице в 1 столбике выбранной строки таблицы
                    command.ExecuteNonQuery();
                }
                using (db2.GetConnect())
                {
                    db2.ConnectOpen();
                    var dataAdapter = new SqlDataAdapter("select * from klient where status = 0", db2.GetConnect());//обновление таблицы на форме
                    var data = new DataTable();
                    dataAdapter.Fill(data);
                    klient.ItemsSource = data.DefaultView;
                }
            }
            else
            {
                using (db.GetConnect())
                {
                    db.ConnectOpen();
                    var command = new SqlCommand("insert into klient(FIO,Adres,TF,Status)values('" + FIO.Text + "','" + Adres.Text + "','" + Nomer.Text + "',0)", db.GetConnect());
                    command.ExecuteNonQuery(); //запрос на добавление Клииента
                }
                using (db2.GetConnect())
                {
                    db2.ConnectOpen();
                    var dataAdapter = new SqlDataAdapter("select * from klient where status = 0", db2.GetConnect());//обновление таблицы на форме
                    var data = new DataTable();
                    dataAdapter.Fill(data);
                    klient.ItemsSource = data.DefaultView;
                }
            }

            FIO.IsEnabled = false;
            FIO.Text = "";
            Adres.IsEnabled = false;
            Adres.Text = "";
            Nomer.IsEnabled = false;
            Nomer.Text = "";
            OK.IsEnabled = false;
            Otm.IsEnabled = false;
            redact2 = false;
        }

        private void delit_Click(object sender, RoutedEventArgs e) //запрос на удаление клиента
        {
            DB db = new DB();
            DB db2 = new DB();
            try
            {
                
                using (DataContext bae = new DataContext(db.getString()))
                {
                    Table<klient> uslugis = bae.GetTable<klient>();
                    var query = bae.GetTable<klient>().Where(u => u.ID == ((klient)klient.SelectedItem).ID);
                    klient usluga = new klient();
                    usluga = query.FirstOrDefault();
                    if (usluga != null)
                    {
                        usluga.Status = true;
                    }
                    bae.SubmitChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла ошибка"); //При ошибке выскакивает сообщение об ошибке
            }

        }


        private void Novzak_Click(object sender, RoutedEventArgs e)//заполнение комбобоксов сущетвующими клиентами и услугами
        {
            DB db = new DB();
            DB db2 = new DB();
            try
            {
                using (db.GetConnect())
                {
                    db.ConnectOpen();
                    var dataAdapter = new SqlDataAdapter("Select Nazvanie from uslugi where status = 0", db.GetConnect());//получение списка услуг
                    var data = new DataTable();
                    dataAdapter.Fill(data);
                    nazvanieuslugi.Items.Clear();//отчистка комбобокса чтобы не повторялись услуги
                    for (int i = 0; i < data.Rows.Count; i++) //Цикл проходит столько раз, сколько услуг есть в таблице
                    {
                        nazvanieuslugi.Items.Add(data.Rows[i][0]);//Добавление услуг в комбобокс
                    }
                }

                using (db2.GetConnect())
                {
                    db2.ConnectOpen();
                    var dataAdapter = new SqlDataAdapter("Select FIO from klient where status = 0", db2.GetConnect());//получение списка клиентов
                    var data = new DataTable();
                    dataAdapter.Fill(data);
                    fioklienta.Items.Clear();//отчистка комбобокса чтобы не повторялись клиенты
                    for (int i = 0; i < data.Rows.Count; i++) //Цикл проходит столько раз, сколько клиентов есть в таблице
                    {
                        fioklienta.Items.Add(data.Rows[i][0]);//цикл для заполнения списка клиентов
                    }
                }
                nazvanieuslugi.IsEnabled = true;
                fioklienta.IsEnabled = true;
                datePicker1.IsEnabled = true;
                ok.IsEnabled = true;
                Otmen.IsEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла ошибка"); //При ошибке выскакивает сообщение об ошибке
            }
        }
        private void ok_Click_1(object sender, RoutedEventArgs e)//Добавление услуги
        {
            DB db = new DB();
            DB db2 = new DB();
            DB db3 = new DB();
            DB db4 = new DB();
            string kod, ID;

            using (db.GetConnect())
            {
                db.ConnectOpen();
                var data = new DataTable();
                var dataAdapter = new SqlDataAdapter("Select kod from uslugi where Nazvanie ='" + nazvanieuslugi.Text + "'", db.GetConnect()); //поиск ид услуги по названию, выбранному в комбобоксе
                dataAdapter.Fill(data);
                kod = data.Rows[0][0].ToString();//сохранение кода услуги
            }

            using (db2.GetConnect())
            {
                db2.ConnectOpen();
                var data2 = new DataTable();
                var dataAdapter2 = new SqlDataAdapter("Select ID from klient where FIO = '" + fioklienta.Text + "'", db2.GetConnect());//поиск ид клиента по ФИО, выбранному в комбобоксе
                dataAdapter2.Fill(data2);
                ID = data2.Rows[0][0].ToString();// сохранение id клиента
            }

            using (db3.GetConnect())
            {
                db3.ConnectOpen();
                var command = new SqlCommand("insert into zakazy(idklient,koduslugi,Data,OkazYSL,Status)values(" + ID + ",'" + kod + "','" + datePicker1.SelectedDate.Value.ToString("dd'.'MM'.'yyyy") + "',0,0)", db3.GetConnect());
                command.ExecuteNonQuery();
            }

            using (db4.GetConnect())
            {
                db4.ConnectOpen();
                var dataAdapter3 = new SqlDataAdapter("select * from View_1 where status = 0", db4.GetConnect());//обновление таблицы (представления) на форме
                var data3 = new DataTable();
                dataAdapter3.Fill(data3);
                zakaza.ItemsSource = data3.DefaultView;
            }

            nazvanieuslugi.Text = "";
            nazvanieuslugi.IsEnabled = false;
            fioklienta.Text = "";
            fioklienta.IsEnabled = false;
            datePicker1.SelectedDate = DateTime.Now;
            datePicker1.IsEnabled = false;
            ok.IsEnabled = false;
            Otmen.IsEnabled = false;
        }

        private void Otmen_Click(object sender, RoutedEventArgs e) //выключение и отчистка кнопок и комбобоксов
        {
            nazvanieuslugi.Text = "";
            nazvanieuslugi.IsEnabled = false;
            fioklienta.Text = "";
            fioklienta.IsEnabled = false;
            datePicker1.SelectedDate = DateTime.Now;
            datePicker1.IsEnabled = false;
            ok.IsEnabled = false;
            Otmen.IsEnabled = false;
        }

        private void vip_Click(object sender, RoutedEventArgs e)//отметка о выполнении заказа
        {
            DB db = new DB();
            DB db2 = new DB();
            using (db.GetConnect())
            {
                db.ConnectOpen();
                new SqlCommand("update zakazy set OkazYSL = 1 where id=" + ((DataRowView)zakaza.SelectedItem)[0].ToString(), db.GetConnect()).ExecuteNonQuery(); //запрос на изменения статуса услуги на 1 где ид услуги равен выбранному в таблице заказцу
            }

            using (db2.GetConnect())
            {
                db2.ConnectOpen();
                var dataAdapter3 = new SqlDataAdapter("select * from View_1 where status = 0", db2.GetConnect());//обновление таблицы на форме
                var data3 = new DataTable();
                dataAdapter3.Fill(data3);
                zakaza.ItemsSource = data3.DefaultView;
            }
        }

        private void zakaza_SelectionChanged(object sender, SelectionChangedEventArgs e) //поиск клиента по нажатию на заказ
        {
            DB db = new DB();
            if (zakaza.SelectedItem != null)
                using (DataContext bae = new DataContext(db.getString()))// создание контекста
                {

                    Table<klient> uslugis = bae.GetTable<klient>(); //создание таблицы
                    var query = bae.GetTable<klient>().Where(u => u.Status == false && u.ID==((View_1)zakaza.SelectedItem).idklient); // фильтрация только со статусом 0
                    inf.ItemsSource = query; //заполнение таблицы данными

                }
        }

        private void oki_Click(object sender, RoutedEventArgs e) //поиск заказов по дате

        {
           
            using (DataContext db = new DataContext(Properties.Settings.Default.AtelieConnectionString))
            {
                string date = datePicker2.Text;
                Table<uslugi> uslugi = db.GetTable<uslugi>();
                Table<klient> klient = db.GetTable<klient>();
                Table<zakazy> zakaz = db.GetTable<zakazy>();
                var query = from a in zakaz
                            join c in uslugi on a.idklient equals c.kod
                            where a.Data == Convert.ToDateTime(date)
                            select new { a.id, c.Nazvanie, a.Data,  a.Status  };
                zapros.ItemsSource = query;
            }

        }

        private void Zapr_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void okk_Click(object sender, RoutedEventArgs e)
        {
            
           
            using (DataContext db = new DataContext(Properties.Settings.Default.AtelieConnectionString))
            {
                string date = Convert.ToString(viborusl.SelectedItem);
                           Table<uslugi> uslugis = db.GetTable<uslugi>();
                var usl = (from a in uslugis
                           where a.Nazvanie == date
                           select a).ToArray();
                           Table<zakazy> zakazs = db.GetTable<zakazy>();
                var query = from a in zakazs
                            join c in uslugis on a.koduslugi equals c.kod
                            where a.koduslugi == usl[0].kod
                            select new { a.id, c.Nazvanie, a.Data, a.Status };
                zapros.ItemsSource = query;
            }

        }

        private void okkk_Click(object sender, RoutedEventArgs e)
        {
            
            
            using (DataContext db = new DataContext(Properties.Settings.Default.AtelieConnectionString))
            {
                string date = Convert.ToString(viborpo.SelectedItem);
                          Table<klient> klients = db.GetTable<klient>();
                var kl = (from a in klients
                          where a.FIO == date
                          select a).ToArray();
                Table<uslugi> uslugis = db.GetTable<uslugi>();
               
                Table<zakazy> zakazs = db.GetTable<zakazy>();
                var query = from a in zakazs
                            join b in klients on a.idklient equals b.ID
                            join c in uslugis on a.koduslugi equals c.kod
                            where a.idklient == kl[0].ID
                            select new { a.id, c.Nazvanie, a.Data, a.Status };
                zapros.ItemsSource = query;
            }
        }

        private void viborusl_DropDownOpened(object sender, EventArgs e) //заполнение комбобокса услуг, по его открытию 
        {
            DB db = new DB();
            using (db.GetConnect())
            {
                db.ConnectOpen();
                var dataAdapter = new SqlDataAdapter("Select Nazvanie from uslugi where status = 0", db.GetConnect());//получение списка услуг
                var data = new DataTable();
                dataAdapter.Fill(data);
                viborusl.Items.Clear();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    viborusl.Items.Add(data.Rows[i][0]);//цикл для заполнения списка услуг
                }

            }

        }

        private void viborpo_DropDownOpened(object sender, EventArgs e) //заполнение комбобокса клиентов по его открытию
        {
            DB db = new DB();
            using (db.GetConnect())
            {
                db.ConnectOpen();
                var dataAdapter = new SqlDataAdapter("Select FIO from klient where status = 0", db.GetConnect());//получение списка клиентов
                var data = new DataTable();
                dataAdapter.Fill(data);
                viborpo.Items.Clear();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    viborpo.Items.Add(data.Rows[i][0]);//цикл для заполнения списка клиентов
                }

            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            DB db2 = new DB();
            try
            {
                using (DataContext bae = new DataContext(db2.getString()))// создание контекста
                {

                    Table<uslugi> uslugis = bae.GetTable<uslugi>(); //создание таблицы
                    uslygi.ItemsSource = uslugis; //заполнение таблицы данными

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
    }
}
