using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATMSystem.Core;

namespace ATMSystem
{
    public partial class Admin_DoiMatKhau : Form
    {
        private User user=null;
        private readonly WorkContext workContext;
        public Admin_DoiMatKhau(User user, WorkContext workContext)
        {
            this.user = user;
            this.workContext = workContext;
            InitializeComponent();
            this.CenterToParent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user == null)
            {
                return;
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


            if (txtMKmoi.Text.Trim().Length <= 6)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới có độ dài trên 6 ký tự");
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

            var condition = "Admin_ID=@nID and Admin_Password=@oldPass";

            var parameters = new Dictionary<string, object>
            {
                {"@nID",user.ID},
                {"@oldPass",txtMKcu.Text}
            };

            //kiểm tra mật khẩu cũ
            var dt = workContext.GetRecordsInATable(string.Empty, "Administrator", condition, parameters);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("Bạn nhập sai mật khẩu cũ. Vui lòng nhập lại");
                return;
            }

            parameters.Remove("@oldPass");

            parameters.Add("@nPassword", txtMKmoi.Text);

            var stt = workContext.ExecuteProcedureParams("sp_change_password", parameters);

            if (stt)
            {
                MessageBox.Show("Đổi mật khẩu thành công");
                txtMKcu.Text = string.Empty;
                txtMKmoi.Text = string.Empty;
                txtreMkmoi.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu không thành công");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
