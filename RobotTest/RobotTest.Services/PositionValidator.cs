using RobotTest.Models;
using RobotTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Services
{
    public class PositionValidator : IPositionValidator
    {
        public bool IsPositionValid(Board board, Vector2 position)
        {
            throw new NotImplementedException();
        }

        public bool IsPositionValid(Board board, Vector2 position, Direction direction)
        {
            return true;
        }
    }
}
