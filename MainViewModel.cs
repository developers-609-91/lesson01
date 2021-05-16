using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace App1
{
    public class MainViewModel : BindableObject
    {
        private ObservableCollection<Item> allTasks = new ObservableCollection<Item>();
        private string description;
        private int num = 0;
        private Color choosedColor = Color.Red;
        private Color red = Color.Red;
        private Color green = Color.Green;
        private Color blue = Color.Blue;
        private Color purple = Color.Purple;
        private Color pink = Color.Pink;
        private Color orange = Color.Orange;



        public ICommand SetRed
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = red;
                }
                );
            }
        }

        public ICommand SetGreen
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = green;
                }
                );
            }
        }
        public ICommand SetBlue
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = blue;
                }
                );
            }
        }

        public ICommand SetPurple
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = purple;
                }
                );
            }
        }

        public ICommand SetPink
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = pink;
                }
                );
            }
        }

        public ICommand SetOrange
        {
            get
            {
                return new Command(() =>
                {
                    choosedColor = orange;
                }
                );
            }
        }
        public ICommand AddTask
        {
            get
            {
                return new Command(() =>
                {
                    if (description != null)
                    {
                        AllTasks.Add(new Item() { color = choosedColor, description = this.description, num = this.num, normalColor = choosedColor });
                    }
                }
                );

            }
        }
        public ICommand DeleteAll
        {
            get
            {
                return new Command(() =>
                {
                    AllTasks.Clear();
                }
                );

            }
        }


        public ICommand DeleteChoosed
        {
            get
            {
                return new Command(() =>
                {
                    int size = allTasks.Count;
                    for (int i = 0; i < size; i++)
                    {
                        if (allTasks[i].Done)
                        {
                            allTasks.Remove(allTasks[i]);
                            size--;
                            i--;
                        }
                    }
                }
                );

            }
        }


        public ObservableCollection<Item> AllTasks
        {
            get
            {
                return allTasks;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (!(value == description))
                {
                    description = value;
                }
                OnPropertyChanged("Description");
            }
        }
        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                if (!(value == num))
                {
                    num = value;
                }
                OnPropertyChanged("Num");
            }
        }


    };


    public class Item : BindableObject
    {
        private bool done = false;
        private TextDecorations textDecoration = TextDecorations.None;
        public string description;
        public Color color;
        public int num = 0;
        private Color doneColor = Color.Gray;
        public Color normalColor;
        public bool isSelected;

        

        public Color DoneColor
        {
            get
            {
                return doneColor;
            }
        }


        public Color NormalColor
        {
            get
            {
                return normalColor;
            }
        }
        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
                OnPropertyChanged("Num");
            }
        }
        public Color COLOR
        {
            get
            {
                return color;
            }
            set
            {
                if (done)
                {
                    color = doneColor;
                }
                else
                {
                    color = normalColor;
                }

                OnPropertyChanged("COLOR");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }


        public bool Done
        {
            get
            {
                return done;
            }
            set
            {
                done = value;
                System.Diagnostics.Debug.WriteLine(done);
                OnPropertyChanged("Done");
                TextDecoration = TextDecorations.Strikethrough;
                COLOR = doneColor;
            }
        }

        public TextDecorations TextDecoration
        {
            get
            {
                return textDecoration;
            }
            set
            {
                if (done)
                    textDecoration = TextDecorations.Strikethrough;
                else
                    textDecoration = TextDecorations.None;
                OnPropertyChanged();
            }
        }
    }
}
