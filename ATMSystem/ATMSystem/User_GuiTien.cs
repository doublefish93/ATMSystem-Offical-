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

            var condition = string.Format("Tran_Date >= DATEADD(day, DATEDIFF(day, 0, getdate()), 0) and Tran_Type=0 and Acc_From_ID=@accId ");
            
            var parameters = new Dictionary<string, object>()
            {
                {"@accId",account.AccountId}
            };

            var times = workContext.CountRecords("*", false, "Transaction", condition, parameters);

            lblSoLan.Text = times.ToString();
        }

        private bool GuiTien(string amount, string note)
        {
            decimal money;

            Decimal.TryParse(amount, out money);
            
            if(money<=0)
            {
                MessageBox.Show("Quý khách vui lòng nhập lại số tiền");
                return false;
            }

            if (money > atmInfor.Sys_DA)
            {
                MessageBox.Show("Số tiền quý khách muốn gửi vượt quá số tiền quy định");
                return false;
            }
            if (money % atmInfor.Sys_AIM != 0)
            {
                MessageBox.Show("Số tiền quý khách nhập phải chia hết cho " + atmInfor.Sys_AIM);
                return false;
            }
            int times;
            int.TryParse(lblSoLan.Text, out times);

            if (times >= atmInfor.Sys_DT)
            {
                MessageBox.Show(string.Format("Quý khách đã quá {0} lần gửi tiền trong ngày theo quy định ",
                    atmInfor.Sys_DT));
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
                this.Dispose();
            }
         
                this.Dispose();
        }
    }
}
