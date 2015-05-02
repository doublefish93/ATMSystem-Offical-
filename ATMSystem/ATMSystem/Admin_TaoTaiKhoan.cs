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
    public partial class Admin_TaoTaiKhoan : Form
    {
        private readonly WorkContext workContext;
        private readonly string id;
        public Admin_TaoTaiKhoan(WorkContext workContext,string id)
        {
            this.workContext = workContext;
            this.id = id;
            InitializeComponent();
            this.CenterToScreen();
        }
        

       
    }
}
