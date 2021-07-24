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
    public class UserService : IUserService
    {
        private  string _baseUrl;
        private readonly HttpClient _client;

        public UserService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _baseUrl = config["UrlToUse"];
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            var httpResponse = await _client.GetAsync(_baseUrl);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrive tasks"); // a modifier en personnal exception
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<UserModel>>(content);

            return tasks;
        }

        public async Task<UserModel> GetUserAsync(int id)
        {
            var httpResponse = await _client.GetAsync($"{_baseUrl}{id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrive tasks"); // a modifier en personnal exception
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var Item = JsonConvert.DeserializeObject<UserModel>(content);

            return Item;
        }
        public async Task<UserModel> CreateUserAsync(UserModel task)
        {
            var content = JsonConvert.SerializeObject(task);
            var httpResponse = await _client.PostAsync(_baseUrl, new StringContent(content, Encoding.Default, "application/json"));
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrive tasks"); // a modifier en personnal exception
            }
            var createdTask = JsonConvert.DeserializeObject<UserModel>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;

        }
              
        public async Task<UserModel> UpdateUserAsync(UserModel task)
        {
            var content = JsonConvert.SerializeObject(task);
            var httpResponse = await _client.PutAsync(_baseUrl, new StringContent(content, Encoding.Default, "application/json"));
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrive tasks"); // a modifier en personnal exception
            }
            var createdTask = JsonConvert.DeserializeObject<UserModel>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

        public async Task DeleteUserAsync(int id)
        {
            var httpResponse = await _client.DeleteAsync($"{_baseUrl}{id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete the user"); // a modifier en personnal exception
            }

        }
    }
}
