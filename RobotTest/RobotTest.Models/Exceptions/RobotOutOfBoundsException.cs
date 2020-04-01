using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Models.Exceptions
{
    public class RobotOutOfBoundsException : Exception
    {
        public RobotOutOfBoundsException(Vector2 position) : base ($"Robot is going out of bounds at position {position.X}, {position.Y}")
        {
        }
    }
}
