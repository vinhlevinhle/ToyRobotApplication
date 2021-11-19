# Auther : Vinh Le 

# ToyRobotApplication

This document will briefly describe how the application was created and how it can be compiled and run.

The application is written in C# and is a MS Console Application developed using MS Visual Studio Professional 2019. 
However, this project solution can also be loaded and work with Visual Studio Code (MS Free or Community tool edition).

The project's structure starts at the root folder ToyRobotApplication with 3 main sub projects.

- ToyRobotApplication
     - RobotClassLibrary 
	 - ToyRobotApplication
	 - UnitTestToyRobot
	 README.md
	 ToyRobotApplication.sln

Steps to build and run the ToyRobot console application. 
This assume the end user is familiar with basic development on Windows using MS Visual Studio IDE tool.

1) Clone the ToyRobot from GitHub then load your Visual Studio IDE
2) Open the project solution file ToyRobotApplication.sln under the root folder mention above
3) To build this project in release mode by changing the build configuration manager from debug to release option.
4) Then to launch the ToyRobot Console application that we just built, select 'Debug' from the top menu
5) In the 'Debug' dropdown select the option 'Start Without Debugging'
6) A black console window will display the welcome message with a menu item list explaining how to control the ToyRobot

To run the unit test, exit the ToyRobot Console application with 'q'
1) Go back to VS IDE, from the 'Test' dropdown menu, select 'Run All Tests'
2) Another IDE window will open up automatically to review all the unit tests that have been successfully executed
3) All the unit tests should be green to indicate that they all have passed the test.

