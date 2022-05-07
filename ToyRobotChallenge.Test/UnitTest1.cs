using NUnit.Framework;

namespace ToyRobotChallenge.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
            // Need to have input handling testing
            // test giberish without place command
            // test commands being ignored before a place
            // lots more todo here

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
        }
    }
}