using RobotTest.Models;
using RobotTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Services.Interfaces
{
    public interface IBoardService
    {
        void DrawBoard(Board boardToDraw);

        bool PlaceObjectAtPosition(string boardName, IBoardItem boardItem, Vector2 position);

        bool MoveObjectAtPosition(string boardName, Vector2 source, Vector2 destination);

        Board GetBoard(string name);

        Robot GetRobot(string boardName);

        void SaveBoard(Board board);

    }
}
