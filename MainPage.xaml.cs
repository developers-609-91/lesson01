using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MainViewModel viewModel = new MainViewModel();
            
            BindingContext = viewModel;


        }
        
        private void SwipeItem_Invoked(object sender, EventArgs e)
        {
            DisplayAlert("Hello", "World", "Cancel");
        }
    }
}
