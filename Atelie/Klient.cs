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
        [Table(Name = "klient")]
        public class klient
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "ID")]
            public int ID { get; set; }

            [Column(Name = "FIO")]
            public string FIO { get; set; }

            [Column(Name = "Adres")]
            public string Adres { get; set; }

            [Column(Name = "TF")]
            public string TF { get; set; }
            [Column(Name = "Status")]
            public bool Status { get; set; }
        }
 }


