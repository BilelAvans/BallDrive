using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BallDrive.Data.Characters.Items;

namespace BallDrive.Data.Characters.Enemies
{
    public static class CharacterFactory
    {
        public static int Width = 400, Height = 600;

        public static NPC RandomNPC(int width, int height)
        {
            Tuple<int, int> randoms = randomXY(width, height);
            NPC npc = new NPC(randoms.Item1, randoms.Item2);
            return npc;
        }

        public static NPC RandomMovingNPC(int width, int height)
        {
            Tuple<int, int> randoms = randomXY(width, height);
            MovingNPC npc = new MovingNPC(randoms.Item1, randoms.Item2);
            return npc;
        }

        public static NPC RandomBombNPC(int width, int height)
        {
            Tuple<int, int> randoms = randomXY(width, height);
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


        public static Item RandomStarItem(int width, int height)
        {
            Tuple<int, int> randoms = randomXY(400, 600);
            Item item = new StarModeItem(randoms.Item1, randoms.Item2);
            return item;
        }

        public static Item RandomMultiplyerEnhancer(int width, int height)
        {
            Tuple<int, int> randoms = randomXY(400, 600);
            Item item = new MultiplyerEnhancerItem(randoms.Item1, randoms.Item2);
            return item;
        }

        public static Item RandomShooterItem(int width, int height)
        {
            Tuple<int, int> randoms = randomXY(400, 600);
            Item item = new ShooterItem(randoms.Item1, randoms.Item2);
            return item;
        }

        public static Item RandomSpeedBoostItem(int width, int height)
        {
            Tuple<int, int> randoms = randomXY(400, 600);
            SpeedBoostItem item = new SpeedBoostItem(randoms.Item1, randoms.Item2);
            return item;
        }


        public static Item RandomItem(int width, int height)
        {
            int number = (new Random()).Next(9);

            if (number < 3)
                return RandomStarItem(width, height);
            if (number <= 6)
                return RandomShooterItem(width, height);
            if (number <= 9)
                return RandomSpeedBoostItem(width, height);
            
            return (Item)RandomMultiplyerEnhancer(width, height);
        }
    }
}
