using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;
using CarWashWebApiService.Models;
using CarWashWebApiService.Repository;


namespace CarWashWebApiService.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {  
       IloginRepository iloginRepository = new IloginRepository();


        [HttpGet]
        [Route("CustomerLogin")]
        public  Customer CustomerLogin(UserLogin login)
        {
            var user =  iloginRepository.CustomerLogin(login);
            return user; 
        }
        [HttpGet]
        [Route("WasherLogin")]
        public Customer WasherLogin(UserLogin login)
        {
            var user = iloginRepository.WasherLogin(login);
            return user;
        }
    }
}
