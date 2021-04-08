using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinApp
{
	class Categories : BindableObject
	{
		private Color _myColor;

		public Color MyColor
		{
			get { return _myColor; }
			set
			{
				_myColor = value;
				OnPropertyChanged(nameof(MyColor));
			}
		}

	}
}
