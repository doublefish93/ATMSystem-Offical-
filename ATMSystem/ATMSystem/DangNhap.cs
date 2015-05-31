using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using ATMSystem.Core;
using ATMSystem.Domain;

namespace ATMSystem
{
    public partial class DangNhap : Form
    {
        private readonly WorkContext workContext;
        public DangNhap(WorkContext workContext)
        {
            this.workContext = workContext;
            InitializeComponent();
            this.CenterToScreen();
            LoadDanhSachCayATM();
        }

        private void LoadDanhSachCayATM()
        {
            var condition = "Bank_Status = 1 ";
            var dt = workContext.GetRecordsInATable(string.Empty, "ATM_Info", condition, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbbATM.Items.Add(string.Format("Cây ATM - {0}", dt.Rows[i]["Sys_ID"]));
                }
            }

        }


        private void button1_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtTK.Text))
            {
                MessageBox.Show("Bạn chưa nhập tài khoản");
                return;
            }

            if (string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
                return;
            }

            string conditionWhere = "Admin_Username=@User and Admin_Password=@Pass";

            var dictionary = new Dictionary<string, object>
                {
                    {"@User", txtTK.Text},
                    {"@Pass", txtMK.Text}
                };

            var dt = workContext.GetRecordsInATable(null, "Administrator", conditionWhere,
                dictionary);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu của bạn không đúng!");
                return;
            }

            MessageBox.Show("Đăng nhập thành công");

            var user = new User();
            int id;
            int.TryParse(dt.Rows[0][0].ToString(), out id);

            user.ID = id;
            user.Name = dt.Rows[0][1].ToString();

            txtMK.Text = string.Empty;
            new Admin_MainForm(user, this, workContext).Show();
            this.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (cbbATM.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn cây ATM");
                return;
            }
            if (string.IsNullOrEmpty(txtAccount.Text.Trim()))
            {
                MessageBox.Show("Mời nhập tài khoản");
                return;
            }
            if (string.IsNullOrEmpty(txtPin.Text.Trim()))
            {
                MessageBox.Show("Mời nhập mã PIN");
                return;
            }
            var condition = "Acc_No = @accNo and Acc_PIN = @accPin and Acc_Status=1 and Acc_Delete=0";

            var parameters = new Dictionary<string, object>()
            {
                {"@accNo",txtAccount.Text.Trim()},
                {"@accPin",txtPin.Text.Trim()}

            };
            var dt = workContext.GetRecordsInATable(string.Empty, "Account", condition, parameters);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    int accountId, userId;
                    decimal balance;
                    int.TryParse(dt.Rows[0]["Acc_ID"].ToString(), out accountId);
                    int.TryParse(dt.Rows[0]["User_ID"].ToString(), out userId);
                    Decimal.TryParse(dt.Rows[0]["Acc_Balance"].ToString(), out balance);
                    var account = new Account();

                    account.AccountId = accountId;
                    account.UserId = userId;
                    account.AccountNo = dt.Rows[0]["Acc_No"].ToString();
                    account.AccountBalance = balance;
                    account.AccountStatus = true;
                    account.AcccountDelete = false;

                    var selectedItem = cbbATM.SelectedItem.ToString();

                    if (!selectedItem.Contains("-"))
                    {
                        return;
                    }
                    selectedItem = selectedItem.Replace("-", " ");

                    var stringArray = selectedItem.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    var id = stringArray.LastOrDefault();

                    var dtAtm = workContext.GetById(string.Empty, "ATM_Info", id);
                    if (dtAtm == null)
                    {
                        MessageBox.Show("Cây ATM bị hỏng");
                        return;
                    }
                    var Atm = ConvertFromTableToEntity(dtAtm);
                    this.Visible = false;
                    new User_MainForm(workContext, account,Atm).Show();

                }
                else
                {
                    MessageBox.Show("Bạn Nhập Sai Tài Khoản");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Đăng Nhập Lỗi");
            }
        }

        private ATMInfor ConvertFromTableToEntity(DataTable dt)
        {
            var entity = new ATMInfor();
            if (dt == null || dt.Rows.Count <= 0)
            {
                return entity;
            }
            int id, sysWt, sysDt;
            decimal sysWa, sysDa, sysMat,sysAim, sysFc1, sysFc2, sysFc3, sysFc4, sysFc5, sysFc6, totalMoney;

            int.TryParse(dt.Rows[0]["Sys_ID"].ToString(), out id);
            decimal.TryParse(dt.Rows[0]["Sys_WA"].ToString(), out sysWa);
            decimal.TryParse(dt.Rows[0]["Sys_DA"].ToString(), out sysDa);
            int.TryParse(dt.Rows[0]["Sys_WT"].ToString(), out sysWt);
            int.TryParse(dt.Rows[0]["Sys_DT"].ToString(), out sysDt);
            decimal.TryParse(dt.Rows[0]["Sys_MAT"].ToString(), out sysMat);
            decimal.TryParse(dt.Rows[0]["Sys_AIM"].ToString(), out sysAim);
            decimal.TryParse(dt.Rows[0]["Sys_FC1"].ToString(), out sysFc1);
            decimal.TryParse(dt.Rows[0]["Sys_FC2"].ToString(), out sysFc2);
            decimal.TryParse(dt.Rows[0]["Sys_FC3"].ToString(), out sysFc3);
            decimal.TryParse(dt.Rows[0]["Sys_FC4"].ToString(), out sysFc4);
            decimal.TryParse(dt.Rows[0]["Sys_FC5"].ToString(), out sysFc5);
            decimal.TryParse(dt.Rows[0]["Sys_FC6"].ToString(), out sysFc6);
            decimal.TryParse(dt.Rows[0]["Sys_TotalMoney"].ToString(), out totalMoney);

            entity.Id = id;
            entity.Sys_WA = sysWa;
            entity.Sys_DA = sysDa;
            entity.Sys_WT = sysWt;
            entity.Sys_DT = sysDt;
            entity.Sys_MAT = sysMat;
            entity.Sys_AIM = sysAim;
            entity.Sys_FC1 = sysFc1;
            entity.Sys_FC2 = sysFc2;
            entity.Sys_FC3 = sysFc3;
            entity.Sys_FC4 = sysFc4;
            entity.Sys_FC5 = sysFc5;
            entity.Sys_FC6 = sysFc6;
            entity.Sys_TotalMoney = totalMoney;

            return entity;
        }
    }

}
