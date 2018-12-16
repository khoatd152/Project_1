using Project_1.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1.UI
{
    public partial class Login : Form
    {
        bool LoginState;
        LoginAndGetDataForMain log;
        public Login()
        {
            InitializeComponent();
            log = new LoginAndGetDataForMain();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cboAuthentication.Items.Add("Windows Authentication");
            cboAuthentication.Items.Add("SQL Server Authentication");
            cboAuthentication.SelectedIndex = 0;
            txtServer.Text = "LOCALHOST";
            txtUser.Enabled = false;
            txtPass.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginState = false;
            this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            
            if (log.LoginSQL(txtUser.Text, txtPass.Text,cboAuthentication.SelectedIndex))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginState = true;
                this.Hide();
                Main f = new Main(log);
                f.ShowDialog();
            }
            else
            {
                LoginState = false;
                MessageBox.Show("Kết nối đến SQL thất bại\nVui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void cboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAuthentication.SelectedIndex == 0)
            {
                txtPass.Enabled = false;
                txtUser.Enabled = false;
            }
            else
            {
                txtPass.Enabled = true;
                txtUser.Enabled = true;
            }
        }

    }
}
