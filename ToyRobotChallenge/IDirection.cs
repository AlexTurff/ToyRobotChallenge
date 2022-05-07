using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    public interface IDirection
    {
        CompassDirections CurrentDirection { get; }

        CompassDirections TurnLeft();

        CompassDirections TurnRight();
    }

    public class Direction : IDirection
    {
        public CompassDirections CurrentDirection { get; private set; }


        public Direction(CompassDirections initialDirection)
        {
            CurrentDirection = initialDirection;
        }


        public CompassDirections TurnLeft()
        {
            throw new NotImplementedException();
        }

        public CompassDirections TurnRight()
        {
            throw new NotImplementedException();
        }
    }
}
