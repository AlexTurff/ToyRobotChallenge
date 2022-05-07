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
        private readonly Action<string> reportCallback;
        public IRobot RobotToControl { get; set; }


        public InputHandler(IRobot robotToControl, Action<string> reportCallback)
        {
            RobotToControl = robotToControl;
            this.reportCallback = reportCallback;
        }


        public void ProcessInputLine(string input)
        {
            throw new NotImplementedException();
        }

        private string Report()
        {
            throw new NotImplementedException();
        }
    }
}
