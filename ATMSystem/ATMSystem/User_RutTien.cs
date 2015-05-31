using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using ATMSystem.Core;
using ATMSystem.Domain;

namespace ATMSystem
{
    public partial class User_RutTien : Form
    {
        private readonly WorkContext workContext;
        private readonly Account account;
        private readonly ATMInfor atm;

        public User_RutTien(WorkContext workContext, Account account, ATMInfor atm)
        {
            this.workContext = workContext;
            this.account = account;
            this.atm = atm;
            InitializeComponent();
            this.CenterToScreen();
            LoadFastCastButton();
            LoadThongTinTaiKhoan();
        }

        private void LoadFastCastButton()
        {
            btnFC1.Text = atm.Sys_FC1.ToString(CultureInfo.InvariantCulture);
            btnFC2.Text = atm.Sys_FC2.ToString(CultureInfo.InvariantCulture);
            btnFC3.Text = atm.Sys_FC3.ToString(CultureInfo.InvariantCulture);
            btnFC4.Text = atm.Sys_FC4.ToString(CultureInfo.InvariantCulture);
            btnFC5.Text = atm.Sys_FC5.ToString(CultureInfo.InvariantCulture);
            btnFC6.Text = atm.Sys_FC6.ToString(CultureInfo.InvariantCulture);
        }

        private void LoadThongTinTaiKhoan()
        {
            lblSoTaiKhoan.Text = StringExtensions.ConvertAccountNoToDisplay(account.AccountNo);
            lblSoDu.Text = account.AccountBalance.ToString(CultureInfo.InvariantCulture);
            var condition = string.Format("Tran_Type=1 and Acc_From_ID=@accId ");
            var parameters = new Dictionary<string, object>()
            {
                {"@accId",account.AccountId}
            };
            // var dt = workContext.CountRecords("*", false, "Transaction", condition, null);
        }

        private bool RutTien(string amount)
        {
            if (string.IsNullOrEmpty(amount))
            {
                MessageBox.Show("Lỗi hệ thống");
                return false;
            }
            decimal money;
            decimal.TryParse(amount, out money);
            if (money < 0)
            {
                MessageBox.Show("Lỗi hệ thống");
                return false;
            }
            if (atm.Sys_TotalMoney < money)
            {
                MessageBox.Show("Cây ATM hết tiền mời bạn chọn cây ATM khác");
                return false;
            }
            var parameters = new Dictionary<string, object>()
            {
                {"@bType", 1},
                {"@nAccID", account.AccountId},
                {"@fAmount", money}
            };
           
                using (var transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    try
                    {
                        atm.Sys_TotalMoney = atm.Sys_TotalMoney - money;
                        account.AccountBalance = account.AccountBalance - money;
                        if (atm.Sys_TotalMoney <= 0 || account.AccountBalance <= 0)
                        {
                            Transaction.Current.Rollback();
                        }

                        var statusTran = workContext.ExecuteProcedureParams("sp_transaction", parameters);
                        if (!statusTran)
                        {
                            Transaction.Current.Rollback();
                        }
                        parameters.Clear();

                        parameters.Add("@nSys_TotalMoney", atm.Sys_TotalMoney);

                        parameters.Add("@nID", account.AccountId);

                        var statusAtm = workContext.ExecuteProcedureParams("sp_update_money_ATM_Info", parameters);

                        if (!statusAtm)
                        {
                            Transaction.Current.Rollback();
                        }

                        if (Transaction.Current.TransactionInformation.Status == TransactionStatus.Aborted)
                        {
                            return false;
                        }

                        transaction.Complete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi hệ thống");
                        transaction.Dispose();
                        return false;
                    }

                }

            lblSoDu.Text = account.AccountBalance.ToString();
            return true;
        }

        private void btnFC1_Click(object sender, EventArgs e)
        {
            var check = RutTien(btnFC1.Text);
            if (check)
            {
                MessageBox.Show("Rút tiền thành công");
            }
        }

        private void btnFC2_Click(object sender, EventArgs e)
        {
            var check = RutTien(btnFC2.Text);
            if (check)
            {
                MessageBox.Show("Rút tiền thành công");
            }
        }

        private void btnFC4_Click(object sender, EventArgs e)
        {
            var check = RutTien(btnFC4.Text);
            if (check)
            {
                MessageBox.Show("Rút tiền thành công");
            }

        }

        private void btnFC5_Click(object sender, EventArgs e)
        {
            var check = RutTien(btnFC5.Text);
            if (check)
            {
                MessageBox.Show("Rút tiền thành công");
            }

        }

        private void btnFC6_Click(object sender, EventArgs e)
        {
            var check = RutTien(btnFC6.Text);
            if (check)
            {
                MessageBox.Show("Rút tiền thành công");
            }

        }

        private void btnFC3_Click(object sender, EventArgs e)
        {
            var check = RutTien(btnFC3.Text);
            if (check)
            {
                MessageBox.Show("Rút tiền thành công");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
