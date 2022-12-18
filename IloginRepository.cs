using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using CarWashWebApiService.Interface;
using CarWashWebApiService.Models;


namespace CarWashWebApiService.Repository
{
    public class IloginRepository : Ilogin
    {
        CarWashEntities carWashDatabaseContext = new CarWashEntities();

        public Customer CustomerLogin(UserLogin login)
        {

            var Role = new Customer()
            {
                Email = login.Email,
                Password = login.Password,
                Role = "Customer"
            };
            var customerData= carWashDatabaseContext.Customers.Where(u => u.Email == Role.Email && u.Password == Role.Password && u.Role == Role.Role).SingleOrDefault();

            var user = new Customer()
            {
                Id = customerData.Id,
                FirstName = customerData.FirstName,
                LastName = customerData.LastName,
                Email = customerData.Email,
                PhoneNumber = customerData.PhoneNumber,
                Role = customerData.Role,
            };
            return user;
        }

        public Customer WasherLogin(UserLogin login)
        {
            var Role = new Customer()
            {
                Email = login.Email,
                Password = login.Password,
                Role = "Washer"
            };
            var washerData = carWashDatabaseContext.Customers.Where(u => u.Email == Role.Email && u.Password == Role.Password && u.Role == Role.Role).SingleOrDefault();

            var user = new Customer()
            {
                Id = washerData.Id,
                FirstName = washerData.FirstName,
                LastName = washerData.LastName,
                Email = washerData.Email,
                PhoneNumber = washerData.PhoneNumber,
                Role = washerData.Role,
            };
            return user;
        }
   
    }
}