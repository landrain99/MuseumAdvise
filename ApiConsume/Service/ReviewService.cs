using ApiConsume.Interface;
using ApiConsume.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.Service
{
    public class ReviewService : IReviewService
    {
        private string _baseUrl;
        private readonly HttpClient _client;

        public ReviewService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _baseUrl = config["UrlToUse"];
        }

        public async Task<List<ReviewModel>> GetAllAsync()
        {
            var httpResponse = await _client.GetAsync(_baseUrl);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrive tasks"); // a modifier en personnal exception
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<ReviewModel>>(content);

            return tasks;
        }

        /*
        public Task<ReviewModel> GetReviewByID(int id);


        public Task<ReviewModel> PutReview(ReviewModel mdReview);
        public Task<ReviewModel> PostReview(ReviewModel mdReview);
        
        public Task DeleteReview(int id);
        */


    }
}
