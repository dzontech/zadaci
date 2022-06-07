using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priprema6.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PatientController: ControllerBase
	{
		private IPatientBusiness patientBusiness;

		public PatientController(IPatientBusiness patientBusiness)
		{
			this.patientBusiness = patientBusiness;
		}

		[HttpGet("getall")]
		public List<Patient> GetPatients()
		{
			return this.patientBusiness.GetPatients();
		}

		[HttpGet("get/{lbo}")]
		public Patient GetByLBO(string lbo)
		{
			return this.patientBusiness.GetByLBO(lbo);
		}

		[HttpPut("update/{id}")]
		public bool Update(Patient p, int id)
		{
			return this.patientBusiness.Update(p, id);
		}

		[HttpPost("insert")]
		public bool Insert(Patient p)
		{
			return this.patientBusiness.Insert(p);
		}
	}
}
