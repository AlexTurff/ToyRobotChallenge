using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ToyRobotChallenge
{
    public interface IInputHandler
    {
        void ProcessInputLine(string input);
    }

    public class InputHandler : IInputHandler
    {
        private const string MoveCommand = "MOVE";
        private const string TurnLeftCommand = "LEFT";
        private const string TurnRightCommand = "RIGHT";
        private const string ReportCommand = "REPORT";
        private const string PlaceCommand = "PLACE";
        // regex that looks for the following format "PLACE X,Y,Direction" and has capture groups to extract the fields
        private readonly Regex _placeCommandRegex = new Regex("^PLACE ([0-9]+),([0-9]+),([A-Z]+)$",RegexOptions.Compiled);

        private readonly Action<string> _writeToInterfaceCallback;
        public IRobot RobotToControl { get; set; }

        public InputHandler(IRobot robotToControl, Action<string> writeToInterfaceCallback)
        {
            RobotToControl = robotToControl ?? throw new ArgumentNullException(nameof(robotToControl));
            _writeToInterfaceCallback = writeToInterfaceCallback ?? throw new ArgumentNullException(nameof(writeToInterfaceCallback));
        }

        public void ProcessInputLine(string input)
        {
            if (input.Equals(MoveCommand)) 
            {
                RobotToControl.Move();
            }
            else if (input.Equals(TurnLeftCommand)) 
            {
                RobotToControl.TurnLeft();
            }
            else if (input.Equals(TurnRightCommand)) 
            {
                RobotToControl.TurnRight();
            }
            else if (input.Equals(ReportCommand)) 
            {
                _writeToInterfaceCallback(Report());
            }
            else if (input.StartsWith(PlaceCommand))
            {
                ParsePlaceCommand(input);
            }
            else
            {
                _writeToInterfaceCallback(ConsoleMessageResources.InputNotRecognised);
            }
        }

        private void ParsePlaceCommand(string input)
        {
            var matchResult = _placeCommandRegex.Match(input);

            if (!matchResult.Success || matchResult.Groups.Count != 4)
            {
                _writeToInterfaceCallback(ConsoleMessageResources.PlaceCommandBadFormat);

                return;
            }

            // regex groups are base 1
            var horizontalGroupValue = matchResult.Groups[1];
            var verticalGroupValue = matchResult.Groups[2];
            var directionGroupValue = matchResult.Groups[3];

            var horizontalParsed = int.TryParse(horizontalGroupValue.Value, out int horizontalValue);
            var verticalParsed = int.TryParse(verticalGroupValue.Value, out int verticalValue);
            var directionParsed = CompassDirectionParser.TryParseInputString(directionGroupValue.Value, out CompassDirection parsedDirection);

            if (!horizontalParsed || !verticalParsed || !directionParsed)
            {
                _writeToInterfaceCallback(ConsoleMessageResources.PlaceCommandBadFormat);

                return;
            }

            var coordinate = new Coordinate(horizontalValue, verticalValue);
            var direction = new Direction(parsedDirection);

            RobotToControl.Place(coordinate, direction);
        }

        private string Report()
        {
            return $"Output: {RobotToControl.CurrentPosition.HorizontalPosition},{RobotToControl.CurrentPosition.VerticalPosition},{RobotToControl.CurrentDirection?.ToString().ToUpper()}";
        }
    }
}
