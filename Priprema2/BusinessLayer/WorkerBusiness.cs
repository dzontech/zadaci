using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
	public class WorkerBusiness : IWorkerBusiness
	{
		private IWorkerRepository workerRepository;

		public WorkerBusiness(IWorkerRepository workerRepository)
		{
			this.workerRepository = workerRepository;
		}

		public List<Worker> GetAllWorkers()
		{
			List<Worker> list = this.workerRepository.GetAllWorkers();
			if (list.Count > 0)
				return list;
			else
				return null;
		}

		public List<Worker> GetWorkersWithProfession(string profession)
		{
			List<Worker> list = this.workerRepository.GetAllWorkers();
			return list.FindAll(w => w.Profession.Equals(profession));
		}

		public bool InsertWorker(Worker worker)
		{
			if (this.workerRepository.InsertWorker(worker) > 0)
				return true;
			else
				return false;
		}
	}
}
