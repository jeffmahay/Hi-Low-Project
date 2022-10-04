class CardDeck
{
    List<string> cards = new List<string>(); // Creates the data type for the cards to be stored in

    public CardDeck()
    {
        string[] suits = {"Hearts", "Spades", "Clubs", "Diamonds"};
        string[] faces = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Jack", "Queen", "King"};

        foreach (string a in suits)
        {
            foreach (string b in faces)
            {
                cards.Add($"{b} of {a}");
            }
        }
    }

    public List<string> draw(List<string> cards)
    {
        int i = Random.Next(cards.Count);
    }
}