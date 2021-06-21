using FreshMvvm;
using Sqlite.Models;
using Sqlite.Repositories;
using Sqlite.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sqlite
{
    public partial class App : Application
    {
        

        public class MyPageModelMapper : IFreshPageModelMapper
        {
            public string GetPageTypeName(Type pageModelType)
            {
                var mainpagemodel = typeof(MainPageModel);
                var s = Type.GetType(mainpagemodel.AssemblyQualifiedName);
                return pageModelType.AssemblyQualifiedName
                    .Replace("PageModel", "Page")
                 .Replace("ViewModel", "Page");
            }
        }

        private static BaseRepository<Customer> _customerRepository;
        public static BaseRepository<Customer> CustomerRepository
        {
            get
            {
                if(_customerRepository == null)
                {
                    _customerRepository = new BaseRepository<Customer>();
                }
                return _customerRepository;
            }
        }

        private static BaseRepository<Order> _orderRepository;
        public static BaseRepository<Order> OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new BaseRepository<Order>();
                }
                return _orderRepository;
            }
        }

        private static BaseRepository<Passport> _passportRepository;
        public static BaseRepository<Passport> PassportRepository
        {
            get
            {
                if (_passportRepository == null)
                {
                    _passportRepository = new BaseRepository<Passport>();
                }
                return _passportRepository;
            }
        }
        public App()
        {
            InitNavigation();

        }

        private void InitNavigation()
        {
            FreshPageModelResolver.PageModelMapper = new MyPageModelMapper();
            var page = FreshPageModelResolver.ResolvePageModel<MainPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
