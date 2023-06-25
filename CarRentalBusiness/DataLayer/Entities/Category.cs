﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public float Warranty { get; set; }

        public List<Car> Cars { get; set; }
    }
}
