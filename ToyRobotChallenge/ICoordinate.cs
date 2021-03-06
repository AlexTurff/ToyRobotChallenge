namespace ToyRobotChallenge
{
    public interface ICoordinate
    {
        /// <summary>
        /// X co-ordinate (base 0)
        /// </summary>
        int HorizontalPosition { get; }

        /// <summary>
        /// Y co-ordinate (base 0)
        /// </summary>
        int VerticalPosition { get; }
    }
}
