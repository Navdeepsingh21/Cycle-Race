using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cycle_Race
{
    class Cyclists
    {
        public int startingPosition { get; set; }
        public int raceTrackLength { get; set; }
        public string name { get; set; }
        public PictureBox cycle { get; set; }
        public bool winner = false;
        public Random random = new Random();

        public bool startRace()
        {
            int movement = random.Next(1, 8);

            Point point = cycle.Location;
            point.X += movement;
            cycle.Location = point;

            if (point.X >= raceTrackLength)
                return true;
            else
                return false;
        }

        public void TakeStartPosition()
        {
            cycle.Left = startingPosition;
        }
    }
}
