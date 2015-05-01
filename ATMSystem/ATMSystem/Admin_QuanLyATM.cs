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
            btnSubmit.Text = "Thêm Mới";
            lblStatus.Text = string.Empty;
        }

        private void LoadDanhSachCayATM()
        {
            var dt = workContext.GetRecordsInATable("Sys_ID", "ATM_Info", string.Empty, null);
            listATM.Items.Clear();
            if (dt != null)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var name = string.Format("Cây ATM Mã {0}", dt.Rows[i]["Sys_ID"]);
                    listATM.Items.Add(name);
                }
            }
        }

        private void LoadCacTruongTheoId(string id)
        {
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

        private void Clear()
        {
            txtMaxAmountDeposit.Text = string.Empty;
            txtMaxAmountWithdraw.Text = string.Empty;
            txtMaxMoneyTransfer.Text = string.Empty;
            txtTotalMoney.Text = string.Empty;
            txtMaxTimeDeposit.Text = string.Empty;
            txtMaxTimeWithdraw.Text = string.Empty;
            txtMutipleAmount.Text = string.Empty;
            txtLevel1.Text = string.Empty;
            txtLevel2.Text = string.Empty;
            txtLevel3.Text = string.Empty;
            txtLevel4.Text = string.Empty;
            txtLevel5.Text = string.Empty;
            txtLevel6.Text = string.Empty;
            cbStatus.Checked = false;
            lblStatus.Text = string.Empty;
            listATM.ClearSelected();
            btnSubmit.Text = "Thêm Mới";
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

                var stringArray = itemSelected.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var id = stringArray.LastOrDefault();

                LoadCacTruongTheoId(id);
            }
        }

        private bool Check()
        {
            if (string.IsNullOrEmpty(txtMaxAmountWithdraw.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số lượng tiền tối đa trong 1 lần rút ");
                return false;
            }
            if (string.IsNullOrEmpty(txtMaxTimeWithdraw.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số lần tối đa trong 1 lần rút ");
                return false;
            }
            if (string.IsNullOrEmpty(txtMaxAmountDeposit.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số lượng tiền tối đa trong 1 lần gửi");
                return false;
            }
            if (string.IsNullOrEmpty(txtMaxTimeDeposit.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số lần tối đa trong 1 lần gửi ");
                return false;
            }
            if (string.IsNullOrEmpty(txtMaxMoneyTransfer.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số tiền tối đa trong 1 lần chuyển tiền ");
                return false;
            }
            if (string.IsNullOrEmpty(txtMutipleAmount.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số chia");
                return false;
            }
            if (string.IsNullOrEmpty(txtTotalMoney.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số tiền hiện có trong cây ATM");
                return false;
            }
            if (string.IsNullOrEmpty(txtLevel1.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số tiền rút nhanh mức 1");
                return false;
            }
            if (string.IsNullOrEmpty(txtLevel2.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số tiền rút nhanh mức 2");
                return false;
            }
            if (string.IsNullOrEmpty(txtLevel3.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số tiền rút nhanh mức 3");
                return false;
            }
            if (string.IsNullOrEmpty(txtLevel4.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số tiền rút nhanh mức 4");
                return false;
            }
            if (string.IsNullOrEmpty(txtLevel5.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số tiền rút nhanh mức 5");
                return false;
            }
            if (string.IsNullOrEmpty(txtLevel6.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số tiền rút nhanh mức 6");
                return false;
            }

            int WA, WT, DA, DT, AIM, MaxTransfer, TotalMoney, FC1, FC2, FC3, FC4, FC5, FC6;

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
                return false;
            }
            if (WT <= 0 || WT > 100)
            {
                MessageBox.Show("Vui lòng nhập số lần rút lớn hơn 0 và bé hơn 100");
                return false;
            }
            if (DA <= 0 || DA > 100000000)
            {
                MessageBox.Show("Vui lòng nhập số tiền gửi lớn hơn 0 và bé hơn 100,000,000");
                return false;
            }
            if (DT <= 0 || DT > 100)
            {
                MessageBox.Show("Vui lòng nhập số lần gửi lớn hơn 0 và bé hơn 100");
                return false;
            }
            if (AIM <= 0 || AIM > 1000)
            {
                MessageBox.Show("Vui lòng nhập số chia lớn hơn 0 và bé hơn 1000");
                return false;
            }
            if (MaxTransfer <= 0 || MaxTransfer > 100000000)
            {
                MessageBox.Show("Vui lòng nhập số tiền chuyển lớn hơn 0 và bé hơn 100,000,000");
                return false;
            }
            if (TotalMoney <= 0 || TotalMoney > 100000000)
            {
                MessageBox.Show("Vui lòng nhập số tiền có trong cây ATM lớn hơn 0 và bé hơn 100,000,000");
                return false;
            }
            if (FC1 <= 0 || FC1 > 1000000)
            {
                MessageBox.Show("Vui lòng nhập số tiền rút nhanh mức 1 lớn hơn 0 và bé hơn 1,000,000");
                return false;
            }
            if (FC2 <= 0 || FC2 > 1000000)
            {
                MessageBox.Show("Vui lòng nhập số tiền rút nhanh mức 1 lớn hơn 0 và bé hơn 1,000,000");
                return false;
            }
            if (FC3 <= 0 || FC3 > 1000000)
            {
                MessageBox.Show("Vui lòng nhập số tiền rút nhanh mức 1 lớn hơn 0 và bé hơn 1,000,000");
                return false;
            }
            if (FC4 <= 0 || FC4 > 1000000)
            {
                MessageBox.Show("Vui lòng nhập số tiền rút nhanh mức 1 lớn hơn 0 và bé hơn 1,000,000");
                return false;
            }
            if (FC5 <= 0 || FC5 > 1000000)
            {
                MessageBox.Show("Vui lòng nhập số tiền rút nhanh mức 1 lớn hơn 0 và bé hơn 1,000,000");
                return false;
            }
            if (FC6 <= 0 || FC6 > 1000000)
            {
                MessageBox.Show("Vui lòng nhập số tiền rút nhanh mức 1 lớn hơn 0 và bé hơn 1,000,000");
                return false;
            }
            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text.Equals("Cập Nhập"))
            {
                if (Check())
                {
                    var itemSelected = listATM.SelectedItem.ToString();

                    var stringArray = itemSelected.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                    var id = stringArray.LastOrDefault();

                    if (string.IsNullOrEmpty(id))
                    {
                        MessageBox.Show("Bạn chưa chọn cây ATM");
                        return;
                    }

                    var parameters = new Dictionary<string, object>()
                    {
                        {"@nSys_WA", txtMaxAmountWithdraw.Text},
                        {"@nSys_DA", txtMaxAmountDeposit.Text},
                        {"@nSys_WT", txtMaxTimeWithdraw.Text},
                        {"@nSys_DT", txtMaxTimeDeposit.Text},
                        {"@nSys_MAT", txtMaxMoneyTransfer.Text},
                        {"@nSys_AIM", txtMutipleAmount.Text},
                        {"@nSys_FC1", txtLevel1.Text},
                        {"@nSys_FC2", txtLevel2.Text},
                        {"@nSys_FC3", txtLevel3.Text},
                        {"@nSys_FC4", txtLevel4.Text},
                        {"@nSys_FC5", txtLevel5.Text},
                        {"@nSys_FC6", txtLevel6.Text},
                        {"@nSys_TotalMoney", txtTotalMoney.Text},
                        {"@nBank_Status", cbStatus.CheckState},
                        {"@nID", id},
                    };

                    var status = workContext.ExecuteProcedureParams("sp_edit_ATM_Info", parameters);

                    if (status)
                    {
                        MessageBox.Show("Cập Nhập Thành Công");
                        LoadCacTruongTheoId(id);
                    }
                    else
                    {
                        MessageBox.Show("Cập Nhập Không Thành Công");
                    }
                }
            }
            else
            {
                if (Check())
                {
                    var random = new Random();

                    var id =random.Next(100, int.MaxValue);

                    var parameters = new Dictionary<string, object>()
                    {
                        {"@nSys_WA", txtMaxAmountWithdraw.Text},
                        {"@nSys_DA", txtMaxAmountDeposit.Text},
                        {"@nSys_WT", txtMaxTimeWithdraw.Text},
                        {"@nSys_DT", txtMaxTimeDeposit.Text},
                        {"@nSys_MAT", txtMaxMoneyTransfer.Text},
                        {"@nSys_AIM", txtMutipleAmount.Text},
                        {"@nSys_FC1", txtLevel1.Text},
                        {"@nSys_FC2", txtLevel2.Text},
                        {"@nSys_FC3", txtLevel3.Text},
                        {"@nSys_FC4", txtLevel4.Text},
                        {"@nSys_FC5", txtLevel5.Text},
                        {"@nSys_FC6", txtLevel6.Text},
                        {"@nSys_TotalMoney", txtTotalMoney.Text},
                        {"@nBank_Status", cbStatus.CheckState},
                        {"@nID", id},
                    };

                    var stt = workContext.ExecuteProcedureParams("sp_insert_ATM_Info", parameters);
                    if (stt)
                    {
                        MessageBox.Show("Thêm Mới Thành Công");
                        Clear();
                        LoadDanhSachCayATM();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Mới Không Thành Công");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
