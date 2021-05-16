using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var mainViewModel = new MainViewModel();
            BindingContext = mainViewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            AddBtn.Background = clickedButton.Background;
        }
    }
}

