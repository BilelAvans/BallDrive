using BallDrive.Data.Characters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Sensors;
using Windows.Foundation;

namespace BallDrive.Data.Controls
{
    public class AccelHandler : ControlHandler
    {
        public Accelerometer A { get; set; }

        public event EventHandler Event;
        
        private uint reportInterval = 100;

        public StoryCharacter Character { get; set; }

        public AccelHandler()
        {
            // Fetch the Accelerator from our device
            A = Accelerometer.GetDefault();
            
            setA();
        }

        private void setA()
        {
            if (A != null)
            {
                if (A.MinimumReportInterval > this.reportInterval)
                    A.ReportInterval = A.MinimumReportInterval;
                else
                    A.ReportInterval = this.reportInterval;

                A.ReadingChanged += new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(A_Changed);
            }
        }

        private void A_Changed(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            calcDirection(sender.GetCurrentReading());
        }

        private void calcDirection(AccelerometerReading reading)
        {
            //Debug.WriteLine("{0}", reading.AccelerationX);
            // Standing still by default
            Direction = Directions.ON_PAUSE;

            // Only move whilst in the right Y-position
            if (reading.AccelerationY > -0.75)
                if (reading.AccelerationX < -0.15)
                    Direction = Directions.NORTH_WEST;
                else if (reading.AccelerationX > 0.15)
                    Direction = Directions.NORTH_EAST;
                else
                    Direction = Directions.NORTH;

            else if (reading.AccelerationY < -0.85)
                if (reading.AccelerationX < -0.15)
                    Direction = Directions.SOUTH_WEST;
                else if (reading.AccelerationX > 0.15)
                    Direction = Directions.SOUTH_EAST;
                else
                    Direction = Directions.SOUTH;

            else if (reading.AccelerationX < -0.15)
                Direction = Directions.WEST;
            else if (reading.AccelerationX > 0.15)
                Direction = Directions.EAST;
            
        }

        private double calcDegrees(int AccelX, int AccelY)
        {
            return 0.0;
        }
    }
}
