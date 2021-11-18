using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RobotClassLibrary;

namespace ToyRobotApplication
{
    class ToyRobotApp
    {
        private String[] argsInput;
        // Passing in the arguments from taken from the console main entry point when the executable was launched.
        public ToyRobotApp(String[] args)
        {
            argsInput = args;
        }

        public void StartUp()
        {
            try
            {
                DisplayUserInstruction disp = new DisplayUserInstruction();
                disp.ShowIntroduction();

                string robotCommand = "Vinh Le";

                BoardDimension bd = new BoardDimension();
                BaseRobot toyRobot = new ToyRobot(bd);
                InputParser inputParser = null;

                while (robotCommand != "q")
                {
                    robotCommand = Console.ReadLine();
                     
                    switch (robotCommand)
                    {                       
                        case "5":
                            inputParser = new UserCommandlineInput(toyRobot, argsInput);
                            inputParser.StartParing();
                            //We just finished with user manual input so let quit automatically in this outter loop!
                            robotCommand = "q";
                            break;
                        case "6":
                            // Not fully implemented yet !
                            inputParser = new UserTextfileInput(toyRobot, argsInput);
                            inputParser.StartParing();
                            robotCommand = "q";
                            break;                                              
                        default:
                            break;
                    }
                }

            }
            catch (NotImplementedException notyet)
            {
                Console.WriteLine("Not yet implemented this TEXT FILE input class !");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught at Starting up Robot application => " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
