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

    public enum RotateDirection
    {
        LEFT = -1,
        RIGHT = 1
    }

    public class Robot : IRobot 
    {
        public Robot(ConsoleColor robotColor, Vector2 position, Direction direction)
        {
            this.Position = position;
            this.Direction = direction;
            ItemColor = robotColor;
            Name = "Johnny-Four";
        }

        public string Name { get; set; }

        public Direction Direction { get; set; }
        public Vector2 Position { get; set; }
        public ConsoleColor ItemColor { get; set; }

        public string ToBoardPiece()
        {
            return "R"+Direction.ToString()[0];
        }

        public string ToBoardReport()
        {
            return $"X: {Position.X} Y: {Position.Y} F: {Direction.ToString()}";
        }
    }
}
