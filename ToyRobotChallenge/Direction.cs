namespace ToyRobotChallenge
{
    public class Direction : IDirection
    {
        public CompassDirection CurrentDirection { get; private set; }


        public Direction(CompassDirection initialDirection)
        {
            CurrentDirection = initialDirection;
        }      

        public CompassDirection TurnLeft()
        {
            // enum values are just integers. Incrementing by 3 and modding by 4 (4 directions) is equivalent to subtracting 1 but doesn't have to deal with modding -ve values
            CurrentDirection = (CompassDirection)(((int)CurrentDirection+3) % 4);

            return CurrentDirection;
        }

        public CompassDirection TurnRight()
        {
            // enum values are just integers. Increment and mod 4 (4 directions) to ensure its always a valid enum value
            CurrentDirection = (CompassDirection)(((int)CurrentDirection + 1) % 4);

            return CurrentDirection;
        }
    }
}
