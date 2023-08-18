class Game
{
    // Private fields
      private string[] wordList = { "algorithm", "programming", "database", "encryption", "software", "interface", "network", "cybersecurity", "cloud", "artificial" };
    private string selectedWord;
    private char[] hiddenWord;
    private int attempts = 8;
    private bool isGameOver = false;

    // Initialize the game
    private void InitializeGame()
    {
        Random random = new Random();
        int randomNumber = random.Next(0, wordList.Length);
        selectedWord = wordList[randomNumber].ToLower();

        hiddenWord = new char[selectedWord.Length];
        for (int i = 0; i < selectedWord.Length; i++)
        {
            hiddenWord[i] = '_';
        }
    }

    // Display current game state
    private void DisplayGameState()
    {
        Console.WriteLine($"\nAttempts remaining: {attempts}");
        Console.WriteLine($"Word: {new string(hiddenWord)}");
    }

    // Handle an incorrect guess
    private void HandleIncorrectGuess()
    {
        attempts--;
        Console.WriteLine("Incorrect guess!");
    }

    // Check game status based on user input
    private void CheckGameStatus(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length > 1)
        {
            Console.WriteLine("Invalid input. Please enter a single letter.");
            return;
        }

        char letter = input[0];
        bool isLetterFound = false;

        for (int i = 0; i < selectedWord.Length; i++)
        {
            if (selectedWord[i] == letter)
            {
                hiddenWord[i] = letter;
                isLetterFound = true;
            }
        }

        if (!isLetterFound)
        {
            HandleIncorrectGuess();
        }

        if (attempts <= 0)
        {
            Console.WriteLine("\nGame over! You ran out of attempts.");
            Console.WriteLine($"The word was: {selectedWord}");
            isGameOver = true;
        }

        if (new string(hiddenWord) == selectedWord)
        {
            Console.WriteLine("\nCongratulations! You guessed the word correctly.");
            Console.WriteLine($"The word was: {selectedWord}");
            isGameOver = true;
        }
    }

    // Display the game menu
    private static void DisplayMenu()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Start a new game");
        Console.WriteLine("2. Exit");
    }

    // Handle user menu choice
    private static void HandleMenuChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                Game newGame = new Game();
                newGame.Start();
                break;
            case 2:
                Console.WriteLine("Thank you for playing!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose a valid option.");
                break;
        }
    }

    

    // Start the game
   public void Start()
    {
        Console.WriteLine("Welcome to Guess the Technology Word Game!");
        Console.WriteLine("The list of words you have to guess: algorithm, programming, database, encryption, software, interface, network, cybersecurity, cloud, artificial");
        InitializeGame();

        do
        {
            DisplayGameState();
            Console.Write("Enter a letter: ");
            string input = Console.ReadLine().ToLower();
            CheckGameStatus(input);
        } while (!isGameOver);

        Console.WriteLine("\nThank you for playing Guess the Word Game!");

        while (true)
        {
            DisplayMenu();
            int menuChoice;
            while (!int.TryParse(Console.ReadLine(), out menuChoice))
            {
                Console.WriteLine("Invalid input. Please enter a valid menu option.");
            }

            HandleMenuChoice(menuChoice);
        }
    }
}