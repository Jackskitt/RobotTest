using Microsoft.Extensions.DependencyInjection;
using RobotTest.Models;
using RobotTest.Models.Exceptions;
using RobotTest.Services;
using RobotTest.Services.Interfaces;
using System;

namespace RobotTest
{
    class Program
    {
        
        /// <summary>
        /// Draws the inital grid and sets the cursor positions up and then processes the user input and handles the errors that occur from it
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection().AddScoped<IBoardService, BoardService>()
                .AddScoped<IRobotService, RobotService>()
                .AddScoped<IPositionValidator, PositionValidator>()
                .AddScoped<IBoardPositionConverter, BoardPositionConverter>()
                .BuildServiceProvider();

            Console.WriteLine("Hello Welcome to the robot board game... thing");
            Console.Write("Please Enter a board name:");
            var boardName = Console.ReadLine();
            var boardService = serviceProvider.GetService<IBoardService>();
            var robotService = serviceProvider.GetService<IRobotService>();
            boardService.CreateNewBoard(boardName, 5, 5);
            boardService.DrawBoard(boardName);
            Console.SetCursorPosition(0, 8);
            while (true)
            {
                Console.Write("Enter a command: ");
                try
                {
                    ReadCommand(boardName, robotService).Invoke();
                    boardService.DrawBoard(boardName);
                } catch(RobotPlacedException e)
                {
                    Console.WriteLine("Robot has not been placed yet, please run the place command");
                }
                catch(RobotOutOfBoundsException e)
                {
                    Console.WriteLine("The robot will fall off the edge and die if you move there :( ");
                }
                catch(RobotAlreadyExistsException e)
                {
                    Console.WriteLine("You can only afford one robot at a time");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Unknown Error");
                }
            }
        }

        /// <summary>
        /// Reads the command input from a user and decides which action to take
        /// </summary>
        /// <param name="boardName"></param>
        /// <param name="robotService"></param>
        /// <returns></returns>
        private static Action ReadCommand(string boardName, IRobotService robotService)
        {

            var command = Console.ReadLine().ToLower();

            switch (command)
            {
                case string comm when comm.Contains("place"):
                    var commandVariables = command.Substring(6, command.Length - 6);
                    var variables = commandVariables.Split(',');
                    if (variables.Length != 3)
                        break;

                    var xSuccess = int.TryParse(variables[0], out var x);
                    var ySuccess = int.TryParse(variables[1], out var y);
                    var fSuccess = Enum.TryParse<Direction>(variables[2].ToUpper(), out var direction);

                    if (!xSuccess || !ySuccess || !fSuccess)
                        break;
                    return () => robotService.PlaceRobot(boardName, new Vector2(x, y), direction);
                case "move":
                    return () => robotService.MoveForward(boardName);
                case "left":
                    return () => robotService.Rotate(boardName, RotateDirection.LEFT);
                case "right":
                    return () => robotService.Rotate(boardName, RotateDirection.RIGHT);
                case "report":
                    return () => { Console.WriteLine(robotService.ReportPosition(boardName)); };
            }
            return () => Console.WriteLine("Invalid input please try again");
        }


    }
}
