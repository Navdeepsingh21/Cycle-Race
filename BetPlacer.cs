using System.Windows.Forms;

namespace Cycle_Race
{
    class BetPlacer
    {
        public Bet bet;
        public int cash { get; set; }
        public RadioButton btnRadio { get; set; }
        public Label label { get; set; }
        public int amount { get; set; }
        public string name { get; set; }

        public void UpdateLabels()
        {
            btnRadio.Text = name + " has $" + cash;
        }

        public void ClearBet()
        {
            bet = null;
            label.Text = name + " hasn't placed a bet!";
        }

        public bool PlaceBet(int betAmount, string winningCyclist)
        {
            this.bet = new Bet() { amount = betAmount, betPlacer = this, cyclist = winningCyclist };
            if (betAmount <= cash)
            {
                label.Text = this.name + " bets $" + betAmount + " on " + winningCyclist;
                this.UpdateLabels();
                return true;
            }
            else
            {
                MessageBox.Show(name + " does not have enough money to cover the bet.");
                return false;
            }
        }

        public void Collect(string winner)
        {
            if (bet != null)
            {
                cash += bet.Payout(winner);
            }
            ClearBet();
            UpdateLabels();
        }
    }
}
