using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClassLibrary
{
    public class Coordinate
    {
        public uint X;
        public uint Y;
        public Direction dir;

        public Coordinate(Coordinate c)
        {
            X = c.X;
            Y = c.Y;
            dir = c.dir;
        }
        public Coordinate(uint x, uint y, Direction d)
        {
            X = x;
            Y = y;
            dir = d;
        }
    }
}
