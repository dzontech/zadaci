﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Desc { get; set; }
		public decimal Price { get; set; }
	}
}
