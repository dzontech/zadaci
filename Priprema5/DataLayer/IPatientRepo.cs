using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface IPatientRepo
	{
		List<Patient> GetPatients();
		int InsertPatient(Patient p);
		int UpdatePatient(UpdatePatientDto p, int id);
		int Delete(int id);
	}
}
