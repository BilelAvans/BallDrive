using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDrive.Data.Notifications
{
    public class NoteQueue : Queue<Note>, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public bool MessageAvailable { get { return current != null ? true : false; } }
        // De queue wordt uitgelezen en in current geplaatst.
        private Note current;
        public Note Current { get { return returnCurrent(); } set { this.current = value; Changed("Current"); } }

        public NoteQueue() : base(0)
        {
            Enqueue(new Note("Notification Example", "It's working, press OK to close this message."));
        }
        // Enqueue extenden.

        public new void Enqueue(Note item)
        {
            base.Enqueue(item);
            // notify new message if no current item is available
            if (current == null)
                Push();
            // Notificeer het publiek dat de beschikbaarheid veranderd zou kunnen zijn.
            Changed("MessageAvailable");
        }
        // Push wordt aangeroepen wanneer in feite op "OK" gedrukt wordt. Dan leegt de current variable en wordt er gekeken of een nieuwe Note beschikbaar is.
        public bool Push()
        {
            // current op nul zetten
            Current = null;
            Changed("MessageAvailable");
            if (Count != 0)     // Is er iets om op te halen? (queue is niet leeg?) 
            {
                Current = base.Dequeue();
                Changed("MessageAvailable");
                return true;
            }
            // Helemaal niets in queue
            return false;
        }

        public Note returnCurrent()
        {
            if (current != null)
                return current;
            // return a new note when no notes are available to avoid null ref exception in XAML bindings
            return new Note("No Error Found", "");
        }

        public void Changed(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }


    }
}
