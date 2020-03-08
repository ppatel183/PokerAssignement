using PokerHandShowDown;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PockerHandShowDown
{
    class Program
    {
        static void Main(string[] args)
        {
           List<Player> Players = new List<Player>();
            
            PokerGame FirstGame = new PokerGame();

            Players.Add(new Player("Joe", new List<Card>() { new Card { Rank = Rank.Three,  Suit = Suit.Heart   },
                                                             new Card { Rank = Rank.Four,   Suit = Suit.Diamond },
                                                             new Card { Rank = Rank.Nine,   Suit = Suit.Heart   },
                                                             new Card { Rank = Rank.Nine,   Suit = Suit.Diamond },
                                                             new Card { Rank = Rank.Queen,  Suit = Suit.Heart   }}));
            Players.Add(new Player("Gen", new List<Card>() { new Card { Rank = Rank.Five,   Suit = Suit.Clubs   },
                                                             new Card { Rank = Rank.Seven,  Suit = Suit.Diamond },
                                                             new Card { Rank = Rank.Nine,   Suit = Suit.Heart   },
                                                             new Card { Rank = Rank.Nine,   Suit = Suit.Spades  },
                                                             new Card { Rank = Rank.Queen,  Suit = Suit.Spades  }}));
            Players.Add(new Player("Bob", new List<Card>() { new Card { Rank = Rank.Two,    Suit = Suit.Heart   },
                                                             new Card { Rank = Rank.Two,    Suit = Suit.Clubs   },
                                                             new Card { Rank = Rank.Five,   Suit = Suit.Spades  },
                                                             new Card { Rank = Rank.Ten,    Suit = Suit.Clubs   },
                                                             new Card { Rank = Rank.Ace,    Suit = Suit.Heart   }}));

            

            ////Evaluate and get winner
            List<Player> Winners = FirstGame.GetWinner(Players);

            foreach (Player player in Winners)
            {
                Console.WriteLine(player.PName + " is winner ");
            }
            Console.ReadLine();
        }
    }
}
