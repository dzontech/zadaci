﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
	public class Patient
	{
		public int Id { get; set; }
		public string  Name { get; set; }
		public string LBO { get; set; }
		public string Gender { get; set; }
	}
}
