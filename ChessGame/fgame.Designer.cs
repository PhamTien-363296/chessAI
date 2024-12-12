namespace ChessGame
{
    partial class fgame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fgame));
            panel1 = new Panel();
            label4 = new Label();
            button1 = new Button();
            btnQuaylai = new Button();
            button3 = new Button();
            label5 = new Label();
            btnCaidat = new Button();
            label6 = new Label();
            label1 = new Label();
            label2 = new Label();
            playerTurn = new Label();
            pieceselect = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            selectX = new Label();
            selectY = new Label();
            colorDialog1 = new ColorDialog();
            panel2 = new Panel();
            label3 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(524, 429);
            panel1.TabIndex = 10;
            panel1.Paint += panel1_Paint;
            panel1.MouseClick += fgame_MouseClick;
            // 
            // label4
            // 
            label4.BackColor = Color.Pink;
            label4.Location = new Point(552, 347);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(239, 94);
            label4.TabIndex = 19;
            // 
            // button1
            // 
            button1.BackColor = Color.LavenderBlush;
            button1.FlatAppearance.BorderColor = Color.DeepPink;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Montserrat Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DeepPink;
            button1.Location = new Point(563, 399);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(101, 31);
            button1.TabIndex = 20;
            button1.Text = "TRỢ GIÚP";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnQuaylai
            // 
            btnQuaylai.BackColor = Color.LavenderBlush;
            btnQuaylai.FlatAppearance.BorderColor = Color.DeepPink;
            btnQuaylai.FlatAppearance.BorderSize = 2;
            btnQuaylai.FlatStyle = FlatStyle.Flat;
            btnQuaylai.Font = new Font("Montserrat Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuaylai.ForeColor = Color.DeepPink;
            btnQuaylai.Location = new Point(562, 359);
            btnQuaylai.Margin = new Padding(2);
            btnQuaylai.Name = "btnQuaylai";
            btnQuaylai.Size = new Size(102, 31);
            btnQuaylai.TabIndex = 21;
            btnQuaylai.Text = "QUAY LẠI";
            btnQuaylai.UseVisualStyleBackColor = false;
            btnQuaylai.Click += btnQuaylai_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.LavenderBlush;
            button3.FlatAppearance.BorderColor = Color.DeepPink;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Montserrat Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.DeepPink;
            button3.Location = new Point(679, 399);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(101, 31);
            button3.TabIndex = 22;
            button3.Text = "THOÁT";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.BackColor = Color.Pink;
            label5.Location = new Point(552, 58);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(239, 278);
            label5.TabIndex = 23;
            // 
            // btnCaidat
            // 
            btnCaidat.BackColor = Color.LavenderBlush;
            btnCaidat.FlatAppearance.BorderColor = Color.DeepPink;
            btnCaidat.FlatAppearance.BorderSize = 2;
            btnCaidat.FlatStyle = FlatStyle.Flat;
            btnCaidat.Font = new Font("Montserrat Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCaidat.ForeColor = Color.DeepPink;
            btnCaidat.Location = new Point(679, 359);
            btnCaidat.Margin = new Padding(2);
            btnCaidat.Name = "btnCaidat";
            btnCaidat.Size = new Size(101, 31);
            btnCaidat.TabIndex = 24;
            btnCaidat.Text = "CÀI ĐẶT";
            btnCaidat.UseVisualStyleBackColor = false;
            btnCaidat.Click += btnCaidat_Click;
            // 
            // label6
            // 
            label6.BackColor = Color.Pink;
            label6.Location = new Point(552, 12);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(239, 34);
            label6.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Pink;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(562, 23);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 26;
            label1.Text = "Lượt chơi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Pink;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(563, 67);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 27;
            label2.Text = "Quân cờ";
            // 
            // playerTurn
            // 
            playerTurn.AutoSize = true;
            playerTurn.BackColor = Color.Pink;
            playerTurn.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playerTurn.Location = new Point(631, 23);
            playerTurn.Margin = new Padding(2, 0, 2, 0);
            playerTurn.Name = "playerTurn";
            playerTurn.Size = new Size(45, 16);
            playerTurn.TabIndex = 28;
            playerTurn.Text = "label7";
            // 
            // pieceselect
            // 
            pieceselect.AutoSize = true;
            pieceselect.BackColor = Color.Pink;
            pieceselect.Font = new Font("Montserrat SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pieceselect.Location = new Point(631, 67);
            pieceselect.Margin = new Padding(2, 0, 2, 0);
            pieceselect.Name = "pieceselect";
            pieceselect.Size = new Size(42, 16);
            pieceselect.TabIndex = 29;
            pieceselect.Text = "label7";
            // 
            // label7
            // 
            label7.BackColor = Color.LavenderBlush;
            label7.Location = new Point(563, 90);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(217, 32);
            label7.TabIndex = 30;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.LavenderBlush;
            label8.Location = new Point(570, 98);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 31;
            label8.Text = "x";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.LavenderBlush;
            label9.Location = new Point(670, 98);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(13, 15);
            label9.TabIndex = 32;
            label9.Text = "y";
            // 
            // selectX
            // 
            selectX.AutoSize = true;
            selectX.BackColor = Color.LavenderBlush;
            selectX.Location = new Point(587, 98);
            selectX.Margin = new Padding(2, 0, 2, 0);
            selectX.Name = "selectX";
            selectX.Size = new Size(44, 15);
            selectX.TabIndex = 33;
            selectX.Text = "label10";
            // 
            // selectY
            // 
            selectY.AutoSize = true;
            selectY.BackColor = Color.LavenderBlush;
            selectY.Location = new Point(687, 98);
            selectY.Margin = new Padding(2, 0, 2, 0);
            selectY.Name = "selectY";
            selectY.Size = new Size(44, 15);
            selectY.TabIndex = 34;
            selectY.Text = "label10";
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Location = new Point(562, 146);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(218, 179);
            panel2.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 8);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 0;
            // 
            // label12
            // 
            label12.BackColor = Color.LavenderBlush;
            label12.Location = new Point(562, 127);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Padding = new Padding(0, 0, 0, 3);
            label12.Size = new Size(218, 21);
            label12.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.LavenderBlush;
            label11.Font = new Font("Montserrat", 9F);
            label11.Location = new Point(687, 127);
            label11.Margin = new Padding(0);
            label11.Name = "label11";
            label11.Padding = new Padding(10, 3, 10, 3);
            label11.Size = new Size(60, 22);
            label11.TabIndex = 2;
            label11.Text = "Black";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.LavenderBlush;
            label10.Font = new Font("Montserrat", 9F);
            label10.Location = new Point(563, 127);
            label10.Margin = new Padding(0);
            label10.Name = "label10";
            label10.Padding = new Padding(10, 3, 10, 3);
            label10.Size = new Size(63, 22);
            label10.TabIndex = 36;
            label10.Text = "White";
            // 
            // fgame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(803, 462);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(panel2);
            Controls.Add(selectY);
            Controls.Add(selectX);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(pieceselect);
            Controls.Add(playerTurn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(btnCaidat);
            Controls.Add(label5);
            Controls.Add(button3);
            Controls.Add(btnQuaylai);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "fgame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CHESS GAME- Nhóm 7 - Người với người";
            MouseClick += fgame_MouseClick;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Label label4;
        private Button button1;
        private Button btnQuaylai;
        private Button button3;
        private Label label5;
        private Button btnCaidat;
        private Label label6;
        private Label label1;
        private Label label2;
        private Label playerTurn;
        private Label pieceselect;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label selectX;
        private Label selectY;
        private ColorDialog colorDialog1;
        private Panel panel2;
        private Label label3;
        private Label label12;
        private Label label11;
        private Label label10;
    }
}