﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWashWebApplication.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}