﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVM_Sorteper.Models
{
    class OldMaidGame : Game
    {
        public OldMaidGame()
        {
            this.gameName = "Old Maid Card Game";
            this.deck = new OldMaidDeck();
        }

    }
}
