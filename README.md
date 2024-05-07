# Instrumon
Created by:
* Michael Freier
* Cameron Clark
* Patrick Hernandez
* Brandon Martin
* David Hill

## Final build of the game
Google Drive: https://drive.google.com/file/d/1z4-GK5so_wIZgaNUBUZYL8w9SLT8pBzy/view?usp=sharing

## Steps to build the game for developers:
* Pull this repository onto your local machine
* Download Unity Hub: https://unity.com/download
* Within Unity Hub, locate your local repository
* Upon discovering your repository, you should be prompted to install the correct build of Unity(2022.3.18f1)
* If the prompt doesn't happen, navigate to https://unity.com/releases/editor/archive and download the correct version (2022.3.18f1)
* Your browser should prompt you to open the download in Unity Hub
* Once the build is installed, launch the project from Unity Hub

## Testing Framework
* The Unity Testing Framework Package is already installed for this project but if it isn't:
* Navigate to the package manager at Window > Package Manager and search for Test, then install the Test Framework package
* Once the package is installed, navigate to the window tab at the top
* Then go to general > Test Runner
* This is where you will run your tests once you create them
* I have already created 2 different folders at the root of the project for editor tests and player tests
* These folders are where you will put your tests scripts respectively
* To create a new test script, right click within the folder that the test will be for (player or editor),
* Then navigate to Create > Testing > C# Test Script
* Your new script should now appear in the Test Runner Window
* Once the script is completed, you can run all tests or a specific test from within the Test Runner window
* If the test passes, then it will show a checkmark next to the test in the Test Runner window
* I have sample test scripts that automatically pass if you want to see if your Test Runner is working properly
* When writing test scripts, use the assert method to make sure everything is running according to plan for the script being tested.
* For help writing tests, I found this video that shows an example of someone's test: https://www.youtube.com/watch?v=043EY6H5424
* The example in the video above is shown at 4:45 which should help you guys get started with writing your tests
* If you need any additional help, seek out additional tutorials or Michael in our Discord server

## Compiling
Steps to compile the final product in Unity.
* Click File > Build Settings
* Select every scene used in the final game
* Pick which platform the game is being exported for (Probably Windows or Mac)
* All settings can be left at their default unless you want otherwise
* Click Build
* Select a local save location
* Navigate to where it is saved and test the build


### MovementTesting Cameron Clark
Steps to Run MovementTesting Test
* Open TestRunner in Window tab
* Select MovementTesting in PlayMode Testing
* Run Test
* Wait for Test to complete, should start the WorldLayer and have player move around
* Test complete, should pass all tests currently

### BattleSwitchTest Michael Freier
Steps to run the battle switching test:
* Open TestRunner from Window > General > TestRunner
* Select PlayMode Tab at the top of the new window
* Highlight BattleSwitchTest
* Click Run Selected near the top
* Wait for the test to run
* Once the test completes, it should pass

### PauseMenuTest Patrick Hernandez
Steps to run the battle switching test:
* Open TestRunner from Window > General > TestRunner
* Select PlayMode Tab at the top of the new window
* Highlight PauseMenuTest
* Click Run Selected near the top
* Wait for the test to run
* Once the test completes, it should pass
