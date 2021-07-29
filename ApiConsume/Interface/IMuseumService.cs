using ApiConsume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.Interface
{
    public interface IMuseumService
    {
        Task<List<MuseumModel>> GetAllAsync();
        Task<MuseumModel> GetMuseumById(int id);

        Task<MuseumModel> CreateMuseumAsync(MuseumModel model);
    }
}
