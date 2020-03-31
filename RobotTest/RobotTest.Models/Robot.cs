using System;
using System.Drawing;
using RobotTest.Models.Interfaces;

namespace RobotTest.Models
{
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public class Robot : IRobot 
    {
        public Robot(ConsoleColor robotColor)
        {
            ItemColor = robotColor;
        }

        public string Name { get; set; }

        public Direction Direction { get; set; }
        public Vector2 Position { get; set; }
        public ConsoleColor ItemColor { get; set; }

        public char ToBoardPiece()
        {
            return 'R';
        }
    }
}
