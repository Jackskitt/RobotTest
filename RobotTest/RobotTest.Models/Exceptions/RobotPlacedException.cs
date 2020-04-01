using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Models.Exceptions
{
    public class RobotPlacedException : Exception
    {
        public RobotPlacedException(string boardName) : base($"Robot cannot be placed on board {boardName}")
        {
        }
    }
}
