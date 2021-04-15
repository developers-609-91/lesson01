using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace lab3
{

    public class Product : BindableObject
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity == value) return;
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private Color _clr;
        public Color Clr
        {
            get => _clr;
            set
            {
                if (_clr == value) return;
                _clr = value;
                OnPropertyChanged(nameof(Clr));
            }
        }

        private bool _checked;
        public bool Checked
        {
            get => _checked;
            set
            {
                if (_checked == value) return;
                _checked = value;
                OnPropertyChanged(nameof(Checked));
            }
        }

    }

    public class ViewModel : BindableObject
    {
        public ViewModel()
        {
                AddCommand = new Command<string>(ItemName =>
            {
                var Product = new Product();
                Product.Name = ItemName;
                Product.Quantity = Convert.ToInt32(Quantity);
                Product.Clr = Clr;
                Products.Add(Product);
            }, x => string.IsNullOrWhiteSpace(x) == false);


                ChangeColor = new Command<Color>(newClr =>
                {
                    Clr = newClr;
                }, x => x != Clr);

            Products = new ObservableCollection<Product>();

            DelChecked = new Command(() =>
            {
                foreach (var product in Products.ToList())
                {       
                    if (product.Checked == true)
                    {
                        Products.Remove(product);
                    }
                }
            }, () => true);
        }

        int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity == value) return;
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private Color _clr = Color.Gainsboro;
        public Color Clr
        {
            get => _clr;
            set
            {
                if (_clr == value) return;
                _clr = value;
                OnPropertyChanged(nameof(Clr));
            }
        }





        public ObservableCollection<Product> Products { get; }

        public ICommand
            AddCommand { get; }

        public ICommand
            ChangeColor { get; }

        public ICommand
            DelChecked { get; }


    }

    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModel();
        }
        
    }
}
