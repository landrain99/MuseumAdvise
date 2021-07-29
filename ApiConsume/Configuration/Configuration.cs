using ApiConsume.Interface;
using ApiConsume.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.Configuration
{
    public static class Configuration
    {
        public static void UseServices(this IServiceCollection services)
        {
            services.AddHttpClient<IUserService, UserService>();
            services.AddHttpClient<IReviewService, ReviewService>();
            services.AddHttpClient<IMuseumService, MuseumService>();

        }
    }
}
