using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ToyRobotChallenge.Test
{

    [TestFixture]
    public class ToyRobotTests
    {
        [Test]
        [TestCaseSource(nameof(TestPlaceSource))]        
        public void TestPlace(ICoordinate newPosition, Direction newDirection, ICoordinate expectedPosition, CompassDirection expectedDirection)
        {
            var robot = new ToyRobot();

            robot.Place(newPosition, newDirection);

            var actualPosition = robot.CurrentPosition;
            var actualDirection = robot.CurrentDirection;

            Assert.AreEqual(expectedPosition.HorizontalPosition, actualPosition.HorizontalPosition);
            Assert.AreEqual(expectedPosition.VerticalPosition, actualPosition.VerticalPosition);
            Assert.AreEqual(expectedDirection, actualDirection);
        }

        public static IEnumerable<TestCaseData> TestPlaceSource()
        {
            //ICoordinates newPosition, CompassDirection newDirection, ICoordinates expectedPosition, CompassDirection expectedDirection
            yield return new TestCaseData(new Coordinate(0, 0), new Direction(CompassDirection.North), new Coordinate(0, 0), CompassDirection.North).SetName("TestDirection North");
            yield return new TestCaseData(new Coordinate(0, 0), new Direction(CompassDirection.East), new Coordinate(0, 0), CompassDirection.East).SetName("TestDirection North");
            yield return new TestCaseData(new Coordinate(0, 0), new Direction(CompassDirection.South), new Coordinate(0, 0), CompassDirection.South).SetName("TestDirection North");
            yield return new TestCaseData(new Coordinate(0, 0), new Direction(CompassDirection.West), new Coordinate(0, 0), CompassDirection.West).SetName("TestDirection North");

            yield return new TestCaseData(new Coordinate(1, 0), new Direction(CompassDirection.North), new Coordinate(1, 0), CompassDirection.North).SetName("TestPosition X");
            yield return new TestCaseData(new Coordinate(0, 1), new Direction(CompassDirection.North), new Coordinate(0, 1), CompassDirection.North).SetName("TestPosition Y");
            yield return new TestCaseData(new Coordinate(1, 1), new Direction(CompassDirection.North), new Coordinate(1, 1), CompassDirection.North).SetName("TestPosition XY");
            yield return new TestCaseData(new Coordinate(2, 3), new Direction(CompassDirection.North), new Coordinate(2, 3), CompassDirection.North).SetName("TestPosition XY 2");
            yield return new TestCaseData(new Coordinate(4, 4), new Direction(CompassDirection.North), new Coordinate(4, 4), CompassDirection.North).SetName("TestPosition Max Bounds");
        }

        [Test]
        [TestCaseSource(nameof(TestOutOfBoundsPlaceSource))]
        public void TestInvalidPlace(ICoordinate newPosition, IDirection newDirection)
        {
            var robot = new ToyRobot();

            var thrownException = Assert.Throws<IndexOutOfRangeException>(() => robot.Place(newPosition, newDirection));
            Assert.AreEqual($"Requested position ({newPosition.HorizontalPosition},{newPosition.VerticalPosition}) is not in bounds of the board of size (5,5)",
                thrownException.Message);
        }

        public static IEnumerable<TestCaseData> TestOutOfBoundsPlaceSource()
        {
            //ICoordinates newPosition, CompassDirection newDirection
            yield return new TestCaseData(new Coordinate(-1, 0), new Direction(CompassDirection.North));
            yield return new TestCaseData(new Coordinate(0, -1), new Direction(CompassDirection.North));
            yield return new TestCaseData(new Coordinate(-1, -1), new Direction(CompassDirection.North));
            yield return new TestCaseData(new Coordinate(5, 0), new Direction(CompassDirection.North));
            yield return new TestCaseData(new Coordinate(0, 5), new Direction(CompassDirection.North));
            yield return new TestCaseData(new Coordinate(5, 5), new Direction(CompassDirection.North));
        }

        [Test]
        public void TestNullPositionPlace()
        {
            var robot = new ToyRobot();

            var thrownException = Assert.Throws<ArgumentNullException>(() => robot.Place(null, new Direction(CompassDirection.North)));
        }

        public void TestTurnLeft()
        {
            var directionMoq = new Mock<IDirection>();
            directionMoq.Setup(x => x.TurnLeft()).Verifiable();
            var robot = new ToyRobot();
            robot.Place(new Coordinate(0,0), directionMoq.Object);

            robot.TurnLeft();

            Assert.DoesNotThrow(() => directionMoq.Verify());
        }

        public void TestTurnRight()
        {
            var directionMoq = new Mock<IDirection>();
            directionMoq.Setup(x => x.TurnRight()).Verifiable();
            var robot = new ToyRobot();
            robot.Place(new Coordinate(0, 0), directionMoq.Object);

            robot.TurnRight();

            Assert.DoesNotThrow(() => directionMoq.Verify());
        }

        [Test]
        [TestCaseSource(nameof(TestMoveSource))]
        public void TestMove(ICoordinate initialPosition, IDirection initialDirection, ICoordinate expectedPosition)
        {
            var robot = new ToyRobot();
            robot.Place(initialPosition, initialDirection);

            robot.Move();

            Assert.AreEqual(expectedPosition.HorizontalPosition, robot.CurrentPosition.HorizontalPosition);
            Assert.AreEqual(expectedPosition.VerticalPosition, robot.CurrentPosition.VerticalPosition);
            Assert.AreEqual(initialDirection, robot.CurrentDirection);
        }

        public static IEnumerable<TestCaseData> TestMoveSource()
        {
            //ICoordinates initialPosition, IDirection initialDirection, ICoordinates expectedPosition
            yield return new TestCaseData(new Coordinate(2, 2), new Direction(CompassDirection.North), new Coordinate(2, 3)).SetName("moving North");
            yield return new TestCaseData(new Coordinate(2,2), new Direction(CompassDirection.East), new Coordinate(3, 2)).SetName("moving East");
            yield return new TestCaseData(new Coordinate(2, 2), new Direction(CompassDirection.South), new Coordinate(2, 1)).SetName("moving South");
            yield return new TestCaseData(new Coordinate(2, 2), new Direction(CompassDirection.West), new Coordinate(1, 2)).SetName("moving West");

            yield return new TestCaseData(new Coordinate(2, 3), new Direction(CompassDirection.North), new Coordinate(2, 4)).SetName("moving North2");
            yield return new TestCaseData(new Coordinate(3, 2), new Direction(CompassDirection.East), new Coordinate(4, 2)).SetName("moving East2");
            yield return new TestCaseData(new Coordinate(2, 1), new Direction(CompassDirection.South), new Coordinate(2, 0)).SetName("moving South2");
            yield return new TestCaseData(new Coordinate(1, 2), new Direction(CompassDirection.West), new Coordinate(0, 2)).SetName("moving West2");

            yield return new TestCaseData(new Coordinate(2, 4), new Direction(CompassDirection.North), new Coordinate(2, 4)).SetName("Trying to move off north of table");
            yield return new TestCaseData(new Coordinate(4, 2), new Direction(CompassDirection.East), new Coordinate(4, 2)).SetName("Trying to move off east of table");
            yield return new TestCaseData(new Coordinate(2, 0), new Direction(CompassDirection.South), new Coordinate(2, 0)).SetName("Trying to move off south of table");
            yield return new TestCaseData(new Coordinate(0, 2), new Direction(CompassDirection.West), new Coordinate(0, 2)).SetName("Trying to move off west of table");
        }

        [Test]
        public void TestMultiplePlace()
        {
            var robot = new ToyRobot();

            robot.Place(new Coordinate(2,2), new Direction(CompassDirection.North));
            robot.Place(new Coordinate(1, 3), new Direction(CompassDirection.West));

            var actualPosition = robot.CurrentPosition;
            var actualDirection = robot.CurrentDirection;

            Assert.AreEqual(1, actualPosition.HorizontalPosition);
            Assert.AreEqual(3, actualPosition.VerticalPosition);
            Assert.AreEqual(CompassDirection.West, actualDirection);
        }
    }
}