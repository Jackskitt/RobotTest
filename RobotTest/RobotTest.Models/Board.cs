using RobotTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Models
{
    public class Board
    {
        public Board(string name, int width, int height, IBoardItem[,] boardItems)
        {
            this.Name = name;
            this.Width = width;
            this.Height = height;
            BoardItems = boardItems;
        }
        public Board(string name, int width, int height)
        {
            this.Name = name;
            this.Width = width;
            this.Height = height;
        }

        public string Name { get; set; }

        public IBoardItem[,] BoardItems { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public Vector2 RobotPosition { get; set; }

    }
}
