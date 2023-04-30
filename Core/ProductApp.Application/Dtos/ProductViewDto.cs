﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Application.Dtos
{
    public class ProductViewDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImgURL { get; set; }

    }
}
