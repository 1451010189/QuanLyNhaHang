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
    public partial class RestaurentManagementSystem : Form
    {
        public RestaurentManagementSystem()
        {
            InitializeComponent();
        }

        private void RestaurentManagementSystem_Load(object sender, EventArgs e)
        {

        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýBànToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GiaodichBanhang giaodichbanhang = new GiaodichBanhang();
            giaodichbanhang.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Floor floor = new Floor();
            floor.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TableManagement table = new TableManagement();
            table.Show();
        }

        private void qUảnLýMụcMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupDish groupdish = new GroupDish();
            groupdish.Show();
        }

        private void danhSáchMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dish dish = new Dish();
            dish.Show();
        }

        private void quảnLýLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pack pack = new Pack();
            pack.Show();
        }
    }
}
