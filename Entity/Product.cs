﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        public int Product_Id {  get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public int Stock { get; set; }

        public bool Active { get; set; }

    }
}
