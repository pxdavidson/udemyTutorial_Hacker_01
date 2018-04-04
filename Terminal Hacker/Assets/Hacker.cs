using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    //Game Configuration
    enum Screen { MainMenu, Password, Win }
    Screen currentScreen;
    string[] level1Passwords =  {"book", "lamp", "word", "read", "open"};
    string[] level2Passwords = { "crime", "punch", "crash", "siren", "shoot" };
    string[] level3Passwords = { "bloodied", "ravenous", "infected", "corporation", "debilitating" };

    //Game States
    int level;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu("hacker.exe_Root");
    }

    // Display main menu
    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("//Firewall breached... " +
            "\nWhich system would you like to access?" +
            "\n" +
            "\nEnter 1 for Local Library" +
            "\nEnter 2 for Raccoon City PD" +
            "\nEnter 3 for Umbrella Laboratories" +
            "\n");
    }

    // Take the users input and send it to another method to be processed
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("hacker.exe_Root");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            PasswordGuess(input);
        }
    }

    // Take the users input and allow them to select options from the ShowMainMenu method
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            DisplayPassword();
        }
        else if (input == "zombies")
        {
            ShowMainMenu("Dispatching Lethal Response...");
        }
        else
        {
            ShowMainMenu("Please enter valid entry");
        }
    }

    //Display to the user what level they have selected and request a password before taking input
    void DisplayPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter password");
        switch (level)
        {
            case 1:
                password = level1Passwords[2]; // todo: make random
                break;
            case 2:
                password = level2Passwords[2]; // todo: make random
                break;
            case 3:
                password = level3Passwords[2]; // todo: make random
                break;
            default:
                Debug.LogError("ERROR NO PASSWORD");
                break;
        }
    }

    // Take the users input and check if it is a valid password
    void PasswordGuess(string input)
    {
        if (input == password)
        {
            WinScreen();
        }
        else
        {
            Terminal.ClearScreen();
            ShowMainMenu("Incorrect, try again");
            DisplayPassword();
        }
    }

    //Win screen
    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("You're in! Press any key to continue.");
    }
}
