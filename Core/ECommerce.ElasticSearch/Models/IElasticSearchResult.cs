﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ElasticSearch.Models
{
    public interface IElasticSearchResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
