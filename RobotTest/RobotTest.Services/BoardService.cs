using RobotTest.Models;
using RobotTest.Models.Interfaces;
using RobotTest.Services.Interfaces;
using System;

namespace RobotTest.Services
{
    public class BoardService : IBoardService
    {
        public void DrawBoard(Board boardToDraw)
        {
            for (var x = 0; x < boardToDraw.Width; x++)
            {
                for (var y = 0; y < boardToDraw.Height; y++)
                {
                    var item = boardToDraw.BoardItems[x, y];
                    Console.ForegroundColor = item.ItemColor;
                    Console.WriteLine($"| {item.ToBoardPiece()} | ");
                    Console.ResetColor();
                }
            }
        }

        public bool PlaceObjectAtPosition(IBoardItem boardItem, Vector2 position)
        {


            return true;            
        }
    }
}
