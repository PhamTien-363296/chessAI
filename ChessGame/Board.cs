using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Numerics;

namespace ChessGame
{
    public class Board
    {
        private Piece[] _pieces = new Piece[64];
        private bool _checkMate = false;
        private Player _turn = Player.White;

        private int _firstThreeMoves = 0;

        public Piece[] Pieces { get => _pieces; set => _pieces = value; }
        public bool CheckMate { get => _checkMate; set => _checkMate = value; }
        public Player Turn { get => _turn; set => _turn = value; }

        private Stack<MoveHistory> _moveHistory = new Stack<MoveHistory>();

        /// Hàm tạo khởi tạo vị trí bắt đầu của bàn cờ 
        ///Đặt tất cả các quân cờ vào vị trí ban đầu của chúng
        public Board()
        {
            //vị trí đặt các quân cờ
            // White
            for (int i = 0; i < 8; i++)
                Pieces[8 + i] = new Pawn(Type.wPawn, Player.White, 8 + i);

            Pieces[0] = new Rook(Type.wRook, Player.White, 0);
            Pieces[1] = new Knight(Type.wKnight, Player.White, 1);
            Pieces[2] = new Bishop(Type.wBishop, Player.White, 2);
            Pieces[3] = new Queen(Type.wQueen, Player.White, 3);
            Pieces[4] = new King(Type.wKing, Player.White, 4);
            Pieces[5] = new Bishop(Type.wBishop, Player.White, 5);
            Pieces[6] = new Knight(Type.wKnight, Player.White, 6);
            Pieces[7] = new Rook(Type.wRook, Player.White, 7);

            //Black
            for (int i = 0; i < 8; i++)
                Pieces[48 + i] = new Pawn(Type.bPawn, Player.Black, 48 + i);

            Pieces[56] = new Rook(Type.bRook, Player.Black, 56);
            Pieces[57] = new Knight(Type.bKnight, Player.Black, 57);
            Pieces[58] = new Bishop(Type.bBishop, Player.Black, 58);
            Pieces[59] = new Queen(Type.bQueen, Player.Black, 59);
            Pieces[60] = new King(Type.bKing, Player.Black, 60);
            Pieces[61] = new Bishop(Type.bBishop, Player.Black, 61);
            Pieces[62] = new Knight(Type.bKnight, Player.Black, 62);
            Pieces[63] = new Rook(Type.bRook, Player.Black, 63);

            Turn = Player.White;

        }

        /// Tạo bước đi hợp lệ cho từng quân cờ (1)
        public static List<int> GetLegalMoves(int tile, Board board)
        {
            List<int> legalMoves = new List<int>();
            if (board.Pieces[tile] != null)
                legalMoves = board.Pieces[tile].LegalMoves(tile, board);

            return legalMoves;
        }

        //Nhận các chuyển động hợp pháp của tất cả các quân cờ
        public static List<Move> GetAllLegalMoves(Player player, Board board, bool filter = true)
        {
            List<Move> allLegalMoves = new List<Move>();
            List<int> allPieces = GetPieces(board.Pieces, player);

            foreach (var tile in allPieces)
            {
                List<int> legalMoves = GetLegalMoves(tile, board);

                foreach (var move in legalMoves)
                {
                    allLegalMoves.Add(new Move(tile, move));
                }
            }

            return filter == true ?
            MoveGen.FilterIlegalMoves(allLegalMoves, board) : allLegalMoves;
        }


        //Lấy tất cả quân cờ
        public static List<int> GetPieces(Piece[] pieces, Player player)
        {
            List<int> allPieces = new List<int>();

            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i] == null)
                {
                    continue;
                }
                else if (pieces[i].Player == player)
                {
                    allPieces.Add(i);
                }
            }
            return allPieces;
        }

        //Di chuyển quân cờ
        //Người với AI
        public static void MovePiece(Board board, int tile, int move)
        {
            if (board.Pieces[tile] != null)
            {

                Piece piece = board.Pieces[tile];
                Piece capturedPiece = board.Pieces[move];

                board._moveHistory.Push(new MoveHistory(tile, move, capturedPiece, piece.Player, piece));

                if (board.Pieces[tile].Moved == false)
                {
                    board.Pieces[tile].SetMoved(true);
                }

                board.Pieces[move] = board.Pieces[tile];
                board.Pieces[tile] = null;

                board.Pieces[move].ChangePosition(move);

                KingCastled(board, tile, move);
                // Kiểm tra thăng cấp quân tốt và chỉ gọi một lần
                if (piece.GetPiece == Type.wPawn || piece.GetPiece == Type.bPawn)
                {
                    PawnPromoted2(board.Pieces, move);
                }
            }
        }

        //Di chuyển quân cờ
        //Người với người
        public static void MovePiece2(Board board, int tile, int move)
        {
            Piece piece = board.Pieces[tile];

            if (piece != null)
            {
                // Kiểm tra xem quân cờ thuộc về người chơi nào và thực hiện di chuyển tương ứng
                if (piece.Player == Player.White)
                {
                    Piece capturedPiece = board.Pieces[move];

                    board._moveHistory.Push(new MoveHistory(tile, move, capturedPiece, piece.Player, piece));
                    // Nếu là quân cờ của người chơi trắng
                    if (!piece.Moved)
                    {
                        piece.SetMoved(true);
                    }

                    // Thực hiện di chuyển quân cờ
                    board.Pieces[move] = piece;
                    board.Pieces[tile] = null;
                    piece.ChangePosition(move);

                    // Kiểm tra và thực hiện các hành động khác
                    KingCastled(board, tile, move);
                    PawnPromoted(board.Pieces, move);
                }
                else if (piece.Player == Player.Black)
                {
                    Piece capturedPiece = board.Pieces[move];

                    board._moveHistory.Push(new MoveHistory(tile, move, capturedPiece, piece.Player, piece));
                    // Nếu là quân cờ của người chơi đen
                    if (!piece.Moved)
                    {
                        piece.SetMoved(true);
                    }

                    // Thực hiện di chuyển quân cờ
                    board.Pieces[move] = piece;
                    board.Pieces[tile] = null;
                    piece.ChangePosition(move);

                    // Kiểm tra và thực hiện các hành động khác
                    KingCastled(board, tile, move);
                    PawnPromoted(board.Pieces, move);
                }
            }
        }

        //Thực hiện nhập thành
        public static void KingCastled(Board board, int tile, int move)
        {
            if (tile == 4 || tile == 60)
            {
                if (board.Pieces[move].GetPiece == Type.wKing || board.Pieces[move].GetPiece == Type.bKing)
                {
                    int rank = board.Pieces[move].GetPiece == Type.wKing ? 7 : 63;

                    if (move == rank - 1 && board.Pieces[rank].Moved == false)
                        MovePiece(board, rank, rank - 2);

                    else if (move == rank - 5 && board.Pieces[rank - 7].Moved == false)
                        MovePiece(board, rank - 7, rank - 4);
                }
            }
        }

        //Thăng tiến cho quân tốt
        //Người với người
        public static bool PawnPromoted(Piece[] pieces, int move)
        {
            Coordinate position = new Coordinate(move);
            Player currentPlayer = pieces[move].Player;
            Type currentPieceType = pieces[move].GetPiece;

            if (currentPieceType == Type.wPawn && position.y == 7)
            {
                using (fWhitePromotion promotionForm = new fWhitePromotion())
                {
                    if (promotionForm.ShowDialog() == DialogResult.OK)
                    {
                        Type selectedType = promotionForm.SelectedType;
                        pieces[move] = CreatePiece(currentPlayer, selectedType, move);
                        return true;
                    }
                }
            }

            if (currentPieceType == Type.bPawn && position.y == 0)
            {
                using (fBlackPromotion promotionForm = new fBlackPromotion())
                {
                    if (promotionForm.ShowDialog() == DialogResult.OK)
                    {
                        Type selectedType = promotionForm.SelectedType;
                        pieces[move] = CreatePiece(currentPlayer, selectedType, move);
                        return true;
                    }
                }
            }

            return false;
        }

        private static Piece CreatePiece(Player player, Type type, int move)
        {
            if (player == Player.White)
            {
                switch (type)
                {
                    case Type.wQueen:
                        return new Queen(Type.wQueen, player, move);
                    case Type.wRook:
                        return new Rook(Type.wRook, player, move);
                    case Type.wBishop:
                        return new Bishop(Type.wBishop, player, move);
                    case Type.wKnight:
                        return new Knight(Type.wKnight, player, move);
                    default:
                        throw new ArgumentException("Invalid piece type.");
                }
            }
            else
            {
                switch (type)
                {
                    case Type.bQueen:
                        return new Queen(Type.bQueen, player, move);
                    case Type.bRook:
                        return new Rook(Type.bRook, player, move);
                    case Type.bBishop:
                        return new Bishop(Type.bBishop, player, move);
                    case Type.bKnight:
                        return new Knight(Type.bKnight, player, move);
                    default:
                        throw new ArgumentException("Invalid piece type.");
                }
            }
        }


        //Thăng tiến cho tốt
        //Người với AI
        public static bool PawnPromoted2(Piece[] pieces, int move)
        {
            Coordinate position = new Coordinate(move);

            if (pieces[move].GetPiece == Type.wPawn && position.y == 7)
            {
                pieces[move] = new Queen(Type.wQueen, Player.White, move);
                return true;
            }

            else if (pieces[move].GetPiece == Type.bPawn && position.y == 0)
            {
                pieces[move] = new Queen(Type.bQueen, Player.Black, move);
                return true;
            }

            return false;
        }


        // Kiểm tra quân vua
        public static bool KingChecked(Type king, Board board)
        {
            MoveGen.ValidateCastling = false;

            Player opponent = king == Type.wKing ? Player.Black : Player.White;
            List<Move> legalMoves = Board.GetAllLegalMoves(opponent, board, false);

            MoveGen.ValidateCastling = true;
            foreach (Move move in legalMoves)
            {
                if (move.Next == Board.GetKingPosition(board.Pieces, king))
                {
                    return true;
                }
            }
            return false;
        }

        // Lấy vị trí quân vua
        public static int GetKingPosition(Piece[] pieces, Type piece)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i] != null)
                {
                    if (pieces[i].GetPiece == piece)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        // Sao chép bảng hiện tại
        public static Board CopyBoard(Board oldBoard)
        {
            Board newBoard = new Board();
            newBoard = ObjectExtensions.Copy(oldBoard);
            return newBoard;
        }

        // Lấy chuyển động và lượt của người chơi
        //Người với AI
        public bool GetMove(int tile, int next, Board board)
        {
            bool valid = false;

            List<Move> legalMoves = GetAllLegalMoves(Player.White, board);

            foreach (var move in legalMoves)
                if (move.Tile == tile && move.Next == next)
                    valid = true;

            if (valid == false)
                return false;

            MovePiece(board, tile, next);

            if (IsCheckmated(Player.White))
                return false;

            board.Save(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\book\learn.txt", tile, next, board);
            Turn = Player.Black;
            BlackTurn();
            return true;
        }

        // Con người tạo ra sự chuyển động
        //Người với người
        public bool GetMove2(int tile, int next, Board board, Player currentPlayer)
        {
            List<Move> legalMoves = GetAllLegalMoves(currentPlayer, board);

            bool valid = false;

            foreach (var move in legalMoves)
            {
                if (move.Tile == tile && move.Next == next)
                {
                    valid = true;
                    break;
                }
            }

            if (!valid)
                return false;

            MovePiece2(board, tile, next);

            if (IsCheckmated(currentPlayer))
                return false;

            if (currentPlayer == Player.White)
                Turn = Player.Black;
            else
                Turn = Player.White;

            return true;
        }

        // AI tạo ra chuyển động
        public void BlackTurn()
        {
            AI ai = new AI(2);
            if (Turn == Player.Black)
            {
                Thread.Sleep(100);
                if (this._firstThreeMoves < 2)
                {

                    ai.EvaluateAI(this);
                }


                if (IsCheckmated(Player.Black))
                    return;

                Turn = Player.White;
            }
        }

        //Lượt chơi của quân đen
        public bool BlackTurn2(int tile, int next, Board board)
        {
            return GetMove2(tile, next, board, Player.Black);
        }

        // Kiểm tra và xét thắng thua
        public bool IsCheckmated(Player player)
        {
            if (CheckMate == true)
            {
                Player winner = player == Player.White ? Player.Black : Player.White;
                return true;
            }

            return false;
        }

        //Kiểm tra nếu còn 2 King
        public bool IsKingOnlyLeft()
        {
            int whitePiecesCount = 0;
            int blackPiecesCount = 0;

            foreach (var piece in Pieces)
            {
                if (piece != null)
                {
                    if (piece.Player == Player.White)
                    {
                        whitePiecesCount++;
                    }
                    else if (piece.Player == Player.Black)
                    {
                        blackPiecesCount++;
                    }
                }
            }

            return whitePiecesCount == 1 && blackPiecesCount == 1;
        }

        // Lưu lại bước đi để học hỏi
        public void Save(string fileName, int tile, int next, Board board)
        {
            StreamWriter writer = File.AppendText(fileName);
            try
            {
                string a;
                string b;

                if (tile < 10)
                {
                    a = "0";
                }
                else
                {
                    a = "";
                }

                if (next < 10)
                {
                    b = "0";
                }
                else
                {
                    b = "";
                }

                if (board.CheckMate == true)
                {
                    writer.WriteLine("End Game");
                }
                else
                {
                    writer.Write(board.Turn);
                    writer.Write("   ");
                    writer.Write(a + tile);
                    writer.Write("   ");
                    writer.Write(b + next);
                    writer.WriteLine("");
                }

            }
            finally
            {
                writer.Close();
            }
        }

        //Lưu trạng thái của game
        public void SaveStatus(string fileName, Board board)
        {
            StreamWriter writer = File.AppendText(fileName);
            try
            {
                if (board._firstThreeMoves == 0)
                {
                    writer.WriteLine("New Game");
                    writer.WriteLine("");

                }
                if (board.CheckMate == true)
                {
                    writer.WriteLine("");
                    writer.WriteLine("End Game");
                    writer.WriteLine("");
                }
            }
            finally
            {
                writer.Close();
            }
        }

        public MoveHistory UndoLastMove()
        {
            if (_moveHistory.Count > 0)
            {
                MoveHistory lastMove = _moveHistory.Pop();
                Piece movedPiece = Pieces[lastMove.End];
                Pieces[lastMove.Start] = movedPiece;
                Pieces[lastMove.End] = lastMove.CapturedPiece;
                movedPiece.ChangePosition(lastMove.Start);
                if (!movedPiece.Moved)
                {
                    movedPiece.SetMoved(false);
                }
                if ((lastMove.MovedPiece.GetType() == typeof(King)) && (lastMove.Start == 4 || lastMove.Start == 60))
                {
                    MoveHistory rookMove = _moveHistory.Pop();
                    Piece rook = Pieces[rookMove.End];
                    Pieces[rookMove.Start] = rook;
                    Pieces[rookMove.End] = rookMove.CapturedPiece;
                    rook.ChangePosition(rookMove.Start);

                    Turn = Turn == Player.White ? Player.Black : Player.White;
                    return lastMove;
                }

                if (lastMove.MovedPiece.GetType() == typeof(Pawn))
                {
                    if (movedPiece.Player == Player.White)
                    {
                        Pieces[lastMove.Start] = new Pawn(Type.wPawn, movedPiece.Player, lastMove.Start);
                    }
                    else
                    {
                        Pieces[lastMove.Start] = new Pawn(Type.bPawn, movedPiece.Player, lastMove.Start);
                    }
                }

                Turn = Turn == Player.White ? Player.Black : Player.White;
                return lastMove;
            }
            return null;
        }
        public MoveHistory UndoLastMoveAI()
        {
            if (_moveHistory.Count > 0)
            {
                // Lấy thông tin về nước đi của người chơi
                MoveHistory lastMovePlayer = _moveHistory.Pop();
                Piece movedPiecePlayer = Pieces[lastMovePlayer.End];
                Pieces[lastMovePlayer.Start] = movedPiecePlayer;
                Pieces[lastMovePlayer.End] = lastMovePlayer.CapturedPiece;
                movedPiecePlayer.ChangePosition(lastMovePlayer.Start);

                // Kiểm tra và đặt lại trạng thái đã di chuyển của quân cờ người chơi
                if (!movedPiecePlayer.Moved)
                {
                    movedPiecePlayer.SetMoved(false);
                }


                // Lấy thông tin về nước đi của AI
                MoveHistory lastMoveAI = _moveHistory.Pop();
                Piece movedPieceAI = Pieces[lastMoveAI.End];
                Pieces[lastMoveAI.Start] = movedPieceAI;
                Pieces[lastMoveAI.End] = lastMoveAI.CapturedPiece;
                movedPieceAI.ChangePosition(lastMoveAI.Start);

                // Kiểm tra và đặt lại trạng thái đã di chuyển của quân cờ AI
                if (!movedPieceAI.Moved)
                {
                    movedPieceAI.SetMoved(false);
                }

                if ((lastMovePlayer.MovedPiece.GetType() == typeof(King)) && (lastMovePlayer.Start == 4 || lastMovePlayer.Start == 60))
                {
                    MoveHistory rookMove = _moveHistory.Pop();
                    Piece rook = Pieces[rookMove.End];
                    Pieces[rookMove.Start] = rook;
                    Pieces[rookMove.End] = rookMove.CapturedPiece;
                    rook.ChangePosition(rookMove.Start);

                    Turn = Turn == Player.White ? Player.White : Player.Black;
                    return lastMovePlayer;
                }


                if (lastMoveAI.MovedPiece.GetType() == typeof(Pawn))
                {
                    Pieces[lastMoveAI.Start] = new Pawn(Type.wPawn, movedPieceAI.Player, lastMoveAI.Start);
                }
                // Đảo ngược lượt chơi
                Turn = Turn == Player.Black ? Player.Black : Player.White;

                // Trả về thông tin về hai nước đi đã hoàn tác (của AI hoặc người chơi tùy vào thứ tự trong ngăn xếp)
                return new MoveHistory(lastMoveAI.Start, lastMoveAI.End, lastMoveAI.CapturedPiece, lastMoveAI.Player, lastMoveAI.MovedPiece);
            }
            return null;
        }
    }

}