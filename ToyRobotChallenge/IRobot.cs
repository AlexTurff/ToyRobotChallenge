using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    public interface IRobot
    {
        CompassDirection? CurrentDirection { get; }
        ICoordinate CurrentPosition { get; }

        void Move();
        void TurnLeft();
        void TurnRight();
        void Place(ICoordinate newPosition, IDirection newDirection);
    }

    public class ToyRobot : IRobot
    {
        private readonly int boardWidth = 5;
        private readonly int boardHeight = 5;

        private IDirection Direction { get; set; }
        private bool HasBeenPlaced => CurrentPosition != null && CurrentDirection != null;

        public CompassDirection? CurrentDirection { get { return Direction?.CurrentDirection; } }
        public ICoordinate CurrentPosition { get; private set; }

        public void Move()
        {
            if (HasBeenPlaced)
            {
                switch (CurrentDirection)
                {
                    case CompassDirection.North:
                        if (CurrentPosition.VerticalPosition + 1 < boardHeight)
                        {
                            CurrentPosition = new Coordinate(CurrentPosition.HorizontalPosition, CurrentPosition.VerticalPosition + 1);
                        }
                        break;
                    case CompassDirection.East:
                        if (CurrentPosition.HorizontalPosition + 1 < boardWidth)
                        {
                            CurrentPosition = new Coordinate(CurrentPosition.HorizontalPosition + 1, CurrentPosition.VerticalPosition);
                        }
                        break;
                    case CompassDirection.South:
                        if (CurrentPosition.VerticalPosition - 1 >= 0)
                        {
                            CurrentPosition = new Coordinate(CurrentPosition.HorizontalPosition, CurrentPosition.VerticalPosition - 1);
                        }
                        break;
                    case CompassDirection.West:
                        if (CurrentPosition.HorizontalPosition -1 >= 0)
                        {
                            CurrentPosition = new Coordinate(CurrentPosition.HorizontalPosition - 1, CurrentPosition.VerticalPosition);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Place(ICoordinate newPosition, IDirection newDirection)
        {
            if (newPosition == null) throw new ArgumentNullException(nameof(newPosition));
            if (newDirection == null) throw new ArgumentNullException(nameof(newDirection));

            if (newPosition.VerticalPosition < 0 || newPosition.VerticalPosition >= boardHeight || newPosition.HorizontalPosition < 0 || newPosition.HorizontalPosition >= boardWidth)
            {
                throw new IndexOutOfRangeException(string.Format(ConsoleMessageResources.PlaceCommandOutOfRange, newPosition.HorizontalPosition, newPosition.VerticalPosition,
                    boardWidth, boardHeight));
            }

            CurrentPosition = newPosition;
            Direction = newDirection;

        }

        public void TurnLeft()
        {
            if (HasBeenPlaced)
            {
                Direction.TurnLeft();
            }
        }

        public void TurnRight()
        {
            if (HasBeenPlaced)
            {
                Direction.TurnRight();
            }
        }
    }
}
