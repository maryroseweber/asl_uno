using System;


public enum unocolor
{
    none=0, // for wild cards
    blue=1,
    green=2,
    red=3,
    yellow=4,
    count=5 // for iteration
};

public enum unoword
{
    none=0, // for non-word cards
    drawTwo=1,
    reverse=2,
    skip=3,
    wild=4,
    wildDrawFour=5,
    count=6 // for iteration
}

public enum unodirection
{
    clockwise=0,
    counterclockwise=1
}

[Flags]
public enum unomatchtype
{
    matchNone = 0,
    matchColor = 1,
    matchNumber = 2,
    matchWord = 4,

}

public enum unocardlocation
{
    drawDeck = 0,
    discardDeck = 1,
    playerHand = 2
}

