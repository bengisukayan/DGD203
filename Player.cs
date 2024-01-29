using System;

public class Player
{
    public string playerName;
    public bool sillycatsyndrome;
    public Inventory _bag;

    public Player(string name)
    {
        playerName = name;
        sillycatsyndrome = false;
        _bag = new Inventory(this);
    }
    public void SillyCatSyndrome()
    {
        sillycatsyndrome = true;
        Console.WriteLine("What is going on! You just got too silly.");
    }
}