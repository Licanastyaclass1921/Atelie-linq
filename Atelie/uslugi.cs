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
    [Table(Name = "uslugi")]
    public class uslugi
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "kod")]
        public int kod { get; set; }

        [Column(Name = "Nazvanie")]
        public string Nazvanie { get; set; }

        [Column(Name = "Hena")]
        public float Hena { get; set; }

        [Column(Name = "Status")]
        public bool Status { get; set; }
    }
}
