using System;
using System.Collections.Generic;

public static class Game
{

    private static List<IPlayer> players;
    private static IPlayer currentPlayer;
    private static Rules currentRules = new Rules();

    private static bool AiCanPlayerPlay(IPlayer player)
    {
        return false;
    }
    private static void AiChooseCardToPlayer(IPlayer player)
    {

    }
    private static void StartGameDealCards()
    {
        // need to implement

    }
    // Message PlayerHasNoCards(Player)

    private static void ResetGame()
    {
        // clear the players array to create a "new" set of players
        players.Clear();

        // create the bots
        for (int i = 0; i < (currentRules.MaximumPlayerCount - 1); i++)
        {
            players.Add(new PlayerBot());
        }

        // create the human player
        players.Add(new PlayerHuman());

    }
    private static void EndPlayerTurn()
    {

    }

    private static bool PlayingClockwise = true;

    private static IPlayer NextPlayer = null;

    private static DeckBase Deck;


    private static void Reset()
    {

    }


}
