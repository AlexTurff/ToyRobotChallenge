using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    public interface IRobot
    {
        IDirection CurrentDirection { get; }
        IPosition CurrentPosition { get; }

        void Move();
        void TurnLeft();
        void TurnRight();
        void Place(IPosition newPosition);
        string Report();
    }

    public class ToyRobot : IRobot
    {
        public IDirection CurrentDirection => throw new NotImplementedException();

        public IPosition CurrentPosition => throw new NotImplementedException();

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Place(IPosition newPosition)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public void TurnLeft()
        {
            throw new NotImplementedException();
        }

        public void TurnRight()
        {
            throw new NotImplementedException();
        }
    }
}
