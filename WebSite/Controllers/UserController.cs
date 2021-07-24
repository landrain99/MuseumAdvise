using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebSite.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _client;
        private string _domain;
        private readonly ILogger<UserController> _logger; // for the logger part NEED TO FINISH

        public UserController(HttpClient client)
        {
            _client = client;
        }


        public IActionResult CreateUser()
        {
            return View();
        }





    }
}
