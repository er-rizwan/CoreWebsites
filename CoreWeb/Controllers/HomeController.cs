using CoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index()
		{
			var studentdata = await studentDB.Students.ToListAsync();
				return View(studentdata);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Student student)
		{
			if (ModelState.IsValid)
			{
			await studentDB.Students.AddAsync(student);
				await studentDB.SaveChangesAsync();
				TempData["create_msg"] = "Successfully Created.";
                return RedirectToAction("Index","Home");
			}
				TempData["Create_msg"] = "Unseccessful. Try again!";
            return View(student);
		     }

        public async Task<IActionResult> Details(int? id)
        {
				if (id == null || studentDB.Students==null) {
				 return NotFound();
				}
				var studentdata = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);
				if (studentdata == null)
				{
                    return NotFound();
                }
			 return View(studentdata);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }

            var studentdata = await studentDB.Students.FindAsync(id);

			if (studentdata == null) {
				return NotFound();
			}

			return View(studentdata);
        }

		[HttpPost]
		public async Task<IActionResult> Edit(int? id,Student student)
		{
			if (!ModelState.IsValid)
			{
                return View(student);
			}

			if (student.Id != id) {
				return NotFound();
			}

            studentDB.Students.Update(student);
            await studentDB.SaveChangesAsync();
            TempData["edit_msg"] = "Successfully Updated.";
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var studentdata = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (studentdata == null)
            {
                return NotFound();
            }
            return View(studentdata);
        }

		[HttpPost,ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirm(int? id)
		{
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }

            var studentdata = await studentDB.Students.FindAsync(id);

            if (studentdata == null)
            {
                return NotFound();
            }

			studentDB.Students.Remove(studentdata);
			await studentDB.SaveChangesAsync();
            TempData["delete_msg"] = "Successfully Deleted.";
            return RedirectToAction("Index", "Home");
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
