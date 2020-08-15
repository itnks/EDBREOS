using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EDBREOS.Models;
using Microsoft.EntityFrameworkCore;

namespace EDBREOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly Contexts db;

        public HomeController(Contexts context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var _allProjects = db.Projects.ToList();
            return View(_allProjects);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            List<Project> _projects = new List<Project>();
            _projects = await db.Project.Where(_p => _p.Project_Id == id).ToListAsync();
            return View(_projects);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
