using BallDrive.Data.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace BallDrive.Data.Games
{
    public class Multiplyer: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        // Default hit value
        public const int DEFAULT_POINTS_PER_HIT = 1;

        public const int MAX_MULTIPLYER = 5;

        // Multiplyer starts with 1 (score * 1)
        private double multiplyer = 1; 
        public double MP { get { return multiplyer; } set { setMP(value); Changed("MP"); } }

        private DifficultySettings.DIFFICULTY difficulty;

        public enum multiplyerBonus
        {
            NO_BONUS,
            MULTIPLYER_X10_BONUS,
            DOUBLE_POINTS,
            TRIPLE_POINTS
        }

        public multiplyerBonus MPBonus { get; set; } = multiplyerBonus.NO_BONUS;

        public Multiplyer(DifficultySettings.DIFFICULTY diff)
        {
            this.difficulty = diff;
        }
        // Increment multiplyer and return points we should gain
        public int Increment()
        {
            if (!(MP + 1 > MAX_MULTIPLYER))
                MP += 1;

            return (int)(DEFAULT_POINTS_PER_HIT * getMultiplyerPoints());
        }
        // Decrement multiplyer
        public void Decrement()
        {
            if (multiplyer - 2 < 1)
                MP = 1;
            else
                MP -= 2;
        }
        // Reset our multiplyer to 1.
        public void Clear()
        {
            MP = 1;
        }

        public void setMP(double newMP)
        {
            switch (MPBonus) {
                case multiplyerBonus.NO_BONUS: this.multiplyer = newMP; break;
                case multiplyerBonus.MULTIPLYER_X10_BONUS: this.multiplyer = 10; break;
            }
        }

        // asjust multiplyer by difficulty and return it
        private int getMultiplyerPoints()
        {
            switch (difficulty)
            {
                case DifficultySettings.DIFFICULTY.EASY:
                    return (int)(1 * multiplyer);
                default:
                    return (int)(2 * multiplyer);
                case DifficultySettings.DIFFICULTY.HARD:
                    return (int)(3 * multiplyer);
            }
        }

        private async void Changed(string propertyName)
        {
            if (PropertyChanged != null)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                });
            }
        }
    }
}
