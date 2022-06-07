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
		bool Insert(Patient p);
		bool Update(Patient p, int id);

		Patient GetByLBO(string lbo);
	}
}
