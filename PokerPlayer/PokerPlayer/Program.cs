using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var Deck = new Deck();

            Deck.Shuffle();

            PokerPlayer player1 = new PokerPlayer(Deck.Deal(5));
            player1.ShowHand();
            Console.WriteLine();
            
            Console.ReadKey();
        }
    }
}
