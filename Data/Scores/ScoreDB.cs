using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BallDrive.Data.Scores
{
    public static class ScoreDB
    {

        public static async void saveScores(List<HighScore> scores)
        {
            try
            {

                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("highscores.txt", CreationCollisionOption.ReplaceExisting);

                await FileIO.WriteLinesAsync(file, scores.Select(score => score.Name + "," + score.Score + "," + score.Time + "," + score.Difficulty));
            }
            catch (NullReferenceException ex) {
                Debug.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<HighScore>> loadScores()
        {
            //await (await ApplicationData.Current.LocalFolder.GetFileAsync("highscores.txt")).DeleteAsync(StorageDeleteOption.PermanentDelete);
            List<HighScore> tempHighscores = new List<HighScore>();
            
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("highscores.txt");

                List<string> hcStrings = (await FileIO.ReadLinesAsync(file)).ToList();

                foreach (string line in hcStrings)
                {
                    string[] splitContent = line.Split(',');
                    tempHighscores.Add(new HighScore(splitContent[0], int.Parse(splitContent[1]), DateTime.Parse(splitContent[2]), Controls.DifficultySettings.stringToDiff(splitContent[3])));
                }

                return tempHighscores;
            }
            catch (NullReferenceException ex)
            {

            }
            catch (FileNotFoundException ex)
            {
            }
            catch (IndexOutOfRangeException ex)
            {
                Debug.WriteLine(ex.Source);
            }
            // No items returned
             
            return tempHighscores;        
           
        }

    }
}
