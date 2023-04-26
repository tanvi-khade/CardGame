using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Models
{
    public class Card
    {
        public CardSuit Suit { get; set; }

        public int FaceValue { get; set; }

        public override string ToString()
        {
            var faceValue = FaceValue.ToString();

            switch (faceValue)
            {
                case "1":
                    {
                        faceValue = "Ace";
                        break;
                    }
                case "11":
                    {
                        faceValue = "Jack";
                        break;
                    }
                case "12":
                    {
                        faceValue = "Queen";
                        break;
                    }
                case "13":
                    {
                        faceValue = "King";
                        break;
                    }
            }

            return $"{faceValue} of {Suit} ";
        }
    }
}
