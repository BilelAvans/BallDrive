using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace BallDrive.Data.Characters.Enemies
{
    public class TeleportingNPC: NPC
    {

        private int teleportCounter = 0;
        private int maxTeleports = 0;

        public TeleportingNPC(int x, int y): base(x, y)
        {
            this.currentColor = Colors.Orange;
        }

        public bool lifeCycleEnded() {

            if (base.lifecycleEnded() || teleportCounter == maxTeleports)
                return true;

            return false;

        }

    }
}
