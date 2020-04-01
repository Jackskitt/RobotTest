using RobotTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotTest.Services.Interfaces
{
    public interface IRobotService
    {
        /// <summary>
        /// Moves the robot forward in it's current direction
        /// </summary>
        /// <param name="boardName"></param>
        /// <returns>False if the robot cannot make the move</returns>
        bool MoveForward(string boardName);

        /// <summary>
        /// Places the robot on a board in a certain position and direction
        /// </summary>
        /// <param name="boardName"></param>
        /// <param name="position">Board position to move to </param>
        /// <param name="direction">The direction the robot should face</param>
        /// <returns></returns>
        Robot PlaceRobot(string boardName, Vector2 position, Direction direction);

        /// <summary>
        /// Rotates the current robot in the board either left or right
        /// </summary>
        /// <param name="boardName"></param>
        /// <param name="direction"></param>
        void Rotate(string boardName, RotateDirection direction);

        /// <summary>
        /// Reports the robots position within the board
        /// </summary>
        /// <param name="boardName"></param>
        /// <returns>The position of the board object</returns>
        string ReportPosition(string boardName);

        /// <summary>
        /// Gets the current robot within the board
        /// </summary>
        /// <param name="boardName"></param>
        /// <returns></returns>
        Robot GetRobot(string boardName);
    }
}
