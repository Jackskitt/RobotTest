using RobotTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Services.Interfaces
{
    public interface IPositionValidator
    {
        /// <summary>
        /// Validates that a position is valid within a board
        /// </summary>
        /// <param name="board"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsPositionValid(Board board, Vector2 position);
    }
}
