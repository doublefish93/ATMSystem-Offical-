namespace ATMSystem
{
    partial class User_DoiMaPin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOldPin = new System.Windows.Forms.TextBox();
            this.txtNewPin = new System.Windows.Forms.TextBox();
            this.txtReNewPin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Pin Cũ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã Pin Mới";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nhập Lại Mã Pin Mới";
            // 
            // txtOldPin
            // 
            this.txtOldPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPin.Location = new System.Drawing.Point(149, 52);
            this.txtOldPin.MaxLength = 4;
            this.txtOldPin.Name = "txtOldPin";
            this.txtOldPin.PasswordChar = '*';
            this.txtOldPin.Size = new System.Drawing.Size(149, 32);
            this.txtOldPin.TabIndex = 4;
            this.txtOldPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOldPin.TextChanged += new System.EventHandler(this.txtOldPin_TextChanged);
            // 
            // txtNewPin
            // 
            this.txtNewPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPin.Location = new System.Drawing.Point(149, 111);
            this.txtNewPin.MaxLength = 4;
            this.txtNewPin.Name = "txtNewPin";
            this.txtNewPin.PasswordChar = '*';
            this.txtNewPin.Size = new System.Drawing.Size(149, 32);
            this.txtNewPin.TabIndex = 5;
            this.txtNewPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewPin.TextChanged += new System.EventHandler(this.txtNewPin_TextChanged);
            // 
            // txtReNewPin
            // 
            this.txtReNewPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReNewPin.Location = new System.Drawing.Point(149, 179);
            this.txtReNewPin.MaxLength = 4;
            this.txtReNewPin.Name = "txtReNewPin";
            this.txtReNewPin.PasswordChar = '*';
            this.txtReNewPin.Size = new System.Drawing.Size(149, 32);
            this.txtReNewPin.TabIndex = 6;
            this.txtReNewPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReNewPin.TextChanged += new System.EventHandler(this.txtReNewPin_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Đổi Mã Pin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 36);
            this.button2.TabIndex = 8;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(223, 244);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 36);
            this.button3.TabIndex = 9;
            this.button3.Text = "Đóng";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // User_DoiMaPin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 310);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtReNewPin);
            this.Controls.Add(this.txtNewPin);
            this.Controls.Add(this.txtOldPin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "User_DoiMaPin";
            this.Text = "User_DoiMaPin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOldPin;
        private System.Windows.Forms.TextBox txtNewPin;
        private System.Windows.Forms.TextBox txtReNewPin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}