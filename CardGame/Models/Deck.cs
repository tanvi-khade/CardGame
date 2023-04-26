using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Models
{
    public class Deck
    {
        public List<Card> Cards { get; set; }


        public void DisplayDeck()
        {
            foreach (var card in Cards)
            {
                Console.WriteLine(card.ToString());
            }
        }

        public void Shuffle()
        {
            var random = new Random();

            for (int i = 0; i < Cards.Count; i++)
            {
                var randomIndex = random.Next(i, Cards.Count - 1);
                var cardOne = Cards[randomIndex];
                var cardTwo = Cards[i];

                Cards.RemoveAt(randomIndex);
                Cards.Insert(randomIndex, cardTwo);

                Cards.RemoveAt(i);
                Cards.Insert(i, cardOne);
            }
        }

        public void Deal(ref Player[] players, int numberOfCardsPerPlayer)
        {
            foreach (var player in players)
            {
                var cards = Cards.Take(numberOfCardsPerPlayer);
                player.Cards = cards.ToList();
                Cards.RemoveRange(0, numberOfCardsPerPlayer - 1);
            }
        }

        public Player ChooseWinner(Player[] players)
        {
            var winner = players.Where(p => p.Cards.Sum(c => c.FaceValue) == players.Select(p => new { sum = p.Cards.Sum(c => c.FaceValue) }).Max(s => s.sum)).FirstOrDefault();
                //players.Select(p => new { p.Id, sum = p.Cards.Sum(c => c.FaceValue) }).Max(s => s.sum);
            return winner;
        }


        public Deck()
        {
            Cards = new List<Card>();

            Array suits = Enum.GetValues(typeof(CardSuit));

            foreach (CardSuit suit in suits)
            {
                for (int i = 1; i <= 13; i++)
                {
                    Cards.Add(new Card
                    {
                        Suit = suit,
                        FaceValue = i
                    });
                }
            }
        }
    }
}
