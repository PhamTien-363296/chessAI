using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{

    // Xác định người chơi là trắng và đen
    //emun sử dụng như các giá trị của một kiểu dữ liệu riêng biệt.
    public enum Player 
    {
        Black,
        White,
    }

    //xác định các loại quân cờ
    public enum Type
    {
        //Quân cờ trắng
        wRook,
        wKnight,
        wBishop,
        wQueen,
        wKing,
        wPawn,

        //Quân cờ đen
        bRook,
        bKnight,
        bBishop,
        bQueen,
        bKing,
        bPawn
    }

    //Lớp: Biểu diễn một vị trí trên bàn cờ sử dụng tọa độ x và y
    public class Coordinate
    {
        public int x { get; set; }
        public int y { get; set; }

        public Coordinate(int location)
        {
            y = location / 8;
            x = location - y * 8;
        }
    }

    //Cấu trúc: Xác định các giá trị không đổi đại diện cho các nước đi
    public struct Vector
    {
        // bishop, queen, pawn, rook, king
        // Di chuyển thẳng 
        public const int up = 8;
        public const int down = -8;
        public const int left = -1;
        public const int right = 1;

        // Di chuyển chéo 
        public const int upLeft = 7;
        public const int upRight = 9;
        public const int lowLeft = -9;
        public const int lowRight = -7;

        // knight
        // Di chuyển hình chữ “L”
        public const int nUpLeft = 15;
        public const int nUpRight = 17;
        public const int nDownLeft = -17;
        public const int nDownRight = -15;
        public const int nLeftUp = 6;
        public const int nLeftDown = -10;
        public const int nRightUp = 10;
        public const int nRightDown = -6;

    }



}
