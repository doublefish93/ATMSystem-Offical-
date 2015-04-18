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
    public partial class Admin_QuanLyNganHang : Form
    {
        private readonly WorkContext workContext;
        public Admin_QuanLyNganHang(WorkContext workContext)
        {
            this.workContext = workContext;
            InitializeComponent();

            this.CenterToScreen();

        }

        public void ThongTinNganHangLoad()
        {
            txtAddress.Enabled = false;
            txtFax.Enabled = false;
            txtName.Enabled = false;
            txtPhone.Enabled = false;
            btnSubmit.Text = "Edit";

            var dt = workContext.GetRecordsInATable(string.Empty, "Bank_Info", string.Empty, null);

            if (dt.Rows.Count <= 0)
            {
                this.Dispose();
            }

            try
            {
                txtName.Text = dt.Rows[0]["Bank_Name"].ToString();
                txtPhone.Text = dt.Rows[0]["Bank_Phone"].ToString();
                txtAddress.Text = dt.Rows[0]["Bank_Address"].ToString();
                txtFax.Text = dt.Rows[0]["Bank_Fax"].ToString();
                txtID.Text = dt.Rows[0]["Bank_ID"].ToString();
            }
            catch (Exception ex)
            {
                this.Dispose();
            }
        }

        private void Admin_QuanLyNganHang_Load(object sender, EventArgs e)
        {
            ThongTinNganHangLoad();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text.Equals("Edit"))
            {
                this.Dispose();
            }
            else
            {
                ThongTinNganHangLoad();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text.Equals("Edit"))
            {
                btnSubmit.Text = "Save";
                txtAddress.Enabled = true;
                txtFax.Enabled = true;
                txtName.Enabled = true;
                txtPhone.Enabled = true;
            }
            else
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa tên ngân hàng");
                    return;
                }
                if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập địa chỉ");
                    return;
                }
                if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số điện thoại");
                    return;
                }
                if (string.IsNullOrEmpty(txtFax.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập số fax");
                    return;
                }

                var parameters = new Dictionary<string, object>
                {
                    {"@nName", txtName.Text.Trim()},
                    {"@nAddress", txtAddress.Text.Trim()},
                    {"@nFax", txtFax.Text.Trim()},
                    {"@nPhone", txtPhone.Text.Trim()},
                    {"@nID", txtID.Text.Trim()}
                };

                var stt = workContext.ExecuteProcedureParams("sp_edit_bank_info", parameters);
                MessageBox.Show(stt ? "Cập nhật thành công" : "Cập nhật không thành công");
                ThongTinNganHangLoad();
            }


        }
    }
}
