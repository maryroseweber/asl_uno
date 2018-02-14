using UnityEngine;

public class Card : MonoBehaviour {

    private int number;
    private unocolor color;
    private unoword word;
    
    public Card(int n, unocolor c, unoword w)
    {
        number = n;
        color = c;
        word = w;

    }
}
