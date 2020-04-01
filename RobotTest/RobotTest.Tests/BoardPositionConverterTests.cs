using RobotTest.Models;
using RobotTest.Services;
using Xunit;

namespace RobotTest.Tests
{
    public class BoardPositionConverterTests
    {
        [Theory]
        [InlineData(0, 0, 0, 4)]
        [InlineData(0, 4, 0, 0)]
        [InlineData(4, 0, 4, 4)]
        [InlineData(2, 2, 2, 2)]
        [InlineData(4, 4, 4, 0)]
        public void TestToBoardCoordinatesBounds(int inputX, int inputY, int expectedX, int expectedY)
        {
            var converter = new BoardPositionConverter();
            var board = new Board("test", 5, 5);

            var newCoords = converter.ToBoardCoordinates(new Vector2(inputX, inputY), board);
            Assert.Equal(new Vector2(expectedX, expectedY), newCoords);
        }
        [Theory]
        [InlineData(0, 4,0, 0)]
        [InlineData(0, 0,0, 4)]
        [InlineData(4, 4,4, 0)]
        [InlineData(2, 2,2, 2)]
        [InlineData(4, 0, 4, 4)]
        public void TestFromBoardCoordinatesBounds(int inputX, int inputY, int expectedX, int expectedY)
        {
            var converter = new BoardPositionConverter();
            var board = new Board("test", 5, 5);

            var newCoords = converter.FromBoardCoordinates(new Vector2(inputX, inputY), board);
            Assert.Equal(new Vector2(expectedX, expectedY), newCoords);
        }

    }
}
