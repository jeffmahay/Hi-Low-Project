class player
{


public string Main()
    {
        
    }

public int playerScore()
{
    int score = 300;

    if(guessRight() = true)
    {
        score += 100;
    }
    else if (guessRight() = false)
    {
        score -= 75;
    }
}

public bool guessRight()
{
    if(nextCard() > currentCard())
    {
        return true;
    }
    else if(nextCard() < currentCard())
    {
        return false;
    }
    else if(nextCard() == currentCard())
    {
        return true;
    }
}

public int currentCard()
{

}
public int nextCard()
{

}








}


