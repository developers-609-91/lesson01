using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.ComponentModel;

namespace App1  
{
    class TodoItem : INotifyPropertyChanged
    {
        private string name;
        private bool done;
        private int count;
        private string color = "";

        public event PropertyChangedEventHandler PropertyChanged;

        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Done
        {
            get { return done; }
            set
            {
                if (done != value)
                {
                    done = value;
                    OnPropertyChanged("Done");
                }
            }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
