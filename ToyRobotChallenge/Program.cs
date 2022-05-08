using System;

namespace ToyRobotChallenge
{
    class Program
    {
        static void Main()
        {
            var inputHandler = new RobotInputHandler(new ToyRobot(), Console.WriteLine);

            while (true)
            {
                inputHandler.ProcessInputLine(Console.ReadLine());
            }
        }
    }
}
