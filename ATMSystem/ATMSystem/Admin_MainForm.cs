using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSystem
{
    public partial class Admin_MainForm : Form
    {
        private User user = null;
        private DangNhap dangNhapForm = null;
        public Admin_MainForm(User user, DangNhap dangNhapForm)
        {
            this.user = user;
            this.dangNhapForm = dangNhapForm;
            InitializeComponent();
            this.CenterToScreen();
        }

        private void đăngXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            dangNhapForm.Visible = true;
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
            new Admin_DoiMatKhau(user).ShowDialog();
        }

    }
}
