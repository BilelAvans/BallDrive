using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Shapes;
using Windows.System;
using Windows.UI;

namespace BallDrive.Data.Characters
{
    public class NPC : Character
    {

        private DateTime spawnTime;
        public TimeSpan timeToLive { get; set; }

        public int[] Destination { get; set; }

        public NPC(int x, int y) : base(x, y, 10, 25, Colors.Cyan)
        {
            this.spawnTime      =   DateTime.Now;
            this.timeToLive     =   TimeSpan.FromSeconds(15);
        }


        public bool lifecycleEnded()
        {
            if (timeToLive != null) {
                // Kill after x amount of time
                if (DateTime.Now - this.spawnTime > timeToLive)
                    return true;
            }
            
            return false; 
        }
        
    }
}
