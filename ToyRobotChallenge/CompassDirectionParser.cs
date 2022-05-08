using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    /// <summary>
    /// Helper extension to provide very basic parsing support for input from the console into the CompassDirection Enum
    /// </summary>
    static class CompassDirectionParser
    {
        /// <summary>
        /// Parses all caps cardinal compass direction strings into CompassDirection values 
        /// </summary>
        /// <returns>The parsed CompassDirection value</returns>
        /// <exception cref="ArgumentException">Argument exception thrown if the input string is not a recognised value</exception>
        public static bool TryParseInputString(string initialDirectionString, out CompassDirection parsedDirection)
        {
            switch (initialDirectionString)
            {
                case "NORTH":
                    parsedDirection = CompassDirection.North;
                    break;
                case "EAST":
                    parsedDirection = CompassDirection.East;                    
                    break;
                case "SOUTH":
                    parsedDirection = CompassDirection.South;                    
                    break;
                case "WEST":
                    parsedDirection = CompassDirection.West;
                    break;
                default:
                    parsedDirection = default(CompassDirection);
                    return false;
            }

            return true;
        }
    }
}
