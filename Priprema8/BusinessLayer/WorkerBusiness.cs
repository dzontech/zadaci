using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
	public class WorkerBusiness : IWorkerBusiness
	{
		private IWorkerRepo workerRepository;

		public WorkerBusiness(IWorkerRepo workerRepository)
		{
			this.workerRepository = workerRepository;
		}

		public List<Worker> GetAllWorkers()
		{
			List<Worker> list = this.workerRepository.GetWorkers();
			if (list.Count > 0)
				return list;
			else
				return null;
		}

		public List<Worker> GetWorkersWithProfession(string profession)
		{
			List<Worker> list = this.workerRepository.GetWorkers();
			return list.FindAll(w => w.Profession.Equals(profession));
		}

		public bool InsertWorker(Worker worker)
		{
			if (this.workerRepository.Insert(worker) > 0)
				return true;
			else
				return false;
		}
	}
}
