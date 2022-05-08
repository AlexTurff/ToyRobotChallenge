using System;

namespace ToyRobotChallenge
{
    /// <summary>
    /// Class modeling a toy robot on a 5x5 board
    /// </summary>
    public class ToyRobot : IRobot
    {
        private readonly int boardWidth = 5;
        private readonly int boardHeight = 5;

        private IDirection Direction { get; set; }
        private bool HasBeenPlaced => CurrentPosition != null && CurrentDirection != null;

        /// <inheritdoc />
        public CompassDirection? CurrentDirection => Direction?.CurrentDirection;

        /// <inheritdoc />
        public ICoordinate CurrentPosition { get; private set; }

        /// <inheritdoc />
        public void Move()
        {
            if (HasBeenPlaced)
            {
                ICoordinate newLocation;
                switch (CurrentDirection)
                {
                    case CompassDirection.North:
                        newLocation = new Coordinate(CurrentPosition.HorizontalPosition, CurrentPosition.VerticalPosition + 1);
                        break;
                    case CompassDirection.East:
                        newLocation = new Coordinate(CurrentPosition.HorizontalPosition + 1, CurrentPosition.VerticalPosition);
                        break;
                    case CompassDirection.South:
                        newLocation = new Coordinate(CurrentPosition.HorizontalPosition, CurrentPosition.VerticalPosition - 1);
                        break;
                    case CompassDirection.West:
                        newLocation = new Coordinate(CurrentPosition.HorizontalPosition - 1, CurrentPosition.VerticalPosition);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (IsCoordinateOnBoard(newLocation))
                {
                    CurrentPosition = newLocation;
                }
            }
        }

        /// <inheritdoc />
        public void Place(ICoordinate newPosition, IDirection newDirection)
        {
            if (newPosition == null) throw new ArgumentNullException(nameof(newPosition));
            if (newDirection == null) throw new ArgumentNullException(nameof(newDirection));

            if (!IsCoordinateOnBoard(newPosition))
            {
                throw new IndexOutOfRangeException(string.Format(ConsoleMessageResources.PlaceCommandOutOfRange, newPosition.HorizontalPosition, newPosition.VerticalPosition,
                    boardWidth, boardHeight));
            }

            CurrentPosition = newPosition;
            Direction = newDirection;
        }

        /// <inheritdoc />
        public void TurnLeft()
        {
            if (HasBeenPlaced)
            {
                Direction.TurnLeft();
            }
        }

        /// <inheritdoc />
        public void TurnRight()
        {
            if (HasBeenPlaced)
            {
                Direction.TurnRight();
            }
        }

        /// <summary>
        /// Checks if the passed coordinates are valid (are they on the board or not)
        /// </summary>
        /// <param name="coordinate">X,Y coordinates to check</param>
        /// <returns>if the passed location is on the board/table</returns>
        private bool IsCoordinateOnBoard(ICoordinate coordinate)
        {
            if (coordinate.HorizontalPosition < 0 || coordinate.HorizontalPosition >= boardWidth || coordinate.VerticalPosition < 0 || coordinate.VerticalPosition >= boardHeight)
            {
                return false;
            }

            return true;
        }
    }
}