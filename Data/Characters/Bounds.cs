using BallDrive.Data.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDrive.Data.Characters.Enemies
{
    public class Bounds
    {

        public int BoundX { get; set; }
        public int BoundY { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int offsetX { get; set; }
        public int offsetY { get; set; }

        public Bounds(int boundsX, int boundsY, int width, int height)
        {
            this.BoundX = boundsX;
            this.BoundY = boundsY;
            this.Width  = width;
            this.Height = height;
        }
        public Bounds(int boundsX, int boundsY, int width, int height, int offSetX, int offSetY): this(boundsX, boundsY, width, height)
        {
            this.offsetX = offsetX;
            this.offsetY = offsetY;
        }

        public ControlHandler.Directions getSpawnArea()
        {
            if (BoundX < Width / 2 && BoundY > Height / 2)
                return ControlHandler.Directions.SOUTH_WEST;
            if (BoundX < Width / 2 && BoundY < Height / 2)
                return ControlHandler.Directions.NORTH_WEST;
            if (BoundX > Width / 2 && BoundY > Height / 2)
                return ControlHandler.Directions.SOUTH_EAST;
            if (BoundX > Width / 2 && BoundY < Height / 2)
                return ControlHandler.Directions.NORTH_EAST;

            return ControlHandler.Directions.NORTH_WEST;
        }
    }
}
