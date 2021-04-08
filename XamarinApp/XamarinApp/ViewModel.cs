using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinApp
{
	class ViewModel : BindableObject
	{
		public ICommand MyCommand { get; }
		public ICommand DelCommand { get; }
		private string _InputString;
		private int _Num;
		public ObservableCollection<Model> MyCollection { get; } = new ObservableCollection<Model>();

		public ObservableCollection<Categories> Colors { get; } = new ObservableCollection<Categories>()
		{
			new Categories(){MyColor = Color.Blue},
			new Categories(){MyColor = Color.Green},
			new Categories(){MyColor = Color.Red},
			new Categories(){MyColor = Color.Yellow},
			new Categories(){MyColor = Color.BurlyWood}
		};

		public ViewModel()
		{
			MyCommand = new Command(OnBtnClick);
			DelCommand = new Command(DelBtn);
		}

		private Categories seCategories;

		public Categories SelectedCategories
		{
			get { return seCategories; }
			set
			{
				seCategories = value;
				OnPropertyChanged(nameof(Categories));
			}
		}



		public int Num
		{
			get { return _Num; }
			set
			{
				_Num = value;
				OnPropertyChanged();
			}
		}

		public string InputString
		{
			get { return _InputString; }
			set
			{
				_InputString = value;
				OnPropertyChanged(nameof(InputString));
			}
		}


		public void DelBtn()
		{
			for (int i = MyCollection.Count-1; i >= 0; i--)
			{
				if (MyCollection[i].IsDone == true)
					MyCollection.RemoveAt(i);
			}
		}

		public void OnBtnClick()
		{
			if (String.IsNullOrWhiteSpace(InputString))
			{
				InputString = null;
				return;
			}
			if(Num < 1)
			{
				Num = 1;
				return;
			}
			Model NewModel = new Model
			{
				SomeString = InputString,
				Number = Num,
				IsDone = false,
				ItemColour = SelectedCategories.MyColor
			};
			MyCollection.Add(NewModel);
			InputString = null;
			Num = 1;
		}
	}
}
