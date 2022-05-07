using NUnit.Framework;

namespace ToyRobotChallenge.Test
{
    [TestFixture]
    public class DirectionTests
    {
        /// <summary>
        /// Basic test to check Constructor and CurrentDirection getter
        /// </summary>
        [Test]
        [TestCase(CompassDirections.North, CompassDirections.North)]
        [TestCase(CompassDirections.East, CompassDirections.East)]
        [TestCase(CompassDirections.South, CompassDirections.South)]
        [TestCase(CompassDirections.West, CompassDirections.West)]        
        public void TestInitialDirection(CompassDirections initialDirection, CompassDirections expectedDirection) 
        {
            var direction = new Direction(initialDirection);

            Assert.AreEqual(expectedDirection, direction.CurrentDirection);
        }

        /// <summary>
        /// Test turning left once from the initial position
        /// </summary>
        [Test]
        [TestCase(CompassDirections.North, CompassDirections.West)]
        [TestCase(CompassDirections.East, CompassDirections.North)]
        [TestCase(CompassDirections.South, CompassDirections.East)]
        [TestCase(CompassDirections.West, CompassDirections.South)]
        public void TestLeftTurn(CompassDirections initialDirection, CompassDirections expectedDirection) 
        {
            var direction = new Direction(initialDirection);

            var newDirection = direction.TurnLeft();

            Assert.AreEqual(expectedDirection, direction.CurrentDirection);
            Assert.AreEqual(expectedDirection, newDirection);
        }

        /// <summary>
        /// Test turning right once from the initial position
        /// </summary>
        [Test]
        [TestCase(CompassDirections.North, CompassDirections.East)]
        [TestCase(CompassDirections.East, CompassDirections.South)]
        [TestCase(CompassDirections.South, CompassDirections.West)]
        [TestCase(CompassDirections.West, CompassDirections.North)]
        public void TestRightTurn(CompassDirections initialDirection, CompassDirections expectedDirection) 
        {
            var direction = new Direction(initialDirection);

            var newDirection = direction.TurnRight();

            Assert.AreEqual(expectedDirection, direction.CurrentDirection);
            Assert.AreEqual(expectedDirection, newDirection);
        }

        /// <summary>
        /// Test turning multiple times
        /// </summary>
        [Test]
        public void TestMultipleTurns()
        {
            var direction = new Direction(CompassDirections.North);

            var actualDirectionOne = direction.TurnRight();
            var actualDirectionTwo = direction.TurnRight();
            var actualDirectionThree = direction.TurnRight();
            var finalDirection = direction.TurnLeft();

            Assert.AreEqual(CompassDirections.East, actualDirectionOne,"Unexpected direction after turn one");
            Assert.AreEqual(CompassDirections.South, actualDirectionTwo, "Unexpected direction after turn two");
            Assert.AreEqual(CompassDirections.West, actualDirectionThree, "Unexpected direction after turn three");
            Assert.AreEqual(CompassDirections.South, finalDirection, "Unexpected direction after turn four (from method return)");
            Assert.AreEqual(CompassDirections.South, direction.CurrentDirection, "Unexpected direction after turn four (from property)");
        }
    }
}