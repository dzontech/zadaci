using BusinessLayer;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priprema5.Controllers
{
	[Route("api/patients")]
	[ApiController]
	public class PatientController : ControllerBase
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

		[HttpGet("get/{LBO}")]
		public Patient ShowPatient(string LBO)
		{
			return this.patientBusiness.ShowPatient(LBO);
		}

		[HttpPost("insert")]
		public bool InsertPatient(Patient p)
		{
			return this.patientBusiness.InsertPatient(p);
		}

		[HttpPut("update/{id}")]
		public bool UpdatePatient(UpdatePatientDto p, int id)
		{
			return this.patientBusiness.UpdatePatient(p, id);
		}

		[HttpDelete("delete/{id}")]
		public bool Delete(int id)
		{
			return this.patientBusiness.Delete(id);
		}


	}
}
