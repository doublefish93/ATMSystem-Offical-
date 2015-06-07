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
using ATMSystem.Domain;

namespace ATMSystem
{
    public partial class User_ChuyenTien : Form
    {
        private readonly WorkContext workContext;
        private readonly ATMInfor atmSystem;
        private readonly Account account;
        public User_ChuyenTien(WorkContext workContext, ATMInfor atmSystem, Account account)
        {
            this.workContext = workContext;
            this.atmSystem = atmSystem;
            this.account = account;
            InitializeComponent();
        }

        private void btnChuyenTien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text.Trim()))
            {
                MessageBox.Show("Mời bạn nhập tài khoản");
                return;
            } 
            if (string.IsNullOrEmpty(txtTien.Text.Trim()))
            {
                MessageBox.Show("Mời bạn nhập số tiền");
                return;
            }
            if (txtTaiKhoan.Text.Equals(account.AccountNo))
            {
                MessageBox.Show("Mời bạn nhập số tài khoản bạn muốn gửi");
                return;
            }
            
            decimal money;

            decimal.TryParse(txtTien.Text, out money);

            if(money <= 0 || money > atmSystem.Sys_MAT)
            {
                txtTien.Text = "0";
                
                MessageBox.Show("Mời bạn nhập số tiền > 0 và < "+atmSystem.Sys_MAT.ToString("N2"));

                return;
            }
            if (money > account.AccountBalance)
            {
                MessageBox.Show("Bạn Không Đủ Tiền");
                return;
            }
            if (money % atmSystem.Sys_AIM != 0)
            {
                MessageBox.Show("Số tiền bạn nhập phải chia hết cho "+atmSystem.Sys_AIM);
                return;
            }
            var condition = "Acc_No=@accNo and Acc_Status=1 and Acc_Delete=0";

            var parameters = new Dictionary<string, object>()
            {
                {"@accNo",txtTaiKhoan.Text}
            };
            var dt = workContext.GetRecordsInATable(string.Empty, "Account", condition, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                parameters.Clear();

                parameters.Add("@nFromAccID", account.AccountId);

                parameters.Add("@nToAccID", dt.Rows[0]["Acc_ID"]);

                parameters.Add("@fAmount", txtTien.Text);

                var stt = workContext.ExecuteProcedureParams("sp_fund_transfer", parameters);

                if (stt)
                {
                    MessageBox.Show("Chuyển tiền thành công");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Chuyển tiền không thành công");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại");
                return; 
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
