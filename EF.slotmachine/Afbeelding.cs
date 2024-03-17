using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.slotmachine
{
    internal class Afbeelding
    {
        // private string[] collectie = new string[9] { "aardbei.png", "appel.png", "banaan.png", "kers.png", "kiwi.png", "peer.png", "perzik.png", "pompoen.png", "sinaas.png" };
        private string[] collectie = new string[5] { "aardbei.png", "appel.png", "banaan.png", "kers.png", "peer.png" };
        private Random rnd = new Random();

        public string Spin()
        {
            return collectie[rnd.Next(0, collectie.Length-1)];
        }
    }
}
