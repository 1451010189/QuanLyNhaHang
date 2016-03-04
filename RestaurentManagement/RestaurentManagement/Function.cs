using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RestaurentManagement
{
    class Function
    {
        public SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Restaurent;Integrated Security=True");
        public SqlDataAdapter da = new SqlDataAdapter();
        public SqlCommand cmd = new SqlCommand();
         public void connect()
        {
            cmd.Connection = con;
            con.Open();
        }
        //Function User
         public DataTable GetAccount()
        {
            da = new SqlDataAdapter("SELECT * from R_User", con);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        //Function Floor
        public void Add_Floor(string floorname, string describle)
         {
            connect();
             cmd = new SqlCommand("INSERT INTO `R_Floor` (`FloorName`, `Describle`) VALUES ('" + floorname + "', '" + describle + "')", con);
             cmd.ExecuteNonQuery();
             con.Close();
        }
        public DataTable GetFloor()
        {
            da = new SqlDataAdapter("SELECT * FROM R_Floor",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void Edit_Floor(string floorname, string describle ,int floorid)
        {
            connect();
            cmd = new SqlCommand("UPDATE `R_Floor` SET `FloorName` = '" + floorname + "', `Describle` = '" + describle + "' WHERE `ID` = " + floorid + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete_Floor(string floorname)
        {
            connect();
            cmd = new SqlCommand("DELETE FROM `R_Floor` WHERE `FloorName` = '" + floorname + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
