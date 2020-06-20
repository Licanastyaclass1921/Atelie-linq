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
    [Table(Name = "avtoriz")]
    public class avtoriz
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "id_polzovarela")]
        public int id_polzovarela { get; set; }

        [Column(Name = "login")]
        public string login { get; set; }

        [Column(Name = "Password")]
        public string Password { get; set; }

        [Column(Name = "Roly")]
        public string Roly { get; set; }

        [Column(Name = "FIO")]
        public string FIO { get; set; }

    }
}
