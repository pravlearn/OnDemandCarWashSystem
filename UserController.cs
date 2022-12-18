using CarWashWebApiService.Models;
using CarWashWebApiService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarWashWebApiService.Controllers
{
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {
        UserRepository userRepository = new UserRepository();

        [HttpPost]
        [Route("AddUser")]
        public Customer AddUser(Customer customer)
        {
            try
            {
                userRepository.CreateUser(customer);
            }
            catch (Exception)
            {
                throw;
            }
            return customer;
        }
        [HttpGet]
        [Route("GetallUsers")]
        public List<Customer> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public void Deleteuser(int id)
        {
           userRepository.Delete(id);
        }
    }
}
