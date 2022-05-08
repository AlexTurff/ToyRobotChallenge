namespace ToyRobotChallenge
{
    /// <summary>
    /// Interface for the management basic compass point direction in a 2d plane through turning left and right
    /// </summary>
    public interface IDirection
    {
        CompassDirection CurrentDirection { get; }

        CompassDirection TurnLeft();

        CompassDirection TurnRight();
    }
}
