using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManagement
{
    public partial class Dish : Form
    {
        public Dish()
        {
            InitializeComponent();
        }
        RestaurentManagement.Function1.Connect con = new Function1.Connect();
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtDishName.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên món ăn", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtDishID.Text = String.Empty;
                int kq = con.xulydulieu("INSERT INTO R_Dish (DishName,Price,GroupID, Describle) VALUES (N'" + txtDishName.Text + "', N'" + txtdishprice.Text + "','"+cbdishgroup.SelectedValue.ToString()+"','"+txtDishDescrible.Text+"')");
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
        private void GetTable()
        {
            DataTable dt = new DataTable();
            dt = con.laybang("Select ID,DishName,Price,(select DishGroupName from R_DishGroup where R_DishGroup.ID=R_Dish.GroupID ), Describle from R_Dish");
            dgvDish.DataSource = dt;
            dgvDish.Columns[0].HeaderText = "Mã món ăn";
            dgvDish.Columns[1].HeaderText = "Tên món ăn";
            dgvDish.Columns[2].HeaderText = "Giá món ăn";
            dgvDish.Columns[3].HeaderText = "Mục món ăn";
            dgvDish.Columns[4].HeaderText = "Mô tả";

        }
        private void GetComBox()
        {

            SqlCommand mysqlcommand = new SqlCommand();
            mysqlcommand.Connection = con.con;
            mysqlcommand.CommandText = "select ID,DishGroupName from R_DishGroup";
            con.kn_csdl();
            SqlDataAdapter mysqladatareader = new SqlDataAdapter();
            mysqladatareader.SelectCommand = mysqlcommand;
            DataSet mydataset = new DataSet();
            mysqladatareader.Fill(mydataset, "KQ");
            DataTable table_MK = new DataTable();
            table_MK = mydataset.Tables["KQ"];
            cbdishgroup.DataSource = table_MK;
            cbdishgroup.DisplayMember = table_MK.Columns["DishGroupName"].ToString();
            cbdishgroup.ValueMember = table_MK.Columns["ID"].ToString();
            con.con.Close();
        }
        private void Dish_Load(object sender, EventArgs e)
        {
            GetComBox();
            GetTable();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (txtDishName.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên món ăn", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int kq = con.xulydulieu("UPDATE R_Dish SET DishName=N'" + txtDishName.Text + "',Price=N'" + txtdishprice.Text + "',GroupID=N'" + cbdishgroup.SelectedValue.ToString() + "', Describle=N'" + txtDishDescrible.Text + "' WHERE ID='" + Convert.ToInt32(txtDishID.Text) + "'");
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
            if (txtDishID.Text != "" && txtDishID.Text != null)
            {
                int kq = con.xulydulieu("DELETE FROM R_Dish WHERE ID='" + Convert.ToInt32(txtDishID.Text) + "'");

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
                MessageBox.Show("Bạn chưa chọn tầng cần xóa.");
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDish_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow datagridview = new DataGridViewRow();
                datagridview = dgvDish.Rows[e.RowIndex];
                txtDishID.Text = datagridview.Cells[0].Value.ToString();
                txtDishName.Text = datagridview.Cells[1].Value.ToString();
                txtdishprice.Text = datagridview.Cells[2].Value.ToString();
                cbdishgroup.Text = datagridview.Cells[3].Value.ToString();
                txtDishDescrible.Text = datagridview.Cells[4].Value.ToString();
            }
            catch { }
        }
    }
}
