using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace buyList1
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
            var viewModel = MainPage.BindingContext as MainViewModel;
            if (App.Current.Properties.TryGetValue("allTasks", out var serializedItems))
            {
                var items = Newtonsoft.Json.JsonConvert.DeserializeObject<Item[]>(serializedItems.ToString());

                foreach (Item item in items)
                {
                    viewModel.AllTasks.Add(item);
                }
            }
        }

        protected override void OnSleep()
        {
            var viewModel = MainPage.BindingContext as MainViewModel;
            App.Current.Properties["allTasks"] = Newtonsoft.Json.JsonConvert.SerializeObject(viewModel.AllTasks);
        }

        protected override void OnResume()
        {
        }
    }
}
