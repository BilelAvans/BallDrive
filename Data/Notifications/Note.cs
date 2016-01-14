using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDrive.Data.Notifications
{
    public class Note
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public Note(string Title, string Message)
        {
            this.Title = Title;
            this.Message = Message;
        }
    }
}
