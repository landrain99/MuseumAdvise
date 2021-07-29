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
    public class MuseumService : IMuseumService
    {

        private string _baseUrl;
        private readonly HttpClient _client;

        public MuseumService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _baseUrl = config["UrlToUse"];
        }
        public async Task<List<MuseumModel>> GetAllAsync()
        {
            var url = "https://localhost:44317/api/Museum/GetAllMuseum";
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrive tasks"); // a modifier en personnal exception
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<MuseumModel>>(content);

            return tasks;
        }

        public async Task<MuseumModel> GetMuseumById(int id)
        {
            var url = "https://localhost:44317/api/Museum/GetAllMuseum";
            var httpResponse = await _client.GetAsync($"{url}{id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrive tasks"); // a modifier en personnal exception
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var Item = JsonConvert.DeserializeObject<MuseumModel>(content);

            return Item;
        }

        public async Task<MuseumModel> CreateMuseumAsync(MuseumModel model)
        {
            var content = JsonConvert.SerializeObject(model);
            var httpResponse = await _client.PostAsync(_baseUrl, new StringContent(content, Encoding.Default, "application/json"));
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrive tasks"); // a modifier en personnal exception
            }

            var createdTask = JsonConvert.DeserializeObject<MuseumModel>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }
    }
}
