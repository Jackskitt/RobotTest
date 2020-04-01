using RobotTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Services.Interfaces
{
    public interface IRobotService
    {
        bool MoveInDirection(string boardName, Direction direction);

        bool PlaceRobot(string boardName, Vector2 position, Direction direction);

        bool Rotate(string boardName, int direction);

        Robot ReportPosition(string boardName);
    }
}
