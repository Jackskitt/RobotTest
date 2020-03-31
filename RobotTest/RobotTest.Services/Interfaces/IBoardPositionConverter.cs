using RobotTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Services.Interfaces
{
    public interface IBoardPositionConverter
    {
        Vector2 GetPosition(Vector2 position, Board board);
    }
}
