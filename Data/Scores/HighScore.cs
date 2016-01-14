using BallDrive.Data.Controls;
using BallDrive.Data.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDrive.Data.Scores
{
    public class HighScore
    {

        public string   Name { get; private set; }
        public int      Score { get; private set; }

        public DateTime Time { get; private set; }

        public DifficultySettings.DIFFICULTY Difficulty { get; private set; }

        public HighScore(string name, int score, DateTime time, DifficultySettings.DIFFICULTY difficulty)
        {
            this.Name   = name;
            this.Score  = score;
            this.Time   = time;
            this.Difficulty = difficulty;
        }
        // Constructor for highscore
        public HighScore(string name, int score, DifficultySettings.DIFFICULTY difficulty): this(name, score, DateTime.Now, difficulty)
        {
        }

        public override string ToString() {
            return Name + " had " + Score + " Points at "+ Time.ToString() +" playing on "+ Difficulty;
        }

    }
}
