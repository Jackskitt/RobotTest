using RobotTest.Models;
using RobotTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Services.Interfaces
{
    public interface IBoardService
    {
        /// <summary>
        /// Fetches the board by name and then renders it
        /// </summary>
        /// <param name="boardName"></param>
        void DrawBoard(string boardName);

        /// <summary>
        /// Fetches a board from the datastore, places a entity at the position and performs validation if the position
        /// is valid
        /// </summary>
        /// <param name="boardName">The board to fetch</param>
        /// <param name="boardItem">The board item to place</param>
        /// <param name="position">The position to put it in</param>
        /// <returns></returns>
        void PlaceObjectAtPosition(string boardName, IBoardItem boardItem, Vector2 position);

        /// <summary>
        /// Moves the object from a source position to a destination
        /// </summary>
        /// <param name="boardName"></param>
        /// <param name="source">Source position</param>
        /// <param name="destination">Destination position</param>
        /// <returns></returns>
        void MoveObjectAtPosition(string boardName, Vector2 source, Vector2 destination);

        /// <summary>
        /// Fetches the board from the data source
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Board GetBoard(string name);



        /// <summary>
        /// Creates a new empty board with the sizes and adds it to the store
        /// </summary>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        Board CreateNewBoard(string name, int width, int height);

        /// <summary>
        /// Saves any untracked changes to the board
        /// </summary>
        /// <param name="board"></param>
        void SaveBoard(Board board);

    }
}
