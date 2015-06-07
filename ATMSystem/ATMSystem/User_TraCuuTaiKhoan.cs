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
    public partial class User_TraCuuTaiKhoan : Form
    {
        private readonly WorkContext workContext;
        private readonly Account account;

        public User_TraCuuTaiKhoan(WorkContext workContext,
            Account account)
        {
            this.workContext = workContext;
            this.account = account;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            txtTen.Text = string.Format("Số Tài Khoản: {0}", account.AccountNo);
            
            lblSoDu.Text = string.Format("Số Dư Tài Khoản : {0}", account.AccountBalance);
           
            var conditionDeposit =
                "Tran_Date >= DATEADD(day, DATEDIFF(day, 0, getdate()), 0) and Tran_Type=0 and Acc_From_ID=@id";
            
            var conditionWithDraw=
                 "Tran_Date >= DATEADD(day, DATEDIFF(day, 0, getdate()), 0) and Tran_Type=1 and Acc_From_ID=@id";;

            var conditionDepositMonth=
                 "Month(Tran_Date) = Month(getDate()) and Year(Tran_Date)=YEAR(getDate()) and Tran_Type=0 and Acc_From_ID=@id";

            var conditionWithDrawMonth =
                 "Month(Tran_Date) = Month(getDate()) and Year(Tran_Date)=YEAR(getDate()) and Tran_Type=1 and Acc_From_ID=@id";

            var parameters = new Dictionary<string, object>()
            {
                {
                    "id",account.AccountId
                }
            };

            var countDeposit = workContext.CountRecords(string.Empty, false, "Transaction", conditionDeposit, parameters);
            lblSoLanGui.Text = countDeposit < 0 ? string.Empty : string.Format("Quý khách đã gửi tiền : {0} lần trong ngày hôm nay", countDeposit);

            var countWithDraw = workContext.CountRecords(string.Empty, false, "Transaction", conditionWithDraw, parameters);
            lblRutTien.Text = countWithDraw < 0 ? string.Empty : string.Format("Quý khách đã rút tiền : {0} lần trong ngày hôm nay", countWithDraw);

            var sumDeposit = workContext.SumRecords("[Tran_Amount]", "Transaction",conditionDeposit,parameters);
            lblTongTienGui.Text = string.IsNullOrEmpty(sumDeposit) ? string.Empty : string.Format("Tổng số tiền Quý khách đã gửi hôm nay là: {0}", sumDeposit);

            var sumWithDraw = workContext.SumRecords("[Tran_Amount]", "Transaction", conditionWithDraw, parameters);
            lblTongTienRut.Text = string.IsNullOrEmpty(sumWithDraw) ? string.Empty : string.Format("Tổng số tiền Quý khách đã rút hôm nay là: {0}", sumWithDraw);

            var countDepositMonth = workContext.CountRecords(string.Empty, false, "Transaction", conditionDepositMonth, parameters);
            var sumDepositMonth = workContext.SumRecords("[Tran_Amount]", "Transaction", conditionDepositMonth, parameters);

            lblDepositMonth.Text = string.Format("Quý khách đã gửi tiền : {0} lần trong tháng với số tiền {1}", countDepositMonth, sumDepositMonth);

            var countWithDrawMonth = workContext.CountRecords(string.Empty, false, "Transaction", conditionWithDrawMonth, parameters);
            var sumWithDrawMonth = workContext.SumRecords("[Tran_Amount]", "Transaction", conditionWithDrawMonth, parameters);

            lblWithDraw.Text = string.Format("Quý khách đã rút tiền : {0} lần trong tháng với số tiền {1}", countWithDrawMonth, sumWithDrawMonth);
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
