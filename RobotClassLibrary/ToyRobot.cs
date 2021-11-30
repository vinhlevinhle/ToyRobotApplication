using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClassLibrary
{
    public class ToyRobot : BaseRobot
    {
        public ToyRobot(BoardDimension bd)
            : base(bd)
        {
            Debug.Assert(bd != null);

            boardDimension = bd;
            currentPosition = null;
            gotValidPlacement = false;

            obstructionList = new List<Coordinate>();
        }

        /// <summary>
        /// Move the robot move 1 step forward
        /// </summary>
        /// <returns>a result object</returns>
        public override void Move()
        {
            if (gotValidPlacement)
            {
                Coordinate tempNewPos = new Coordinate(currentPosition);
                switch (currentPosition.dir)
                {
                    case Direction.EAST:
                        tempNewPos.X += 1;
                        break;
                    case Direction.WEST:
                        tempNewPos.X -= 1;
                        break;

                    case Direction.NORTH:
                        tempNewPos.Y += 1;
                        break;
                    case Direction.SOUTH:
                        tempNewPos.Y -= 1;
                        break;
                    default:
                        break;
                }
                if (isValidPlacement(tempNewPos))
                {
                    Place(tempNewPos);
                }
            }
        }

        /// <summary>
        /// Turn the robot turns 90 degrees left
        /// </summary>
        /// <returns>a result object</returns>
        public override void TurnLeft()
        {
            if (gotValidPlacement)
            {
                switch (currentPosition.dir)
                {
                    case Direction.NORTH:
                        currentPosition.dir = Direction.WEST;
                        break;
                    case Direction.WEST:
                        currentPosition.dir = Direction.SOUTH;
                        break;
                    case Direction.SOUTH:
                        currentPosition.dir = Direction.EAST;
                        break;
                    case Direction.EAST:
                        currentPosition.dir = Direction.NORTH;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Turn the robot turns 90 degrees right
        /// </summary>
        /// <returns>a result object</returns>
        public override void TurnRight()
        {
            if (gotValidPlacement)
            {
                switch (currentPosition.dir)
                {
                    case Direction.NORTH:
                        currentPosition.dir = Direction.EAST;
                        break;
                    case Direction.EAST:
                        currentPosition.dir = Direction.SOUTH;
                        break;
                    case Direction.SOUTH:
                        currentPosition.dir = Direction.WEST;
                        break;
                    case Direction.WEST:
                        currentPosition.dir = Direction.NORTH;
                        break;
                    default:
                        break;
                }
            }
        }

        public override Coordinate Report()
        {
            if (gotValidPlacement && currentPosition != null)
            {
                //Console.WriteLine(currentPosition.X + "," + currentPosition.Y + " " + currentPosition.dir);
                return currentPosition;
            }
            else
            {
                // invalid coordinate , or null!
                // May be throw an exception here
                return null;
            }
        }

        public override void Avoid(Coordinate avoidObst)
        {
            // add to list of avoidances
            if (isValidPlacement(avoidObst))
            {
                obstructionList.Add(avoidObst);
            }
        }

    }
}
