class Player
{
    public static void Main()
    {
        // References CardDeck file //
        CardDeck deck = new CardDeck();

        // Initial Score //
        int score = 300;

        // Creates a variable to hold the deck of cards created in the CardDeck file //
        List<string> cards = deck.cards;

        // Getting the first card
        string firstCard = cardDrawn(cards);

        // Getting the drawn cards
        List<string> drawn = new List<string>();
        drawn.Add(firstCard);

        // Initial choice
        bool choice = false;

        // Keep playing the game until its over //
        while(IsOver(score, cards, choice) != true)
        {
            int change = terminalDialogue(score, cards, drawn);
            bool decision = playAgain();
            int points = score + change;
            IsOver(points, cards, decision);
        }
    }

    // Function that checks if the conditions of a game over are met //
    public static bool IsOver(int score, List<string> cards, bool choice)
    {
        CardDeck deck = new CardDeck();

        if(score > 0)
        {
            return false;
        }
        else if(deck.draw(cards) == "over")
        {
            return true;
        }
        else if(choice == true)
        {
            return false;
        }
        else
        {
            return true;
        }   
    }

    // Draws a card from the deck and returns said card as an integer //
    public static string cardDrawn(List<string> cards)
    {
        CardDeck deck = new CardDeck();

        string card = deck.draw(cards);

        return card;
    }

    // Holds all the console.writeline code, as well as the score calculator. //
    public static int terminalDialogue(int score, List<string> cards, List<string>drawn)
    {
        CardDeck deck = new CardDeck();

        string next = cardDrawn(cards);
        
        int first = deck.convert(drawn[-1]);
        int second = deck.convert(next);

        Console.WriteLine($"The last card is: {drawn[-1]}");
        Console.WriteLine($"Higher or lower? [h/l]");
        string? input = Console.ReadLine() ?? "";
        Console.WriteLine($"The next card is: {next}");
        int change = scoreCalculator(input, first, second, score);
        return change;
    }

    // checks if the first instance of the deck drawn is greater or lower, and compares that with the user's input //
    public static int scoreCalculator(string input, int first, int second, int score)
    {
        if(input == "h" && second > first)
        {
            return 100;
        }
        else if(input == "h" && second < first)
        {
            return -75;
        }
        else if(input == "l" && second < first)
        {
            return 100;
        }
        else if(input == "l" && second > first)
        {
            return -75;
        }
        else if(input != "l" || input != "h")
        {
            Console.WriteLine("ERROR");
            return 0;
        }
        else
        {
            return 0;
        }
    }

    // checks player's input to decide if the game is over after every round //
    // provides the player with a way to quit whenever they want //
    public static bool playAgain()
    {
        Console.WriteLine("Play again? [y/n]");

        string? input = Console.ReadLine();

        if(input == "y")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}