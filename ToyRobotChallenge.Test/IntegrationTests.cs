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
            // First three tests are the example input/outputs from the task spec
            yield return new TestCaseData(new List<string>()
            {
                "PLACE 0,0,NORTH","MOVE","REPORT"
            }, "Output: 0,1,NORTH").SetName("Spec example 1");

            yield return new TestCaseData(new List<string>()
            {
                "PLACE 0,0,NORTH","LEFT","REPORT"
            }, "Output: 0,0,WEST").SetName("Spec example 2");

            yield return new TestCaseData(new List<string>()
            {
                "PLACE 1,2,EAST","MOVE","MOVE","LEFT","MOVE","REPORT"
            }, "Output: 3,3,NORTH").SetName("Spec example 3");

            // Additional cases by me

            yield return new TestCaseData(new List<string>()
            {
                "PLACE 2,2,NORTH","MOVE","MOVE","REPORT","RIGHT","RIGHT","MOVE","MOVE","REPORT"
            }, "Output: 2,4,NORTHOutput: 2,2,SOUTH").SetName("Move from middle to top, report, then back to middle");

            yield return new TestCaseData(new List<string>()
            {
                "PLACE 2,2,NORTH","PLACE 2,4,NORTH","REPORT","RIGHT","RIGHT","MOVE","MOVE","REPORT"
            }, "Output: 2,4,NORTHOutput: 2,2,SOUTH").SetName("start in middle, replace at top, report, then move back to middle");

            //failure cases
            yield return new TestCaseData(new List<string>()
            {
                "dfgdfg",
            }, ConsoleMessageResources.InputNotRecognised).SetName("gibberish command");

            yield return new TestCaseData(new List<string>()
            {
                "PLACE 2,2,NORTH","move"
            }, ConsoleMessageResources.InputNotRecognised).SetName("bad command (lower case)");

            yield return new TestCaseData(new List<string>()
            {
                "PLACE 2,,NORTH"
            }, ConsoleMessageResources.PlaceCommandBadFormat).SetName("bad PLACE command format");

            yield return new TestCaseData(new List<string>()
            {
                "PLACE 22,22,NORTH"
            }, string.Format(ConsoleMessageResources.PlaceCommandOutOfRange,"22","22","5","5")).SetName("bad PLACE command format");
        }
    }
}
