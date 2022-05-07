using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    interface IDirection
    {
        CompassDirections CurrentDirection { get; }

        CompassDirections TurnLeft();

        CompassDirections TurnRight();
    }
}
