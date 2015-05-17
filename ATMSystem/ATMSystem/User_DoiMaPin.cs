using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATMSystem.Core;
using ATMSystem.Domain;

namespace ATMSystem
{
    public partial class User_DoiMaPin : Form
    {
        private readonly WorkContext workContext;
        private readonly Account account;
        public User_DoiMaPin(WorkContext workContext, Account account)
        {
            this.workContext = workContext;
            this.account = account;
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldPin.Text))
            {
                MessageBox.Show("Mời nhập mã Pin");
                return;
            }
            if (string.IsNullOrEmpty(txtNewPin.Text))
            {
                MessageBox.Show("Mời nhập mã Pin mới");
                return;
            }
            if (string.IsNullOrEmpty(txtReNewPin.Text))
            {
                MessageBox.Show("Mời nhập lại mã Pin mới");
                return;
            }
            if (txtOldPin.Text.Length != 4)
            {

                MessageBox.Show("Mời nhập lại mã Pin cũ");
                return;
            }
            if (txtNewPin.Text.Length != 4)
            {

                MessageBox.Show("Mã PIN mới phải có 4 kí tự");
                return;
            }
            if (txtReNewPin.Text.Length != 4)
            {

                MessageBox.Show("Nhập lại Mã PIN mới phải có 4 kí tự");
                return;
            }
            if (!txtNewPin.Text.Trim().Equals(txtReNewPin.Text.Trim()))
            {
                MessageBox.Show("Mã PIN mới với Nhập Lại Mã PIN mới chưa trùng nhau");
                return;
            }
            var condition = "Acc_No=@accNo and Acc_Pin=@accPin";

            var parameters = new Dictionary<string, object>()
            {
                {"@accNo",account.AccountNo},
                {"@accPin",txtOldPin.Text}
            };

            var dt = workContext.GetRecordsInATable(string.Empty, "Account", condition, parameters);
           
            if (dt != null)
            {
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Nhập sai mã PIN cũ");
                    return;
                }
                parameters.Clear();
                parameters.Add("@nAccID",account.AccountId);
                parameters.Add("@snewPIN",txtNewPin.Text.Trim());
                var status = workContext.ExecuteProcedureParams("sp_change_pin", parameters);
                if (status)
                {
                    MessageBox.Show("Đổi mã PIN thành công");
                    txtOldPin.Text = string.Empty;
                    txtNewPin.Text = string.Empty;
                    txtReNewPin.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Không thể đổi mã PIN");
                }
            }

        }


        private void txtOldPin_TextChanged(object sender, EventArgs e)
        {
            var regex = new Regex(@"^\d{1,4}$");
            var match = regex.Match(txtOldPin.Text);
            if (txtOldPin.Text.Length > 0)
            {
                if (!match.Success)
                {
                    txtOldPin.Text = txtOldPin.Text.Remove(txtOldPin.TextLength - 1);
                }
            }
        }

        private void txtNewPin_TextChanged(object sender, EventArgs e)
        {
            var regex = new Regex(@"^\d{1,4}$");
            var match = regex.Match(txtNewPin.Text);
            if (txtNewPin.Text.Length > 0)
            {
                if (!match.Success)
                {
                    txtNewPin.Text = txtNewPin.Text.Remove(txtNewPin.TextLength - 1);
                }
            }
        }

        private void txtReNewPin_TextChanged(object sender, EventArgs e)
        {
            var regex = new Regex(@"^\d{1,4}$");
            var match = regex.Match(txtReNewPin.Text);
            if (txtReNewPin.Text.Length > 0)
            {
                if (!match.Success)
                {
                    txtReNewPin.Text = txtReNewPin.Text.Remove(txtReNewPin.TextLength - 1);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtOldPin.Text = string.Empty;
            txtNewPin.Text = string.Empty;
            txtReNewPin.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
