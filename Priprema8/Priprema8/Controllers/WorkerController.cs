using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priprema2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkerController : ControllerBase
	{

		private IWorkerBusiness workerBusiness;

		public WorkerController(IWorkerBusiness workerBusiness)
		{
			this.workerBusiness = workerBusiness;
		}

		[HttpGet("getall")]
		public List<Worker> GetAllWorkers()
		{
			return this.workerBusiness.GetAllWorkers();
		}

		[HttpPost("insert")]
		public bool InsertWorker(Worker worker)
		{
			return this.workerBusiness.InsertWorker(worker);
		}

		[HttpGet("get/{profession}")]
		public List<Worker> GetWorkersWithProfession(string profession)
		{
			return this.workerBusiness.GetWorkersWithProfession(profession);
		}

	}
}
