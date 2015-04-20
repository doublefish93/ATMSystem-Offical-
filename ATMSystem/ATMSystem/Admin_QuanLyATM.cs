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
    public partial class Admin_QuanLyATM : Form
    {
        private readonly WorkContext workContext;
        public Admin_QuanLyATM(WorkContext workContext)
        {
            this.workContext = workContext;
            InitializeComponent();
            LoadDanhSachCayATM();
            this.CenterToScreen();
        }

        public void LoadDanhSachCayATM()
        {
            var dt = workContext.GetRecordsInATable("Sys_ID", "ATM_Info", string.Empty, null);

            if (dt != null)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var name = string.Format("Cây ATM {0}", dt.Rows[i]["Sys_ID"]);
                    listATM.Items.Add(name);
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }


        private void label11_Click(object sender, EventArgs e)
        {

        }


        private void listATM_SelectedValueChanged(object sender, EventArgs e)
        {
            btnSubmit.Text = "Cập Nhập";
            if (listATM != null && listATM.SelectedItem != null)
            {

                var itemSelected = listATM.SelectedItem.ToString();

                var stringArray = itemSelected.Split(new[] { " " }, StringSplitOptions.None);

                var id = stringArray.LastOrDefault();

                if (!string.IsNullOrEmpty(id))
                {
                    var dt = workContext.GetById(string.Empty, "ATM_Info", id);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        txtMaxAmountWithdraw.Text = dt.Rows[0]["Sys_WA"].ToString();
                        txtMaxAmountDeposit.Text = dt.Rows[0]["Sys_DA"].ToString();
                        txtMaxTimeWithdraw.Text = dt.Rows[0]["Sys_WT"].ToString();
                        txtMaxTimeDeposit.Text = dt.Rows[0]["Sys_DT"].ToString();
                        txtMutipleAmount.Text = dt.Rows[0]["Sys_AIM"].ToString();
                        txtMaxMoneyTransfer.Text = dt.Rows[0]["Sys_MAT"].ToString();
                        txtTotalMoney.Text = dt.Rows[0]["Sys_TotalMoney"].ToString();
                        txtLevel1.Text = dt.Rows[0]["Sys_FC1"].ToString();
                        txtLevel2.Text = dt.Rows[0]["Sys_FC2"].ToString();
                        txtLevel3.Text = dt.Rows[0]["Sys_FC3"].ToString();
                        txtLevel4.Text = dt.Rows[0]["Sys_FC4"].ToString();
                        txtLevel5.Text = dt.Rows[0]["Sys_FC5"].ToString();
                        txtLevel6.Text = dt.Rows[0]["Sys_FC6"].ToString();
                        int status;
                        int.TryParse(dt.Rows[0]["Bank_Status"].ToString(), out status);
                        if (status == 1)
                        {
                            cbStatus.Checked = true;
                            lblStatus.Text = "Đang hoạt động";
                            lblStatus.ForeColor = Color.Green;
                        }
                        else
                        {
                            cbStatus.Checked = false;
                            lblStatus.Text = "Ngừng hoạt động";
                            lblStatus.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text.Equals("Cập Nhập"))
            {
                if (string.IsNullOrEmpty(txtMaxAmountWithdraw.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số lượng tiền tối đa trong 1 lần rút ");
                    return;
                }
                if (string.IsNullOrEmpty(txtMaxTimeWithdraw.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số lần tối đa trong 1 lần rút ");
                    return;
                }
                if (string.IsNullOrEmpty(txtMaxAmountDeposit.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số lượng tiền tối đa trong 1 lần gửi");
                    return;
                }
                if (string.IsNullOrEmpty(txtMaxTimeDeposit.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số lần tối đa trong 1 lần gửi ");
                    return;
                }
                if (string.IsNullOrEmpty(txtMaxMoneyTransfer.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số tiền tối đa trong 1 lần chuyển tiền ");
                    return;
                }
                if (string.IsNullOrEmpty(txtMutipleAmount.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số chia");
                    return;
                }
                if (string.IsNullOrEmpty(txtTotalMoney.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số tiền hiện có trong cây ATM");
                    return;
                }
                if (string.IsNullOrEmpty(txtLevel1.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số tiền rút nhanh mức 1");
                    return;
                }
                if (string.IsNullOrEmpty(txtLevel2.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số tiền rút nhanh mức 2");
                    return;
                }
                if (string.IsNullOrEmpty(txtLevel3.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số tiền rút nhanh mức 3");
                    return;
                }
                if (string.IsNullOrEmpty(txtLevel4.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số tiền rút nhanh mức 4");
                    return;
                }
                if (string.IsNullOrEmpty(txtLevel5.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số tiền rút nhanh mức 5");
                    return;
                }
                if (string.IsNullOrEmpty(txtLevel6.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số tiền rút nhanh mức 6");
                    return;
                }
                int WA,WT,DA,DT,AIM,MaxTransfer,TotalMoney,FC1,FC2,FC3,FC4,FC5,FC6;

                int.TryParse(txtMaxAmountWithdraw.Text.Trim(), out WA);
                int.TryParse(txtMaxTimeWithdraw.Text.Trim(), out WT);
                int.TryParse(txtMaxAmountDeposit.Text.Trim(), out DA);
                int.TryParse(txtMaxTimeDeposit.Text.Trim(), out DT);
                int.TryParse(txtMutipleAmount.Text.Trim(), out AIM);
                int.TryParse(txtMaxMoneyTransfer.Text.Trim(), out MaxTransfer);
                int.TryParse(txtTotalMoney.Text.Trim(), out TotalMoney);
                int.TryParse(txtLevel1.Text.Trim(), out FC1);
                int.TryParse(txtLevel2.Text.Trim(), out FC2);
                int.TryParse(txtLevel3.Text.Trim(), out FC3);
                int.TryParse(txtLevel4.Text.Trim(), out FC4);
                int.TryParse(txtLevel5.Text.Trim(), out FC5);
                int.TryParse(txtLevel6.Text.Trim(), out FC6);

                if (WA <= 0 || WA > 100000000)
                {
                    MessageBox.Show("Vui lòng nhập số tiền rút lớn hơn 0 và bé hơn 100,000,000");
                    return;
                }
                if (WT <= 0 || WT > 100)
                {
                    MessageBox.Show("Vui lòng nhập số lần rút lớn hơn 0 và bé hơn 100");
                    return;
                } 
                if (DA <= 0 || DA > 100000000)
                {
                    MessageBox.Show("Vui lòng nhập số tiền gửi lớn hơn 0 và bé hơn 100,000,000");
                    return;
                }
                if (DT <= 0 || DT > 100)
                {
                    MessageBox.Show("Vui lòng nhập số lần gửi lớn hơn 0 và bé hơn 100");
                    return;
                }
                if (AIM <= 0 || AIM > 1000)
                {
                    MessageBox.Show("Vui lòng nhập số chia lớn hơn 0 và bé hơn 1000");
                    return;
                }
                if (MaxTransfer <= 0 || MaxTransfer > 100000000)
                {
                    MessageBox.Show("Vui lòng nhập số tiền chuyển lớn hơn 0 và bé hơn 100,000,000");
                    return;
                }
                if (TotalMoney <= 0 || TotalMoney > 100000000)
                {
                    MessageBox.Show("Vui lòng nhập số tiền có trong cây ATM lớn hơn 0 và bé hơn 100,000,000");
                    return;
                }
                if (FC1 <= 0 || FC1 > 1000000)
                {
                    MessageBox.Show("Vui lòng nhập số tiền rút nhanh mức 1 lớn hơn 0 và bé hơn 1,000,000");
                    return;
                }
                if (FC2 <= 0 || FC2 > 1000000)
                {
                    MessageBox.Show("Vui lòng nhập số tiền rút nhanh mức 1 lớn hơn 0 và bé hơn 1,000,000");
                    return;
                }
                if (FC3 <= 0 || FC3 > 1000000)
                {
                    MessageBox.Show("Vui lòng nhập số tiền rút nhanh mức 1 lớn hơn 0 và bé hơn 1,000,000");
                    return;
                }
                if (FC4 <= 0 || FC4 > 1000000)
                {
                    MessageBox.Show("Vui lòng nhập số tiền rút nhanh mức 1 lớn hơn 0 và bé hơn 1,000,000");
                    return;
                }
                if (FC5 <= 0 || FC5 > 1000000)
                {
                    MessageBox.Show("Vui lòng nhập số tiền rút nhanh mức 1 lớn hơn 0 và bé hơn 1,000,000");
                    return;
                }
                if (FC6 <= 0 || FC6 > 1000000)
                {
                    MessageBox.Show("Vui lòng nhập số tiền rút nhanh mức 1 lớn hơn 0 và bé hơn 1,000,000");
                    return;
                }


            }
        }
    }
}
