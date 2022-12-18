using CarWashWebApplication.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CarWashWebApplication.Models;
using System.Net.Http;
using System.Text;
using System.Web.Services.Description;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace CarWashWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<UserModel> user = new List<UserModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("Users/GetallUsers"))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject
                                    <List<UserModel>>(apiResponse);
                }
            }
            return View(user);
        }



        public ActionResult Registration()
        {
            return View();
        }
        public async Task<ActionResult> Create(UserModel user)
        {            
                UserModel userData = new UserModel();
                var service = new ServiceRepository();
                {
                    using (var httpClient = new HttpClient())
                    {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(ConfigurationManager.AppSettings["apiurl"]+ "Users/AddUser", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        userData = JsonConvert.DeserializeObject<UserModel>(apiResponse);
                        return RedirectToAction("Index", "Home");
                    }
                   

                    }
                }
            
            return View(user);
        }
        public async Task<ActionResult> Delete(int id)
        {
            UserModel userData = new UserModel();
            var service = new ServiceRepository();
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.DeleteAsync(ConfigurationManager.AppSettings["apiurl"] + "Users/DeleteUser?id=" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        userData = JsonConvert.DeserializeObject<UserModel>(apiResponse);
                        return RedirectToAction("Index", "Home");
  
                    }


                }
            }
            return RedirectToAction("Index");

        }

    }
}