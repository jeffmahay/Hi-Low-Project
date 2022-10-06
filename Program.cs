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
        int first = cardDrawn(cards);

        // Keep playing the game until its over //
        while(IsOver(score, cards) != true)
        {
            terminalDialogue(score, cards, first);
            playAgain();
        }
    }

    // Function that checks if the conditions of a game over are met //
    public static bool IsOver(int score, List<string> cards)
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
        else if(playAgain() == true)
        {
            return false;
        }
        else
        {
            return true;
        }   
    }

    // Draws a card from the deck and returns said card as an integer //
    public static int cardDrawn(List<string> cards)
    {
        CardDeck deck = new CardDeck();

        string card = deck.draw(cards);

        int cardNumber = deck.convert(card);

        return cardNumber;
    }

    // Holds all the console.writeline code, as well as the score calculator. //
    public static void terminalDialogue(int score, List<string> cards, int first)
    {
        CardDeck deck = new CardDeck();

        int second = cardDrawn(cards);

        Console.WriteLine($"The card is: {first}");
        Console.WriteLine("Higher or lower? [h/l]");
        string? input = Console.ReadLine() ?? "";
        Console.WriteLine($"Next card was: {second}");

        scoreCalculator(input, first, second, score);

        Console.WriteLine($"Your score is: {score}");

        first = second;
    }

    // checks if the first instance of the deck drawn is greater or lower, and compares that with the user's input //
    public static void scoreCalculator(string input, int first, int second, int score)
    {
        if(input == "h" && second > first)
        {
            score += 100;
        }
        else if(input == "h" && second < first)
        {
            score -= 75;
        }
        else if(input == "l" && second < first)
        {
            score += 100;
        }
        else if(input == "l" && second > first)
        {
            score -= 75;
        }
        else if(input != "l" || input != "h")
        {
            Console.WriteLine("ERROR");
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