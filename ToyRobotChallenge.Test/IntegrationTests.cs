using NUnit.Framework;
using System.Collections.Generic;

namespace ToyRobotChallenge.Test
{
    [TestFixture]
    class IntegrationTests
    {
        [Test]
        [TestCaseSource(nameof(IntegrationTestSource))]
        public void IntegrationTest(List<string> inputLines, string expectedOutput)
        {
            var output = "";

            var inputHandler = new RobotInputHandler(new ToyRobot(), (s) => output += s);

            foreach(var inputLine in inputLines)
            {
                inputHandler.ProcessInputLine(inputLine);
            }

            Assert.AreEqual(expectedOutput, output);
        }

        public static IEnumerable<TestCaseData> IntegrationTestSource()
        {
            yield return new TestCaseData(new List<string>()
            {
                "PLACE 0,0,NORTH","MOVE","REPORT"
            }, "Output: 0,1,NORTH");

            yield return new TestCaseData(new List<string>()
            {
                "PLACE 0,0,NORTH","LEFT","REPORT"
            }, "Output: 0,0,WEST");

            yield return new TestCaseData(new List<string>()
            {
                "PLACE 1,2,EAST","MOVE","MOVE","LEFT","MOVE","REPORT"
            }, "Output: 3,3,NORTH");
        }
    }
}
