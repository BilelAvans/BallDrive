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

        public int[] Destination { get; set; }

        private int health;
        public int Health { get { return health; } private set { health = value; Changed("Health"); } }

        public NPC(int x, int y) : base(x, y, 10, 25, Colors.Cyan)
        {
            this.spawnTime      =   DateTime.Now;
            this.timeToLive     =   TimeSpan.FromSeconds(15);
        }

        public NPC(int x, int y, int speed, int size, Color col): base(x, y, speed, size, col)
        {
            this.spawnTime = DateTime.Now;
            this.timeToLive = TimeSpan.FromSeconds(15);
        } 

        public void addHealth(int amount)
        {
            if (health + amount > maxHealth)
                health += 0;
            else
                health += amount;

            if (health < 1)
            {
                // Geen leven meer over
            }
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
