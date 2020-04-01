using RobotTest.Models;
using RobotTest.Services;
using RobotTest.Services.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RobotTest.Tests
{
    public class BoardServiceTests
    {
        [Fact]
        public void TestGetBoardExpectTestBoard()
        {
            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
            var expected = boardService.CreateNewBoard("test", 5, 5);
            var fetched = boardService.GetBoard("test");
            Assert.Equal(expected, fetched);
        }

        [Fact]
        public void CreateBoardExpectBoardInStore()
        {

            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
             boardService.CreateNewBoard("test", 5, 5);
            Assert.NotNull(boardService.GetBoard("test"));
        }

        [Fact]
        public void SaveBoardExpectUpdate()
        {

            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
            boardService.CreateNewBoard("test", 5, 5);
            var testBoard = boardService.GetBoard("test");

            testBoard.Name = "test2";
            boardService.SaveBoard(testBoard);
            var updatedBoard = boardService.GetBoard("test2");
            var oldBoard = boardService.GetBoard("test");
            Assert.NotNull(updatedBoard);
            Assert.Null(oldBoard);
        }

        [Fact]
        public void MoveObjectAtPositionExpectSuccess()
        {
            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
            var robotService = new RobotService(boardService, new PositionValidator());
            boardService.CreateNewBoard("test", 5, 5);
            robotService.PlaceRobot("test", new Vector2(1, 1), Direction.NORTH);
            var robotReport = robotService.ReportPosition("test");
            Assert.Equal("X: 1 Y: 1 F: NORTH", robotReport);
            boardService.MoveObjectAtPosition("test", new Vector2(1, 1), new Vector2(3, 3));
            var newRobotPosition = robotService.ReportPosition("test");

            Assert.Equal("X: 3 Y: 3 F: NORTH", newRobotPosition);
        }
    }
}
