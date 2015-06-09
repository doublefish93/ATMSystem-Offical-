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
    public partial class Admin_BaoCaoHeThong : Form
    {
        private readonly WorkContext workContext;
        public Admin_BaoCaoHeThong(WorkContext workContext)
        {
            this.workContext = workContext;
            InitializeComponent();
            this.CenterToScreen();
            LoadData(null,null);
        }

        private void LoadData(DateTime? dt1, DateTime? dt2)
        {
            var columns =
                "[Rep_ID] as [Mã Hiệu], [Rep_Title] as [Tiêu Đề] ,[Rep_Description] as [Mô Tả],[Rep_Time] as [Thời Gian]";
            string condition = string.Empty;
            if (dt1 != null || dt2 != null)
            {
                condition = "[Rep_Time] between '"+dt1.GetValueOrDefault()+"' and '"+dt2.GetValueOrDefault()+"'";
            }
            var dt = workContext.GetRecordsInATable(columns, "SYSTEM_REPORT", condition, null);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtFrom.Value.CompareTo(dtTo.Value) > 0)
            {
                MessageBox.Show("Ngày Đến phải lớn hơn ngày Bắt Đầu");
                return;
            }
            LoadData(dtFrom.Value,dtTo.Value);
        }
    }
}
