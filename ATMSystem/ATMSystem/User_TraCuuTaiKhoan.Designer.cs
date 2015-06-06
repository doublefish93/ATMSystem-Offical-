namespace ATMSystem
{
    partial class User_TraCuuTaiKhoan
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.Label();
            this.lblRutTien = new System.Windows.Forms.Label();
            this.lblTongTienRut = new System.Windows.Forms.Label();
            this.lblSoTienGui = new System.Windows.Forms.Label();
            this.lblTongTienGui = new System.Windows.Forms.Label();
            this.lblSoDu = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSoDu);
            this.groupBox1.Controls.Add(this.lblTongTienGui);
            this.groupBox1.Controls.Add(this.lblSoTienGui);
            this.groupBox1.Controls.Add(this.lblTongTienRut);
            this.groupBox1.Controls.Add(this.lblRutTien);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 264);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tra Cứu Tài Khoản";
            // 
            // txtTen
            // 
            this.txtTen.AutoSize = true;
            this.txtTen.Location = new System.Drawing.Point(30, 64);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(35, 13);
            this.txtTen.TabIndex = 1;
            this.txtTen.Text = "label2";
            // 
            // lblRutTien
            // 
            this.lblRutTien.AutoSize = true;
            this.lblRutTien.Location = new System.Drawing.Point(30, 110);
            this.lblRutTien.Name = "lblRutTien";
            this.lblRutTien.Size = new System.Drawing.Size(35, 13);
            this.lblRutTien.TabIndex = 2;
            this.lblRutTien.Text = "label3";
            // 
            // lblTongTienRut
            // 
            this.lblTongTienRut.AutoSize = true;
            this.lblTongTienRut.Location = new System.Drawing.Point(30, 158);
            this.lblTongTienRut.Name = "lblTongTienRut";
            this.lblTongTienRut.Size = new System.Drawing.Size(35, 13);
            this.lblTongTienRut.TabIndex = 3;
            this.lblTongTienRut.Text = "label4";
            // 
            // lblSoTienGui
            // 
            this.lblSoTienGui.AutoSize = true;
            this.lblSoTienGui.Location = new System.Drawing.Point(292, 110);
            this.lblSoTienGui.Name = "lblSoTienGui";
            this.lblSoTienGui.Size = new System.Drawing.Size(35, 13);
            this.lblSoTienGui.TabIndex = 4;
            this.lblSoTienGui.Text = "label5";
            // 
            // lblTongTienGui
            // 
            this.lblTongTienGui.AutoSize = true;
            this.lblTongTienGui.Location = new System.Drawing.Point(292, 158);
            this.lblTongTienGui.Name = "lblTongTienGui";
            this.lblTongTienGui.Size = new System.Drawing.Size(35, 13);
            this.lblTongTienGui.TabIndex = 5;
            this.lblTongTienGui.Text = "label6";
            // 
            // lblSoDu
            // 
            this.lblSoDu.AutoSize = true;
            this.lblSoDu.Location = new System.Drawing.Point(30, 222);
            this.lblSoDu.Name = "lblSoDu";
            this.lblSoDu.Size = new System.Drawing.Size(35, 13);
            this.lblSoDu.TabIndex = 6;
            this.lblSoDu.Text = "label7";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(451, 310);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // User_TraCuuTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 354);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Name = "User_TraCuuTaiKhoan";
            this.Text = "User_TraCuuTaiKhoan";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSoDu;
        private System.Windows.Forms.Label lblTongTienGui;
        private System.Windows.Forms.Label lblSoTienGui;
        private System.Windows.Forms.Label lblTongTienRut;
        private System.Windows.Forms.Label lblRutTien;
        private System.Windows.Forms.Label txtTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}