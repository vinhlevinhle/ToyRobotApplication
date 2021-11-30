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

        public List<Coordinate> obstructionList { get; set; }

        public bool gotValidPlacement;

        public BaseRobot(BoardDimension bd)
        {
            boardDimension = bd;
            currentPosition = null;
            gotValidPlacement = false;
        }

        public bool inObstructionList(Coordinate coord)
        {
            bool retVal = false;

            var item = obstructionList.FirstOrDefault<Coordinate>(i => i.X == coord.X && i.Y == coord.Y);
            if (item != null)
            {
                retVal = true;
            }

            return retVal;
        }

        public bool isValidPlacement(Coordinate coord)
        {
            bool retVal = false;

            if (coord != null)
            {
                bool retValInObsList = inObstructionList(coord);

                retVal = boardDimension.validCoordinate(coord.X, coord.Y);
                
                if (retVal && !retValInObsList)
                {
                    retVal = true;  
                }
                else
                {
                    retVal = false;
                }
            }

            return retVal;
        }

        public bool isNotAtCurrentPosition(Coordinate coord)
        {
            bool retVal = true;

            if (coord != null)
            {              
                if (coord.X == currentPosition.X && coord.Y == currentPosition.Y)
                {
                    retVal = false;
                }              
            }

            return retVal;
        }

        public bool isValidAvoidanceCoordinate(Coordinate coord)
        {
            bool retVal = true;

            if (coord != null)
            {
                if (!isNotAtCurrentPosition(coord) || !boardDimension.validCoordinate(coord.X, coord.Y))
                {
                    retVal = false;
                }              
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
            // Bug fix here 30/11/21 should be != to
            else if (!gotValidPlacement)
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

        //Iteration 2
        public abstract void Avoid(Coordinate avoidObst);

    }
}
