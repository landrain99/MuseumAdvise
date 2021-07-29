using ApiConsume.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class ReviewController : Controller
    {
        public IReviewService _reviewService;
        private readonly HttpClient _client;
        private string url;

        public ReviewController(IReviewService reviewService, HttpClient client, IConfiguration _config)
        {
            _reviewService = reviewService;
            _client = client;
            url = _config["UrlToUse"];
        }


        public async Task<IActionResult> GetAllReview()
        {
            var result = await _reviewService.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> Getreview()
        {
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("cannot retrieve quizz names");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<List<ReviewModelWebSite>>(content);
            return View(lst);
        }
    }
}
