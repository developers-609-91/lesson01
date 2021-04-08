using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace XamarinApp
{
	class Model : BindableObject
	{
		private int _Number;
		private string _SomeString;
		private bool _IsDone;
		private Color _ItemColour;

		public Color ItemColour
		{
			get { return _ItemColour; }
			set 
			{
				_ItemColour = value;
				OnPropertyChanged(nameof(ItemColour));
			}
		}



		public int Number
		{
			get { return _Number; }
			set 
			{
				_Number = value;
				OnPropertyChanged(nameof(Number));
			}
		}

		public string SomeString
		{
			get { return _SomeString; }
			set
			{ 
				_SomeString = value;
				OnPropertyChanged(nameof(SomeString));
			}
		}


		public bool IsDone
		{
			get { return _IsDone; }
			set
			{ 
				_IsDone = value;
				OnPropertyChanged(nameof(IsDone));
			}
		}


	}
}
