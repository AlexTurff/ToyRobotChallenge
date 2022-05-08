namespace ToyRobotChallenge
{
    public class Coordinate : ICoordinate
    {
        public Coordinate(int horizontal, int vertical)
        {
            HorizontalPosition = horizontal;
            VerticalPosition = vertical;
        }

        public int HorizontalPosition { get; set; }

        public int VerticalPosition { get; set; }
    }
}
