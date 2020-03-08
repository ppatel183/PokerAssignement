using PockerHandShowDown;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandShowDown
{
    public class Player
    {
        public string PName { get; }
        public List<Card> Cards { get; }

        public Player(string pName, List<Card> cards)
        {
            PName = pName;
            Cards = cards;
        }
    }
  
}
