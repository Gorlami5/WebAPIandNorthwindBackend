﻿using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product:IEntity
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        public string UnitPrice { get; set; }

        public short UnitsInStock { get; set; }
    }
}