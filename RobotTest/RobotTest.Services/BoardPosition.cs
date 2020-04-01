using RobotTest.Models;
using RobotTest.Services.Interfaces;

namespace RobotTest.Services
{

    /// <summary>
    /// For this rotation the equation is symmetrical although this might not always be the case
    /// </summary>
    public class BoardPositionConverter : IBoardPositionConverter
    {
        public Vector2 FromBoardCoordinates(Vector2 position, Board board)
        {
            return ToBoardCoordinates(position, board);
        }

        public Vector2 FromBoardCoordinates(Vector2 position, int height)
        {
            return ToBoardCoordinates(position, height);
        }

        public Vector2 ToBoardCoordinates(Vector2 position, Board board)
        {
            return ToBoardCoordinates(position, board.Height);
        }

        public Vector2 ToBoardCoordinates(Vector2 position, int height)
        {
            return new Vector2(position.X, (position.Y - (height - 1)) * -1);
        }
    }
}
