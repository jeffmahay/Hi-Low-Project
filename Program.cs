class Player
{
    public static void Main()
    {
        // References CardDeck file //
        CardDeck deck = new CardDeck();

        // Initial Score //
        int score = 300;

        // Initial choice
        bool stop = false;

        // Creates a variable to hold the deck of cards created in the CardDeck file //
        List<string> cards = deck.cards;

        // Initial card drawn from the deck //
        string first = deck.draw(cards);
        
        // Keep playing the game until its over //
        while(stop != true)
        { 
            string second = deck.draw(cards);

            int change = terminalDialogue(score, cards, first, second);
            
            score = score + change;
            Console.WriteLine($"Your score is {score}");

            first = second;

            bool decision = playAgain();
            
            stop = IsOver(score, cards, decision);
        }

        Console.WriteLine("Thanks for playing!");
        
    }

    // Function that checks if the conditions of a game over are met //
    public static bool IsOver(int score, List<string> cards, bool decision)
    {
        CardDeck deck = new CardDeck();

        if(deck.draw(cards) == "over")
        {
            return true;
        }
        else if(decision == false || score == 0)
        {
            return true;
        }
        else
        {
            return false;
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
    public static int terminalDialogue(int score, List<string> cards, string first, string second)
    {   
        CardDeck deck = new CardDeck();

        Console.WriteLine($"The last card is: {first}");
        Console.WriteLine($"Higher or lower? [h/l]:");

        string? input = Console.ReadLine() ?? "";

        Console.WriteLine($"The next card is: {second}");

        int convfirst = deck.convert(first);
        int convsecond = deck.convert(second);

        int change = scoreCalculator(input, convfirst, convsecond);

        return change;
    }

    // checks if the first instance of the deck drawn is greater or lower, and compares that with the user's input //
    public static int scoreCalculator(string input, int convfirst, int convsecond)
    {
        if(input == "h" && convsecond > convfirst)
        {
            return 100;
        }
        else if(input == "h" && convsecond < convfirst)
        {
            return -75;
        }
        else if(input == "l" && convsecond < convfirst)
        {
            return 100;
        }
        else if(input == "l" && convsecond > convfirst)
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

        string? continueChoice = Console.ReadLine();

        if(continueChoice == "y")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}