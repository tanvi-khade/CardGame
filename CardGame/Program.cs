// See https://aka.ms/new-console-template for more information
using CardGame.Models;

Console.WriteLine("Hello, World!");

Deck deck = new Deck();
deck.DisplayDeck();

Console.WriteLine(deck.Cards.Count);
Console.WriteLine("Shuffling Cards... ");

deck.Shuffle();
Console.WriteLine("Shuffled Cards: ");
deck.DisplayDeck();

Console.WriteLine("Enter number of players:");
int numberOfPlayers = Convert.ToInt16(Console.ReadLine());
Console.WriteLine("Enter number of cards per player");
int numberOfCards = Convert.ToInt16(Console.ReadLine());

if (numberOfPlayers * numberOfCards > deck.Cards.Count)
{
    Console.WriteLine("Cannot play game with the entered combination of players and cards");
    Console.ReadLine();
    return;
}

var players = new Player[numberOfPlayers];
for (int i = 0; i < numberOfPlayers; i++)
{
    players[i] = new Player()
    {
        Id = i + 1,
        Cards = new List<Card>()
    };
}

deck.Deal(ref players, numberOfCards);

foreach (var p in players)
{
    Console.WriteLine(p);

}

Console.WriteLine( $"Winner is Player {deck.ChooseWinner(players).Id}");
//deck.DisplayDeck();
//Console.WriteLine(deck.Cards.Count);


Console.ReadLine();