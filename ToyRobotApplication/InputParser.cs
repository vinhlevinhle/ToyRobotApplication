using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RobotClassLibrary;

namespace ToyRobotApplication
{
    public abstract class InputParser
    {
        public BaseRobot toyRobot;
        public String[] parseArgs;
        public InputParser(BaseRobot bRobot, String[] args)
        {
            toyRobot = bRobot;
            parseArgs = args;
        }

        public abstract void StartParing(); 
    }
}
