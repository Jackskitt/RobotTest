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

        bool PlaceObjectAtPosition(IBoardItem boardItem, Vector2 position);
    }
}
