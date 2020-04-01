using RobotTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RobotTest.Models
{
    public class DefaultBoardItem : IBoardItem
    {
        public DefaultBoardItem(Vector2 position)
        {
            ItemColor = ConsoleColor.White;
            this.position = position;
        }

        public ConsoleColor ItemColor { get; set; }
        public Vector2 Position { get; set; }

        public char ToBoardPiece()
        {
            return '#';
        }
    }
}
