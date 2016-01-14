using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDrive.Data.Characters
{
    public static class OverlapCalculator
    {
        /*
        public static bool overlaps(this Character ch, Character ch2)
        {
            // Convert ch  => pointarray
            // Convert ch2 => pointarray

            //Dictionary<int, int> ch1Points = new Dictionary<int, int>();
            if (ch is StoryCharacter && ch2 is StoryCharacter)
            {
                double requiredDistance = ch.Size / 2 + ch2.Size / 2;
                requiredDistance++;

                // check if radius of both circles are in reach
                if (Math.Abs(ch.origin()[0] - ch2.origin()[0]) > requiredDistance && Math.Abs(ch.origin()[1] - ch2.origin()[1]) > requiredDistance) {
                    return true;
                }
            }
            return false;
        }
        */
        public static bool overlapsCircle(this Character ch, Character ch2)
        {
            double requiredDistance = ch.Size / 2 + ch2.Size / 2;
            requiredDistance++;

            // check if radius of both circles are in reach
            if (Math.Abs(ch.origin().X - ch2.origin().X) < requiredDistance && Math.Abs(ch.origin().Y - ch2.origin().Y) < requiredDistance)
            {
                //Debug.WriteLine("Point 1: {0}:{1}, Point 2: {2}:{3} -- {4}", ch.origin().X, ch.origin().Y, ch2.origin().X, ch2.origin().Y, requiredDistance);
                return true;
            }

            return false;
        }

        /*
        public static int[] PointArray()
        {
            // Dictionary Array
            for (int x = 1; x < ch.Size; x += 2)
            {
                for (int y = 1; x < ch.Size; y++)
                {

                }
            }
        }
        */
    }
}
