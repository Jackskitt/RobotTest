using RobotTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Services.Interfaces
{ 
    /// <summary>
    /// Used to convert from board position to array position and visa versa, 
    /// used as a injectable service so we can change the coordinate system of the board if we want to later
    /// </summary>
    public interface IBoardPositionConverter
    {
        Vector2 ToBoardCoordinates(Vector2 position, Board board);

        Vector2 FromBoardCoordinates(Vector2 position, Board board);

        Vector2 ToBoardCoordinates(Vector2 position, int height);

        Vector2 FromBoardCoordinates(Vector2 position, int height);
    }
}
