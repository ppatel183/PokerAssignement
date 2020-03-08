using NUnit.Framework;
using PockerHandShowDown;
using PokerHandShowDown;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandShowDownTest
{
    [TestFixture]
    class GameBasicCheck
    {
        [Test]
        public void TestMorethenFiveCard()
        {

            List<Player> Players = new List<Player>();
            PokerGame FirstGame = new PokerGame();//Create game object

            Players.Add(new Player("Joe", new List<Card>() { new Card { Rank = Rank.Three, Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Four,  Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Diamond },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Diamond  },
                                                               new Card { Rank = Rank.Nine, Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Queen, Suit = Suit.Diamond }}));//create poker player
          
            
           var ex =  Assert.Throws<Exception>(() => FirstGame.GetWinner(Players));
            Assert.That(ex.Message,Is.EqualTo("Player in the List has more then 5 Cards"));
        }
    }
}
