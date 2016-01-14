using BallDrive.Data.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDrive.Data.Games
{
    public class BallCatcher: Game
    {

        public BallCatcher(DifficultySettings diffSettings) : base(diffSettings)
        {
            this.Difficulty = diffSettings;   
        }
    }
}
