using RobotTest.Models;
using RobotTest.Models.Interfaces;
using RobotTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotTest.Services
{
    public class BoardService : IBoardService
    {
        /// <summary>
        /// Mock foor the purpose of this test, would usually come from a data source
        /// </summary>
        private readonly List<Board> boards;
        private readonly IBoardPositionConverter boardPositionConverter;
        private readonly IPositionValidator positionValidator;

        public BoardService(List<Board> boards,
            IBoardPositionConverter boardPositionConverter,
            IPositionValidator positionValidator)
        {
            this.boards = boards;
            this.boardPositionConverter = boardPositionConverter;
            this.positionValidator = positionValidator;
        }

        public void DrawBoard(Board boardToDraw)
        {
            Console.SetCursorPosition(0, 5);
            for (var x = 0; x < boardToDraw.Width; x++)
            {
                for (var y = 0; y < boardToDraw.Height; y++)
                {
                    var item = boardToDraw.BoardItems[x, y];
                    Console.ForegroundColor = item.ItemColor;
                    Console.WriteLine($"| {item.ToBoardPiece()} | ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        public Board GetBoard(string name)
        {
            return boards.FirstOrDefault(x => x.Name == name);
        }

        public Robot GetRobot(string boardName)
        {
            var board = GetBoard(boardName);
            foreach (var boardItem in board.BoardItems)
            {
                if (boardItem is IRobot)
                    return (Robot)boardItem;
            }
            return default(Robot);
        }

        public bool MoveObjectAtPosition(string boardName, Vector2 source, Vector2 destination)
        {
            var board = GetBoard(boardName);

            var sourcePosition = boardPositionConverter.FromBoardCoordinates(source, board);
            var destionationPosition = boardPositionConverter.FromBoardCoordinates(destination, board);
            if (!positionValidator.IsPositionValid(board, destionationPosition))
                return false;

            var objectAtSource = board.BoardItems[sourcePosition.X, sourcePosition.Y];
            board.BoardItems[destionationPosition.X, destionationPosition.Y] = objectAtSource;
            board.BoardItems[sourcePosition.X, sourcePosition.Y] = new DefaultBoardItem(source);
            return true;
        }

        public bool PlaceObjectAtPosition(string boardName, IBoardItem boardItem, Vector2 position)
        {
            var board = GetBoard(boardName);
            

            var destPosition = boardPositionConverter.FromBoardCoordinates(position, board);
            if (!positionValidator.IsPositionValid(board, destPosition))
                return false;

            boardItem.Position = destPosition;
            board.BoardItems[destPosition.X, destPosition.Y] = boardItem;

            return true;
        }

        public void SaveBoard(Board board)
        {
            var boardIndex = boards.FindIndex(x => x.Name == board.Name);
            boards[boardIndex] = board;
        }
    }
}
