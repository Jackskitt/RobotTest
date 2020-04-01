using RobotTest.Models;
using System;

namespace RobotTest.Models.Interfaces
{
    public interface IRobot : IBoardItem
    {
        public string Name { get; set; }

        public Direction Direction { get; set; }

        string ToBoardReport();
    }
}
