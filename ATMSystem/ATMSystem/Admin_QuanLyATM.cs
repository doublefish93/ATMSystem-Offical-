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
        }

        public void LoadDanhSachCayATM()
        {
            var dt = workContext.GetRecordsInATable("Sys_ID", "ATM_Info", string.Empty, null);
            
            if (dt != null)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var name = string.Format("Cây ATM {0}", dt.Rows[i]["Sys_ID"]);
                    listATM.Items.Add(name);
                }
            }
            var test = workContext.GetById(string.Empty, "Account", "1");
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

   
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void listATM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
    }
}
