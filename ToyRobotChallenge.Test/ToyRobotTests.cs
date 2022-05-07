using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ToyRobotChallenge.Test
{

    [TestFixture]
    public class ToyRobotTests
    {
        // Robot:
        // basic testing:
        // place -> report
        // place -> move -> report
        // place -> turn -> report
        // combinations thereof

        // bounds testing:
        // test trying to fall off each edge
        // try trying to fall off the same edge repeatedly
        // try placing off the table

        // advanced testing:
        // multiple places in command string
        // multiple reports in command string
        // multiple reports with actions in between
        // test exception handling for out of order commands


        [Test]
        [TestCaseSource("TestPlaceSource")]
        public void TestPlace(int boardWidth, int boardHeight, ICoordinates newPosition, Direction newDirection, ICoordinates expectedPosition, CompassDirection expectedDirection)
        {
            var robot = new ToyRobot(boardWidth, boardHeight);

            robot.Place(newPosition, newDirection);

            var actualPosition = robot.CurrentPosition;
            var actualDirection = robot.CurrentDirection;

            Assert.AreEqual(expectedPosition.HorizontalPosition, actualPosition.HorizontalPosition);
            Assert.AreEqual(expectedPosition.VerticalPosition, actualPosition.VerticalPosition);
            Assert.AreEqual(expectedDirection, actualDirection.CurrentDirection);
        }

        public IEnumerable<TestCaseData> TestPlaceSource()
        {
            //int boardWidth, int boardHeight, ICoordinates newPosition, CompassDirection newDirection, ICoordinates expectedPosition, CompassDirection expectedDirection
            yield return new TestCaseData(5, 5, new Coordinates(0, 0), new Direction(CompassDirection.North), new Coordinates(0, 0), CompassDirection.North).SetName("TestDirection North");
            yield return new TestCaseData(5, 5, new Coordinates(0, 0), new Direction(CompassDirection.East), new Coordinates(0, 0), CompassDirection.East).SetName("TestDirection North");
            yield return new TestCaseData(5, 5, new Coordinates(0, 0), new Direction(CompassDirection.South), new Coordinates(0, 0), CompassDirection.South).SetName("TestDirection North");
            yield return new TestCaseData(5, 5, new Coordinates(0, 0), new Direction(CompassDirection.West), new Coordinates(0, 0), CompassDirection.West).SetName("TestDirection North");

            yield return new TestCaseData(5, 5, new Coordinates(1, 0), new Direction(CompassDirection.North), new Coordinates(1, 0), CompassDirection.North).SetName("TestPosition X");
            yield return new TestCaseData(5, 5, new Coordinates(0, 1), new Direction(CompassDirection.North), new Coordinates(0, 1), CompassDirection.North).SetName("TestPosition Y");
            yield return new TestCaseData(5, 5, new Coordinates(1, 1), new Direction(CompassDirection.North), new Coordinates(1, 1), CompassDirection.North).SetName("TestPosition XY");
            yield return new TestCaseData(5, 5, new Coordinates(2, 3), new Direction(CompassDirection.North), new Coordinates(2, 3), CompassDirection.North).SetName("TestPosition XY 2");
            yield return new TestCaseData(5, 5, new Coordinates(4, 4), new Direction(CompassDirection.North), new Coordinates(4, 4), CompassDirection.North).SetName("TestPosition Max Bounds");
        }

        [Test]
        [TestCaseSource("TestOutOfBoundsPlaceSource")]
        public void TestInvalidPlace(int boardWidth, int boardHeight, ICoordinates newPosition, IDirection newDirection)
        {
            var robot = new ToyRobot(boardWidth, boardHeight);

            var thrownException = Assert.Throws<IndexOutOfRangeException>(() => robot.Place(newPosition, newDirection));
            Assert.AreEqual($"Requested position ({newPosition.HorizontalPosition},{newPosition.VerticalPosition}) is not in bounds of the board of size ({boardWidth},{boardHeight})",
                thrownException.Message);
        }

        public IEnumerable<TestCaseData> TestOutOfBoundsPlaceSource()
        {
            //int boardWidth, int boardHeight, ICoordinates newPosition, CompassDirection newDirection
            yield return new TestCaseData(5, 5, new Coordinates(-1, 0), new Direction(CompassDirection.North));
            yield return new TestCaseData(5, 5, new Coordinates(0, -1), new Direction(CompassDirection.North));
            yield return new TestCaseData(5, 5, new Coordinates(-1, -1), new Direction(CompassDirection.North));
            yield return new TestCaseData(5, 5, new Coordinates(5, 0), new Direction(CompassDirection.North));
            yield return new TestCaseData(5, 5, new Coordinates(0, 5), new Direction(CompassDirection.North));
            yield return new TestCaseData(5, 5, new Coordinates(5, 5), new Direction(CompassDirection.North));
        }

        [Test]
        public void TestNullPositionPlace()
        {
            var robot = new ToyRobot(5, 5);

            var thrownException = Assert.Throws<ArgumentNullException>(() => robot.Place(null, new Direction(CompassDirection.North)));
        }

        [Test]
        [TestCaseSource("TestReportSource")]
        public void TestReport(ICoordinates newPosition, IDirection newDirection, string expectedOutput)
        {
            var robot = new ToyRobot(5, 5);
            robot.Place(newPosition, newDirection);

            var actualReportString = robot.Report();

            Assert.AreEqual(expectedOutput, actualReportString);
        }

        public IEnumerable<TestCaseData> TestReportSource()
        {
            //ICoordinates newPosition, CompassDirection newDirection, string expectedOutput
            yield return new TestCaseData(new Coordinates(0, 0), CompassDirection.North, "Output: 0, 0, NORTH");
            yield return new TestCaseData(new Coordinates(0, 0), CompassDirection.East, "Output: 0, 0, EAST");
            yield return new TestCaseData(new Coordinates(0, 0), CompassDirection.South, "Output: 0, 0, SOUTH");
            yield return new TestCaseData(new Coordinates(0, 0), CompassDirection.West, "Output: 0, 0, WEST");

            yield return new TestCaseData(new Coordinates(1, 0), CompassDirection.West, "Output: 1, 0, WEST");
            yield return new TestCaseData(new Coordinates(0, 1), CompassDirection.West, "Output: 0, 1, WEST");
            yield return new TestCaseData(new Coordinates(3, 3), CompassDirection.West, "Output: 3, 3, WEST");
        }

        public void TestTurnLeft()
        {
            var directionMoq = new Mock<IDirection>();
            directionMoq.Setup(x => x.TurnLeft()).Verifiable();
            var robot = new ToyRobot(5, 5);
            robot.Place(new Coordinates(0,0), directionMoq.Object);


        }
    }
}