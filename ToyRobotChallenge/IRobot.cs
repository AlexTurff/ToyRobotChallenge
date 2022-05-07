using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    interface IRobot
    {
        IDirection CurrentDirection { get; }
        IPosition CurrentPosition { get; }

        void Move();
        void TurnLeft();
        void TurnRight();
        void Place(IPosition newPosition);
        string Report();
    }
}
