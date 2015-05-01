namespace ATMSystem
{
    partial class Admin_QuanLyATM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listATM = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.txtTotalMoney = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLevel6 = new System.Windows.Forms.TextBox();
            this.txtLevel5 = new System.Windows.Forms.TextBox();
            this.txtLevel4 = new System.Windows.Forms.TextBox();
            this.txtLevel3 = new System.Windows.Forms.TextBox();
            this.txtLevel2 = new System.Windows.Forms.TextBox();
            this.txtLevel1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMutipleAmount = new System.Windows.Forms.TextBox();
            this.txtMaxMoneyTransfer = new System.Windows.Forms.TextBox();
            this.txtMaxTimeDeposit = new System.Windows.Forms.TextBox();
            this.txtMaxAmountDeposit = new System.Windows.Forms.TextBox();
            this.txtMaxTimeWithdraw = new System.Windows.Forms.TextBox();
            this.txtMaxAmountWithdraw = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listATM);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 410);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách cây ATM";
            // 
            // listATM
            // 
            this.listATM.FormattingEnabled = true;
            this.listATM.Location = new System.Drawing.Point(7, 20);
            this.listATM.Name = "listATM";
            this.listATM.Size = new System.Drawing.Size(184, 381);
            this.listATM.TabIndex = 0;
            this.listATM.SelectedValueChanged += new System.EventHandler(this.listATM_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSubmit);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.cbStatus);
            this.groupBox2.Controls.Add(this.txtTotalMoney);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtMutipleAmount);
            this.groupBox2.Controls.Add(this.txtMaxMoneyTransfer);
            this.groupBox2.Controls.Add(this.txtMaxTimeDeposit);
            this.groupBox2.Controls.Add(this.txtMaxAmountDeposit);
            this.groupBox2.Controls.Add(this.txtMaxTimeWithdraw);
            this.groupBox2.Controls.Add(this.txtMaxAmountWithdraw);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(215, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 410);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(292, 348);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 41);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(155, 348);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 41);
            this.btnSubmit.TabIndex = 25;
            this.btnSubmit.Text = "Thêm mới";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(7, 331);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(62, 13);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Trạng Thái ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 300);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 13);
            this.label18.TabIndex = 23;
            this.label18.Text = "Trạng Thái :";
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(215, 299);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(15, 14);
            this.cbStatus.TabIndex = 22;
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // txtTotalMoney
            // 
            this.txtTotalMoney.Location = new System.Drawing.Point(215, 256);
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.Size = new System.Drawing.Size(118, 20);
            this.txtTotalMoney.TabIndex = 21;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 259);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(131, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "Số tiền hiện có trong cây :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.txtLevel6);
            this.groupBox3.Controls.Add(this.txtLevel5);
            this.groupBox3.Controls.Add(this.txtLevel4);
            this.groupBox3.Controls.Add(this.txtLevel3);
            this.groupBox3.Controls.Add(this.txtLevel2);
            this.groupBox3.Controls.Add(this.txtLevel1);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(348, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(205, 294);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Các mức rút tiền nhanh";
            // 
            // txtLevel6
            // 
            this.txtLevel6.Location = new System.Drawing.Point(64, 220);
            this.txtLevel6.Name = "txtLevel6";
            this.txtLevel6.Size = new System.Drawing.Size(118, 20);
            this.txtLevel6.TabIndex = 25;
            // 
            // txtLevel5
            // 
            this.txtLevel5.Location = new System.Drawing.Point(64, 183);
            this.txtLevel5.Name = "txtLevel5";
            this.txtLevel5.Size = new System.Drawing.Size(118, 20);
            this.txtLevel5.TabIndex = 24;
            // 
            // txtLevel4
            // 
            this.txtLevel4.Location = new System.Drawing.Point(64, 149);
            this.txtLevel4.Name = "txtLevel4";
            this.txtLevel4.Size = new System.Drawing.Size(118, 20);
            this.txtLevel4.TabIndex = 23;
            // 
            // txtLevel3
            // 
            this.txtLevel3.Location = new System.Drawing.Point(64, 111);
            this.txtLevel3.Name = "txtLevel3";
            this.txtLevel3.Size = new System.Drawing.Size(118, 20);
            this.txtLevel3.TabIndex = 22;
            // 
            // txtLevel2
            // 
            this.txtLevel2.Location = new System.Drawing.Point(64, 73);
            this.txtLevel2.Name = "txtLevel2";
            this.txtLevel2.Size = new System.Drawing.Size(118, 20);
            this.txtLevel2.TabIndex = 21;
            // 
            // txtLevel1
            // 
            this.txtLevel1.Location = new System.Drawing.Point(64, 35);
            this.txtLevel1.Name = "txtLevel1";
            this.txtLevel1.Size = new System.Drawing.Size(118, 20);
            this.txtLevel1.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 223);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 17;
            this.label16.Text = "Mức 6 :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 186);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Mức 5 :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Mức 4 :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Mức 3 :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Mức 2 :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Mức 1 :";
            // 
            // txtMutipleAmount
            // 
            this.txtMutipleAmount.Location = new System.Drawing.Point(215, 219);
            this.txtMutipleAmount.Name = "txtMutipleAmount";
            this.txtMutipleAmount.Size = new System.Drawing.Size(118, 20);
            this.txtMutipleAmount.TabIndex = 17;
            // 
            // txtMaxMoneyTransfer
            // 
            this.txtMaxMoneyTransfer.Location = new System.Drawing.Point(215, 182);
            this.txtMaxMoneyTransfer.Name = "txtMaxMoneyTransfer";
            this.txtMaxMoneyTransfer.Size = new System.Drawing.Size(118, 20);
            this.txtMaxMoneyTransfer.TabIndex = 16;
            // 
            // txtMaxTimeDeposit
            // 
            this.txtMaxTimeDeposit.Location = new System.Drawing.Point(215, 141);
            this.txtMaxTimeDeposit.Name = "txtMaxTimeDeposit";
            this.txtMaxTimeDeposit.Size = new System.Drawing.Size(118, 20);
            this.txtMaxTimeDeposit.TabIndex = 15;
            // 
            // txtMaxAmountDeposit
            // 
            this.txtMaxAmountDeposit.Location = new System.Drawing.Point(215, 101);
            this.txtMaxAmountDeposit.Name = "txtMaxAmountDeposit";
            this.txtMaxAmountDeposit.Size = new System.Drawing.Size(118, 20);
            this.txtMaxAmountDeposit.TabIndex = 14;
            // 
            // txtMaxTimeWithdraw
            // 
            this.txtMaxTimeWithdraw.Location = new System.Drawing.Point(215, 68);
            this.txtMaxTimeWithdraw.Name = "txtMaxTimeWithdraw";
            this.txtMaxTimeWithdraw.Size = new System.Drawing.Size(118, 20);
            this.txtMaxTimeWithdraw.TabIndex = 13;
            // 
            // txtMaxAmountWithdraw
            // 
            this.txtMaxAmountWithdraw.Location = new System.Drawing.Point(215, 29);
            this.txtMaxAmountWithdraw.Name = "txtMaxAmountWithdraw";
            this.txtMaxAmountWithdraw.Size = new System.Drawing.Size(118, 20);
            this.txtMaxAmountWithdraw.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Số tiền khác nhập phải chia hết cho :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Số tiền tối đa trong 1 lần chuyển tiền :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Số lần tối đa được gửi trong 1 ngày :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số tiền tối đa được gửi trong 1 ngày :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số lần tối đa được rút trong 1 ngày :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số tiền tối đa được rút trong 1 ngày :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quản Lý Thông Tin Các Cây ATM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(487, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "label11";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(635, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "label13";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // Admin_QuanLyATM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 473);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Name = "Admin_QuanLyATM";
            this.Text = "Admin_QuanLyATM";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listATM;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtMutipleAmount;
        private System.Windows.Forms.TextBox txtMaxMoneyTransfer;
        private System.Windows.Forms.TextBox txtMaxTimeDeposit;
        private System.Windows.Forms.TextBox txtMaxAmountDeposit;
        private System.Windows.Forms.TextBox txtMaxTimeWithdraw;
        private System.Windows.Forms.TextBox txtMaxAmountWithdraw;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLevel6;
        private System.Windows.Forms.TextBox txtLevel5;
        private System.Windows.Forms.TextBox txtLevel4;
        private System.Windows.Forms.TextBox txtLevel3;
        private System.Windows.Forms.TextBox txtLevel2;
        private System.Windows.Forms.TextBox txtLevel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalMoney;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
    }
}