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
        public User_MainForm(WorkContext workContext, Account account)
        {
            this.workContext = workContext;
            this.account = account;
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnChangePin_Click(object sender, EventArgs e)
        {
            new User_DoiMaPin(workContext,account).Show();
        }
    }
}
