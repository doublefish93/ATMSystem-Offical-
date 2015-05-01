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
        }

        private void LoadDanhSachKhachHang()
        {
            var condition = "User_Delete = 0";
            var columns = "[User_ID] as [ID],[User_IDCard] as [CMT],[User_Name] as [Họ Tên] ," +
                          "[User_Dob] as [Ngày Sinh],[User_Gender] as [Giới Tính] , [User_Address] as [Địa Chỉ]," +
                          "[User_Phone] as [Điện Thoại]";
            var dt = workContext.GetRecordsInATable(columns, "User", condition, null);
            if (dt != null)
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
            btnSubmit.Text = "Thêm Mới";
            lblDemTaiKhoan.Text = string.Empty;
        }
    }
}
