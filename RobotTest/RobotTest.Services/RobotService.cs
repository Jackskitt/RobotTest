using RobotTest.Models;
using RobotTest.Models.Exceptions;
using RobotTest.Models.Interfaces;
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

        public bool MoveForward(string boardName)
        {
            var robot = GetRobot(boardName);
            var board = boardService.GetBoard(boardName);

            var directionVector = Vector2.MatrixFromDirection(robot.Direction);
            var newLocation = directionVector + robot.Position;

            if (!positionValidator.IsPositionValid(board, newLocation))
                throw new RobotOutOfBoundsException(newLocation);

            boardService.MoveObjectAtPosition(boardName, robot.Position, newLocation);
            return true;
        }

        /// <summary>
        /// Places the robot for the board with the default colour in the position in board space
        /// </summary>
        /// <param name="boardName"></param>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Robot PlaceRobot(string boardName, Vector2 position, Direction direction)
        {
            var robotExists = RobotExists(boardName);
            if (robotExists)
                throw new RobotAlreadyExistsException();

            var robotToCreate = new Robot(ConsoleColor.Red, position, direction);
            boardService.PlaceObjectAtPosition(boardName, robotToCreate, position);
            return robotToCreate;
        }

        /// <summary>
        /// Fetches the robot from the board and generates a report string
        /// </summary>
        /// <param name="boardName"></param>
        /// <returns></returns>
        public string ReportPosition(string boardName)
        {
            var robot = GetRobot(boardName);
            return robot.ToBoardReport();
        }

        public Robot GetRobot(string boardName)
        {
            var board = boardService.GetBoard(boardName);
            foreach (var boardItem in board.BoardItems)
            {
                if (boardItem is IRobot)
                    return (Robot)boardItem;
            }

            throw new RobotPlacedException(boardName);
        }

        public bool RobotExists(string boardName)
        {
            var board = boardService.GetBoard(boardName);
            foreach (var boardItem in board.BoardItems)
            {
                if (boardItem is IRobot)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Rotates the robot either left or right
        /// </summary>
        /// <param name="boardName"></param>
        /// <param name="direction"></param>
        public void Rotate(string boardName, RotateDirection direction)
        {
            var robot = GetRobot(boardName);

            var directionInt = (int)robot.Direction;
            var newDirectionInt = (int)direction + directionInt;
            if (newDirectionInt < 0)
                newDirectionInt = 3;

            if (newDirectionInt > 3)
                newDirectionInt = 0;

            var newDirection = (Direction)newDirectionInt;
            robot.Direction = newDirection;
        }
    }
}
