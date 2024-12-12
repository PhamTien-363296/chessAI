using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    public class Move
    {
        public int Tile { get; set; } //Vị trí bắt đầu 
        public int Next { get; set; } //Vị trí kết thúc

        public Move() { }
        public Move(int tile, int next)
        {
            this.Tile = tile;
            this.Next = next;
        }
        public override string ToString()
        {
            int startX = Tile % 8;
            int startY = Tile / 8;
            int endX = Tile % 8;
            int endY = Tile / 8;
            return $"{startX}, {startY}) -> ({endX}, {endY})";
        }

    }
}
