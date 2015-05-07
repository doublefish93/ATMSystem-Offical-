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
        public Admin_QuanLyTaiKhoan(WorkContext workContext)
        {
            this.workContext = workContext;
            InitializeComponent();
            this.CenterToScreen();
            LoadDanhSachNguoiDung();
        }

        private void LoadDanhSachNguoiDung()
        {
            var condition = "User_Delete = 0";
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
                        var value = string.Format("{0}", dt.Rows[i]["Acc_No"]);
                        listAccount.Items.Add(value);
                    }
                }
            }
        }
      
    }
}
