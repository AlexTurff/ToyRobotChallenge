
namespace ToyRobotChallenge
{
    static class CompassDirectionConverter
    {
        /// <summary>
        /// Parses all caps cardinal compass direction strings into CompassDirection values 
        /// </summary>
        /// <returns>The parsed CompassDirection value</returns>
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

        public static string CompassDirectionToOutputString(CompassDirection? direction)
        {
            return (direction?.ToString().ToUpper())??string.Empty;
        }
    }
}
