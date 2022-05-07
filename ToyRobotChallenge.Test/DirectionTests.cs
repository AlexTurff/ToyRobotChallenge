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
        [TestCase(CompassDirection.North, CompassDirection.North)]
        [TestCase(CompassDirection.East, CompassDirection.East)]
        [TestCase(CompassDirection.South, CompassDirection.South)]
        [TestCase(CompassDirection.West, CompassDirection.West)]        
        public void TestInitialDirection(CompassDirection initialDirection, CompassDirection expectedDirection) 
        {
            var direction = new Direction(initialDirection);

            Assert.AreEqual(expectedDirection, direction.CurrentDirection);
        }

        /// <summary>
        /// Test turning left once from the initial position
        /// </summary>
        [Test]
        [TestCase(CompassDirection.North, CompassDirection.West)]
        [TestCase(CompassDirection.East, CompassDirection.North)]
        [TestCase(CompassDirection.South, CompassDirection.East)]
        [TestCase(CompassDirection.West, CompassDirection.South)]
        public void TestLeftTurn(CompassDirection initialDirection, CompassDirection expectedDirection) 
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
        [TestCase(CompassDirection.North, CompassDirection.East)]
        [TestCase(CompassDirection.East, CompassDirection.South)]
        [TestCase(CompassDirection.South, CompassDirection.West)]
        [TestCase(CompassDirection.West, CompassDirection.North)]
        public void TestRightTurn(CompassDirection initialDirection, CompassDirection expectedDirection) 
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
            var direction = new Direction(CompassDirection.North);

            var actualDirectionOne = direction.TurnRight();
            var actualDirectionTwo = direction.TurnRight();
            var actualDirectionThree = direction.TurnRight();
            var finalDirection = direction.TurnLeft();

            Assert.AreEqual(CompassDirection.East, actualDirectionOne,"Unexpected direction after turn one");
            Assert.AreEqual(CompassDirection.South, actualDirectionTwo, "Unexpected direction after turn two");
            Assert.AreEqual(CompassDirection.West, actualDirectionThree, "Unexpected direction after turn three");
            Assert.AreEqual(CompassDirection.South, finalDirection, "Unexpected direction after turn four (from method return)");
            Assert.AreEqual(CompassDirection.South, direction.CurrentDirection, "Unexpected direction after turn four (from property)");
        }
    }
}