﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDrive.Data.Controls
{
    public class DifficultySettings
    {
        public enum DIFFICULTY
        {
            EASY,
            NORMAL,
            HARD
        }
        // game total run time
        public TimeSpan gameTimeLength { get; set; }
        // game difficulty
        public DIFFICULTY difficulty { get; set; }

        public TimeSpan timeToLiveCharacters;

        public TimeSpan reduceSpawnTimePerHit;

        public TimeSpan specialPowerSpawnTime;

        private DifficultySettings(DIFFICULTY difficulty)
        {
            this.difficulty = difficulty;
            setDifficultyDependantSettings();
        }

        public void setDifficultyDependantSettings()
        {
            switch (difficulty)
            {
                case DIFFICULTY.EASY:
                    timeToLiveCharacters = TimeSpan.FromSeconds(15);
                    gameTimeLength = TimeSpan.FromSeconds(45);
                    reduceSpawnTimePerHit = TimeSpan.FromMilliseconds(1);
                    specialPowerSpawnTime = TimeSpan.FromSeconds(12);
                    break;
                case DIFFICULTY.NORMAL:
                    timeToLiveCharacters = TimeSpan.FromSeconds(11);
                    gameTimeLength = TimeSpan.FromSeconds(75);
                    reduceSpawnTimePerHit = TimeSpan.FromMilliseconds(2);
                    specialPowerSpawnTime = TimeSpan.FromSeconds(15);
                    break;
                case DIFFICULTY.HARD:
                    timeToLiveCharacters = TimeSpan.FromSeconds(8);
                    gameTimeLength = TimeSpan.FromSeconds(100);
                    reduceSpawnTimePerHit = TimeSpan.FromMilliseconds(3);
                    specialPowerSpawnTime = TimeSpan.FromSeconds(20);
                    break;

            }
        }

        public static DifficultySettings createByDifficulty(DIFFICULTY difficulty)
        {
            switch (difficulty)
            {
                case DIFFICULTY.EASY: return new DifficultySettings(DIFFICULTY.EASY);
                case DIFFICULTY.NORMAL: return new DifficultySettings(DIFFICULTY.NORMAL);
                case DIFFICULTY.HARD: return new DifficultySettings(DIFFICULTY.HARD);
            }

            return null;
        }

        public static DifficultySettings.DIFFICULTY stringToDiff(string diff)
        {
            if (diff.Contains("Easy") || diff.Contains("EASY"))
                return DIFFICULTY.EASY;
            else if (diff.Contains("Normal") || diff.Contains("NORMAL"))
                return DIFFICULTY.NORMAL;
            else
                return DifficultySettings.DIFFICULTY.HARD;
        }

    }
}
