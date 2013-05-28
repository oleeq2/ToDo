using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace ToDoLib
{
   [DataContract]
    public class Item: INotifyPropertyChanged 
    {
       [DataMember]
        string title;
       [DataMember]
        string descript;
       [DataMember]
        DateTime deadline;
       [DataMember]
       List<string> tags;

       public event PropertyChangedEventHandler PropertyChanged;

       public Item(string title, string descript, DateTime deadline, List<string> tags)
       {
            // TODO: Complete member initialization
            this.title = title;
            this.descript = descript;
            this.deadline = deadline;
            this.tags = new List<string>(tags);
       }

        public override string ToString()
        {
            return "\nTitle: " + title +
                "\nDescription: " + descript +
                "\nDeadline: " + deadline.ToString() +
                "\n Tags: " + string.Join(",", this.tags) + "\n";
        }

        public string Title {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Description { 
            get { return descript; }
             set
            {
                descript = value;
                OnPropertyChanged("Description");
            }
        }

        public DateTime DeadLine {
            get { return deadline; }

        }

        public List<string> Tags { 
            get { return tags; }
             set {
                tags = value;
                OnPropertyChanged("Tags");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
