using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using RobotClassLibrary;

namespace ToyRobotApplication
{
    public class ParseCommand
    {
        public uint X;
        public uint Y;
        string foundCommand;
        Direction dir;

        public ParseCommand()
        {
            foundCommand = "Nothing";
            dir = Direction.NORTH; // Random assignment
            
        }

        public void StartParsing(string command)
        {
            //reset each time
            foundCommand = "Nothing";

            //This pattern forces one space in between tokens
            //string pattern = @"^(MOVE|LEFT|RIGHT|REPORT){1}\s*$";
            //This pattern allows more than one spaces in between tokens
            string pattern = @"\s*(MOVE|LEFT|RIGHT|REPORT){1}\s*$";
            MatchCollection matches = Regex.Matches(command, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                //foundCommand = match.Value.ToUpper();
                foundCommand = match.Groups[1].Value.ToUpper();
                //Console.WriteLine("Found: " + foundCommand);
                break;
            }
            //else continue to look for PLACE x,y direction
            //This pattern forces one space in between tokens
            //pattern = @"^(PLACE){1}\s(\d+),(\d+),\s(NORTH|SOUTH|EAST|WEST){1}\s*$";
            //This pattern allows more than one spaces in between tokens
            pattern = @"\s*(PLACE){1}\s*(\d+)\s*,\s*(\d+)\s*,\s*(NORTH|SOUTH|EAST|WEST){1}\s*$";
            matches = Regex.Matches(command, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                foundCommand = match.Groups[1].Value.ToUpper();
                //Console.WriteLine("Found: " + foundCommand);
                //Console.WriteLine("Found: " + match.Groups[1].Value);
                X = (uint)Int64.Parse(match.Groups[2].Value);
                Y = (uint)Int64.Parse(match.Groups[3].Value);
                //Console.WriteLine("Found X = {0},Y = {1}",X,Y);
                switch (match.Groups[4].Value.ToUpper())
                {
                    case "NORTH":
                        dir = Direction.NORTH;
                        break;
                    case "SOUTH":
                        dir = Direction.SOUTH;
                        break;
                    case "EAST":
                        dir = Direction.EAST;
                        break;
                    case "WEST":
                        dir = Direction.WEST;
                        break;

                    default:
                        break;
                }
            }

            //pattern = @"^(AVOID){1}\s(\d+),(\d+)\s*$";
            //This pattern allows more than one spaces in between tokens
            pattern = @"\s*(AVOID){1}\s*(\d+)\s*,\s*(\d+)\s*$";
            matches = Regex.Matches(command, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                foundCommand = match.Groups[1].Value.ToUpper();
                //Console.WriteLine("Found: " + foundCommand);
                //Console.WriteLine("Found: " + match.Groups[1].Value);
                X = (uint)Int64.Parse(match.Groups[2].Value);
                Y = (uint)Int64.Parse(match.Groups[3].Value);
               
            }
        }

        public string GetCommand()
        {
            return foundCommand;
        }

        public Coordinate GetPlaceCommandCoordinate()
        {
            Coordinate temp = null;

            if (foundCommand == "PLACE")
            {
                temp = new Coordinate(X, Y, dir);
            }
            return temp;
        }

        public Coordinate GetAvoidCommandCoordinate()
        {
            Coordinate temp = null;

            if (foundCommand == "AVOID")
            {
                temp = new Coordinate(X, Y, dir);
            }
            return temp;
        }

    }
}
