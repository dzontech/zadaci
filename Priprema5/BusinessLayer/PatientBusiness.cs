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

		public List<Patient> GetPatients()
		{
			List<Patient> list = this.patientRepo.GetPatients();
			if (list.Count > 0)
				return list;
			else
				return null;
		}

		public bool InsertPatient(Patient p)
		{
			if (this.patientRepo.InsertPatient(p) > 0)
				return true;
			else
				return false;
		}

		public Patient ShowPatient(string LBO)
		{
			List<Patient> list = this.patientRepo.GetPatients();
			return list.Find(p => p.LBO.Equals(LBO));
		}

		public bool UpdatePatient(UpdatePatientDto p, int id)
		{
			bool r = false;
			if (id != 0 && this.patientRepo.UpdatePatient(p, id) > 0)
				r = true;
			return r;
		}

		public bool Delete(int id)
		{
			bool r = false;
			if (id != 0 && this.patientRepo.Delete(id) > 0)
				r = true;
			return r;
		}
	}
}
