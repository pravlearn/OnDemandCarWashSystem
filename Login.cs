﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWashWebApiService.Models
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }   
        public string Role { get; set; }
    }
}