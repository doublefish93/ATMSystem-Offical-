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
    public partial class Admin_MainForm : Form
    {
        private User user = null;
        private DangNhap dangNhapForm = null;
        private readonly WorkContext workContext;
        public Admin_MainForm(User user, DangNhap dangNhapForm, WorkContext workContext)
        {
            this.user = user;
            this.dangNhapForm = dangNhapForm;
            this.workContext = workContext;
            InitializeComponent();
            LoadData();
            this.CenterToScreen();
        }

        private void đăngXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            dangNhapForm.Visible = true;
          
        }

        private void LoadData()
        {
            var tongKhachHang = workContext.CountRecords("*", false, "User", "User_Delete=0", null);
            lblTotalCustomer.Text = tongKhachHang.ToString();

            var tongSoTaiKhoan = workContext.CountRecords("*", false, "Account", "Acc_Status = 1 and Acc_Delete = 0",
                null);
            lblNewCustomer.Text = tongSoTaiKhoan.ToString();

            var tongSoGiaoDich = workContext.CountRecords("*", false, "Transaction", string.Empty, null);
            lblTotalTrans.Text = tongSoGiaoDich.ToString();

            var tongSoTienGiaoDich = workContext.SumRecords("Tran_Amount", "Transaction", string.Empty, null);
            lblTotalMoney.Text = tongSoTienGiaoDich.ToString();

            var condition = "Month(Tran_Date) = Month(getDate()) and Year(Tran_Date)=YEAR(getDate())";
            var tongSoGiaoDichTrongThang = workContext.CountRecords("*", false, "Transaction", condition, null);
            lblTransMonth.Text = tongSoGiaoDichTrongThang.ToString();

            var moneyCondition = "Month(Tran_Date) = Month(getDate()) and Year(Tran_Date)=YEAR(getDate())";
            var tongSoTienGiaoDichTrongThang = workContext.SumRecords("Tran_Amount", "Transaction", moneyCondition, null);
            lblMoney.Text = tongSoTienGiaoDichTrongThang.ToString();

        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Bạn thực sự muốn thoát?", "Thoát", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void đôiMâtKhâuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Admin_DoiMatKhau(user,workContext).ShowDialog();
        }

        private void thôngTinNgânHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Admin_QuanLyNganHang(workContext).ShowDialog();
        }

        private void thôngTinCâyATMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Admin_QuanLyATM(workContext).ShowDialog();
        }

        private void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Admin_QuanLyNguoiDung(workContext).ShowDialog();
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Admin_QuanLyTaiKhoan(workContext).ShowDialog();
        }

        private void báoCáoHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Admin_BaoCaoHeThong(workContext).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
