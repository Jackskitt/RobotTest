using RobotTest.Models;
using RobotTest.Services.Interfaces;
using System;

namespace RobotTest.Services
{
    public class RobotService : IRobotService
    {
        private readonly IBoardService boardService;
        private readonly IPositionValidator positionValidator;

        public RobotService(IBoardService boardService,
            IPositionValidator positionValidator)
        {
            this.boardService = boardService;
            this.positionValidator = positionValidator;
        }

        public bool MoveInDirection(string boardName, Direction direction)
        {
            var robot = boardService.GetRobot(boardName);
            var board = boardService.GetBoard(boardName);

            var directionVector = Vector2.MatrixFromDirection(direction);
            var newLocation = directionVector + robot.Position;

            if (positionValidator.IsPositionValid(board, newLocation))
                throw new Exception("Position Invalid");

            boardService.MoveObjectAtPosition(boardName, robot.Position, newLocation);
            return true;
        }

        public Robot PlaceRobot(string boardName, Vector2 position, Direction direction)
        {
            var robotToCreate = new Robot(ConsoleColor.Red, position, direction);
            boardService.PlaceObjectAtPosition(boardName, robotToCreate, position);
            return robotToCreate;
        }

        public string ReportPosition(string boardName)
        {
            var robot = boardService.GetRobot(boardName);
            return robot.ToBoardReport();
        }

        public bool Rotate(string boardName, RotateDirection direction)
        {
            var robot = boardService.GetRobot(boardName);

            var directionInt = (int)robot.Direction;
            var newDirection = (int)direction + directionInt;
            if (newDirection < 0)
                newDirection = 4;

            if (newDirection > 4)
                newDirection = 0;

            robot.Direction = (Direction)newDirection;


        }
    }
}
