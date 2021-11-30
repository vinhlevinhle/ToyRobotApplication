using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RobotClassLibrary;

namespace ToyRobotApplication
{
    class UserCommandlineInput : InputParser
    {
        public UserCommandlineInput(BaseRobot toyRobot, String[] args)
            : base(toyRobot, args)
        {
        }

        public override void StartParing()
        {
            string userInputCommand = "Vinh Le";
            ParseCommand parser = new ParseCommand();

            Console.WriteLine("Please start issuing your Toy Robot command ...");

            while (userInputCommand != "q")
            {
                userInputCommand = Console.ReadLine();
                parser.StartParsing(userInputCommand);
                switch (parser.GetCommand())
                {
                    case "Nothing":
                        break;
                    case "PLACE":
                        Coordinate coord = parser.GetPlaceCommandCoordinate();
                        toyRobot.Place(coord);
                        break;
                    case "AVOID":
                        Coordinate coordAvoid = parser.GetAvoidCommandCoordinate();
                        toyRobot.Avoid(coordAvoid);
                        break;
                    case "MOVE":
                        toyRobot.Move();
                        break;
                    case "LEFT":
                        toyRobot.TurnLeft();
                        break;
                    case "RIGHT":
                        toyRobot.TurnRight();
                        break;
                    case "REPORT":
                        Coordinate tempCoord = toyRobot.Report();
                        if (tempCoord != null)
                        {
                            Console.WriteLine("Output: " + tempCoord.X + "," + tempCoord.Y + "," + tempCoord.dir);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
