using ApiConsume.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IReviewService _reviewService;
        //public IUserService _userService;
        

        public HomeController(ILogger<HomeController> logger, IReviewService reviewService)
        {
            _logger = logger;
            _reviewService = reviewService;
        }

        public async Task<IActionResult> Index()
        {
            // If the user is authenticated, then this is how you can get the assess token and id token
            
                if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                DateTime accessTokenExpiresAt = DateTime.Parse(
                    await HttpContext.GetTokenAsync("expires_at"),
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind);
                String idToken = await HttpContext.GetTokenAsync("id_token");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
        public async Task<IActionResult> GetAllReview()
        {
            var lst = await _reviewService.GetAllAsync();
            return View(lst);
        }
       
        
    }
}
