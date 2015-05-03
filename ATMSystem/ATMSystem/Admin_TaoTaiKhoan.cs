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
    public partial class Admin_TaoTaiKhoan : Form
    {
        private readonly WorkContext workContext;
        private readonly string id;
        public Admin_TaoTaiKhoan(WorkContext workContext, string id)
        {
            this.workContext = workContext;
            this.id = id;
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnAccountNo_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var n1 = random.Next(1000, 9999);
            var n2 = random.Next(1000, 9999);
            var n3 = random.Next(1000, 9999);
            var n4 = random.Next(1000, 9999);
            var accountNo = string.Format("{0}-{1}-{2}-{3}", n1, n2, n3, n4);
            txtAccount.Text = accountNo;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnPin_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var pin = random.Next(0000, 9999);
            txtPin.Text = pin.ToString();
        }

        private void Clear()
        {
            txtAccount.Text = string.Empty;
            txtPin.Text = string.Empty;
            txtTien.Text = string.Empty;

        }

        private bool Check()
        {
            decimal money;
            if (string.IsNullOrEmpty(txtAccount.Text))
            {
                MessageBox.Show("Bạn chưa tạo mã tài khoản cho khách hàng");
                return false;
            }
            if (string.IsNullOrEmpty(txtPin.Text))
            {
                MessageBox.Show("Bạn chưa tạo mã pin cho khách hàng");
                return false;
            }
            if (string.IsNullOrEmpty(txtTien.Text.Trim()))
            {
                MessageBox.Show("Bạn nhập số tiền ban đầu cho khách hàng");
                return false;
            }
            Decimal.TryParse(txtTien.Text.Trim(), out money);
            if (money<=0 || money>99999999999)
            {
                MessageBox.Show("Mời bạn nhập chính xác số tiền ban đầu cho khách");
                return false;
            }
            return true;
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var parameters = new Dictionary<string, object>()
                    {
                        {"@nAcc_No",txtAccount.Text},
                        {"@nAcc_PIN",txtPin.Text},
                        {"@nAccBalance",txtTien.Text},
                        {"@nID",id},
                    };
                    var stt = workContext.ExecuteProcedureParams("sp_insert_account", parameters);
                    if (stt)
                    {
                        MessageBox.Show("Tạo tài khoản thành công");
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Tạo tài khoản thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Mất kết nối");
                    return;
                }
            }
        }

    }
}
