using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSystem
{
    public partial class Admin_DoiMatKhau : Form
    {
        private User user=null;
        public Admin_DoiMatKhau(User user)
        {
            this.user = user;
            InitializeComponent();
            this.CenterToParent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user == null)
            {
                this.Dispose();
            }

            if (string.IsNullOrEmpty(txtMKcu.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ");
                return;
            }

            if (string.IsNullOrEmpty(txtMKmoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới");
                return;
            }

            if (string.IsNullOrEmpty(txtreMkmoi.Text))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu mới");
                return;
            }

            if (!txtMKmoi.Text.Equals(txtreMkmoi.Text))
            {
                MessageBox.Show("Mật khẩu mới phải trùng với nhập lại mật khẩu mới");
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
