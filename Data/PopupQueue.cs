using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDrive.Data
{
    public class PopupQueue: Queue<string>
    {
        public bool MessageAvailable { get { return true; } set { } }

        public PopupQueue()
        {
            
        }
    }
}
