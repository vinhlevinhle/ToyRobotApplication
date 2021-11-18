using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClassLibrary
{
   
        public enum Direction
        {
            NORTH,
            SOUTH,
            EAST,
            WEST
        }

        public class BoardDimension
        {
            public uint width { get;  }
            public uint length { get; }

            public BoardDimension()
            {
                // default
                length = 5;
                width = 5;
            }
            public BoardDimension(uint l, uint w)
            {
                length = l;
                width = w;
            }

            public bool validCoordinate(uint x, uint y)
            {
                bool boolVal = false;

                if ((x >= 0 && x <= width - 1) && (y >= 0 && y <= length - 1))
                {
                    boolVal = true;
                }

                return boolVal;
            }
        }
 
}
