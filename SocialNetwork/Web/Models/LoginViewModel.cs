﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class LoginViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UrlPhoto { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
    }
}