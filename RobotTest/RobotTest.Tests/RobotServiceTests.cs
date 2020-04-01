using RobotTest.Models;
using RobotTest.Models.Exceptions;
using RobotTest.Services;
using RobotTest.Services.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RobotTest.Tests
{
    public class RobotServiceTests
    {
        [Fact]
        public void RotateRobotLeftExpectSuccess()
        {
            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
            var robotService = new RobotService(boardService, new PositionValidator());
            boardService.CreateNewBoard("test", 5, 5);
            robotService.PlaceRobot("test", new Vector2(1, 1), Direction.NORTH);
            robotService.Rotate("test", RotateDirection.LEFT);
            var robot = robotService.GetRobot("test");
            Assert.Equal(Direction.WEST,robot.Direction);
        }

        [Fact]
        public void RotateRobotRightExpectSuccess()
        {
            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
            var robotService = new RobotService(boardService, new PositionValidator());
            boardService.CreateNewBoard("test", 5, 5);
            robotService.PlaceRobot("test", new Vector2(1, 1), Direction.NORTH);
            robotService.Rotate("test", RotateDirection.RIGHT);
            var robot = robotService.GetRobot("test");
            Assert.Equal(Direction.EAST, robot.Direction);
        }

        [Fact]
        public void ReportAfterPlaceExpectSuccess()
        {
            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
            var robotService = new RobotService(boardService, new PositionValidator());
            boardService.CreateNewBoard("test", 5, 5);
            robotService.PlaceRobot("test", new Vector2(1, 1), Direction.NORTH);
            var robotReport = robotService.ReportPosition("test");
            Assert.Equal("X: 1 Y: 1 F: NORTH", robotReport);
        }


        [Fact]
        public void TestGetRobotWithPlacedRobot()
        {
            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
            var robotService = new RobotService(boardService, new PositionValidator());
            boardService.CreateNewBoard("test", 5, 5);
            robotService.PlaceRobot("test", new Vector2(1, 1), Direction.NORTH);
            var robot = robotService.GetRobot("test");
            Assert.NotNull(robot);
        }

        [Fact]
        public void TestGetRobotWithNoRobotThrowsException()
        {
            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
            var robotService = new RobotService(boardService, new PositionValidator());
            boardService.CreateNewBoard("test", 5, 5);
            Assert.Throws<RobotPlacedException>(() => robotService.GetRobot("test"));
        }

        [Theory]
        [InlineData(Direction.NORTH,1,2)]
        [InlineData(Direction.WEST,0,1)]
        [InlineData(Direction.SOUTH,1,0)]
        [InlineData(Direction.EAST, 2,1)]
        public void TestRobotMoveFromDirectionExpectSuccess(Direction startingDirection, int expectedX, int expectedY)
        {
            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
            var robotService = new RobotService(boardService, new PositionValidator());
            boardService.CreateNewBoard("test", 5, 5);
            robotService.PlaceRobot("test", new Vector2(1, 1), startingDirection);
            var moveResult = robotService.MoveForward("test");
            Assert.True(moveResult);
            var newRobotPosition = robotService.GetRobot("test");

            Assert.Equal(new Vector2(expectedX, expectedY),newRobotPosition.Position);
        }

        [Fact]
        public void TestRobotMoveOffEdgeExpectFalse()
        {
            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
            var robotService = new RobotService(boardService, new PositionValidator());
            boardService.CreateNewBoard("test", 5, 5);
            robotService.PlaceRobot("test", new Vector2(1, 4), Direction.NORTH);
            Assert.Throws<RobotOutOfBoundsException>(() => robotService.MoveForward("test"));           
        }


        [Fact]
        public void TestRobotExistsCheckExpectTrue()
        {
            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
            var robotService = new RobotService(boardService, new PositionValidator());
            boardService.CreateNewBoard("test", 5, 5);
            robotService.PlaceRobot("test", new Vector2(1, 4), Direction.NORTH);
            Assert.True(robotService.RobotExists("test"));
        }

        [Fact]
        public void TestRobotExistsCheckExpectFalse()
        {
            var boardService = new BoardService(new BoardPositionConverter(), new MockPositionValidator());
            var robotService = new RobotService(boardService, new PositionValidator());
            boardService.CreateNewBoard("test", 5, 5);
            Assert.False(robotService.RobotExists("test"));
        }

    }
}
