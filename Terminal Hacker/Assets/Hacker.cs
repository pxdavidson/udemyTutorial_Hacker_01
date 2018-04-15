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
    string system;

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
            SelectLevel(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            ShowMainMenu("hacker.exe_Root");
        }
    }

    // Validate input
    void SelectLevel(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            SetLevel(input);
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

    // Sets the level
    void SetLevel(string input)
    {
        level = int.Parse(input);
        SetSystem();
        SetPassword("Please enter password. Hint: " +
            "\n");
    }

    // Set the system the user is in to display to them
    void SetSystem()
    {
        if (level == 1)
        {
            system = "Library";
        }
        else if (level == 2)
        {
            system = "Police Station";
        }
        else if (level == 3)
        {
            system = "Umbrella Laboratories";
        }
    }

    //Set the password
    void SetPassword(string hint)
    {
        currentScreen = Screen.Password;
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("ERROR NO PASSWORD");
                break;
        }
        DisplayHint(hint);
    }

    //Display the hint
    void DisplayHint(string hint)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(system + " Acessed" +
            "\nEnter 'menu' to return to root");
        Terminal.WriteLine(hint + password.Anagram());
    }

    // Take the users input and check if it is a valid password
    void CheckPassword(string input)
    {
        if (input == password)
        {
            currentScreen = Screen.Win;
            WinScreen();
        }
        else
        {
            SetPassword("Incorrect, new hint: ");
        }
    }

    //Win screen
    void WinScreen()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(@"
You're in! Press Enter to continue.      
      _____
    ,'   Y `.
   /         \
   \ ()  ()  /
    `. /\  ,'
     | ""  |
     [][][]
");
    }
}
