using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
	public class PatientBusiness : IPatientBusiness
	{
		private IPatientRepo patientRepo;

		public PatientBusiness(IPatientRepo patientRepo)
		{
			this.patientRepo = patientRepo;
		}

		public Patient GetByLBO(string lbo)
		{
			List<Patient> list = this.patientRepo.GetPatients();
			return list.Find(p => p.LBO.Equals(lbo));
		}

		public List<Patient> GetPatients()
		{
			List<Patient> list = this.patientRepo.GetPatients();
			if (list.Count > 0)
				return list;
			else
				return null;
		}

		public bool Insert(Patient p)
		{
			if (this.patientRepo.Insert(p) > 0)
				return true;
			else
				return false;
		}

		public bool Update(Patient p, int id)
		{
			bool r = false;
			if (id != 0 && this.patientRepo.Update(p, id) > 0)
				r = true;
			return r;
		}
	}

}
