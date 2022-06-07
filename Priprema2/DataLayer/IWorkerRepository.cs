using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface IWorkerRepository
	{
		List<Worker> GetAllWorkers();
		int InsertWorker(Worker worker);
	}
}
