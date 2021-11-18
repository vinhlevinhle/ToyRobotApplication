using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClassLibrary
{
    public abstract class BaseRobot
    {
        public BoardDimension boardDimension { get; set; }
        public Coordinate currentPosition { get; set; }

        public bool gotValidPlacement;

        public BaseRobot(BoardDimension bd)
        {
            boardDimension = bd;
            currentPosition = null;
            gotValidPlacement = false;
        }

        public bool isValidPlacement(Coordinate coord)
        {
            bool retVal = false;

            if (coord != null)
            {
                retVal = boardDimension.validCoordinate(coord.X, coord.Y);
            }

            return retVal;
        }

        public void Place(Coordinate coord)
        {
            if (isValidPlacement(coord))
            {
                gotValidPlacement = true;
                //currentPosition = new Coordinate(coord.X, coord.Y, coord.dir);
                currentPosition = new Coordinate(coord);
            }
            else if (gotValidPlacement)
            {
                currentPosition = null;
                gotValidPlacement = false;
            }
        }

        // abstract methods to override        
        public abstract void Move();
        public abstract void TurnLeft();
        public abstract void TurnRight();

        public abstract Coordinate Report();

    }
}
