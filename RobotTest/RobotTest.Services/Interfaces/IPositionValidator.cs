using RobotTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Services.Interfaces
{
    public interface IPositionValidator
    {
        public bool IsPositionValid(Board board, Vector2 position);
    }
}
