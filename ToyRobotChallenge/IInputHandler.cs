using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    public interface IInputHandler
    {
        void ProcessInputLine(string input);
    }

    public class InputHandler : IInputHandler
    {
        public InputHandler(IRobot robotToControl)
        {
            RobotToControl = robotToControl;
        }

        public IRobot RobotToControl { get; set; }

        public void ProcessInputLine(string input)
        {
            throw new NotImplementedException();
        }
    }
}
