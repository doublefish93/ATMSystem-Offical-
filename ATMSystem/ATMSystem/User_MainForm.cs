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
    public partial class User_MainForm : Form
    {
        private readonly WorkContext workContext;
        private readonly Account account;
        private readonly ATMInfor atm;
        public User_MainForm(WorkContext workContext, Account account, ATMInfor atm)
        {
            this.workContext = workContext;
            this.account = account;
            this.atm = atm;
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnChangePin_Click(object sender, EventArgs e)
        {
            new User_DoiMaPin(workContext,account).Show();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new User_RutTien(workContext,account,atm).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new User_GuiTien(workContext,account,atm).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new User_ChuyenTien(workContext, atm, account).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new User_TraCuuTaiKhoan(workContext, account).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new User_LichSuGiaoDich(workContext, account).Show();
        }
    }
}
