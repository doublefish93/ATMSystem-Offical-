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
    public partial class Admin_QuanLyNguoiDung : Form
    {
        private readonly WorkContext workContext;
        public Admin_QuanLyNguoiDung(WorkContext workContext)
        {
            this.workContext = workContext;
            InitializeComponent();
            this.CenterToScreen();
            LoadDanhSachKhachHang();
            lblDemTaiKhoan.Text = string.Empty;

        }


        private void LoadDanhSachKhachHang()
        {
            var columns = "[User_ID] as [ID],[User_IDCard] as [CMT],[User_Name] as [Họ Tên] ," +
                          "[User_Dob] as [Ngày Sinh],[User_Gender] as [Giới Tính] , [User_Address] as [Địa Chỉ]," +
                          "[User_Phone] as [Điện Thoại]";

            var condition = "User_Delete = 0";
            var dt = workContext.GetRecordsInATable(columns, "User", condition, null);
            if (dt != null && dt.Rows.Count > 0)
            {

                gridViewDanhSachKhachHang.DataSource = dt;
            }
        }

        private bool Check()
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Mời bạn nhập Họ và Tên của Khách Hàng");
                return false;
            }
            if (string.IsNullOrEmpty(txtCMT.Text))
            {
                MessageBox.Show("Mời bạn nhập chứng minh thư của Khách Hàng");
                return false;
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Mời bạn nhập Địa Chỉ của Khách Hàng");
                return false;
            }
            if (string.IsNullOrEmpty(cbbGioiTinh.SelectedItem.ToString()))
            {
                MessageBox.Show("Mời bạn chọn giới tính");
                return false;
            }
            if (string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Mời bạn nhập số Điện Thoại của Khách Hàng");
                return false;
            }
            if (string.IsNullOrEmpty(dtpDob.Text))
            {
                MessageBox.Show("Mời bạn chọn ngày sinh của Khách Hàng");
                return false;
            }
            var datetime = new DateTime();
            if (!DateTime.TryParse(dtpDob.Text, out datetime))
            {
                MessageBox.Show("Mời bạn chọn ngày sinh của Khách Hàng");
                return false;
            }

            return true;
        }

        private void Clear()
        {
            txtCMT.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtID.Text = string.Empty;
            cbbGioiTinh.SelectedIndex = -1;
            btnSubmit.Text = "Thêm Mới";
            lblDemTaiKhoan.Text = string.Empty;
            btnTaoTaiKhoan.Hide(); 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text.Equals("Cập Nhập"))
            {
                if (Check())
                {
                    var parameters = new Dictionary<string, object>()
                    {
                        {"@nIdCardNo", txtCMT.Text},
                        {"@nFullName", txtHoTen.Text},
                        {"@nGender", cbbGioiTinh.SelectedIndex},
                        {"@nDoB", dtpDob.Value},
                        {"@nPhone", txtDienThoai.Text},
                        {"@nAddress", txtDiaChi.Text},
                        {"@nID", txtID.Text},

                    };
                    var stt = workContext.ExecuteProcedureParams("sp_edit_user", parameters);
                    if (stt)
                    {
                        MessageBox.Show("Cập Nhập Thành Công");
                        Clear();
                        LoadDanhSachKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Cập Nhập Thất Bại");
                    }
                }
            }
            else
            {
                if (Check())
                {
                    var parameters = new Dictionary<string, object>()
                    {
                        {"@nIdCardNo", txtCMT.Text},
                        {"@nFullName", txtHoTen.Text},
                        {"@nGender", cbbGioiTinh.SelectedIndex},
                        {"@nDoB", dtpDob.Value},
                        {"@nPhone", txtDienThoai.Text},
                        {"@nAddress", txtDiaChi.Text},
                    };
                    var stt = workContext.ExecuteProcedureParams("sp_insert_user", parameters);
                    if (stt)
                    {
                        MessageBox.Show("Thêm Mới Thành Công");
                        Clear();
                        LoadDanhSachKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Mới Thất Bại");
                    }
                }
            }
        }

        private void gridViewDanhSachKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    btnTaoTaiKhoan.Show(); 
                    bool gender;
                    var row = this.gridViewDanhSachKhachHang.Rows[e.RowIndex];
                    txtCMT.Text = row.Cells[1].Value.ToString();
                    txtHoTen.Text = row.Cells[2].Value.ToString();
                    dtpDob.Text = row.Cells[3].Value.ToString();
                    bool.TryParse(row.Cells[4].Value.ToString(), out gender);
                    cbbGioiTinh.Text = gender ? "Nam" : "Nữ";
                    txtDiaChi.Text = row.Cells[5].Value.ToString();
                    txtDienThoai.Text = row.Cells[6].Value.ToString();
                    txtID.Text = row.Cells[0].Value.ToString();

                    btnSubmit.Text = "Cập Nhập";

                    const string condition = "User_ID = @userId";

                    var parameters = new Dictionary<string, object>()
                    {
                        {"@userId",row.Cells[0].Value}
                    };
                    var count = workContext.CountRecords(String.Empty, false, "Account", condition, parameters);
                    if (count >= 0)
                    {
                        lblDemTaiKhoan.Text = string.Format("Khách hàng này hiện có {0} tài khoản", count);

                    }
                    else
                    {
                        MessageBox.Show("Xảy ra lỗi");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void gridViewDanhSachKhachHang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gridViewDanhSachKhachHang.ClearSelection();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            gridViewDanhSachKhachHang.ClearSelection();
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            new Admin_TaoTaiKhoan(workContext,txtID.Text).Show();
        }

    }
}
