# Gilded Rose Problem

This is a version of the Guilded Rose Kata, built from the beginning in Visual Studio 2017. It is written in C# using .Net Framework 4.6.1.

# Requirements

- Visual Studio, 2017 onward
- .Net Framework 4.6.1
- NUnit 3.11.0
- Moq 4.10.1 
- NUnit 3 Test Adapter

# Project Setup

Firstly we shall install the required packages to run the tests.
- In the Solution Explorer Right click on the GildedRoseProblem.Test project, then select NuGet Package manager.
- In the Package manager, select the Browse tab. NUnit should be the most popular package so select it then press install.
- Next search for 'Moq' using the search function of the Package manager. Select moq and then install it.

Next we need to install the NUnit 3 test Adapter.
- From the top toolbar select Tools > Extensions and Updates
- select the online menu on the left, then search for and install NUnit 3 Test Adapter.

# Running The App

Firstly you should run the NUnit tests. 
- in the top toolbar select Test > Windows > Test Explorer
- From the test explorer press Run All, this will run all the tests

Once the tests have been run and successfully passed, you can run the project. To run using the Visual Studio debugger press the play button at the top. This will build and run the application.

## Build the App

To Build the app
- Change the build version from Debug to Release
- select Build > Build Solution.
- In File explorer, navigate to the root of the project then > Guilded Rose Problem > Bin > Release. The Application should be in there as Gilded Rose Problem.exe

## Changing the Test Data

To change the test data to see if it works with other data open the project in visual studio, then open the InventoryManagementApp.cs file. Lines 10 - 21 are a list of default items in the inventory, you can add/remove items inside this list using the Item Constructor:

    new Item(Name, SellIn, Quality)
