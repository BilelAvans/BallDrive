using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDrive.Data.Controls
{
    public abstract class ControlHandler
    {
        // Handlers zetten Controls (Toetsenbord, Gyrometer, ...) om naar een Direction
        public enum Directions
        {
            ON_PAUSE,       // zzzzz
            NORTH,
            NORTH_EAST,
            EAST,
            SOUTH_EAST,
            SOUTH,
            SOUTH_WEST,
            WEST,
            NORTH_WEST
        }
        public Directions Direction { get; set; } = Directions.ON_PAUSE;

        public ControlHandler()
        {
        }
    }
}
