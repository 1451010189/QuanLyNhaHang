﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurentManagement.Function1;

namespace RestaurentManagement
{
    public partial class GroupDish : Form
    {
        public GroupDish()
        {
            InitializeComponent();
        }
        private Connect con = new Connect();
        private void dgvGroupDish_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow datagridview = new DataGridViewRow();
                datagridview = dgvGroupDish.Rows[e.RowIndex];
                txtDishID.Text = datagridview.Cells[0].Value.ToString();
                txtDishName.Text = datagridview.Cells[1].Value.ToString();
                txtDishDescrible.Text = datagridview.Cells[2].Value.ToString();
            }
            catch { }
        }
        private void GetTable()
        {
            DataTable dt = new DataTable();
            dt = con.laybang("Select * from R_DishGroup");
            dgvGroupDish.DataSource = dt;
            dgvGroupDish.Columns[0].HeaderText = "Mã mục";
            dgvGroupDish.Columns[1].HeaderText = "Mục món ăn";
            dgvGroupDish.Columns[2].HeaderText = "Mô tả";
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtDishName.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên món ăn", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtDishID.Text = String.Empty;
                int kq = con.xulydulieu("INSERT INTO R_DishGroup (DishGroupName, Describle) VALUES (N'" + txtDishName.Text + "', N'" + txtDishDescrible.Text + "')");
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

        private void GroupDish_Load(object sender, EventArgs e)
        {
            GetTable();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (txtDishName.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên món ăn", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int kq = con.xulydulieu("UPDATE R_DishGroup SET DishGroupName=N'" + txtDishName.Text + "', Describle=N'" + txtDishDescrible.Text + "' WHERE ID='" + Convert.ToInt32(txtDishID.Text) + "'");
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
                int kq = con.xulydulieu("DELETE FROM R_DishGroup WHERE ID='" + Convert.ToInt32(txtDishID.Text) + "'");

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
                MessageBox.Show("Bạn chưa chọn món ăn cần xóa.");
            }
        }
    }
}
