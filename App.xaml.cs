using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            var viewmodel = MainPage.BindingContext as MainViewModel;
            if(App.Current.Properties.TryGetValue("items", out var serializedItems))
            {
                var items = Newtonsoft.Json.JsonConvert.DeserializeObject<TodoItem[]>(serializedItems.ToString());

                foreach(TodoItem item in items)
                {
                    viewmodel.Items.Add(item);
                }
            }
        }

        protected override void OnSleep()
        {
            var viewmodel = MainPage.BindingContext as MainViewModel;
            App.Current.Properties["items"] = Newtonsoft.Json.JsonConvert.SerializeObject(viewmodel.Items);
        }

        protected override void OnResume()
        {

        }
    }
}
