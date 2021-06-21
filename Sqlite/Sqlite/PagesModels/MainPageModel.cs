using Bogus;
using FreshMvvm;
using PropertyChanged;
using Sqlite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sqlite.ViewModels
{

    public class MainPageModel : FreshBasePageModel
    {

        #region Variables

        private List<Customer> _customers;

        public List<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                RaisePropertyChanged();
            }
        }

        private Customer _newCustomer;

        public Customer NewCustomer
        {
            get { return _newCustomer; }
            set
            {
                _newCustomer = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands
        public ICommand AddCommand => new Command(async (s) => await AddCustomer(s));
        public ICommand DeleteCommand => new Command(async (s) => await Delete(s));
        #endregion

        #region Contructor & Init
        public MainPageModel()
        {
        }
        public override void Init(object initData)
        {
            Customers = new List<Customer>();
            var orders = App.OrderRepository.GetItems();

            Refrest();
            GenerateNewCustomer();
        }
        #endregion

        #region Methods
        private void GenerateNewCustomer()
        {
            NewCustomer = new Faker<Customer>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Address, f => f.Person.Address.Street)
                .Generate();

            NewCustomer.Passport = new Passport
            {
                ExpirationDate = DateTime.Now.AddDays(30)
            };
        }

        private void Refrest()
        {
            Customers = App.CustomerRepository.getItemsWithChildren();

            var passport = App.PassportRepository.GetItems();
        }

        private async Task Delete(object s)
        {
            SwipeView swipeView = (SwipeView)s;
            var userDelete = swipeView.BindingContext as Customer;
            App.CustomerRepository.DeleteItem((Customer)userDelete);
            Refrest();
        }

        private async Task AddCustomer(object s)
        {
            App.CustomerRepository.SaveItemWithChildren(NewCustomer);
            Console.WriteLine(App.CustomerRepository.StatusMessage);
            GenerateNewCustomer();
            Refrest();
        }
        #endregion

    }
}
