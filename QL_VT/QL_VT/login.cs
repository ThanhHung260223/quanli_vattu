using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_VT.Class;

namespace QL_VT
{
    public partial class login : Form
    {
        DataTable dt;
        public login()
        {
            InitializeComponent();
            txtPassWord.PasswordChar = '*';
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            txtUser.Focus();
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            txtUser.BorderStyle = BorderStyle.None;
            txtPassWord.BorderStyle = BorderStyle.None;
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPassWord.Clear();
            txtUser.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Functions.Connect();
            string sql = "select * from NguoiDung where TenND=N'" + txtUser.Text + "'and MatKhau =N'" + txtPassWord.Text + "'";
            dt = Functions.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frmMain main = new frmMain(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), int.Parse(dt.Rows[0][2].ToString()));
                main.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin đăng nhập");
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            txtUser.Focus();
        }
    }
}
