using RobotTest.Models;
using RobotTest.Models.Exceptions;
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

        public BoardService(
            IBoardPositionConverter boardPositionConverter,
            IPositionValidator positionValidator)
        {
            this.boards = new List<Board>();
            this.boardPositionConverter = boardPositionConverter;
            this.positionValidator = positionValidator;
        }

        /// <summary>
        /// Redraws the board at the first line of the console and then returns to the current line
        /// </summary>
        /// <param name="boardName"></param>
        public void DrawBoard(string boardName)
        {
            var boardToDraw = GetBoard(boardName);
            var oldCursorLeft = Console.CursorLeft;
            var oldCursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, 1);
            for (var x = 0; x < boardToDraw.Width; x++)
            {
                for (var y = 0; y < boardToDraw.Height; y++)
                {
                    var item = boardToDraw.BoardItems[x, y];
                    if (item == null)
                        continue;

                    Console.ForegroundColor = item.ItemColor;
                    Console.Write($"| {item.ToBoardPiece()} | ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(oldCursorLeft, oldCursorTop);
        }

        /// <summary>
        /// Fetches the board 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Board GetBoard(string name)
        {
            return boards.FirstOrDefault(x => x.Name == name);
        }


        /// <summary>
        /// Converts the source and destionation from board coordinates to array coordinates and attempts to move it from 
        /// the source to the destination leaving an empty tile behind
        /// </summary>
        /// <param name="boardName">The board to place within</param>
        /// <param name="source">Source position in board space</param>
        /// <param name="destination">Destination position in board space</param>
        /// <returns></returns>
        public bool MoveObjectAtPosition(string boardName, Vector2 source, Vector2 destination)
        {
            var board = GetBoard(boardName);

            var sourcePosition = boardPositionConverter.FromBoardCoordinates(source, board);
            var destinationPosition = boardPositionConverter.FromBoardCoordinates(destination, board);
            if (!positionValidator.IsPositionValid(board, destinationPosition))
                return false;

            var objectAtSource = board.BoardItems[sourcePosition.X, sourcePosition.Y];
            board.BoardItems[destinationPosition.X, destinationPosition.Y] = objectAtSource;
            objectAtSource.Position = destination;
            board.BoardItems[sourcePosition.X, sourcePosition.Y] = new DefaultBoardItem(source);
            return true;
        }

        /// <summary>
        /// Converts
        /// </summary>
        /// <param name="boardName"></param>
        /// <param name="boardItem"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool PlaceObjectAtPosition(string boardName, IBoardItem boardItem, Vector2 position)
        {
            var board = GetBoard(boardName);

            var destPosition = boardPositionConverter.FromBoardCoordinates(position, board);
            if (!positionValidator.IsPositionValid(board, destPosition))
                return false;

            boardItem.Position = position;
            board.BoardItems[destPosition.X, destPosition.Y] = boardItem;

            return true;
        }

        public void SaveBoard(Board board)
        {
            var boardIndex = boards.FindIndex(x => x.Name == board.Name);
            if (boardIndex > boards.Count)
                return;
            boards[boardIndex] = board;
        }

        /// <summary>
        /// Creates a new board populating with empty tiles and storing it in the data store
        /// </summary>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Board CreateNewBoard(string name, int width, int height)
        {

            var boardItems = new IBoardItem[width, height];
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var boardPosition = boardPositionConverter.ToBoardCoordinates(new Vector2(x, y), height);
                    boardItems[x, y] = new DefaultBoardItem(boardPosition);
                }
            }

            var board = new Board(name, width, height, boardItems);
            boards.Add(board);
            return board;
        }
    }
}
