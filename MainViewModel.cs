using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using Xamarin.Essentials;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace App1
{
    class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TodoItem> items = new ObservableCollection<TodoItem>();
        private string currentName = "";

        private bool bisqueGroup = true;
        private bool lightGreenGroup = false;
        private bool skyBlueGroup = false;
        private bool pinkGroup = false;
        private bool lightGrayGroup = false;
        private bool darkGoldenrodGroup = false;
        private bool darkVioletGroup = false;

        private Color selectedGroupColor = Color.Bisque;

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void ResetGroups()
        {
            BisqueGroup = false;
            LightGreenGroup = false;
            SkyBlueGroup = false;
            PinkGroup = false;
            LightGrayGroup = false;
            DarkGoldenrodGroup = false;
            DarkVioletGroup = false;
        }

        public bool BisqueGroup
        {
            get { return bisqueGroup; }
            set
            {
                if(bisqueGroup != value)
                {
                    bisqueGroup = value;
                    OnPropertyChanged("BisqueGroup");
                }
            }
        }

        public bool LightGreenGroup
        {
            get { return lightGreenGroup; }
            set
            {
                if (lightGreenGroup != value)
                {
                    lightGreenGroup = value;
                    OnPropertyChanged("LightGreenGroup");
                }
            }
        }

        public bool SkyBlueGroup
        {
            get { return skyBlueGroup; }
            set
            {
                if (skyBlueGroup != value)
                {
                    skyBlueGroup = value;
                    OnPropertyChanged("SkyBlueGroup");
                }
            }
        }

        public bool PinkGroup
        {
            get { return pinkGroup; }
            set
            {
                if (pinkGroup != value)
                {
                    pinkGroup = value;
                    OnPropertyChanged("PinkGroup");
                }
            }
        }

        public bool LightGrayGroup
        {
            get { return lightGrayGroup; }
            set
            {
                if (lightGrayGroup != value)
                {
                    lightGrayGroup = value;
                    OnPropertyChanged("LightGrayGroup");
                }
            }
        }

        public bool DarkGoldenrodGroup
        {
            get { return darkGoldenrodGroup; }
            set
            {
                if (darkGoldenrodGroup != value)
                {
                    darkGoldenrodGroup = value;
                    OnPropertyChanged("DarkGoldenrodGroup");
                }
            }
        }

        public bool DarkVioletGroup
        {
            get { return darkVioletGroup; }
            set
            {
                if (darkVioletGroup != value)
                {
                    darkVioletGroup = value;
                    OnPropertyChanged("DarkVioletGroup");
                }
            }
        }

        public string CurrentName
        {
            get { return currentName; }
            set
            {
                if (currentName != value)
                {
                    currentName = value;
                    OnPropertyChanged("CurrentName");   
                }
            }
        }

        public ObservableCollection<TodoItem> Items
        {
            get { return items; }
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command((e) =>
                {
                if (!string.IsNullOrWhiteSpace(CurrentName))
                {
                    string[] words = CurrentName.Split(new char[] { ' ' });

                    TodoItem newItem;

                    if (int.TryParse(words[words.Length - 1], out int result))
                    {
                            Array.Resize(ref words, words.Length - 1);
                            newItem = new TodoItem() { Name = string.Join(" ", words), Color = selectedGroupColor.ToHex(), Count = result, Done = false };
                    }
                    else
                    {
                        newItem = new TodoItem() { Name = CurrentName, Color = selectedGroupColor.ToHex(), Count = 0, Done = false };
                    }

                    CurrentName = "";
                    Items.Add(newItem);
                    }
                });
            }
        }

        public ICommand BisqueGroupCommand
        {
            get
            {
                return new Command((e) =>
                {
                    ResetGroups();
                    BisqueGroup = true;
                    selectedGroupColor = Color.Bisque;
                });
            }
        }

        public ICommand LightGreenGroupCommand
        {
            get
            {
                return new Command((e) =>
                {
                    ResetGroups();
                    LightGreenGroup = true;
                    selectedGroupColor = Color.LightGreen;
                });
            }
        }

        public ICommand SkyBlueGroupCommand
        {
            get
            {
                return new Command((e) =>
                {
                    ResetGroups();
                    SkyBlueGroup = true;
                    selectedGroupColor = Color.SkyBlue;
                });
            }
        }

        public ICommand PinkGroupCommand
        {
            get
            {
                return new Command((e) =>
                {
                    ResetGroups();
                    PinkGroup = true;
                    selectedGroupColor = Color.Pink;
                });
            }
        }

        public ICommand LightGrayGroupCommand
        {
            get
            {
                return new Command((e) =>
                {
                    ResetGroups();
                    LightGrayGroup = true;
                    selectedGroupColor = Color.LightGray;
                });
            }
        }

        public ICommand DarkGoldenrodGroupCommand
        {
            get
            {
                return new Command((e) =>
                {
                    ResetGroups();
                    DarkGoldenrodGroup = true;
                    selectedGroupColor = Color.DarkGoldenrod;
                });
            }
        }

        public ICommand DarkVioletGroupCommand
        {
            get
            {
                return new Command((e) =>
                {
                    ResetGroups();
                    DarkVioletGroup = true;
                    selectedGroupColor = Color.DarkViolet;
                });
            }
        }

        public ICommand RemoveItemCommand
        {
            get
            {
                return new Command<TodoItem>(e =>
                {
                    for(int i = 0; i < items.Count; i++)
                    {
                        if(items[i].Done)
                        {
                            items.Remove(items[i]);
                            i--;
                        }
                    }
                });

            }
        }
        

        public ICommand RemoveSingleItemCommand
        {
            get
            {
                return new Command<TodoItem>(e =>
                {
                    items.Remove(e);
                });

            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
