
using System;
using System.Collections.Generic;
using System.Text;

namespace PockerHandShowDown
{
    public class Card
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }
    }
    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
    };
    public enum Suit
    {
        Diamond,
        Heart,
        Spades,
        Clubs
    };
}
