namespace ToyRobotChallenge
{
    public interface IRobot
    {
        /// <summary>
        /// The cardinal direction the robot is currently facing
        /// </summary>
        CompassDirection? CurrentDirection { get; }

        /// <summary>
        /// The coordinate of where the  is currently placed
        /// </summary>
        ICoordinate CurrentPosition { get; }

        /// <summary>
        /// Attempts to move the robot one place forwards in its current direction. May not move if not possible from its current position
        /// </summary>
        void Move();

        /// <summary>
        /// turns the robot left
        /// </summary>
        void TurnLeft();

        /// <summary>
        /// Turns the robot right
        /// </summary>
        void TurnRight();

        /// <summary>
        /// Attempts to place the robot at the given location facing in the given direction
        /// </summary>
        /// <param name="newPosition">X,Y coordinate to place the robot at</param>
        /// <param name="newDirection">The direction the robot will be facing when placed</param>
        void Place(ICoordinate newPosition, IDirection newDirection);
    }
}
