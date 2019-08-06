using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace Cycle_Race
{
    public partial class Form1 : Form
    {

        private BetPlacer[] bettor = new BetPlacer[3];
        private Cyclists[] cyclist = new Cyclists[4];
        public string winningCyclist;
        public Random random = new Random();
        private string[] bettors = new string[3] { "Nick", "Nicolas", "Creamie" };          // Please change the names here according to your needs as these were only placeholder names
        private int player1 = 0, player2 = 0, player3 = 0;
        private bool betPlaced;

        public Form1()
        {
            InitializeComponent();

            bettor[0] = new BetPlacer() { cash = 50, label = player1Bet, btnRadio = radioButton1, name = bettors[0] };
            bettor[1] = new BetPlacer() { cash = 75, label = player2Bet, btnRadio = radioButton2, name = bettors[1] };
            bettor[2] = new BetPlacer() { cash = 45, label = player3Bet, btnRadio = radioButton3, name = bettors[2] };

            cyclist[0] = new Cyclists() { name = "Julian ALAPHILIPPE", cycle = cycleBlack, raceTrackLength = raceTrack.Width - cycleBlack.Width, startingPosition = cycleBlack.Left };
            cyclist[1] = new Cyclists() { name = "Egan Arley BERNAL GÓMEZ", cycle = cycleBlue, raceTrackLength = raceTrack.Width - cycleBlack.Width, startingPosition = cycleBlue.Left };
            cyclist[2] = new Cyclists() { name = "Jakob FUGLSANG", cycle = cycleRed, raceTrackLength = raceTrack.Width - cycleBlack.Width, startingPosition = cycleRed.Left };
            cyclist[3] = new Cyclists() { name = "Primož ROGLIČ", cycle = cycleYellow, raceTrackLength = raceTrack.Width - cycleBlack.Width, startingPosition = cycleYellow.Left };

            bettor[0].UpdateLabels();
            bettor[1].UpdateLabels();
            bettor[2].UpdateLabels();

            this.cyclists.FormattingEnabled = true;
            this.cyclists.Items.AddRange(new object[] {
                "Julian ALAPHILIPPE",
                "Egan Arley BERNAL GÓMEZ",
                "Jakob FUGLSANG",
                "Primož ROGLIČ"
            });
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0;  i < cyclist.Length; i++)
            {
                cyclist[random.Next(0, 4)].startRace();
                if (cyclist[i].startRace())
                {
                    timer.Stop();
                    timer.Enabled = false;
                    MessageBox.Show(cyclist[i].name + " has won the race.");
                    winningCyclist = cyclist[i].name;
                    i = cyclist.Length;
                    beginRace.Enabled = true;
                    for (int j = 0; j < bettor.Length; j++)
                    {
                        bettor[j].Collect(winningCyclist);
                    }
                    for (int k = 0; k < cyclist.Length; k++)
                    {
                        cyclist[k].TakeStartPosition();
                    }
                    player1 = 0;
                    player2 = 0;
                    player3 = 0;
                    betPlaced = false;
                }
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Enabled)
                currentBetter.Text = bettors[0];
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Enabled)
                currentBetter.Text = bettors[1];
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Enabled)
                currentBetter.Text = bettors[2];
        }

        private void BeginRace_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < cyclist.Length; j++)
            {
                cyclist[j].TakeStartPosition();
            }
            beginRace.Enabled = false;
            timer.Start();
        }

        private void PlaceBet_Click(object sender, EventArgs e)
        {
            if (currentBetter.Text == bettors[0])
            {
                if (player1 == 0)
                {
                    betPlaced = bettor[0].PlaceBet(Convert.ToInt16(bettingAmount.Value), cyclists.Text.ToString());
                    if (betPlaced)
                    {
                        player1 = 1;
                    }
                    else
                    {
                        MessageBox.Show(bettors[0] + " has already placed a bet");
                    }
                }
            } else if (currentBetter.Text == bettors[1])
            {
                if (player2 == 0)
                {
                    betPlaced = bettor[1].PlaceBet(Convert.ToInt16(bettingAmount.Value), cyclists.Text.ToString());
                    if (betPlaced)
                    {
                        player2 = 1;
                    }
                    else
                    {
                        MessageBox.Show(bettors[1] + " has already placed a bet");

                    }
                }
            } else if (currentBetter.Text == bettors[2])
            {
                if (player3 == 0)
                {
                    betPlaced = bettor[2].PlaceBet(Convert.ToInt16(bettingAmount.Value), cyclists.Text.ToString());
                    if (betPlaced)
                    {
                        player3 = 1;
                    }
                    else
                    {
                        MessageBox.Show(bettors[2] + " has already placed a bet");
                    }
                }
            }
        }
    }
}
