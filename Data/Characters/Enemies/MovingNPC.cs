using BallDrive.Data.Characters.Enemies;
using BallDrive.Data.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace BallDrive.Data.Characters
{

    public class MovingNPC: NPC
    {

        public Bounds bounds { get; set; }

        public int DirectionInDegrees { get; set; }

        public MovingNPC(int x, int y, int moveSpeed): base(x, y)
        {
            bounds = new Bounds(x, y, 400, 600);
            DirectionInDegrees = randomDegrees();
            this.Speed = moveSpeed;
            this.currentColor = Colors.Chocolate;
        }

        public MovingNPC(int x, int y) : this(x, y, 10)
        {
            
        }

        public int randomDegrees()
        {
            Random random = new Random();
            ControlHandler.Directions direct = bounds.getSpawnArea();
            if (direct == ControlHandler.Directions.NORTH_WEST)
                return 90 + random.Next(90);
            else if (direct == ControlHandler.Directions.NORTH_EAST)
                return 180 + random.Next(90);
            else if (direct == ControlHandler.Directions.SOUTH_EAST)
                return 270 + random.Next(90);
            else /*if (direct == ControlHandler.Directions.SOUTH_WEST)*/
                return 0 + random.Next(90);

        }
        
        public new bool lifecycleEnded()
        {
            if (this.outOfBounds(bounds.Width, bounds.Height) || base.lifecycleEnded())
                return true;

            return false;
        }
    }
}
