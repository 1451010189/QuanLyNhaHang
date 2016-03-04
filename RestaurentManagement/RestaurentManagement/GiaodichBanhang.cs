using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RestaurentManagement
{
    public partial class GiaodichBanhang : Form
    {
        public GiaodichBanhang()
        {
          
            InitializeComponent();
        }

        Function1.Connect con = new Function1.Connect();
        private void lbl_Click(object sender, EventArgs e)
        {

        }
       
        private void GiaodichBanhang_Load(object sender, EventArgs e)
        {
            GetControlTable();
        }
        private void GetTable()
        {
            //this.dgvtable.DataSource = null;
            //this.dgvtable.Rows.Clear();
            //DataTable dt = new DataTable();
            //DataTable dt1 = new DataTable();
            //dt = con.laybang("Select (select FloorName from R_Floor where R_Floor.ID=R_Tables.FloorID),TableName from R_Tables");
            //DataRow dr = null;
            //dt.Columns.Add(new DataColumn("FloorName", typeof(string)));
            //dr = dt1.NewRow();
            //for (int i=0; i < dt.Rows.Count;i++ )
            //{
            //    dr[0] = dt.Rows[i].ItemArray[1].ToString();
            //}
            //dgvtable.DataSource = dt1;
            //dgvtable.Columns[0].HeaderText = "";
        }
        private void GetControlTable()
        {
            Panel newpanel = null;
            Function1.Connect con1 = null;
            DataTable dt1 = new DataTable();
            DataTable dt = null;
            dt1 = con.laybang("Select* from R_Floor");

            for (int j = 0; j < dt1.Rows.Count;j++ )
            {
                con1 = new Function1.Connect();
                dt = new DataTable();
                newpanel = new Panel();
                dt = con1.laybang("Select TableName,TableNumber from R_Tables where FloorID='" + Convert.ToInt32(dt1.Rows[j]["ID"].ToString()) + "'");
                newpanel.Size = new Size(571, 75);
                newpanel.AutoSize = true;
                newpanel.Name = "pnFloor" + dt1.Rows[j]["ID"].ToString();
                if (dt.Rows.Count > 7)
                {
                    newpanel.Location = new Point(26, 48 + (j * 81) + 38);
                }
                else if (dt.Rows.Count > 14)
                {
                    newpanel.Location = new Point(26, 48 + (j * 81) + 72);
                }
                else
                {
                    newpanel.Location = new Point(26, 48 + (j * 81));
                }
                this.Controls.Add(newpanel);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Button newButton = new Button();
                    newButton.Text = dt.Rows[i]["TableName"].ToString();
                    newButton.Name = "btn" + dt.Rows[i]["TableNumber"].ToString();
                    newButton.Height = 35;
                    newButton.Width = 70;
                    if (i > 7)
                    {
                        newButton.Location = new Point(3 + ((i - 8) * 81), 39 + 43);
                    }
                    else if (i > 14)
                    {
                        newButton.Location = new Point(3 + ((i - 15) * 81), 39 + 86);
                    }
                    else
                    {
                        newButton.Location = new Point(3 + (i * 81), 39);
                    }
                    newButton.Location = new Point(3 + (i * 81), 39);
                    newpanel.Controls.Add(newButton);
                }
                TextBox textbox = new TextBox();
                textbox.Text = dt1.Rows[j]["FloorName"].ToString();
                textbox.BackColor = Color.LightGray;
                textbox.Name = "txtfloor" + dt1.Rows[j]["ID"].ToString();
                textbox.Size = new Size(563, 20);
                textbox.TextAlign = HorizontalAlignment.Center;
                textbox.Enabled = false;
                textbox.Location = new Point(3, 3);
                newpanel.Controls.Add(textbox);
                dt.Dispose();
                con1.dongketnoi();
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
