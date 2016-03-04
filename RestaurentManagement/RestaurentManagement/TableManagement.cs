using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurentManagement.Function1;
using System.Data.SqlClient;

namespace RestaurentManagement
{
    public partial class TableManagement : Form
    {
        public TableManagement()
        {
            InitializeComponent();
        }
        Connect con = new Connect();
       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TableManagement_Load(object sender, EventArgs e)
        {
            GetComBox();
            GetTable();
        }
        private void GetTable()
        {
            DataTable dt = new DataTable();
            dt = con.laybang("select ID,TableName,TableNumber,(select FloorName from R_Floor where R_Floor.ID=R_Tables.FloorID) from R_Tables");
            dgvTable.DataSource = dt;
            dgvTable.Columns[0].HeaderText = "Mã Bản";
            dgvTable.Columns[1].HeaderText = "Tên Bàn";
            dgvTable.Columns[2].HeaderText = "Số Bàn";
            dgvTable.Columns[3].HeaderText = "Tầng";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txttablename.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên bàn", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                else if(txttablenumber.Text =="")
            {
                MessageBox.Show("Bạn chưa nhập số bàn", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txttableid.Text = String.Empty;
                int kq = con.xulydulieu("INSERT INTO R_Tables (TableName, TableNumber,FloorID) VALUES (N'" + txttablename.Text + "', N'" + txttablenumber.Text + "','"+Convert.ToInt32(cbfloor.SelectedValue.ToString())+"')");
                if (kq > 0)
                {
                    MessageBox.Show("Bạn đã thêm mới thành công");
                    GetTable();
                }
                else
                {
                    MessageBox.Show("Không thành công, vui lòng kiểm tra lại!");
                }
            }
        }
        private void GetComBox()
        {
           
            SqlCommand mysqlcommand = new SqlCommand();
            mysqlcommand.Connection = con.con;
            mysqlcommand.CommandText = "select ID,FloorName from R_Floor";
            con.kn_csdl();
            SqlDataAdapter mysqladatareader = new SqlDataAdapter();
            mysqladatareader.SelectCommand = mysqlcommand;
            DataSet mydataset = new DataSet();
            mysqladatareader.Fill(mydataset, "KQ");
            DataTable table_MK = new DataTable();
            table_MK = mydataset.Tables["KQ"];
            cbfloor.DataSource = table_MK;
            cbfloor.DisplayMember = table_MK.Columns["FloorName"].ToString();
            cbfloor.ValueMember = table_MK.Columns["ID"].ToString();


            con.con.Close();


        }
        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow datagridview = new DataGridViewRow();
                datagridview = dgvTable.Rows[e.RowIndex];
                txttableid.Text = datagridview.Cells[0].Value.ToString();
                txttablename.Text = datagridview.Cells[1].Value.ToString();
                txttablenumber.Text = datagridview.Cells[2].Value.ToString();
                cbfloor.Text = datagridview.Cells[3].Value.ToString();
            }
            catch { }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (txttablename.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên bàn", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txttablenumber.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số bàn", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                int kq = con.xulydulieu("UPDATE R_Tables SET TableName=N'" + txttablename.Text + "', TableNumber=N'" + txttablenumber.Text + "',FloorID='"+Convert.ToInt32(cbfloor.SelectedValue.ToString())+"' WHERE ID='" + Convert.ToInt32(txttableid.Text) + "'");
                if (kq > 0)
                {
                    MessageBox.Show("Bạn đã sửa mới thành công");
                    GetTable();
                }
                else
                {
                    MessageBox.Show("Không thành công, vui lòng kiểm tra lại!");
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txttableid.Text != "" && txttableid.Text != null)
            {
                int kq = con.xulydulieu("DELETE FROM R_Table WHERE ID='" + Convert.ToInt32(txttableid.Text) + "'");

                if (kq > 0)
                {
                    MessageBox.Show("Bạn đã xóa thành công");
                    GetTable();
                }
                else
                {
                    MessageBox.Show("Không thành công, vui lòng kiểm tra lại!");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn bảng cần xóa.");
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
