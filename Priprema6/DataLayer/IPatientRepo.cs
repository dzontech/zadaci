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
		int Insert(Patient p);
		int Update(Patient p, int id);
		
	}
}
