using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ChessGame
{
    public class AI
    {
        // “Đánh giá” độ sâu của thuật toán minimax
        private int depth;

        // Giá trị mảnh
        private const int pawnValue = 100;
        private const int knightValue = 320;
        private const int bishopValue = 330;
        private const int rookValue = 500;
        private const int queenValue = 900;
        private const int kingValue = 20000;

        // Điểm vị trí
        private static readonly int[] bestPawnPositions = {
              0,  0,  0,  0,  0,  0,  0,  0,
             50, 50, 50, 50, 50, 50, 50, 50,
             10, 10, 20, 30, 30, 20, 10, 10,
              5,  5, 10, 25, 25, 10,  5,  5,
              0,  0,  0, 20, 20,  0,  0,  0,
              5, -5,-10,  0,  0,-10, -5,  5,
              5, 10, 10,-20,-20, 10, 10,  5,
              0,  0,  0,  0,  0,  0,  0,  0
        };

        private static readonly int[] bestKnightPositions = {
            -50,-40,-30,-30,-30,-30,-40,-50,
            -40,-20,  0,  0,  0,  0,-20,-40,
            -30,  0, 10, 15, 15, 10,  0,-30,
            -30,  5, 15, 20, 20, 15,  5,-30,
            -30,  0, 15, 20, 20, 15,  0,-30,
            -30,  5, 10, 15, 15, 10,  5,-30,
            -40,-20,  0,  5,  5,  0,-20,-40,
            -50,-40,-30,-30,-30,-30,-40,-50,
        };

        private static readonly int[] bestBishopPositions = {
            -20,-10,-10,-10,-10,-10,-10,-20,
            -10,  0,  0,  0,  0,  0,  0,-10,
            -10,  0,  5, 10, 10,  5,  0,-10,
            -10,  5,  5, 10, 10,  5,  5,-10,
            -10,  0, 10, 10, 10, 10,  0,-10,
            -10, 10, 10, 10, 10, 10, 10,-10,
            -10,  5,  0,  0,  0,  0,  5,-10,
            -20,-10,-10,-10,-10,-10,-10,-20,
        };

        private static readonly int[] bestRookPositions = {
              0,  0,  0,  0,  0,  0,  0,  0,
              5, 10, 10, 10, 10, 10, 10,  5,
             -5,  0,  0,  0,  0,  0,  0, -5,
             -5,  0,  0,  0,  0,  0,  0, -5,
             -5,  0,  0,  0,  0,  0,  0, -5,
             -5,  0,  0,  0,  0,  0,  0, -5,
             -5,  0,  0,  0,  0,  0,  0, -5,
              0,  0,  0,  5,  5,  0,  0,  0
        };

        private static readonly int[] bestQueenPositions = {
             -20,-10,-10, -5, -5,-10,-10,-20,
             -10,  0,  0,  0,  0,  0,  0,-10,
             -10,  0,  5,  5,  5,  5,  0,-10,
              -5,  0,  5,  5,  5,  5,  0, -5,
               0,  0,  5,  5,  5,  5,  0, -5,
             -10,  5,  5,  5,  5,  5,  0,-10,
             -10,  0,  5,  0,  0,  0,  0,-10,
             -20,-10,-10, -5, -5,-10,-10,-20
        };

        private static readonly int[] bestKingPositions = {
            -30,-40,-40,-50,-50,-40,-40,-30,
            -30,-40,-40,-50,-50,-40,-40,-30,
            -30,-40,-40,-50,-50,-40,-40,-30,
            -30,-40,-40,-50,-50,-40,-40,-30,
            -20,-30,-30,-40,-40,-30,-30,-20,
            -10,-20,-20,-20,-20,-20,-20,-10,
             20, 20,  0,  0,  0,  0, 20, 20,
             20, 30, 10,  0,  0, 10, 30, 20
        };

        public AI(int _depth)
        {
            depth = _depth;
        }

        // Tính điểm
        public int CalculatePoint(Board board)
        {
            int scoreWhite = 0;
            int scoreBlack = 0;
            scoreWhite += GetScoreFromExistingPieces(Player.White, board);
            scoreBlack += GetScoreFromExistingPieces(Player.Black, board);

            int evaluation = scoreBlack - scoreWhite;

            int prespective = (board.Turn == Player.White) ? -1 : 1;
            return evaluation * prespective;
        }

        //Nhận điểm từ các quân cờ hiện có
        private static int GetScoreFromExistingPieces(Player player, Board board)
        {
            int material = 0;

            for (int i = 0; i < 64; i++)
            {
                if (board.Pieces[i] != null)
                {
                    if (board.Pieces[i].GetType() == typeof(Pawn) && board.Pieces[i].Player == player)
                    {
                        material += (pawnValue + bestPawnPositions[i]); // plus "+ bestPawnPositions[i]" if you want, but it doesn't work well
                    }
                    if (board.Pieces[i].GetType() == typeof(Knight) && board.Pieces[i].Player == player)
                    {
                        material += (knightValue); // plus "+ bestKnightPositions[i]" if you want, but it doesn't work well
                    }
                    if (board.Pieces[i].GetType() == typeof(Bishop) && board.Pieces[i].Player == player)
                    {
                        material += (bishopValue); // plus "+ bestBishopPositions[i]" if you want, but it doesn't work well
                    }
                    if (board.Pieces[i].GetType() == typeof(Rook) && board.Pieces[i].Player == player)
                    {
                        material += (rookValue); // plus "+ bestRookPositions[i]" if you want, but it doesn't work well
                    }
                    if (board.Pieces[i].GetType() == typeof(Queen) && board.Pieces[i].Player == player)
                    {
                        material += (queenValue); // plus "+ bestQueenPositions[i]" if you want, but it doesn't work well
                    }
                    if (board.Pieces[i].GetType() == typeof(King) && board.Pieces[i].Player == player)
                    {
                        material += (kingValue); // plus "+ bestKingPositions[i]" if you want, but it doesn't work well
                    }
                }
            }
            return material;
        }

        //+++++++++++++++++++++++++++++++++++++ MINIMAX ALGORITHM ++++++++++++++++++++++++++++++++++++

        //Tạo bảng đã di chuyển
        private Board GenerateMovedBoard(Board oldBoard, Move move)
        {
            Board newBoard = new Board();
            newBoard = ObjectExtensions.Copy(oldBoard);
            Board.MovePiece(newBoard, move.Tile, move.Next);
            return newBoard;
        }

       
        private int GetPieceValue(Board board, int index)
        {
            if (board.Pieces[index].GetType() == typeof(Pawn))
            {
                return pawnValue;
            }
            else if (board.Pieces[index].GetType() == typeof(Rook))
            {
                return rookValue;
            }
            else if (board.Pieces[index].GetType() == typeof(Knight))
            {
                return knightValue;
            }
            else if (board.Pieces[index].GetType() == typeof(Bishop))
            {
                return bishopValue;
            }
            else if (board.Pieces[index].GetType() == typeof(Queen))
            {
                return queenValue;
            }
            else if (board.Pieces[index].GetType() == typeof(King))
            {
                return kingValue;
            }

            return 0;
        }

        //Lệnh di chuyển
        private void OrderMoves(List<Move> moveList, Board board)
        {
            int[] moveScore = new int[moveList.Count];
            for (int i = 0; i < moveList.Count; i++)
            {
                moveScore[i] = 0;

                if (board.Pieces[moveList[i].Next] != null)
                {
                    moveScore[i] += 10 * GetPieceValue(board, moveList[i].Next) - GetPieceValue(board, moveList[i].Tile);
                }

                if (Board.PawnPromoted2(board.Pieces, moveList[i].Tile))
                {
                    moveScore[i] += queenValue;
                }

            }

            for (int sorted = 0; sorted < moveList.Count; sorted++)
            {
                int bestScore = int.MinValue;
                int bestScoreIndex = 0;

                for (int i = sorted; i < moveList.Count; i++)
                {
                    if (moveScore[i] > bestScore)
                    {
                        bestScore = moveScore[i];
                        bestScoreIndex = i;
                    }
                }

                // swap
                Move bestMove = moveList[bestScoreIndex];
                moveList[bestScoreIndex] = moveList[sorted];
                moveList[sorted] = bestMove;
            }
        }

        private int Minimax(Board board, int depth, int alpha, int beta, bool isMaximizingPlayer)
        {
            if (depth == 0)
                return CalculatePoint(board);

            if (isMaximizingPlayer)
            {
                int bestValue = int.MinValue;

                List<Move> possibleMoves = Board.GetAllLegalMoves(Player.Black, board);

                OrderMoves(possibleMoves, board);
                foreach (var move in possibleMoves)
                {
                    Board newBoard = GenerateMovedBoard(board, move);

                    int value = Minimax(newBoard, depth - 1, alpha, beta, false);

                    bestValue = Math.Max(value, bestValue);

                    alpha = Math.Max(alpha, value);

                    if (beta <= alpha)
                    {
                        break;
                    }
                }

                return bestValue;
            }
            else
            {
                int bestValue = int.MaxValue;

                List<Move> possibleMoves = Board.GetAllLegalMoves(Player.White, board);

                OrderMoves(possibleMoves, board);
                foreach (var move in possibleMoves)
                {
                    Board newBoard = GenerateMovedBoard(board, move);

                    int value = Minimax(board, depth - 1, alpha, beta, true);

                    bestValue = Math.Min(value, bestValue);

                    beta = Math.Min(beta, value);

                    if (beta <= alpha)
                    {
                        break;
                    }
                }

                return bestValue;
            }
        }

        public Move GetBestMove(Board board)
        {
            int bestValue = int.MinValue;
            Move bestMove = null;
            bool turn;
            if (board.Turn == Player.Black)
            {
                turn = false;
            }
            else
            {
                turn = true;
            }

            List<Move> possibleMoves = Board.GetAllLegalMoves(board.Turn, board);

            OrderMoves(possibleMoves, board);
            foreach (var move in possibleMoves)
            {
                Board newBoard = GenerateMovedBoard(board, move);

                int value = Minimax(newBoard, depth, int.MinValue, int.MaxValue, turn);

                if (value >= bestValue)
                {
                    bestValue = value;
                    bestMove = move;
                }
            }

            return bestMove;
        }

        public List<MoveEvaluation> GetBestMoves(Board board)
        {
            List<MoveEvaluation> moveEvaluations = new List<MoveEvaluation>();

            bool turn = (board.Turn == Player.White);
            List<Move> possibleMoves = Board.GetAllLegalMoves(board.Turn, board);

            OrderMoves(possibleMoves, board);
            foreach (var move in possibleMoves)
            {
                Board newBoard = GenerateMovedBoard(board, move);
                int value = Minimax(newBoard, depth, int.MinValue, int.MaxValue, turn);

                moveEvaluations.Add(new MoveEvaluation
                {
                    Move = move,
                    Evaluation = value
                });
            }

            return moveEvaluations;
        }

        //+++++++++++++ END +++++++++++++++++++ MINIMAX ALGORITHM ++++++++++++++++++++++++++++++++++++               

        public void EvaluateAI(Board board)
        {

            Move move = GetBestMove(board);
            if (move == null) return;
            Board.MovePiece(board, move.Tile, move.Next);
            board.Save(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\book\learn.txt", move.Tile, move.Next, board);
        }

    }

    public class MoveEvaluation
    {
        public Move Move { get; set; }
        public int Evaluation { get; set; }
    }
}