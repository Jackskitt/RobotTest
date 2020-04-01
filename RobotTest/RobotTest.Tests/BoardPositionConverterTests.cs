using RobotTest.Models;
using RobotTest.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RobotTest.Tests
{
    public class BoardPositionConverterTests
    {
        [Fact]
        public void TestOriginExpectSuccess()
        {
            var converter = new BoardPositionConverter();
            var board = new Board(5, 5);

            var newCoords = converter.ToBoardCoordinates(new Vector2(0, 0), board);
            Assert.Equal(new Vector2(0, 5), newCoords);
        }

        [Fact]
        public void TestOriginEndExpectSuccess()
        {
            var converter = new BoardPositionConverter();
            var board = new Board(5, 5);

            var newCoords = converter.ToBoardCoordinates(new Vector2(5, 4), board);
            Assert.Equal(new Vector2(5, 1), newCoords);
        }

        [Fact]
        public void FromBoard54Expect51()
        {
            var converter = new BoardPositionConverter();
            var board = new Board(5, 5);

            var newCoords = converter.FromBoardCoordinates(new Vector2(5, 1), board);
            Assert.Equal(new Vector2(5, 4), newCoords);
        }

        [Fact]
        public void TestOriginMiddleExpectSuccess()
        {
            var converter = new BoardPositionConverter();
            var board = new Board(5, 5);

            var newCoords = converter.FromBoardCoordinates(new Vector2(3, 1), board);
            Assert.Equal(new Vector2(3, 4), newCoords);
        }
    }
}
