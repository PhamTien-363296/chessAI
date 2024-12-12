using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ChessGame;
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace ChessGame
{
    public partial class fgameAi : Form
    {
        Board board;
        private Piece SelectedPiece { get; set; }
        private Color whiteSquareColor;
        private Color blackSquareColor;
        private Color formBackgroundColor;
        // Khai báo một danh sách lưu trữ lịch sử nước đi
        List<MoveHistory> moveHistory = new List<MoveHistory>();

        //Trợ giúp
        private List<Move> suggestedMoves = new List<Move>();
        private MoveEvaluation bestMoveEval;

        public fgameAi()
        {
            InitializeComponent();
            board = new Board();
            board.SaveStatus(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\book\learn.txt", board);
            updateUI();

            whiteSquareColor = Color.White;
            blackSquareColor = Color.LightBlue;
            formBackgroundColor = this.BackColor;

            panel2.AutoScroll = true;
        }
        private void updateUI()
        {
            playerTurn.Text = board.Turn.ToString();
            if (SelectedPiece != null)
            {
                if (SelectedPiece.GetType() == typeof(Pawn))
                {
                    pieceselect.Text = "Pawn";
                }
                else if (SelectedPiece.GetType() == typeof(Rook))
                {
                    pieceselect.Text = "Rook";
                }
                else if (SelectedPiece.GetType() == typeof(Knight))
                {
                    pieceselect.Text = "Knight";
                }
                else if (SelectedPiece.GetType() == typeof(Bishop))
                {
                    pieceselect.Text = "Bishop";
                }
                else if (SelectedPiece.GetType() == typeof(Queen))
                {
                    pieceselect.Text = "Queen";
                }
                else if (SelectedPiece.GetType() == typeof(King))
                {
                    pieceselect.Text = "King";
                }
                selectX.Text = (SelectedPiece._position.x + 1).ToString();
                selectY.Text = (SelectedPiece._position.y + 1).ToString();
            }
            else
            {
                pieceselect.Text = "null";
                selectX.Text = "null";
                selectY.Text = "null";
            }
            if (board.CheckMate == true)
            {
                board.SaveStatus(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\book\learn.txt", board);
                if (board.Turn == Player.White)
                {
                    List<Move> list = Board.GetAllLegalMoves(Player.Black, board);
                    foreach (Move move in list)
                    {
                        if (move.Next == Board.GetKingPosition(board.Pieces, Type.wKing))
                        {
                            MessageBox.Show("You Lose!");
                            this.Close();
                        }
                    }
                    //MessageBox.Show("Draw!");
                    //this.Close();
                }
                if (board.Turn == Player.Black)
                {
                    List<Move> list = Board.GetAllLegalMoves(Player.White, board);

                    foreach (Move move in list)
                    {
                        if (move.Next == Board.GetKingPosition(board.Pieces, Type.bKing))
                        {
                            MessageBox.Show("You Win!");
                            this.Close();

                        }
                    }
                    //MessageBox.Show("Draw!");
                    //this.Close();
                }
            }
            else if (board.IsKingOnlyLeft())
            {
                MessageBox.Show("Hòa!");
                this.Close();
            }
        }

        public void DrawPiece(PaintEventArgs e, Player player, string white, string black, int i, int j)
        {
            Font drawFont = new Font("Arial", 26);
            SolidBrush textBrush = new SolidBrush(System.Drawing.Color.Black);
            int width = panel1.Width / 8;
            int height = panel1.Height / 8;

            switch (player)
            {
                case Player.White:
                    e.Graphics.DrawString(white, drawFont, textBrush, width / 8 + j * width, 8 * height - (7 * height / 9 + i * height));
                    break;
                case Player.Black:
                    e.Graphics.DrawString(black, drawFont, textBrush, width / 8 + j * width, 8 * height - (7 * height / 9 + i * height));
                    break;
            }
        }

        public void DrawSquare(PaintEventArgs e, int x, int y)
        {
            Brush brush;
            if ((x + y) % 2 == 0)
            {
                brush = new SolidBrush(whiteSquareColor);
                if (SelectedPiece != null && SelectedPiece._position.x == x && SelectedPiece._position.y == y - 1)
                {
                    brush = Brushes.DodgerBlue;
                }
            }
            else if (SelectedPiece != null && SelectedPiece._position.x == x && SelectedPiece._position.y == y - 1)
            {
                brush = Brushes.DodgerBlue;
            }
            else
            {
                brush = new SolidBrush(blackSquareColor);
            }

            if (SelectedPiece != null)
            {
                int tile = SelectedPiece._position.x + SelectedPiece._position.y * 8;
                foreach (int move in SelectedPiece.LegalMoves(tile, board))
                {
                    int m = move / 8;
                    int n = move - m * 8;
                    if (m == y - 1 && n == x)
                    {
                        brush = Brushes.DeepSkyBlue;
                    }
                }
            }

            int xPanel, yPanel;
            int width = panel1.Width / 8;
            int height = panel1.Height / 8;
            xPanel = x * width;
            yPanel = panel1.Height - height * y;
            e.Graphics.FillRectangle(brush, xPanel, yPanel, width, height);
        }

        /// Draw the board 
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Brush darkSquare = Brushes.Pink;
            Brush lightSquare = Brushes.LightPink;

            Font drawFont = new Font("Arial", 16);
            SolidBrush textBrush = new SolidBrush(System.Drawing.Color.Black);
            int width = panel1.Width / 8;
            int height = panel1.Height / 8;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    DrawSquare(e, i, j);
                }
            }


            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    int tile = x + y * 8;


                    if (board.Pieces[tile] != null)
                    {
                        Player player = board.Pieces[tile].Player;
                        if (board.Pieces[tile].GetType() == typeof(Pawn))
                        {
                            DrawPiece(e, player, "♙", "♟", y, x);
                        }
                        else if (board.Pieces[tile].GetType() == typeof(Rook))
                        {
                            DrawPiece(e, player, "♖", "♜", y, x);
                        }
                        else if (board.Pieces[tile].GetType() == typeof(Knight))
                        {
                            DrawPiece(e, player, "♘", "♞", y, x);
                        }
                        else if (board.Pieces[tile].GetType() == typeof(Bishop))
                        {
                            DrawPiece(e, player, "♗", "♝", y, x);
                        }
                        else if (board.Pieces[tile].GetType() == typeof(Queen))
                        {
                            DrawPiece(e, player, "♕", "♛", y, x);
                        }
                        else if (board.Pieces[tile].GetType() == typeof(King))
                        {
                            DrawPiece(e, player, "♔", "♚", y, x);
                        }
                    }
                }
            }
            //làm nổi bật các nước đi gợi ý
            foreach (var move in suggestedMoves)
            {
                int startX = move.Tile % 8;
                int startY = move.Tile / 8;
                int endX = move.Next % 8;
                int endY = move.Next / 8;
                //tạo solidbrush từ màu sắc 
                SolidBrush blackBrush = new SolidBrush(Color.FromArgb(100, Color.Black));
                SolidBrush greenBrush = new SolidBrush(Color.FromArgb(100, Color.Green));

                //vẽ vị trí bắt đầu
                e.Graphics.FillRectangle(blackBrush, startX * width, panel1.Height - (startY + 1) * height, width, height);

                //vẽ vị trí kết thúc
                e.Graphics.FillRectangle(greenBrush, endX * width, panel1.Height - (endY + 1) * height, width, height);

                //giải phóng solidbrush
                blackBrush.Dispose();
                greenBrush.Dispose();
            }
        }
        


        private void fgameAi_MouseClick(object sender, MouseEventArgs e)
        {
            if (board.Turn == Player.White)
            {
                decimal width = panel1.Width / 8;
                decimal height = panel1.Height / 8;

                decimal x = e.X / width;
                decimal i = Math.Floor(x);
                decimal y = e.Y / height;
                decimal j = 7 - Math.Floor(y);

                decimal clickedSquarePoint = (j * 8 + i);
                int clicked = Convert.ToInt32(clickedSquarePoint);
                Piece p = board.Pieces[clicked];
                if (SelectedPiece == null && p != null)
                {
                    if (p.Player == board.Turn)
                    {
                        SelectedPiece = p;
                        panel1.Invalidate();

                    }
                    else
                    {
                        MessageBox.Show("Đây là quân đen");
                    }
                }
                else
                {
                    if (p != null && p.Player == board.Turn)
                    {
                        SelectedPiece = p;
                        panel1.Invalidate();
                    }
                    else
                    {
                        if (SelectedPiece != null)
                        {
                            int m = SelectedPiece._position.x;
                            int n = SelectedPiece._position.y;
                            int tile = (m + n * 8);

                            if (board.GetMove(tile, clicked, board) == false)
                            {
                                MessageBox.Show("Không thể di chuyển");
                            }

                            Piece movedPiece = SelectedPiece;
                            AddMoveToHistory(new MoveHistory(tile, clicked, movedPiece, board.Turn, movedPiece));
                            SelectedPiece = null;
                            suggestedMoves.Clear();
                            panel1.Invalidate();

                        }
                        else
                        {
                            SelectedPiece = null;
                        }
                    }
                }
                updateUI();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCaidat_Click(object sender, EventArgs e)
        {
            using (fColorSettings colorSettingsForm = new fColorSettings(whiteSquareColor, blackSquareColor, formBackgroundColor))
            {
                if (colorSettingsForm.ShowDialog() == DialogResult.OK)
                {
                    whiteSquareColor = colorSettingsForm.WhiteSquareColor;
                    blackSquareColor = colorSettingsForm.BlackSquareColor;
                    formBackgroundColor = colorSettingsForm.FormBackgroundColor;

                    this.BackColor = formBackgroundColor;

                    panel1.Invalidate();
                }
            }
        }

        private void AddMoveToHistory(MoveHistory move)
        {

            moveHistory.Add(move);
            UpdateMoveHistoryPanel();
        }

        private void UpdateMoveHistoryPanel()
        {
            panel2.Controls.Clear();

            int leftOffset = 10;
            int rightOffset = panel2.Width - 150;
            int topOffset = 10;
            int yOffset = 35;

            for (int i = 0; i < moveHistory.Count; i++)
            {
                MoveHistory move = moveHistory[i];
                int x, y;
                x = leftOffset;
                y = topOffset + i * yOffset;

                Label moveLabel = new Label();
                moveLabel.Text = move.ToString();
                moveLabel.AutoSize = true;
                moveLabel.Location = new Point(x, y);

                panel2.Controls.Add(moveLabel);
            }

            panel2.AutoScrollPosition = new Point(0, panel2.VerticalScroll.Maximum);
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            MoveHistory undoneMove = board.UndoLastMoveAI();
            if (undoneMove != null)
            {
                moveHistory.RemoveAt(moveHistory.Count - 1);
                UpdateMoveHistoryPanel();
            }
            updateUI();
            panel1.Invalidate();
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            AI ai = new AI(3);
            List<MoveEvaluation> moveEvaluations = ai.GetBestMoves(board);

            if (moveEvaluations.Count > 0)
            {
                bestMoveEval = moveEvaluations[0]; // Chọn nước đi tốt nhất làm gợi ý
                suggestedMoves.Clear();
                suggestedMoves.Add(bestMoveEval.Move);

                panel1.Invalidate(); // Yêu cầu panel1 vẽ lại
            }
        }
    }
}
