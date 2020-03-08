using NUnit.Framework;
using PockerHandShowDown;
using PokerHandShowDown;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandShowDownTest
{
    //[TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFindPairs()
        {
            var list = new List<Card>() { new Card { Rank = Rank.Three, Suit = Suit.Heart   },
                                          new Card { Rank = Rank.Four,  Suit = Suit.Diamond },
                                          new Card { Rank = Rank.Nine, Suit = Suit.Clubs    },
                                          new Card { Rank = Rank.Nine, Suit = Suit.Diamond  },
                                          new Card { Rank = Rank.Queen, Suit = Suit.Heart   }
            };

            PokerGame pg = new PokerGame();
            var result = pg.findPairs(list);
            Assert.AreEqual(2, result.Item2);
        }
        [Test]
        public void TestFlush()
        {
            
            var list = new List<Card>() { new Card { Rank = Rank.Three, Suit = Suit.Diamond },
                                          new Card { Rank = Rank.Four,  Suit = Suit.Diamond },
                                          new Card { Rank = Rank.Nine, Suit = Suit.Diamond  },
                                          new Card { Rank = Rank.Nine, Suit = Suit.Diamond  },
                                          new Card { Rank = Rank.Queen, Suit = Suit.Diamond }};

            PokerGame pg = new PokerGame();
            bool result = pg.IsFlush(list);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void TestFlush2()
        {

            var list = new List<Card>() { new Card { Rank = Rank.Three, Suit = Suit.Diamond  },
                                          new Card { Rank = Rank.Four,  Suit = Suit.Diamond  },
                                          new Card { Rank = Rank.Nine, Suit = Suit.Heart     },
                                          new Card { Rank = Rank.Nine, Suit = Suit.Diamond   },
                                          new Card { Rank = Rank.Queen, Suit = Suit.Diamond  }};

            PokerGame pg = new PokerGame();
            bool result = pg.IsFlush(list);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void testHighestCardInHand()
        {
            var p1 = new Player("Joe", new List<Card>() { new Card { Rank = Rank.Jack, Suit = Suit.Heart  },
                                                                  new Card { Rank = Rank.Four,  Suit = Suit.Diamond  },
                                                                  new Card { Rank = Rank.Nine, Suit = Suit.Clubs },
                                                                  new Card { Rank = Rank.Nine, Suit = Suit.Diamond  },
                                                                  new Card { Rank = Rank.Queen, Suit = Suit.Heart }});//create poker player
            var p2 = new Player("Gen", new List<Card>() { new Card { Rank = Rank.Five, Suit = Suit.Clubs  },
                                                                  new Card { Rank = Rank.Seven,  Suit = Suit.Diamond  },
                                                                  new Card { Rank = Rank.Nine, Suit = Suit.Heart },
                                                                  new Card { Rank = Rank.Nine, Suit = Suit.Spades  },
                                                                  new Card { Rank = Rank.Queen, Suit = Suit.Spades }});

            PokerGame pg = new PokerGame();
            var result = pg.findPlayerWithHighCard(p1, p2);
            Assert.AreEqual(p1, result);

        }
        [Test]
        public void TestIsCategoryFlush()
        {
            List<Player> Players = new List<Player>();
            PokerGame FirstGame = new PokerGame();//Create game object

            Players.Add(new Player("Joe", new List<Card>() { new Card { Rank = Rank.Three, Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Four,  Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Diamond },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Queen, Suit = Suit.Diamond }}));//create poker player
            Players.Add(new Player("Gen", new List<Card>() { new Card { Rank = Rank.Five, Suit = Suit.Clubs  },
                                                              new Card { Rank = Rank.Seven,  Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Heart },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Spades  },
                                                              new Card { Rank = Rank.Queen, Suit = Suit.Spades }}));
            Players.Add(new Player("Bob", new List<Card>() { new Card { Rank = Rank.Two, Suit = Suit.Heart  },
                                                              new Card { Rank = Rank.Two,  Suit = Suit.Clubs  },
                                                              new Card { Rank = Rank.Five, Suit = Suit.Spades },
                                                              new Card { Rank = Rank.Ten, Suit = Suit.Clubs  },
                                                              new Card { Rank = Rank.Ace, Suit = Suit.Heart  }}));


           List<Player> winners =  FirstGame.GetWinner(Players);
            Assert.AreEqual("Joe", winners.First().PName);
        }

        [Test]
        public void TestIsCategoryThreeOfaKind()
        {
            List<Player> Players = new List<Player>();
            PokerGame FirstGame = new PokerGame();//Create game object


            Players.Add(new Player("Joe", new List<Card>() { new Card { Rank = Rank.Three, Suit = Suit.Heart  },
                                                         new Card { Rank = Rank.Three,  Suit = Suit.Heart  },
                                                         new Card { Rank = Rank.Three, Suit = Suit.Heart },
                                                         new Card { Rank = Rank.Jack, Suit = Suit.Diamond  },
                                                         new Card { Rank = Rank.King, Suit = Suit.Heart }}));

            List<Player> winners = FirstGame.GetWinner(Players);

            Assert.AreEqual("Joe", winners.First().PName);
        }
        [Test]
        public void TestIsCategoryPair()
        {
            List<Player> Players = new List<Player>();
            PokerGame FirstGame = new PokerGame();//Create game object

            Players.Add(new Player("Joe", new List<Card>() { new Card { Rank = Rank.Three, Suit = Suit.Heart  },
                                                         new Card { Rank = Rank.Six,  Suit = Suit.Heart  },
                                                         new Card { Rank = Rank.Eight, Suit = Suit.Heart },
                                                         new Card { Rank = Rank.Jack, Suit = Suit.Heart  },
                                                         new Card { Rank = Rank.King, Suit = Suit.Heart }}));

            List<Player> winners = FirstGame.GetWinner(Players);

            Assert.AreEqual("Joe", winners.First().PName);
        }

        [Test]
        public void CheckGame1()
        {
            List<Player> Players = new List<Player>();
            PokerGame FirstGame = new PokerGame();//Create game object

            Players.Add(new Player("Joe", new List<Card>() { new Card { Rank = Rank.Three, Suit = Suit.Heart  },
                                                              new Card { Rank = Rank.Four,  Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Clubs },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Queen, Suit = Suit.Heart }}));//create poker player
            Players.Add(new Player("Jen", new List<Card>() { new Card { Rank = Rank.Five, Suit = Suit.Clubs  },
                                                              new Card { Rank = Rank.Seven,  Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Heart },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Spades  },
                                                              new Card { Rank = Rank.Queen, Suit = Suit.Spades }}));
            Players.Add(new Player("Bob", new List<Card>() { new Card { Rank = Rank.Two, Suit = Suit.Heart  },
                                                              new Card { Rank = Rank.Two,  Suit = Suit.Clubs  },
                                                              new Card { Rank = Rank.Five, Suit = Suit.Spades },
                                                              new Card { Rank = Rank.Ten, Suit = Suit.Clubs  },
                                                              new Card { Rank = Rank.Ace, Suit = Suit.Heart  }}));


            List<Player> winners = FirstGame.GetWinner(Players);

            Assert.AreEqual("Jen", winners.First().PName);
        }
        [Test]
        public void CheckGame2()
        {
            List<Player> Players = new List<Player>();


            PokerGame FirstGame = new PokerGame();//Create game object

            Players.Add(new Player("Joe", new List<Card>() {  new Card { Rank = Rank.Three, Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Four,  Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Diamond },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Queen, Suit = Suit.Diamond }}));//create poker player
            Players.Add(new Player("Jen", new List<Card>() {  new Card { Rank = Rank.Five, Suit = Suit.Clubs  },
                                                               new Card { Rank = Rank.Queen,  Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Queen, Suit = Suit.Heart },
                                                               new Card { Rank = Rank.Queen, Suit = Suit.Spades  },
                                                              new Card { Rank = Rank.Queen, Suit = Suit.Spades }}));
            Players.Add(new Player("Bob", new List<Card>() { new Card { Rank = Rank.Two, Suit = Suit.Heart  },
                                                              new Card { Rank = Rank.Two,  Suit = Suit.Clubs  },
                                                              new Card { Rank = Rank.Five, Suit = Suit.Spades },
                                                              new Card { Rank = Rank.Ten, Suit = Suit.Clubs  },
                                                              new Card { Rank = Rank.Ace, Suit = Suit.Heart  }}));


            List<Player> winners = FirstGame.GetWinner(Players);

            Assert.AreEqual("Joe", winners.First().PName);
        }
        [Test]
        public void CheckGame3()
        {
            List<Player> Players = new List<Player>();


            PokerGame FirstGame = new PokerGame();//Create game object

            Players.Add(new Player("Joe", new List<Card>() {  new Card { Rank = Rank.Three, Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Four,  Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Diamond },
                                                              new Card { Rank = Rank.Nine, Suit = Suit.Diamond  },
                                                              new Card { Rank = Rank.Queen, Suit = Suit.Diamond }}));//create poker player
            Players.Add(new Player("Jen", new List<Card>() {  new Card { Rank = Rank.Five, Suit = Suit.Clubs  },
                                                               new Card { Rank = Rank.Queen,  Suit = Suit.Clubs  },
                                                              new Card { Rank = Rank.Queen, Suit = Suit.Clubs },
                                                               new Card { Rank = Rank.Queen, Suit = Suit.Clubs  },
                                                              new Card { Rank = Rank.Queen, Suit = Suit.Clubs }}));
            Players.Add(new Player("Bob", new List<Card>() { new Card { Rank = Rank.Two, Suit = Suit.Heart  },
                                                              new Card { Rank = Rank.Two,  Suit = Suit.Clubs  },
                                                              new Card { Rank = Rank.Five, Suit = Suit.Spades },
                                                              new Card { Rank = Rank.Ten, Suit = Suit.Clubs  },
                                                              new Card { Rank = Rank.Ace, Suit = Suit.Heart  }}));


            List<Player> winners = FirstGame.GetWinner(Players);

            Assert.AreEqual("Jen", winners.First().PName);
        }
    }
}