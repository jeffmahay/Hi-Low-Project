class CardDeck
{
    List<string> cards = new List<string>(); // Creates the data type for the cards to be stored in

    public CardDeck() // Digitally creates the card deck
    {
        string[] suits = {"Hearts", "Spades", "Clubs", "Diamonds"};
        string[] faces = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};

        foreach (string a in suits)
        {
            foreach (string b in faces)
            {
                cards.Add($"{b} of {a}");
            }
        }
    }

    public string draw(List<string> cards) // Draws a card from the deck at random
    {
        if (cards.Count > 0)
        {
            var random = new Random();
            int i = random.Next(cards.Count);
            string drawn = cards[i];
            cards.Remove(drawn);
            return drawn;
        }
        else
        {
            return "out";
        }
        
    }

    public int convert(string drawn) // Convert card names into number for the game
    {
        string[] parts = drawn.Split(" of ");
        if (parts[1] == "Ace")
        {
            return 13;
        }
        else if (parts[1] == "Jack")
        {
            return 10;
        }
        else if (parts[1] == "Queen")
        {
            return 11;
        }
        else if (parts[1] == "King")
        {
            return 12;
        }
        else
        {
            return int.Parse(parts[1]);
        }
    }
}