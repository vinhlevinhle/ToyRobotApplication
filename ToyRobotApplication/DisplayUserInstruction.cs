using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotApplication
{
    class DisplayUserInstruction
    {
        public DisplayUserInstruction()
        {

        }

        public void ShowIntroduction()
        {
            Console.WriteLine("Vinh Le version 0.7 - ToyRobot Challenge!");
            Console.WriteLine(" ");
            Console.WriteLine("1- Commands are NOT case sensitive. They must contain EXACT format");
            Console.WriteLine("2- Basic Robot instruction with format => [PLACE X,Y, Direction] , ignore the square brackets marking ");
            Console.WriteLine("3- Multiple spaces are allowed in between the tokens eg [   PLACE X  ,Y   ,Direction]");
            Console.WriteLine("4- Please refer to TOYROBOT challenge for further detailed instructions");
            Console.WriteLine("5- Enter (5) for direct commandline instruction via console to control the robot. ");
            Console.WriteLine("6- Enter (6) for a single text file input, eg: InputTest.txt ");
            Console.WriteLine("7- To quit at anytime, please enter q ");
        }
    }
}
