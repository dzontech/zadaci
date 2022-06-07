using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public interface IWorkerBusiness
	{
		List<Worker> GetAllWorkers();
		bool InsertWorker(Worker worker);

		List<Worker> GetWorkersWithProfession(string profession);

	}
}
