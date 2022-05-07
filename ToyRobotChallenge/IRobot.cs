using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    public interface IRobot
    {
        IDirection CurrentDirection { get; }
        ICoordinates CurrentPosition { get; }

        void Move();
        void TurnLeft();
        void TurnRight();
        void Place(ICoordinates newPosition, CompassDirection newDirection);
        string Report();
    }

    public class ToyRobot : IRobot
    {
        private readonly int boardWidth;
        private readonly int boardHeight;

        public ToyRobot(int boardWidth, int boardHeight)
        {
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
        }

        public IDirection CurrentDirection { get; private set; }

        public ICoordinates CurrentPosition { get; private set; }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Place(ICoordinates newPosition, CompassDirection newDirection)
        {
            // todo make out of bounds error format available to unit tests?
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
