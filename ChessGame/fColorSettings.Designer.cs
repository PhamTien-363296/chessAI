namespace ChessGame
{
    partial class fColorSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fColorSettings));
            btnChangeWhiteColor = new Button();
            btnChangeBlackColor = new Button();
            btnSave = new Button();
            btnChangeBackgroundColor = new Button();
            SuspendLayout();
            // 
            // btnChangeWhiteColor
            // 
            btnChangeWhiteColor.FlatAppearance.BorderColor = Color.Black;
            btnChangeWhiteColor.FlatAppearance.BorderSize = 2;
            btnChangeWhiteColor.FlatStyle = FlatStyle.Flat;
            btnChangeWhiteColor.Font = new Font("Segoe UI", 12F);
            btnChangeWhiteColor.ForeColor = SystemColors.Desktop;
            btnChangeWhiteColor.Location = new Point(25, 19);
            btnChangeWhiteColor.Margin = new Padding(2);
            btnChangeWhiteColor.Name = "btnChangeWhiteColor";
            btnChangeWhiteColor.Size = new Size(161, 60);
            btnChangeWhiteColor.TabIndex = 0;
            btnChangeWhiteColor.Text = "♚ Đổi nền trắng";
            btnChangeWhiteColor.UseVisualStyleBackColor = true;
            btnChangeWhiteColor.Click += btnChangeWhiteColor_Click;
            // 
            // btnChangeBlackColor
            // 
            btnChangeBlackColor.FlatAppearance.BorderColor = Color.Black;
            btnChangeBlackColor.FlatAppearance.BorderSize = 2;
            btnChangeBlackColor.FlatStyle = FlatStyle.Flat;
            btnChangeBlackColor.Font = new Font("Segoe UI", 12F);
            btnChangeBlackColor.ForeColor = SystemColors.Desktop;
            btnChangeBlackColor.Location = new Point(197, 19);
            btnChangeBlackColor.Margin = new Padding(2);
            btnChangeBlackColor.Name = "btnChangeBlackColor";
            btnChangeBlackColor.Size = new Size(161, 60);
            btnChangeBlackColor.TabIndex = 1;
            btnChangeBlackColor.Text = "♔ Đổi nền đen";
            btnChangeBlackColor.UseVisualStyleBackColor = true;
            btnChangeBlackColor.Click += btnChangeBlackColor_Click;
            // 
            // btnSave
            // 
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 2;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F);
            btnSave.ForeColor = SystemColors.Desktop;
            btnSave.Location = new Point(132, 177);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(127, 38);
            btnSave.TabIndex = 2;
            btnSave.Text = "Lưu thay đổi";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnChangeBackgroundColor
            // 
            btnChangeBackgroundColor.FlatAppearance.BorderColor = Color.Black;
            btnChangeBackgroundColor.FlatAppearance.BorderSize = 2;
            btnChangeBackgroundColor.FlatStyle = FlatStyle.Flat;
            btnChangeBackgroundColor.Font = new Font("Segoe UI", 12F);
            btnChangeBackgroundColor.ForeColor = SystemColors.Desktop;
            btnChangeBackgroundColor.Location = new Point(25, 96);
            btnChangeBackgroundColor.Margin = new Padding(2);
            btnChangeBackgroundColor.Name = "btnChangeBackgroundColor";
            btnChangeBackgroundColor.Size = new Size(333, 64);
            btnChangeBackgroundColor.TabIndex = 3;
            btnChangeBackgroundColor.Text = "Đổi màu nền";
            btnChangeBackgroundColor.UseVisualStyleBackColor = true;
            btnChangeBackgroundColor.Click += btnChangeBackgroundColor_Click;
            // 
            // fColorSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(386, 238);
            Controls.Add(btnChangeBackgroundColor);
            Controls.Add(btnSave);
            Controls.Add(btnChangeBlackColor);
            Controls.Add(btnChangeWhiteColor);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "fColorSettings";
            Text = "Cài đặt màu";
            Click += btnChangeBlackColor_Click;
            ResumeLayout(false);
        }

        #endregion
        private Button btnChangeWhiteColor;
        private Button btnChangeBlackColor;
        private Button btnSave;
        private Button btnChangeBackgroundColor;
    }
}