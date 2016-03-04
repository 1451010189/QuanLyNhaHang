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
    public partial class Login : Form
    {
        
        Function cls = new Function();
        public static string role;

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            DataTable table = cls.GetAccount();
            dgvLogin.DataSource = table;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Please, Input Username or Password!", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                int check = 0;
                DataTable table = cls.GetAccount();
                DataRow mr = null;
                mr = table.Rows[0];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (txtUser.Text == mr["UserName"].ToString() && txtPass.Text == mr["Password"].ToString())
                    {
                        check = 1;
                        if (mr["Status"].ToString() != null)
                        {
                            role = "admin";
                            MessageBox.Show("Welcome to Admin", "Login Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Hide();
                            RestaurentManagementSystem main = new RestaurentManagementSystem();
                            main.ShowDialog();

                        }
                        else
                        {
                            role = "user";
                            MessageBox.Show("Welcome to User", "Login Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Hide();
                            RestaurentManagementSystem main = new RestaurentManagementSystem();
                            main.ShowDialog();
                        }
                    }
                
                }
                if (check == 0)
                {
                    MessageBox.Show("UserName or Password incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

       
    }
}
