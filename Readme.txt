To Run the ToyRobotChallenge application you can either build and run it in visual studio, or download the application from the release on github.

To Run in Visual Studio:
	Open the solution in visual studio 2019 or higher.
	You will need to have .net Core 3.1 installed. If this is not on your system you will have to dowload it (https://dotnet.microsoft.com/en-us/download/dotnet/3.1)
	Building the solution should download the required dependencies from nuget (Nunit and Moq for the test project)
	Run the ToyRobotChallenge project and input commands into the console

To Run Directly:
	Download the release zip from the latest release on the github page
	Unzip the release package
	run "ToyRobotChallenge.exe" and enter your commands into the console

Using the application:
	Enter a supported command into the console and press enter for it to be processed
	The robot must be placed on the board before any of the other commands will be processed. Commands entered before the robot is placed will be discarded.
	The robot will ignore MOVE commands that result in it falling off the table/board
	entering an unrecognised command, or trying to place the robot off the table will result in an error message being displayed in the console
	the board is a 5 by 5 grid with 0,0 being the south west corner
Supported Commands:
	"PLACE [x-coordinate],[y-coordinate],[direction]" Places the robot at the given location on the board, facing in the provided direction. Supported directions are "NORTH", "EAST", "SOUTH" and "WEST"
	"MOVE" moves the robot one place forwards in its current direction
	"LEFT" turns the robot left by 90 degrees
	"RIGHT" turns the robot right by 90 degrees
	"REPORT" prints the current location and direction of the robot to the console

Example Inputs - these can be pasted into the console:
	Starts bottom left (facing north) and moves north once:
PLACE 0,0,NORTH
MOVE
REPORT

	Starts bottom left (facing north) and turns left:
PLACE 0,0,NORTH
LEFT
REPORT

	Starts in 1,2 facing east, moves to the east side of the board then turns left and moves north once:
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT

	Starts in the middle of the board, moves to the top (reports location once here too), turns around and moves back to where it started (facing the other way)
PLACE 2,2,NORTH
MOVE
MOVE
REPORT
RIGHT
RIGHT
MOVE
MOVE
REPORT
