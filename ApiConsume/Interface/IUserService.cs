using ApiConsume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.Interface
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllAsync();
        Task<UserModel> GetUserAsync(int id);
        Task<UserModel> CreateUserAsync(UserModel task);
        Task<UserModel> UpdateUserAsync(UserModel task);
        Task DeleteUserAsync(int id);


    }
}
