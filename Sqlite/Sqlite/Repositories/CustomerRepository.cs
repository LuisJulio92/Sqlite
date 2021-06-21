//using Sqlite.Models;
//using SQLite;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Sqlite.Repositories
//{
//    public class CustomerRepository
//    {
//        SQLiteConnection connection;

//        public string StatusMessage { get; set; }

//        public CustomerRepository()
//        {
//            connection =
//                new SQLiteConnection(Constans.DatabasePath, Constans.Flags);
//            connection.CreateTable<Customer>();
//        }


//        public void AddOrUpdate(Customer _custoner)
//        {
//            int result = 0;
//            try
//            {
//                //id
//                if(_custoner.Id != 0)
//                {
//                    result = connection.Update(_custoner);
//                    StatusMessage = string.Format($"{result} Esa monda se actualizo");
//                }
//                else
//                {
//                    result = connection.Insert(_custoner);
//                    StatusMessage = string.Format($"{result} registro(s) agregado(s)");
//                }
//            }
//            catch(Exception ex)
//            {
//                StatusMessage = $"Error: {ex.Message}";
//            }
//        }

//        public List<Customer> GetAll()
//        {
//            try
//            {
//                return connection.Table<Customer>().ToList();
//            }
//            catch (Exception ex)
//            {
//                StatusMessage = $"Error: {ex.Message}";
//            }
//            return null;
//        }

//        public Customer Get(int id)
//        {

//            try
//            {
//                return connection
//                    .Table<Customer>()
//                    .FirstOrDefault(x => x.Id == id);
//            }
//            catch (Exception ex)
//            {
//                StatusMessage = $"Error: {ex.Message}";
//            }
//            return null;
//        }
       
//        public void Delete(int customerId)
//        {
//            try
//            {
//                var customer = Get(customerId);
//                connection.Delete(customer);
//            }
//            catch (Exception ex)
//            {
//                StatusMessage = $"Error: {ex.Message}";
//            }
//        }

//    }
//}
