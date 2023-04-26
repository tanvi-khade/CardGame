using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Models
{
    public class Player
    {
        public int Id { get; set; }

        public List<Card> Cards { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Player {Id} has: ");
            foreach( var card in Cards)
            {
                stringBuilder.AppendLine( card.ToString() );
            }

            return stringBuilder.ToString();
        }
    }
}
