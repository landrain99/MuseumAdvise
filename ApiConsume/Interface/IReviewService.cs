﻿using ApiConsume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.Interface
{
    public interface IReviewService
    {
        Task<List<ReviewModel>> GetAllAsync();
       
    }
}
