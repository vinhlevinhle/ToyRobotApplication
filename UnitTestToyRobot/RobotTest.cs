using Microsoft.VisualStudio.TestTools.UnitTesting;

using RobotClassLibrary;

namespace UnnitTestToyRobot
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void TestBoardAndRobotValidity()
        {
            // Test the default contrustor and set up default height = 5 and width = 5
            BoardDimension board = new BoardDimension();
            Assert.IsNotNull(board);

            uint expectedWidth = 5;
            uint expectedLength = 5;
            uint actualWidth = board.width;
            uint actualLength = board.length;
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedLength, actualLength);
            // Test for fail condition
            Assert.AreNotEqual(expectedLength, 6);

            //A valid board dimension should not crash ToyRobot
            BaseRobot toyRobot = new ToyRobot(board);
            Assert.IsNotNull(toyRobot);
        }

        [TestMethod]
        public void TestDifferentSizeBoardAndRobotValidity()
        {
            // Test the 10x10 board with none default contrustor 
            BoardDimension board = new BoardDimension(10,10);
            Assert.IsNotNull(board);

            uint expectedWidth = 10;
            uint expectedLength = 10;
            uint actualWidth = board.width;
            uint actualLength = board.length;
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedLength, actualLength);
            // Test for fail condition
            Assert.AreNotEqual(expectedLength, 16);

            //A valid board dimension should not crash ToyRobot
            BaseRobot toyRobot = new ToyRobot(board);
            Assert.IsNotNull(toyRobot);
        }

        [TestMethod]
        public void Test8x8BoardAndRobotValidity()
        {
            // Test the 8x8 board with none default contrustor 
            BoardDimension board = new BoardDimension(8, 8);
            Assert.IsNotNull(board);

            uint expectedWidth = 8;
            uint expectedLength = 8;
            uint actualWidth = board.width;
            uint actualLength = board.length;
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedLength, actualLength);
            // Test for fail condition
            Assert.AreNotEqual(expectedLength, 16);

            //A valid board dimension should not crash ToyRobot
            BaseRobot toyRobot = new ToyRobot(board);
            Assert.IsNotNull(toyRobot);
        }

        [TestMethod]
        public void TestInvalidPlacement()
        {
            // Default c'tor 5,5 board
            BoardDimension board = new BoardDimension();
            BaseRobot toyRobot = new ToyRobot(board);

            //Test place command at 10,10, NORTH (Case insensitive)
            Coordinate invalidCoord = new Coordinate((uint)10, (uint)10, Direction.NORTH);
            Assert.IsNotNull(invalidCoord);

            toyRobot.Place(invalidCoord);            

            // Get the value return by Robot report api , expect it to be null because we gave it an invalid coordinate
            Coordinate actualCoord = toyRobot.Report();
            Assert.IsNull(actualCoord);

            Assert.AreEqual(false, CompareCoordinates(invalidCoord, actualCoord));
        }

        public static bool CompareCoordinates(Coordinate expectedCoord, Coordinate actualCoord)
        {
            bool retValue = false;

            if (expectedCoord == null || actualCoord == null)
            {
                retValue = false ;
            }
            else if (expectedCoord == null && actualCoord == null)
            {
                retValue = true;
            }
            else if (
                   expectedCoord.X == actualCoord.X &&
                   expectedCoord.Y == actualCoord.Y &&
                   expectedCoord.dir == actualCoord.dir )
                   {
                        retValue = true;
                   }

            return retValue;
        }

        [TestMethod]
        public void TestRobotPlacement()
        {
            // Default c'tor 5,5 board
            BoardDimension board = new BoardDimension();
            BaseRobot toyRobot = new ToyRobot(board);

            //Test place command at 0,0, NORTH (Case insensitive)
            Coordinate at00North = new Coordinate(0, 0, Direction.NORTH);
            Assert.IsNotNull(at00North);

            toyRobot.Place(at00North);
            Assert.IsTrue(toyRobot.isValidPlacement(at00North));

            // Compare with the value return by Robot report api
            Coordinate actualCoord = toyRobot.Report();
            Assert.AreEqual(true, CompareCoordinates(at00North, actualCoord));
        }

        [TestMethod]
        public void TestRobotFullTurnClockwise()
        {
            // So let start at 0,0, North facing then move 4 times with each move follows by a right turn command
            // So we expect the ToyRobot to return to its original starting coordinate or position.

            // Default c'tor 5,5 board
            BoardDimension board = new BoardDimension();
            BaseRobot toyRobot = new ToyRobot(board);

            //Test place command at 0,0, NORTH (Case insensitive)
            Coordinate at00North = new Coordinate(0, 0, Direction.NORTH);
            toyRobot.Place(at00North);
            toyRobot.Move();
            Coordinate expectedCoord = new Coordinate(0, 1, Direction.NORTH);
            Assert.AreEqual(true, CompareCoordinates(expectedCoord, toyRobot.Report()));

            toyRobot.TurnRight();
            toyRobot.Move();
            expectedCoord.X = 1;
            expectedCoord.Y = 1;
            expectedCoord.dir = Direction.EAST;
            Assert.AreEqual(true, CompareCoordinates(expectedCoord, toyRobot.Report()));

            toyRobot.TurnRight();
            toyRobot.Move();
            expectedCoord.X = 1;
            expectedCoord.Y = 0;
            expectedCoord.dir = Direction.SOUTH;
            Assert.AreEqual(true, CompareCoordinates(expectedCoord, toyRobot.Report()));

            toyRobot.TurnRight();
            toyRobot.Move();
            toyRobot.TurnRight();
            expectedCoord.X = 0;
            expectedCoord.Y = 0;
            expectedCoord.dir = Direction.NORTH;
            Assert.AreEqual(true, CompareCoordinates(expectedCoord, toyRobot.Report()));

        }

        [TestMethod]
        public void TestRobotFullTurnAntiClockwise()
        {
            // So let start at 0,0, EAST facing then move 4 times with each move follows by a left turn command
            // So we expect the ToyRobot to return to its original starting coordinate or position.

            // Default c'tor 5,5 board
            BoardDimension board = new BoardDimension();
            BaseRobot toyRobot = new ToyRobot(board);

            //Test place command at 0,0, NORTH (Case insensitive)
            Coordinate at00East = new Coordinate(0, 0, Direction.EAST);
            toyRobot.Place(at00East);
            toyRobot.Move();
            Coordinate expectedCoord = new Coordinate(1, 0, Direction.EAST);
            Assert.AreEqual(true, CompareCoordinates(expectedCoord, toyRobot.Report()));

            toyRobot.TurnLeft();
            toyRobot.Move();
            expectedCoord.X = 1;
            expectedCoord.Y = 1;
            expectedCoord.dir = Direction.NORTH;
            Assert.AreEqual(true, CompareCoordinates(expectedCoord, toyRobot.Report()));

            toyRobot.TurnLeft();
            toyRobot.Move();
            expectedCoord.X = 0;
            expectedCoord.Y = 1;
            expectedCoord.dir = Direction.WEST;
            Assert.AreEqual(true, CompareCoordinates(expectedCoord, toyRobot.Report()));

            toyRobot.TurnLeft();
            toyRobot.Move();
            toyRobot.TurnLeft();
            expectedCoord.X = 0;
            expectedCoord.Y = 0;
            expectedCoord.dir = Direction.EAST;
            Assert.AreEqual(true, CompareCoordinates(expectedCoord, toyRobot.Report()));

        }

        [TestMethod]
        public void TestRobotToMakeInvalidMoveOffWestSideOfBoard()
        {
            // So let start at 0,0,West. We are trying to make the ToyRobot go off the West side of the board
            // which is the left side if a person is facing directly infront of the board
            // Default c'tor 5,5 board
            BoardDimension board = new BoardDimension();
            BaseRobot toyRobot = new ToyRobot(board);

            //Test place command at 0,0, NORTH (Case insensitive)
            Coordinate at00West = new Coordinate(0, 0, Direction.WEST);
            toyRobot.Place(at00West);
            Assert.IsTrue(toyRobot.isValidPlacement(toyRobot.Report()));
            toyRobot.Move();
            // This is still true because the move was off the board, so the Robot refused to move
            Assert.IsTrue(toyRobot.isValidPlacement(toyRobot.Report()));
            // We havent moved at all due to invalid command
            Assert.AreEqual(true, CompareCoordinates(at00West, toyRobot.Report()));
        }

        [TestMethod]
        public void TestRobotToMakeInvalidMoveOffEastSideOfBoard()
        {
            // So let start at 5,5,East. We are trying to make the ToyRobot go off the East side of the board
            // which is the right side if a person is facing directly infront of the board

            BoardDimension board = new BoardDimension();
            BaseRobot toyRobot = new ToyRobot(board);

            //Test place command at (5-1),(5-1), East (Case insensitive)
            Coordinate at44East = new Coordinate((5 - 1), (5 - 1), Direction.EAST);
            toyRobot.Place(at44East);
            Assert.IsTrue(toyRobot.isValidPlacement(toyRobot.Report()));
            toyRobot.Move();
            // This is still true because the move was off the board, so the Robot refused to move
            Assert.IsTrue(toyRobot.isValidPlacement(toyRobot.Report()));
            // We havent moved at all due to invalid command
            Assert.AreEqual(true, CompareCoordinates(at44East, toyRobot.Report()));
        }

        [TestMethod]
        public void TestRobotMoveNorthFromEdgeToEdgeThenOffBoard()
        {
            // So let start at 0,0,NORTH. We are trying to make the ToyRobot continuously move north
            // until it encounters the edge of the board and no further advance

            BoardDimension board = new BoardDimension();
            BaseRobot toyRobot = new ToyRobot(board);

            //Test place command at 0,0,North (Case insensitive)
            Coordinate tempCoord = new Coordinate(0, 0, Direction.NORTH);
            toyRobot.Place(tempCoord);
            Assert.IsTrue(toyRobot.isValidPlacement(toyRobot.Report()));

            uint overBoard = 1;
            uint x = 0;
            for (uint y = 0; y < board.length + overBoard; y++)
            {
                toyRobot.Move();
                tempCoord = new Coordinate(x, y, Direction.NORTH);               
            }
            //THis is to prove that the loop went passed the edge of the North board
            Assert.AreEqual((uint)5, tempCoord.Y);

            // The last Coordinate after the for loop is 0,5,NORTH , but the maximun valid coordinate 0,4,NORTH
            Assert.AreEqual(false, CompareCoordinates(tempCoord, toyRobot.Report()));
            

            // Max moves in North direction
            tempCoord = new Coordinate(0, board.length - 1, Direction.NORTH);
            Assert.AreEqual(true, CompareCoordinates(tempCoord, toyRobot.Report()));
        }

        [TestMethod]
        public void TestRobotMoveEastFromEdgeToEdgeThenOffBoard()
        {
            // So let start at 0,0,NORTH. We are trying to make the ToyRobot continuously move north
            // until it encounters the edge of the board and no further advance

            BoardDimension board = new BoardDimension();
            BaseRobot toyRobot = new ToyRobot(board);

            //Test place command at 0,0,East (Case insensitive)
            Coordinate tempCoord = new Coordinate(0, 0, Direction.EAST);
            toyRobot.Place(tempCoord);
            Assert.IsTrue(toyRobot.isValidPlacement(toyRobot.Report()));

            int overBoard = 1;
            uint y = 0;
            for (uint x = 0; x < board.width + overBoard; x++)
            {
                toyRobot.Move();
                tempCoord = new Coordinate(x, y, Direction.EAST);
            }
            //THis is to prove that the loop went passed the edge of the East board
            Assert.AreEqual((uint)5, tempCoord.X);
            // The last Coordinate after the for loop is 0,5,EAST , but the maximun valid coordinate 0,4,EAST
            Assert.AreEqual(false, CompareCoordinates(tempCoord, toyRobot.Report()));

            // Max moves in North direction
            tempCoord = new Coordinate(board.width - 1, y, Direction.EAST);
            Assert.AreEqual(true, CompareCoordinates(tempCoord, toyRobot.Report()));
        }

    }
}
