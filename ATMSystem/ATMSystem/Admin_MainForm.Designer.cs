namespace ATMSystem
{
    partial class Admin_MainForm
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
            this.stsBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tacVuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đôiMâtKhâuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuâtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.thôngTinVêPhânMêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinVêTacGiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinNgânHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCâyATMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSe1 = new ATMSystem.DataSe();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSe1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsBar
            // 
            this.stsBar.Name = "stsBar";
            this.stsBar.Size = new System.Drawing.Size(39, 17);
            this.stsBar.Text = "Status";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tacVuToolStripMenuItem,
            this.thôngKêToolStripMenuItem,
            this.thôngTinToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(898, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tacVuToolStripMenuItem
            // 
            this.tacVuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đôiMâtKhâuToolStripMenuItem,
            this.đăngXuâtToolStripMenuItem,
            this.toolStripSeparator1,
            this.thoatToolStripMenuItem});
            this.tacVuToolStripMenuItem.Name = "tacVuToolStripMenuItem";
            this.tacVuToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.tacVuToolStripMenuItem.Text = "Tác vụ";
            // 
            // đôiMâtKhâuToolStripMenuItem
            // 
            this.đôiMâtKhâuToolStripMenuItem.Name = "đôiMâtKhâuToolStripMenuItem";
            this.đôiMâtKhâuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.đôiMâtKhâuToolStripMenuItem.Text = "Đổi mật khẩu";
            this.đôiMâtKhâuToolStripMenuItem.Click += new System.EventHandler(this.đôiMâtKhâuToolStripMenuItem_Click);
            // 
            // đăngXuâtToolStripMenuItem
            // 
            this.đăngXuâtToolStripMenuItem.Name = "đăngXuâtToolStripMenuItem";
            this.đăngXuâtToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.đăngXuâtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuâtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuâtToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.thoatToolStripMenuItem.Text = "Thoát";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 380);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(898, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // thôngTinVêPhânMêmToolStripMenuItem
            // 
            this.thôngTinVêPhânMêmToolStripMenuItem.Name = "thôngTinVêPhânMêmToolStripMenuItem";
            this.thôngTinVêPhânMêmToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.thôngTinVêPhânMêmToolStripMenuItem.Text = "Thông tin về phần mềm";
            // 
            // thôngTinVêTacGiaToolStripMenuItem
            // 
            this.thôngTinVêTacGiaToolStripMenuItem.Name = "thôngTinVêTacGiaToolStripMenuItem";
            this.thôngTinVêTacGiaToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.thôngTinVêTacGiaToolStripMenuItem.Text = "Thông tin về tác giả";
            // 
            // thôngTinToolStripMenuItem
            // 
            this.thôngTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinVêPhânMêmToolStripMenuItem,
            this.thôngTinVêTacGiaToolStripMenuItem});
            this.thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            this.thôngTinToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.thôngTinToolStripMenuItem.Text = "Thông Tin";
            // 
            // thôngKêToolStripMenuItem
            // 
            this.thôngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinNgânHàngToolStripMenuItem,
            this.thôngTinCâyATMToolStripMenuItem,
            this.quảnLýNgườiDùngToolStripMenuItem,
            this.logsToolStripMenuItem});
            this.thôngKêToolStripMenuItem.Name = "thôngKêToolStripMenuItem";
            this.thôngKêToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.thôngKêToolStripMenuItem.Text = "Quản lý";
            // 
            // thôngTinNgânHàngToolStripMenuItem
            // 
            this.thôngTinNgânHàngToolStripMenuItem.Name = "thôngTinNgânHàngToolStripMenuItem";
            this.thôngTinNgânHàngToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.thôngTinNgânHàngToolStripMenuItem.Text = "Thông Tin Ngân Hàng";
            // 
            // thôngTinCâyATMToolStripMenuItem
            // 
            this.thôngTinCâyATMToolStripMenuItem.Name = "thôngTinCâyATMToolStripMenuItem";
            this.thôngTinCâyATMToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.thôngTinCâyATMToolStripMenuItem.Text = "Thông Tin Cây ATM";
            // 
            // quảnLýNgườiDùngToolStripMenuItem
            // 
            this.quảnLýNgườiDùngToolStripMenuItem.Name = "quảnLýNgườiDùngToolStripMenuItem";
            this.quảnLýNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.quảnLýNgườiDùngToolStripMenuItem.Text = "Quản Lý Người Dùng";
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.logsToolStripMenuItem.Text = "Báo Cáo Hệ Thống";
            // 
            // dataSe1
            // 
            this.dataSe1.DataSetName = "DataSe";
            this.dataSe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 114);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(207, 235);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(206, 142);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(692, 235);
            this.panel4.TabIndex = 6;
            // 
            // Admin_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 402);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Admin_MainForm";
            this.Text = "Admin_MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSe1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel stsBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tacVuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đôiMâtKhâuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuâtToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem thôngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinNgânHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCâyATMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNgườiDùngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinVêPhânMêmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinVêTacGiaToolStripMenuItem;
        private DataSe dataSe1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}