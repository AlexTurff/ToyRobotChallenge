using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    public interface IPosition
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

    public class Coordinates : IPosition
    {
        public int HorizontalPosition => throw new NotImplementedException();

        public int VerticalPosition => throw new NotImplementedException();
    }
}
