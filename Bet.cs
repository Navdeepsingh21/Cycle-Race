using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycle_Race
{
    class Bet
    {
        public int amount { get; set; }
        private int winningMultiplier = 4;          // This value holds the value for how much does player win (e.g. Bet Placed = 40$ so the winning will be 40 * winning multipler = 160)
        public string cyclist { get; set; }
        public BetPlacer betPlacer = new BetPlacer();

        public string GetDescription()
        {
            if (amount == 0)
                return betPlacer.name + " hasn't placed a bet.";
            else
                return betPlacer.name + " placed bet of $" + amount + " on " + cyclist;
        }

        public int Payout(string winner)
        {
            if (winner == cyclist)
                return amount * winningMultiplier;
            else
                return (0 - amount);
        }
    }
}
