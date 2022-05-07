using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    public interface IDirection
    {
        CompassDirection CurrentDirection { get; }

        CompassDirection TurnLeft();

        CompassDirection TurnRight();
    }

    public class Direction : IDirection
    {
        public CompassDirection CurrentDirection { get; private set; }


        public Direction(CompassDirection initialDirection)
        {
            CurrentDirection = initialDirection;
        }


        public CompassDirection TurnLeft()
        {
            throw new NotImplementedException();
        }

        public CompassDirection TurnRight()
        {
            throw new NotImplementedException();
        }
    }
}
