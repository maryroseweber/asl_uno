using UnityEngine;


public class Card {

    [SerializeField]
    private int number;
    [SerializeField]
    private unocolor color;
    [SerializeField]
    private unoword word;
    [SerializeField]
    private unocardlocation location;

    public Card(int n, unocolor c, unoword w)
    {
        number = n;
        color = c;
        word = w;
        location = unocardlocation.drawDeck;

    }

    // we only want these values to be modifiable in the constructor,
    // so we'll use a public functions to get their values
    // it would be nice to use Variable { get; } but that isn't available
    // in the version of C# the Unity supports <<sadness>>

    public int Number()
    {
        return number;
    }
    
    public unocolor Color()
    {
        return color;
    }

    public unoword Word()
    {
        return word;
    }

    public unocardlocation Location()
    {
        return location;
    }

    
}
