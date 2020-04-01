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
            if (board == default(Board))
                throw new ArgumentNullException("Need a board to validate a position against");

            if (position.X >= board.Width || position.X < 0)
                return false;

            if (position.Y >= board.Height || position.Y < 0)
                return false;

            return true;
        }

    }
}
