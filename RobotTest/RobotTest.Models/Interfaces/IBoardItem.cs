using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RobotTest.Models.Interfaces
{
    public interface IBoardItem
    {
        ConsoleColor ItemColor { get; set; }

        Vector2 Position { get; set; }

        char ToBoardPiece();
    }
}
