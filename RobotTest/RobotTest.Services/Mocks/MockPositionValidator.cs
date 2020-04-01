using RobotTest.Models;
using RobotTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Services.Mocks
{
    public class MockPositionValidator : IPositionValidator
    {
        public bool IsPositionValid(Board board, Vector2 position)
        {
            return true;
        }

    }
}
