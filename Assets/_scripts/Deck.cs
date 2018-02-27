using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    // a deck is a FILO collection of cards, so we'll use a stack
    [SerializeField]
    private Stack<Card> deck;

    public Deck()
    {
        deck = new Stack<Card>();
    }

    public void AddCard(Card card)
    {
        deck.Push(card);
    }

    public Card ViewTopCard()
    {
        return deck.Peek();
    }

    public void RemoveTopCard()
    {
        deck.Pop();
    }

    public int GetCardCount()
    {
        return deck.Count;
    }

    public void PopulateTestDeck()
    {
        EmptyDeck();
        AddCard(new Card(3, unocolor.red, unoword.none)); // Red 3
        AddCard(new Card(2, unocolor.red, unoword.none)); // Red 2
        AddCard(new Card(2, unocolor.blue, unoword.none)); // Blue 2
        AddCard(new Card(0, unocolor.none, unoword.wildDrawFour));  // Wild Draw Four
    }

    public void EmptyDeck()
    {
        deck.Clear();
    }

    public bool Test()
    {
        bool retval = true;

        PopulateTestDeck();
        
        if (retval)
        {
            // test to make sure the cards were stored in the correct order - top card whould be the WildDrawFour
            Card topCard = ViewTopCard();
            retval = topCard.Number() == 0 && topCard.Color() == unocolor.none && topCard.Word() == unoword.wildDrawFour;
            TestRunner.LogTestResult(retval, "DeckBase.Test.1 Cards Stored In Correct Order");
        }

        if (retval)
        {
            // test to make sure cards can be removed from deck and will remain in the correct order
            // after removing a card, the top card should be a Blue 2
            RemoveTopCard();
            Card topCard = ViewTopCard();
            retval = topCard.Number() == 2 && topCard.Color() == unocolor.blue && topCard.Word() == unoword.none;
            TestRunner.LogTestResult(retval, "DeckBase.Test.2 Cards Remain In Correct Order After Removing Top Card");
        }


        return retval;

    }
}
