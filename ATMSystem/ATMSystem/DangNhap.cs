using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using ATMSystem.Core;

namespace ATMSystem
{
    public partial class DangNhap : Form
    {
        private readonly WorkContext workContext;
        public DangNhap(WorkContext workContext)
        {
            this.workContext = workContext;
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txtTK.Text))
            {
                MessageBox.Show("Bạn chưa nhập tài khoản");
                return;
            }

            if (string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
                return;
            }

            string conditionWhere = "Admin_Username=@User and Admin_Password=@Pass";

            var dictionary = new Dictionary<string, object>
                {
                    {"@User", txtTK.Text},
                    {"@Pass", txtMK.Text}
                };

            var dt = workContext.GetRecordsInATable(null, "Administrator", conditionWhere,
                dictionary);

            if (dt == null|| dt.Rows.Count <= 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu của bạn không đúng!");
                return;
            }

            MessageBox.Show("Đăng nhập thành công");

            var user = new User();
            int id;
            int.TryParse(dt.Rows[0][0].ToString(), out id);

            user.ID = id;
            user.Name = dt.Rows[0][1].ToString();

            txtMK.Text = string.Empty;
            new Admin_MainForm(user, this,workContext).Show();
            this.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
