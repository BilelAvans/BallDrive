using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDrive.Data.Characters.Enemies
{
    public static class CharacterFactory
    {
        public static NPC RandomNPC(int width, int height)
        {
            Tuple<int, int> randoms = randomXY(400, 600);
            NPC npc = new NPC(randoms.Item1, randoms.Item2);
            return npc;
        }

        public static NPC RandomMovingNPC(int width, int height)
        {
            Tuple<int, int> randoms = randomXY(400, 600);
            MovingNPC npc = new MovingNPC(randoms.Item1, randoms.Item2);
            return npc;
        }

        public static NPC RandomBombNPC(int width, int height)
        {
            Tuple<int, int> randoms = randomXY(400, 600);
            BombNPC npc = new BombNPC(randoms.Item1, randoms.Item2);
            return npc;
        }

        public static NPC Random(int width, int height)
        {
            
            int number = (new Random()).Next(12);

            if (number < 7)
                return RandomNPC(width, height);
            else if (number <= 9)
                return RandomMovingNPC(width, height);
            else if (number <= 12)
                return RandomBombNPC(width, height);

            return RandomNPC(width, height);
        }

        public static Tuple<int, int> randomXY(int width, int height) {
            Random random = new Random();
            int x = random.Next(width);
            random = new Random(random.GetHashCode());
            int y = random.Next(height);

            return new Tuple<int, int>(x, y);
        }
    }
}
