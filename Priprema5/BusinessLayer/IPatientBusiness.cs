using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public interface IPatientBusiness
	{
		List<Patient> GetPatients();
		bool InsertPatient(Patient p);
		bool UpdatePatient(UpdatePatientDto p, int id);

		bool Delete(int id);
		Patient ShowPatient(string LBO);
	}
}
