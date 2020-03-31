using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Models
{
    public class Vector2
    {
        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
