namespace ChessGame
{
    partial class fmain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmain));
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnNg = new Button();
            btnAi = new Button();
            btnEnd = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(287, 64);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            // 
            // label4
            // 
            label4.BackColor = Color.White;
            label4.Location = new Point(213, 19);
            label4.Name = "label4";
            label4.Size = new Size(385, 113);
            label4.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Goudy Old Style", 39.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(226, 28);
            label5.Name = "label5";
            label5.Size = new Size(354, 62);
            label5.TabIndex = 11;
            label5.Text = "CHESS GAME";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Montserrat", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(350, 88);
            label6.Name = "label6";
            label6.Size = new Size(93, 33);
            label6.TabIndex = 12;
            label6.Text = "MENU";
            // 
            // btnNg
            // 
            btnNg.BackColor = Color.White;
            btnNg.Font = new Font("Montserrat Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNg.ForeColor = Color.DeepPink;
            btnNg.Location = new Point(287, 142);
            btnNg.Name = "btnNg";
            btnNg.Size = new Size(237, 50);
            btnNg.TabIndex = 14;
            btnNg.Text = "Người với Người";
            btnNg.UseVisualStyleBackColor = false;
            btnNg.Click += btnNg_Click;
            // 
            // btnAi
            // 
            btnAi.BackColor = Color.White;
            btnAi.Font = new Font("Montserrat Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAi.ForeColor = Color.DodgerBlue;
            btnAi.Location = new Point(287, 198);
            btnAi.Name = "btnAi";
            btnAi.Size = new Size(237, 49);
            btnAi.TabIndex = 15;
            btnAi.Text = "Người với Máy";
            btnAi.UseVisualStyleBackColor = false;
            btnAi.Click += btnAi_Click;
            // 
            // btnEnd
            // 
            btnEnd.BackColor = Color.LightGray;
            btnEnd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnd.Location = new Point(350, 253);
            btnEnd.Name = "btnEnd";
            btnEnd.Size = new Size(100, 31);
            btnEnd.TabIndex = 16;
            btnEnd.Text = "Thoát";
            btnEnd.UseVisualStyleBackColor = false;
            btnEnd.Click += btnEnd_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 426);
            label2.Name = "label2";
            label2.Padding = new Padding(5);
            label2.Size = new Size(199, 31);
            label2.TabIndex = 18;
            label2.Text = "Nhóm 7 - Trí tuệ nhân tạo";
            // 
            // fmain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 466);
            Controls.Add(label2);
            Controls.Add(btnEnd);
            Controls.Add(btnAi);
            Controls.Add(btnNg);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Name = "fmain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CHESS GAME - Nhóm 7";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAi;
        private Button btnEnd;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnNg;
        private Button button2;
        private Label label2;
    }
}
