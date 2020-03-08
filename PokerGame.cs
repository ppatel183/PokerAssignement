using PokerHandShowDown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PockerHandShowDown
{
    public class PokerGame
    {

        public List<Player> GetWinner(List<Player> Players)
        {
            List<Player> Winners = new List<Player>();
            Player currentWinner = null;
            bool cuurentWinnerFlush = false;
            Rank currentWinerPairRank = Rank.Two;
            int currentWinerPairCount = 0;
          

            if (Players.Any(x => x.Cards.Count() > 5))
            {
                throw new Exception("Player in the List has more then 5 Cards");
            }
            else
            {

                foreach (Player player in Players)
                {

                    if (currentWinner == null)//assigne default winner
                    {
                        currentWinner = player;
                        cuurentWinnerFlush = IsFlush(currentWinner.Cards);
                        var tuple = findPairs(currentWinner.Cards);
                        currentWinerPairRank = tuple.Item1;
                        currentWinerPairCount = tuple.Item2;
                        continue;
                    }

                    bool p1flush = IsFlush(player.Cards);
                    var p1Pairs = findPairs(player.Cards);

                    // flush check
                    if (p1flush && cuurentWinnerFlush)
                    {
                        currentWinner = findPlayerWithHighCard(currentWinner, player);
                        if (currentWinner == player)
                        {
                            currentWinerPairCount = p1Pairs.Item2;
                            currentWinerPairRank = p1Pairs.Item1;
                            cuurentWinnerFlush = p1flush;
                            continue;
                        }
                    }
                    else if (cuurentWinnerFlush)
                    {
                        continue;
                    }
                    else if (p1flush)
                    {
                        cuurentWinnerFlush = p1flush;
                        currentWinerPairCount = p1Pairs.Item2;
                        currentWinerPairRank = p1Pairs.Item1;
                        currentWinner = player;
                        continue;
                    }

                    // pair match
                    if (p1Pairs.Item2 == currentWinerPairCount)
                    {
                        if (p1Pairs.Item1 == currentWinerPairRank)
                        {
                            currentWinner = findPlayerWithHighCard(currentWinner, player);
                            if (currentWinner == player)
                            {
                                currentWinerPairCount = p1Pairs.Item2;
                                currentWinerPairRank = p1Pairs.Item1;
                                cuurentWinnerFlush = p1flush;
                                continue;
                            }
                        }
                        else if (p1Pairs.Item1 > currentWinerPairRank)
                        {
                            currentWinerPairCount = p1Pairs.Item2;
                            currentWinerPairRank = p1Pairs.Item1;
                            cuurentWinnerFlush = p1flush;
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (currentWinerPairCount > p1Pairs.Item2)
                    {
                        continue;
                    }
                    else if (p1Pairs.Item2 > currentWinerPairCount)
                    {
                        currentWinerPairCount = p1Pairs.Item2;
                        currentWinerPairRank = p1Pairs.Item1;
                        cuurentWinnerFlush = p1flush;
                        currentWinner = player;
                        continue;
                    }
                    // high card
                    currentWinner = findPlayerWithHighCard(currentWinner, player);
                    if (currentWinner == player)
                    {
                        currentWinerPairCount = p1Pairs.Item2;
                        currentWinerPairRank = p1Pairs.Item1;
                        cuurentWinnerFlush = p1flush;
                    }

                }

            }
            Winners.Add(currentWinner);
            return Winners;
        }

      
        public Player findPlayerWithHighCard(Player p1, Player p2)
        {
            List<Card> p1Order = p1.Cards.Select(x => x).OrderByDescending(x => x.Rank).ToList();
            List<Card> p2Order = p2.Cards.Select(x => x).OrderByDescending(x => x.Rank).ToList();

            for (int i = 0; i < 5; i++)
            {
                Card c1 = p1Order[i];
                Card c2 = p2Order[i];

                if (c1.Rank > c2.Rank)
                {
                    return p1;
                } 
                else if (c2.Rank > c1.Rank)
                {
                    return p2;
                }
            }
         
            return null;
        }

        public Tuple<Rank, int> findPairs(List<Card> cards)
        {
            var f = cards.GroupBy(x => x.Rank)
                .Select(t => new { Rank = t.Key, Count = t.Count() })
                .OrderByDescending(x => x.Count)
                .First();

            return new Tuple<Rank, int>(f.Rank, f.Count);
        }

        public bool IsFlush(List<Card> Cards)
        {
            return Cards.GroupBy(x => x.Suit).Count() == 1 ? true : false;
        }
    }
}
