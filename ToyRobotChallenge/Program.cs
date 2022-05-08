using System;

namespace ToyRobotChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputHandler = new InputHandler(new ToyRobot(), s => Console.WriteLine(s));

            while (true)
            {
                inputHandler.ProcessInputLine(Console.ReadLine());
            }
        }
    }
}
