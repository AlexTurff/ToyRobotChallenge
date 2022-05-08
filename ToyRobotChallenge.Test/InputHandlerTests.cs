using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ToyRobotChallenge.Test
{
    [TestFixture]
    public class InputHandlerTests
    {
        [Test]
        [TestCaseSource(nameof(TestReportSource))]
        public void TestReport(ICoordinate position, CompassDirection direction, string expectedOutput)
        {
            var robotMock = new Mock<IRobot>();
            robotMock.SetupGet(x => x.CurrentDirection).Returns(direction);
            robotMock.SetupGet(x => x.CurrentPosition).Returns(position);
            var robot = robotMock.Object;
            var actualReportOutput = "";
            var inputHandler = new RobotInputHandler(robot, (s) => actualReportOutput = s);

            inputHandler.ProcessInputLine("REPORT");

            Assert.AreEqual(expectedOutput, actualReportOutput,"Output not in expected format. Unexpected empty output most likely means report command as not been interpreted.");
        }

        public static IEnumerable<TestCaseData> TestReportSource()
        {
            //ICoordinates newPosition, CompassDirection newDirection, string expectedOutput
            yield return new TestCaseData(new Coordinate(0, 0), CompassDirection.North, "Output: 0,0,NORTH");
            yield return new TestCaseData(new Coordinate(0, 0), CompassDirection.East, "Output: 0,0,EAST");
            yield return new TestCaseData(new Coordinate(0, 0), CompassDirection.South, "Output: 0,0,SOUTH");
            yield return new TestCaseData(new Coordinate(0, 0), CompassDirection.West, "Output: 0,0,WEST");

            yield return new TestCaseData(new Coordinate(1, 0), CompassDirection.West, "Output: 1,0,WEST");
            yield return new TestCaseData(new Coordinate(0, 1), CompassDirection.West, "Output: 0,1,WEST");
            yield return new TestCaseData(new Coordinate(3, 3), CompassDirection.West, "Output: 3,3,WEST");
        }

        [Test]
        [TestCase("PLACE 1,2,EAST", true, 1,2,CompassDirection.East)]
        [TestCase("PLACE 2,1,WEST", true, 2,1,CompassDirection.West)]
        [TestCase("PLACED 2,1,WEST",false, null, null,null)]
        [TestCase("placed 2,1,WEST", false, null, null,null)]
        [TestCase("Placed 2,1,WEST", false, null, null,null)]
        [TestCase("PLACED 2,1,west", false, null, null,null)]
        [TestCase("PLACED 2 1 WEST", false, null, null,null)]
        [TestCase("gfdgret", false, null, null,null)]
        public void TestProcessInputLinePlace(string inputLine, bool expectedPlaceCalled, int? expectedX, int? expectedY, CompassDirection? expectedDirection)
        {
            ICoordinate actualCoordinate = null;
            IDirection actualDirection = null;

            var robotMock = new Mock<IRobot>();
            robotMock.Setup(x => x.Place(It.IsAny<ICoordinate>(),It.IsAny<IDirection>())).Callback<ICoordinate,IDirection>((c,d) => 
                { 
                    actualCoordinate = c;
                    actualDirection = d;
                }).Verifiable();
            var robot = robotMock.Object;
            var inputHandler = new RobotInputHandler(robot, (s) => { });

            inputHandler.ProcessInputLine(inputLine);

            if (expectedPlaceCalled)
            {
                Assert.NotNull(actualCoordinate);
                Assert.AreEqual(expectedX, actualCoordinate.HorizontalPosition);
                Assert.AreEqual(expectedY, actualCoordinate.VerticalPosition);
                Assert.AreEqual(expectedDirection, actualDirection.CurrentDirection);
                Assert.DoesNotThrow(() => robotMock.Verify());
            }

            Assert.DoesNotThrow(() => robotMock.VerifyNoOtherCalls());
        }

        [Test]
        [TestCase("MOVE", true)]
        [TestCase("MOVE ", false)]
        [TestCase(" MOVE", false)]
        [TestCase("MOVED", false)]
        [TestCase("move", false)]
        [TestCase("Move", false)]
        [TestCase("gdfgfhghfgh", false)]
        [TestCase("", false)]
        public void TestProcessInputLineMove(string inputLine, bool expectedMoveCalled)
        {
            var robotMock = new Mock<IRobot>();
            robotMock.Setup(x => x.Move()).Verifiable();
            var robot = robotMock.Object;
            var inputHandler = new RobotInputHandler(robot, (s) => { });

            inputHandler.ProcessInputLine(inputLine);

            if (expectedMoveCalled)
            {
                Assert.DoesNotThrow(() => robotMock.Verify());                
            }

            Assert.DoesNotThrow(() => robotMock.VerifyNoOtherCalls());
        }

        [Test]
        [TestCase("LEFT", true)]
        [TestCase("LEFT ", false)]
        [TestCase(" LEFT", false)]
        [TestCase("LEFTY", false)]
        [TestCase("left", false)]
        [TestCase("Left", false)]
        [TestCase("dfgdfgreg", false)]
        [TestCase("", false)]
        public void TestProcessInputLineLeft(string inputLine, bool expectedLeftCalled)
        {
            var robotMock = new Mock<IRobot>();
            robotMock.Setup(x => x.TurnLeft()).Verifiable();
            var robot = robotMock.Object;
            var inputHandler = new RobotInputHandler(robot, (s) => { });

            inputHandler.ProcessInputLine(inputLine);

            if (expectedLeftCalled)
            {
                Assert.DoesNotThrow(() => robotMock.Verify());
            }

            Assert.DoesNotThrow(() => robotMock.VerifyNoOtherCalls());
        }

        [Test]
        [TestCase("RIGHT", true)]
        [TestCase("RIGHT ", false)]
        [TestCase(" RIGHT", false)]
        [TestCase("RIGHTY", false)]
        [TestCase("right", false)]
        [TestCase("Right", false)]
        [TestCase("dfgdfgreg", false)]
        [TestCase("", false)]
        public void TestProcessInputLineRight(string inputLine, bool expectedRightCalled)
        {
            var robotMock = new Mock<IRobot>();
            robotMock.Setup(x => x.TurnRight()).Verifiable();
            var robot = robotMock.Object;
            var inputHandler = new RobotInputHandler(robot, (s) => { });

            inputHandler.ProcessInputLine(inputLine);

            if (expectedRightCalled)
            {
                Assert.DoesNotThrow(() => robotMock.Verify());
            }

            Assert.DoesNotThrow(() => robotMock.VerifyNoOtherCalls());
        }


    }
}