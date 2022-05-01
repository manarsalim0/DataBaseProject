using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResourcesBankNew.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;


namespace ResourcesBankNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ResourcesBankContext _context;

        public HomeController(ILogger<HomeController> logger, ResourcesBankContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.EngFaculties = _context.EngFaculties.ToList();
            List<searchM> searchMs = new List<searchM>()
            {
                new searchM(){Id=1,Name="Faculty"},
                new searchM(){Id=2,Name="Major"},
                //new searchM(){Id=3,Name="Level"},
                new searchM(){Id=4,Name="Course"}
            };
            var selecitListmodel = new selecitListModel 
            { 
                engFaculties=_context.EngFaculties.ToList(), 
                level = _context.Levels.ToList(), 
                courses = _context.Courses.ToList(), 
                major =_context.Majors.ToList(),
                searchM= searchMs

            };

            return View(selecitListmodel);
        }

        public JsonResult GetMajorByFacultyId(int Id)
        {
            var data = _context.Majors.Where(z => z.FacultyId == Id).ToList();
            return Json(data);
        }
        public JsonResult GetLevelByMajorId(int Id)
        {
            var data = _context.Levels.Where(z => z.MajorId == Id).ToList();
            return Json(data);
        } 
        public JsonResult GetCourseByLevelId(int Id)
        {
            var data = _context.Courses.Where(z => z.LevelId == Id).ToList();
            return Json(data);
        } 
        public JsonResult Getlinke(int Id)
        {
            var data = _context.Courses.Where(z => z.CourseId == Id).FirstOrDefault();
            return Json(data);
        }
        
        public JsonResult search(int Id, string text)
        {
            if (Id == 1)
            {
                var Faculty = _context.EngFaculties.Where(z => z.FacultyName.Contains(text)).Include(x => x.Majors).ToList();
                return Json(Faculty);

            }
            else if (Id == 2)
            {
                var Major = _context.Majors.Include(x => x.Faculty).Include(x => x.Levels).Where(z => z.Name.Contains(text)).ToList();
                return Json(Major);

            }
            //else if (Id == 3) 
            //{ 
            //    var data = _context.Levels.Include(x => x.Courses).Include(x => x.Major).Where(z => z.LevelNum.Contains(int(text))).ToList(); 
            //    return Json(data); 

            //} 
            else
            {
                var data = _context.Courses.Where(z => z.CourseName.Contains(text)).Include(x => x.Level).Include(x => x.Level.Major.Faculty).Include(x => x.Level.Major).ToList();
                return Json(data);
            }
        }
        //public JsonResult GetFacultiyList(string searchTerm)
        //{
        //    var FacultyList = _context.EngFaculties.ToList();

        //    if (searchTerm != null)
        //    {
        //        FacultyList = _context.EngFaculties.Where(z => z.FacultyName.Contains(searchTerm)).ToList();
        //    }

        //    var modifiedData = FacultyList.Select(x => new
        //    {
        //        id = x.FacultyId,
        //        text = x.FacultyName
        //    });
        //    return Json(modifiedData);
        //}

        //public IActionResult Privacy()
        //{
        //    List<searchM> searchMs = new List<searchM>()
        //    {
        //        new searchM(){Id=1,Name="Faculty"},
        //        new searchM(){Id=2,Name="Major"},
        //        new searchM(){Id=3,Name="Level"},
        //        new searchM(){Id=4,Name="Course"}
        //    };
        //    ViewBag.items = new SelectList(searchMs, "Id", "Name");
        //    return View();
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
