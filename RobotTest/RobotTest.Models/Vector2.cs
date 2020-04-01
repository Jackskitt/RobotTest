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

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X * b.X, a.Y * b.Y);
        }

        public static Vector2 MatrixFromDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    return new Vector2(0, 1);
                case Direction.EAST:
                    return new Vector2(1, 0);
                case Direction.SOUTH:
                    return new Vector2(0, -1);
                case Direction.WEST:
                    return new Vector2(-1, 0);
            }
            return new Vector2(0, 0);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2))
                return false;

            var other = (Vector2)obj;

            return (X == other.X && Y == other.Y);
        }
    }
}
