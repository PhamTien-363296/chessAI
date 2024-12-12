using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class MoveHistory
    {
        public int Start { get; set; }
        public int End { get; set; }
        public Piece CapturedPiece { get; set; }
        public Player Player { get; set; }
        public Piece MovedPiece { get; set; }


        public MoveHistory(int start, int end, Piece capturedPiece, Player player, Piece movedPiece)
        {
            Start = start;
            End = end;
            CapturedPiece = capturedPiece;
            Player = player;
            MovedPiece = movedPiece;
        }

        //public override string ToString2()
        //{
        //    int startX = Start % 8 + 1;
        //    int startY = Start / 8 + 1;
        //    int endX = End % 8 + 1;
        //    int endY = End / 8 + 1;

        //    string captured = CapturedPiece != null ? $" captures {CapturedPiece.GetType().Name}" : "";
        //    return $"[{startX},{startY}] to [{endX},{endY}]{captured}";
        //}

        public override string ToString()
        {
            int endX, endY;

            if (Player == Player.White)
            {
                endX = End % 8 + 1;
                endY = End / 8 + 1;
            }
            else 
            {
                endX = End % 8 + 1;
                endY = End / 8 + 1;
            }
            string pieceName = MovedPiece != null ? MovedPiece.GetType().Name : "Unknown Piece";
            return $"[{endX},{endY}] - {pieceName}";
        }
    }
}
