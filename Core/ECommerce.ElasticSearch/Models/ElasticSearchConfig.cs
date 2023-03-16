﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ElasticSearch.Models
{
    public class ElasticSearchConfig
    {
        public string ConnectionString { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
