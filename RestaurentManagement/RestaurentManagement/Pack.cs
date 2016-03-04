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
    public partial class Pack : Form
    {
        public Pack()
        {
            InitializeComponent();
        }
        Function1.Connect con = new Function1.Connect();
        
        private void lblfloor_Click(object sender, EventArgs e)
        {
            GetTable();
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            if (txtpackname.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên thể loại", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int kq = con.xulydulieu("UPDATE R_Packs SET PackName=N'" + txtpackname.Text + "', Describle=N'" + txtdes.Text + "' WHERE ID='" + Convert.ToInt32(txtpackid.Text) + "'");
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
            if (txtpackid.Text != "" && txtpackid.Text != null)
            {
                int kq = con.xulydulieu("DELETE FROM R_Floor WHERE ID='" + Convert.ToInt32(txtpackid.Text) + "'");

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
                MessageBox.Show("Bạn chưa chọn thể loại cần xóa.");
            }
        }
        private void GetTable()
        {
            DataTable dt = new DataTable();
            dt = con.laybang("Select * from R_Packs");
            dgvPack.DataSource = dt;
            dgvPack.Columns[0].HeaderText = "Mã thể loại";
            dgvPack.Columns[1].HeaderText = "Tên thể loại";
            dgvPack.Columns[2].HeaderText = "Mô tả";

        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtpackname.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tầng", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtpackid.Text = String.Empty;
                int kq = con.xulydulieu("INSERT INTO R_Packs (PackName, Describle) VALUES (N'" + txtpackname.Text + "', N'" + txtdes.Text + "')");
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

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPack_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow datagridview = new DataGridViewRow();
                datagridview = dgvPack.Rows[e.RowIndex];
                txtpackid.Text = datagridview.Cells[0].Value.ToString();
                txtpackname.Text = datagridview.Cells[1].Value.ToString();
                txtdes.Text = datagridview.Cells[2].Value.ToString();
            }
            catch { }
        }

        private void Pack_Load(object sender, EventArgs e)
        {
            GetTable();
        }

      
    }
}
