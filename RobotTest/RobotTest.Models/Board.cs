using RobotTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Models
{
    public class Board
    {
        public Board(int width, int height)
        {
            BoardItems = new IBoardItem[width, height];
            this.Width = width;
            this.Height = height;
        }

        public IBoardItem[,] BoardItems { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public Vector2 RobotPosition { get; set; }

        public bool IsPositionValid(Vector2 position)
        {

        }

        public static Vector2 GetNormalisedPosition(int width, int height);
    }
}
