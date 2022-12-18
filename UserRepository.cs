using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CarWashWebApiService.Interface;
using CarWashWebApiService.Models;

namespace CarWashWebApiService.Repository
{
    public class UserRepository : IUser<Customer>
    {
        CarWashEntities carWashDatabaseContext = new CarWashEntities();

        
        public Customer CreateUser(Customer customer)
        {

            try
            {
                var newuser = new Customer()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Password = customer.Password,
                    Role = customer.Role
                };

                if (carWashDatabaseContext != null)
                {
                    carWashDatabaseContext.Customers.Add(newuser);
                    carWashDatabaseContext.SaveChanges();
                    return newuser;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public void Delete(int id)
        {
            Customer customer = carWashDatabaseContext.Customers.Find(id);
            carWashDatabaseContext.Customers.Remove(customer);
            carWashDatabaseContext.SaveChanges();
        }

        public List<Customer> GetAllUsers()
        {
            return carWashDatabaseContext.Customers.ToList();

        }

        public List<Customer> GetAllWashers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetUserbyEmail(int email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetUserbyId(int email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetUserId(int id)
        {
            if (carWashDatabaseContext != null)
            {
                var customer = from c in carWashDatabaseContext.Customers where c.Id == id select c;
                
                return customer;
            }
            return null;
        }
    }
}