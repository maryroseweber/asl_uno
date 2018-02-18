// This is a data-only object that will contain rules for the game
// This class will be persisted and can be loaded/unloaded/shared/etc....

public class Rules {

    // Can players immediately play a card they just drew IF it is legal to do so?
    public bool CanPlayDrawnCard = true;

    // What is the maximum number of players (human or bot) that are allowed?
    public int MaximumPlayerCount = 4;

    // Can the game play itself without any human players?
    public bool AllowSelfPlay = true;

    // Are remote (Internet) players allowed?
    public bool AllowRemotePlayers = false; // not implemented yet

    // How many points must players score to win the game?
    // If this number is zero, then only 1 round is played, and the first person to have zero cards in their hand wins the game
    // If this number is non-zero, then multiple rounds are played and the first person to reach this score is the winner
    // If using standard UNO rules, this number would be 500
    public int WinningScore = 0;

    // What is the default play direction?
    public unodirection DefaultPlayDirection = unodirection.clockwise;

    // What is the deck composition?
    public class DeckComposition
    {
        public int[] BlueNumberCards = new int[19] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int[] GreenNumberCards = new int[19] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int[] RedNumberCards = new int[19] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int[] YellowNumberCards = new int[19] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int DrawTwoCardsPerColor = 2;
        public int ReverseCardsPerColor = 2;
        public int SkipCardsPerColor = 2;
        public int WildCards = 4;
        public int WildDrawFourCards = 4;
    }

    // How many points are each card worth?
    // This is only used if the WinningScore is non-zero
    // Number cards are assumed to have point values equal to their face value
    public class PointValues
    {
        public int DrawTwo = 20;
        public int Reverse = 20;
        public int Skip = 20;
        public int Wild = 50;
        public int WildDrawFour = 50;
    }

    // How many cards are initially dealt to each player?
    public int StartingDealCardCount = 7;

    // What types of matches are allowed?
    public unomatchtype LegalMatches = unomatchtype.matchColor | unomatchtype.matchNumber | unomatchtype.matchWord;

    // Does a player have to keep drawing until they can play?
    // This is a popular home rule
    public bool MustDrawUntilCanPlay = false;

    // Can a player play a WildDrawFour at any time?
    // Standard UNO rules would set this to false, meaning that a WildDrawFour can only be played if it is the ONLY card a player can legally play
    public bool WildDrawFourAnyTime = false;

    // Can a player play a WildCard at any time?
    // Standard UNO rules would set this to true, meaning that a Wild card can be played at any time  even if a player could legally play another card
    public bool WildAnyTime = true;

    // How many cards must a player draw if they have played a WildDrawFour card and were caught cheating?
    // This is only applicable when WildDrawFourAnyTime is false
    public int WildDrawFourCheatPenalty = 4;

    // How many cards must a player draw if they challenged a WildDrawFour card, but the challenged player was NOT chearing?
    // This is IN ADDITION to the four cards that must be drawn due to the Draw Four card itself
    // This is only applicable when WildDrawFourAnyTime is false
    public int WildDrawFourLegalPenalty = 2;



}
