using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy_Chicken
{
    class Player
    {
        public string name;
        public System.Drawing.Color playerColor;
        public int bank = 0;
        public int score = 0;
        public Player(string name, System.Drawing.Color playerColor)
        {
            this.name = name;
            this.playerColor = playerColor;
        }
    }
}
