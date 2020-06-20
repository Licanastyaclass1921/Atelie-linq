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
    [Table(Name = "View_1")]
    public class View_1
    { 
        [Column(Name = "idklient")]
        public int  idklient { get; set; }
       
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Id")]
        public int Id { get; set; }


        [Column(Name = "Nazvanie")]
        public string Nazvanie { get; set; }

        [Column(Name = "koduslugi")]
        public int koduslugi { get; set; }

        [Column(Name = "Data")]
        public DateTime Data { get; set; }

        [Column(Name = "OkazYSL")]
        public bool OkazYSL { get; set; }

        [Column(Name = "Status")]
        public bool Status { get; set; }

    }
}
