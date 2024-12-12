namespace ChessGame
{
    partial class fBlackPromotion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBlackPromotion));
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnBishop = new Button();
            btnKnight = new Button();
            btnRook = new Button();
            btnQueen = new Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Montserrat Medium", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(51, 12);
            label5.Name = "label5";
            label5.Size = new Size(225, 26);
            label5.TabIndex = 17;
            label5.Text = "Phong cấp quân Tốt";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(255, 51);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 16;
            label4.Text = "Bishop";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(177, 51);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 15;
            label3.Text = "Knight";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(105, 51);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 14;
            label2.Text = "Rook";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 51);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 13;
            label1.Text = "Queen";
            // 
            // btnBishop
            // 
            btnBishop.BackColor = Color.White;
            btnBishop.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBishop.Location = new Point(240, 69);
            btnBishop.Name = "btnBishop";
            btnBishop.Size = new Size(70, 70);
            btnBishop.TabIndex = 12;
            btnBishop.Text = "♝";
            btnBishop.UseVisualStyleBackColor = false;
            btnBishop.Click += btnBishop_Click;
            // 
            // btnKnight
            // 
            btnKnight.BackColor = Color.White;
            btnKnight.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnKnight.Location = new Point(164, 69);
            btnKnight.Name = "btnKnight";
            btnKnight.Size = new Size(70, 70);
            btnKnight.TabIndex = 11;
            btnKnight.Text = "♞";
            btnKnight.UseVisualStyleBackColor = false;
            btnKnight.Click += btnKnight_Click;
            // 
            // btnRook
            // 
            btnRook.BackColor = Color.White;
            btnRook.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRook.Location = new Point(88, 69);
            btnRook.Name = "btnRook";
            btnRook.Size = new Size(70, 70);
            btnRook.TabIndex = 10;
            btnRook.Text = "♜";
            btnRook.UseVisualStyleBackColor = false;
            btnRook.Click += btnRook_Click;
            // 
            // btnQueen
            // 
            btnQueen.BackColor = Color.White;
            btnQueen.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnQueen.Location = new Point(12, 69);
            btnQueen.Name = "btnQueen";
            btnQueen.Size = new Size(70, 70);
            btnQueen.TabIndex = 9;
            btnQueen.Text = "♛";
            btnQueen.UseVisualStyleBackColor = false;
            btnQueen.Click += btnQueen_Click;
            // 
            // fBlackPromotion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(322, 150);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBishop);
            Controls.Add(btnKnight);
            Controls.Add(btnRook);
            Controls.Add(btnQueen);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "fBlackPromotion";
            Text = "Phong cấp quân Tốt Đen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnBishop;
        private Button btnKnight;
        private Button btnRook;
        private Button btnQueen;
    }
}