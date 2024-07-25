using CoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly StudentDBContext studentDB;

		//private readonly ILogger<HomeController> _logger;

		//public HomeController(ILogger<HomeController> logger)
		//{
		//	_logger = logger;
		//}
		public HomeController(StudentDBContext studentDB)
        {
			this.studentDB = studentDB;
		}
        public IActionResult Index()
		{
			var studentdata = studentDB.Students.ToList();
				return View(studentdata);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
