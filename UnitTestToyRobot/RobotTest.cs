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
            // Test the default contrustor now failing and set up default height = 5 and width = 5
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

            BaseRobot toyRobot = new ToyRobot(board);
            Assert.IsNotNull(toyRobot);

        }

        [TestMethod]
        public void TestRobotValidity()
        {

        }
    }
}
