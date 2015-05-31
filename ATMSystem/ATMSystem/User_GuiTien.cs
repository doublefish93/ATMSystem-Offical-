using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using ATMSystem.Core;
using ATMSystem.Domain;

namespace ATMSystem
{
    public partial class User_GuiTien : Form
    {
        private readonly WorkContext workContext;
        private readonly Account account;
        private readonly ATMInfor atmInfor;
        public User_GuiTien(WorkContext workContext, Account account, ATMInfor atmInfor)
        {
            this.workContext = workContext;
            this.account = account;
            this.atmInfor = atmInfor;
            InitializeComponent();
            LoadThongTinTaiKhoan();
        }
     
        private void LoadThongTinTaiKhoan()
        {
            lblAccountNo.Text = StringExtensions.ConvertAccountNoToDisplay(account.AccountNo);
            lblAccountBalance.Text = account.AccountBalance.ToString();
            lblNote.Text = string.Format("Số tiền bạn nhập phải thấp hơn {0} và phải chia hết cho {1}", atmInfor.Sys_DA,
                atmInfor.Sys_AIM);
        }

        private bool GuiTien(string amount, string note)
        {
            decimal money;
            Decimal.TryParse(amount, out money);
            if(money<=0)
            {
                return false;
            }
            if (money > atmInfor.Sys_DA)
            {
                return false;
            }
            using (var tran =new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var parameters = new Dictionary<string, object>()
                {
                    {"@bType", 0},
                    {"@nAccID", account.AccountId},
                    {"@fAmount", money},
                };
                account.AccountBalance = account.AccountBalance + money;
                
                atmInfor.Sys_TotalMoney = atmInfor.Sys_TotalMoney + money;

                var status = workContext.ExecuteProcedureParams("sp_transaction", parameters);
                if (!status)
                {
                    Transaction.Current.Rollback();
                }
                if (Transaction.Current.TransactionInformation.Status == TransactionStatus.Aborted)
                {
                    return false;
                }
                tran.Complete();
            }

            return true;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var check = GuiTien(txtAmount.Text, txtNote.Text);
            if (check)
            {
                MessageBox.Show("Gửi Tiền Thành Công");
            }
        }
    }
}
