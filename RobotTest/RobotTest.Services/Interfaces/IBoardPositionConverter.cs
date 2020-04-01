using RobotTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Services.Interfaces
{
    public interface IBoardPositionConverter
    {
        Vector2 ToBoardCoordinates(Vector2 position, Board board);

        Vector2 FromBoardCoordinates(Vector2 position, Board board);
    }
}
