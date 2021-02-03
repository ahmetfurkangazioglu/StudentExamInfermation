using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OgrenciNotBilgisi
{
   public class Baglanti
    {
        public SqlConnection baglan()
        {
            SqlConnection baglan1 = new SqlConnection(@"Data Source=DESKTOP-GME4UDL\;Initial Catalog=DbOgrenciSınav;Integrated Security=True");
            baglan1.Open();
            return baglan1;
        }
    }
}
