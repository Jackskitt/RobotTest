using RobotTest.Models;
using RobotTest.Services;
using Xunit;

namespace RobotTest.Tests
{
    public class BoardPositionValidatorTests
    {
        [Theory]
        [InlineData(0, 4, true)]
        [InlineData(0, 0, true)]
        [InlineData(4, 4, true)]
        [InlineData(2, 2, true)]
        [InlineData(4, 0, true)]
        [InlineData(-1, 0, false)]
        [InlineData(5, 0, false)]
        [InlineData(5, 5, false)]
        [InlineData(3, 5, false)]
        public void TestFromBoardCoordinatesBounds(int inputX, int inputY, bool expected)
        {
            var converter = new PositionValidator();
            var board = new Board("test", 5, 5);

            var newCoords = converter.IsPositionValid(board, new Vector2(inputX, inputY));
            Assert.Equal(expected, newCoords);
        }
    }
}
