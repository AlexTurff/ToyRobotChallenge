using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    public interface ICoordinates
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

    public class Coordinates : ICoordinates
    {
        public Coordinates(int horizontal, int vertical)
        {
            HorizontalPosition = horizontal;
            VerticalPosition = vertical;
        }

        public int HorizontalPosition { get; set; }

        public int VerticalPosition { get; set; }
    }
}
