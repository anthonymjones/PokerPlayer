using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer
{
    public enum PokerHands
    {
        HighCard,
        OnePair,
        TwoPairs,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }

    class PokerPlayer
    {
        //STEP 1. Delcare Properties
        public List<Cards> Hand { get; set; }
        public PokerHands PokerHands { get; set; }


        //STEP 2. Constructors
        public PokerPlayer(List <Cards> Hand) 
        {
            this.PokerHands = (PokerHands)0;
            this.Hand = Hand;
        }

        //STEP 3. Methods and Functions
        public void DrawHand(List<Cards> HandDealt)
        {
            PokerHands = (PokerHands)0;
            Hand = HandDealt;
        }

        public bool RoyalFlush()
        {
            return this.StraightFlush() && this.Hand.Any(x => x.Rank == Rank.Ace);
        }
        public bool StraightFlush()
        {
            return this.Straight() && this.HasFlush();
        }
        public bool FourOfAKind()
        {
            return this.Hand.GroupBy(x => x.Rank).Count() == 2 && this.Hand.GroupBy(x => x.Rank).Any(x => x.Count() == 4);

        }
        public bool FullHouse()
        {
            return this.Hand.GroupBy(x => x.Rank).Count() == 2 && this.Hand.GroupBy(x => x.Rank).Any(x => x.Count() == 3);

        }
        public bool HasFlush()
        {
            //how to select just one property of an object and get only unique (distinct) values
            //selects only the suits of our cards, takes only the distinct values, and counts them.
            //if there is only 1 suit, it must be a flush
            //.Select > Suit .Distint > .Count(only 1) = true
            return this.Hand.Select(x => x.Suit).Distinct().Count() == 1;
        }
        public bool Straight()
        {
            return this.Hand.Select(x => x.Rank).Distinct().Count() == 5 && (int)this.Hand.OrderByDescending(x => x.Rank).First().Rank - (int)this.Hand.OrderByDescending(x => x.Rank).Last().Rank == 4;
        }
        public bool ThreeOfAKind()
        {
                IEnumerable<IGrouping<Rank, Cards>> groupRankList = this.Hand.GroupBy(x => x.Rank);
                return groupRankList.Where(x => x.Count() == 3).Any();            
        }
        public bool TwoPair()
        {
            return this.Hand.GroupBy(x => x.Rank).Count() == 3 && this.Hand.GroupBy(x => x.Rank).Any(x => x.Count() == 2);

        }
        public bool HasOnePair()
        {
                return this.Hand.Select(x => x.Rank).Distinct().Count() == 4;   
        }
        public bool HighCard()
        {
            return this.Hand.OrderBy(x => x.Rank).Distinct().Count() == 5;
        }
        public void ShowHand()
        {
            if (RoyalFlush())
            {
                PokerHands = (PokerHands)9;
            }
            else if (StraightFlush())
            {
                PokerHands = (PokerHands)8;
            }
            else if (FourOfAKind())
            {
                PokerHands = (PokerHands)7;
            }
            else if (FullHouse())
            {
                PokerHands = (PokerHands)6;
            }
            else if (HasFlush())
            {
                PokerHands = (PokerHands)5;
            }
            else if (Straight())
            {
                PokerHands = (PokerHands)4;
            }
            else if (ThreeOfAKind())
            {
                PokerHands = (PokerHands)3;
            }
            else if (TwoPair())
            {
                PokerHands = (PokerHands)2;
            }
            else if (HasOnePair())
            {
                PokerHands = (PokerHands)1;
            }
            Console.WriteLine(PokerHands);
        }
        public void GetHand()
        {
            Console.WriteLine(this.Hand);
        }
    }
}
