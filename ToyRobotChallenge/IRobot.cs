using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    public interface IRobot
    {
        CompassDirection? CurrentDirection { get; }
        ICoordinates CurrentPosition { get; }

        void Move();
        void TurnLeft();
        void TurnRight();
        void Place(ICoordinates newPosition, IDirection newDirection);
    }

    public class ToyRobot : IRobot
    {
        private readonly int boardWidth = 5;
        private readonly int boardHeight = 5;

        private IDirection Direction { get; set; }
        private ICoordinates Position { get; set; }

        public CompassDirection? CurrentDirection { get { return Direction?.CurrentDirection; } }

        // Don't return the current object (as it could be modified outside) - return a copy
        public ICoordinates CurrentPosition { get { return Position == null ? null : new Coordinates(Position.HorizontalPosition, Position.VerticalPosition); } }

        public ToyRobot()
        {

        }
               
        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Place(ICoordinates newPosition, IDirection newDirection)
        {
            // todo make out of bounds error format available to unit tests?
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
