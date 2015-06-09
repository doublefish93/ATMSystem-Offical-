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
    public partial class User_LichSuGiaoDich : Form
    {
        private readonly WorkContext workContext;
        private readonly Account account;
        public User_LichSuGiaoDich(WorkContext workContext, Account account)
        {
            this.workContext = workContext;
            this.account = account;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var columns = "Tran_ID as [Mã Giao Dịch], Tran_Amount as [Số Tiền Giao Dịch], Tran_Balance as [Số Dư], Tran_Reason as [Lý Do], Tran_Date as [Thời Gian Giao Dịch]";
            var condition = "Acc_From_ID=@fid or Acc_To_ID=@tid";
            var parameters = new Dictionary<string, object>()
            {
                {"@fid",account.AccountId},
                {"@tid",account.AccountId},
            };
            var dt = workContext.GetRecordsInATable(columns, "Transaction", condition, parameters);
            if (dt != null)
            {
                gridHistory.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
