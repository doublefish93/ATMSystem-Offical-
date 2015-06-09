using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATMSystem.Core;

namespace ATMSystem
{
    public partial class Admin_QuanLyTaiKhoan : Form
    {
        private readonly WorkContext workContext;
        private string accId=string.Empty;
        public Admin_QuanLyTaiKhoan(WorkContext workContext)
        {
            this.workContext = workContext;
            InitializeComponent();
            this.CenterToScreen();
            LoadDanhSachNguoiDung(string.Empty);
        }
        
        private void LoadDanhSachNguoiDung(string search)
        {
            listUser.Items.Clear();
            string condition = string.Empty;
            if (string.IsNullOrEmpty(search))
            {
                condition = "User_Delete = 0";
            }
            else
            {
                condition = "User_Delete = 0 and ([User_Name] like '% " + search + " %' or [User_IDCard]  like '% " + search + " %' )";
                
            }
            listAccount.Items.Clear();
            var dt = workContext.GetRecordsInATable(string.Empty, "User", condition, null);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var value = string.Format("{0} - {1} - {2}", dt.Rows[i]["User_ID"], dt.Rows[i]["User_Name"],
                        dt.Rows[i]["User_IDCard"]);
                    listUser.Items.Add(value);
                }
            }
        }

        private void listUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            listAccount.Items.Clear();
            var selected = listUser.SelectedItem;
            if (selected != null)
            {
                var stringArray = selected.ToString().Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                var userId = stringArray.FirstOrDefault();
                var condition = "Acc_Delete = 0 And User_ID= @userID";
                var parameters = new Dictionary<string, object>()
            {
                {"@userID",userId}
            };
                var dt = workContext.GetRecordsInATable(String.Empty, "Account", condition, parameters);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var value = StringExtensions.ConvertAccountNoToDisplay(dt.Rows[i]["Acc_No"].ToString());
                        listAccount.Items.Add(value);
                    }
                }
            }
            btnUpdate.Visible = false;
            lblBalance.Visible = false;
            lblStatus.Visible = false;
        }

        private void listAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = listAccount.SelectedItem;
            if (selected != null)
            {
                var accountNo = StringExtensions.ConvertAccountNoToDb(selected.ToString());
                var dtGetAccountId = workContext.GetRecordsInATable("*", "Account", "Acc_No='" + accountNo+"'", null);
                if (dtGetAccountId != null && dtGetAccountId.Rows.Count > 0)
                {
                    var id = dtGetAccountId.Rows[0]["Acc_ID"];
                    accId = id.ToString();
                    lblBalance.Text = string.Format("Số Dư Hiện Tại Của Tài Khoản: {0}",
                        dtGetAccountId.Rows[0]["Acc_Balance"]);
                    bool status;
                    Boolean.TryParse(dtGetAccountId.Rows[0]["Acc_Status"].ToString(), out status);
                    btnUpdate.Visible = true;
                    lblBalance.Visible = true;
                    lblStatus.Visible = true;
                    if (status)
                    {
                        lblStatus.Text = "Tài Khoản đang hoạt động";
                        lblStatus.ForeColor = Color.Green;
                        btnUpdate.Text = "Khóa Tài Khoản";
                    }
                    else
                    {
                        lblStatus.Text = "Tài Khoản đang bị Khóa";
                        lblStatus.ForeColor = Color.Red;
                        btnUpdate.Text = "Mở Khóa Tài Khoản";
                    }

                    var parameters = new Dictionary<string, object>()
                    {
                        {"@id", id}
                    };
                    var condition = "[Acc_From_ID] = @id or [Acc_To_ID] = @id";
                    var columns =
                        "[Tran_Date] as [Thời Gian] ,[Tran_Balance] as [Số Dư] , [Tran_Amount] as [Số Tiền],  [Tran_Reason] as [Lý Do]";
                    var dt = workContext.GetRecordsInATable(columns, "Transaction", condition, parameters);
                    dataGridView1.DataSource = dt ?? null;
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool status;
            status = !btnUpdate.Text.Equals("Khóa Tài Khoản");
            var parameter = new Dictionary<string, object>()
            {
                {"@bStatus", status},
                {"@nAccID ", accId},
            };
            var stt = workContext.ExecuteProcedureParams("sp_set_status_acc", parameter);
            if (stt)
            {
                MessageBox.Show("Cập Nhật Tài Khoản Thành Công");
                if (!status)
                {
                    lblStatus.Text = "Tài Khoản đang bị Khóa";
                    lblStatus.ForeColor = Color.Red;
                    btnUpdate.Text = "Mở Khóa Tài Khoản";
                }
                else
                {
                    lblStatus.Text = "Tài Khoản đang hoạt động";
                    lblStatus.ForeColor = Color.Green;
                    btnUpdate.Text = "Khóa Tài Khoản";
                }
            }
            else
            {
                MessageBox.Show("Cập Nhật Tài Khoản Thất Bại");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var search = txtSearch.Text.Trim();
            LoadDanhSachNguoiDung(search);
        }

    }
}
