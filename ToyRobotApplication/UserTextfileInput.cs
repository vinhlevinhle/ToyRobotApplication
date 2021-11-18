using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RobotClassLibrary;

namespace ToyRobotApplication
{
    class UserTextfileInput : InputParser
    {
        public UserTextfileInput(BaseRobot toyRobot, String[] args)
            : base(toyRobot, args)
        {
        }

        public override void StartParing()
        {
            throw new NotImplementedException();
        }
    }
}
