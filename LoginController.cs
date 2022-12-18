using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CarWashWebApplication.Models;
using CarWashWebApplication.Repository;
using Newtonsoft.Json;

namespace CarWashWebApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login u)
        {
            if (ModelState.IsValid)
            {
                var service = new ServiceRepository();
                UserModel user = new UserModel();
                {
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = service.GetResponse("login/CustomerLogin"))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            user = JsonConvert.DeserializeObject<UserModel>(apiResponse);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                   
                }
            }
            return View(u);
        }
    }
}