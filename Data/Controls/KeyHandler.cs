using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDrive.Data.Controls
{
    public class KeyHandler: ControlHandler
    {        
        
        private List<uint> keyhits;
        
        public KeyHandler()
        {
            keyhits = new List<uint>();
        }
        
        public void registerKey(uint scancode) {
            keyhits.Add(scancode);
            calcDirection();
        }

        public void removeKey(uint scancode)
        {
            keyhits.RemoveAll(hit => hit == scancode);
            //Debug.WriteLine("Removed: {0}", scancode);
            calcDirection();
        }

        public void calcDirection() {

            if (keyhits.Contains(72) && keyhits.Contains(75))       // LEFT, UP
                Direction = Directions.NORTH_WEST;
            else if (keyhits.Contains(72) && keyhits.Contains(77))  // RIGHT, UP
                Direction = Directions.NORTH_EAST;
            else if (keyhits.Contains(77) && keyhits.Contains(80))
                Direction = Directions.SOUTH_EAST;
            else if (keyhits.Contains(80) && keyhits.Contains(75))
                Direction = Directions.SOUTH_WEST;
            else if (keyhits.Contains(72))
                Direction = Directions.NORTH;
            else if (keyhits.Contains(75))
                Direction = Directions.WEST;
            else if (keyhits.Contains(77))
                Direction = Directions.EAST;
            else if (keyhits.Contains(80))
                Direction = Directions.SOUTH;
            else 
                Direction = Directions.ON_PAUSE;

        }
    }
}
