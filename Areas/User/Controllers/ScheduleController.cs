using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart_ELearning.Data;
using Smart_ELearning.Models;
using Smart_ELearning.Services.Interfaces;
using Smart_ELearning.ViewModels;

namespace Smart_ELearning.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "Teacher")]
    public class ScheduleController : Controller
    {
        private readonly IClassService _classService;
        private readonly ApplicationDbContext _context;
        private readonly IScheduleService _schedule;
        private readonly ISubjectService _subject;

        public ScheduleController(IScheduleService schedule, IClassService classService, ISubjectService subject,
            ApplicationDbContext context)
        {
            _schedule = schedule;
            _classService = classService;
            _subject = subject;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id, int? classId)
        {
            var scheduleViewModel = new ScheduleViewModel
            {
                ScheduleModel = new ScheduleModel
                {
                    DateTime = DateTime.Now.Date
                },
                ClassListItems = _classService.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                SubjectListItems = _subject.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null)
            {
                if (classId.HasValue)
                {
                    var classModel = _classService.GetById(classId.Value);
                    ViewBag.ClassId = classModel.Id;
                    ViewBag.ClassName = classModel.Name;
                    scheduleViewModel.ScheduleModel.ClassId = classModel.Id;
                }

                return View(scheduleViewModel);
            }

            scheduleViewModel.ScheduleModel = _schedule.GetById(id);
            return View(scheduleViewModel);
        }

        public IActionResult ScheduleToTest(int id)
        {
            var classFromDb = _schedule.GetById(id);
            ViewBag.ScheduleId = classFromDb.Id;
            ViewBag.ClassId = classFromDb.ClassId;
            ViewBag.ScheduleName = classFromDb.Title;
            return View();
        }

        [HttpGet]
        public IActionResult GetScheduleToTest(int id)
        {
            var obj = _schedule.GetScheduleToTest(id);
            return Json(new {data = obj});
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] int id)
        {
            var ojbFromdb = _context.TestModels.FirstOrDefault(u => u.Id == id);
            if (ojbFromdb == null) return Json(new {success = false, Message = "Error While Lock/Unlock"});

            if (ojbFromdb.LockoutEnd != null && ojbFromdb.LockoutEnd > DateTime.Now)
                ojbFromdb.LockoutEnd = DateTime.Now;
            else
                ojbFromdb.LockoutEnd = DateTime.Now.AddYears(1000);

            _context.SaveChanges();
            return Json(new {success = true, Message = "Success"});
        }

        public async Task<IActionResult> ClassSchedule(int? classId)
        {
            var data = await _classService.GetByIdAsync(classId.Value);
            ViewBag.ClassId = data.Id;
            ViewBag.ClassName = data.Name;
            return View();
        }

        #region APICall

        [HttpGet]
        public IActionResult GetClassSchedule(int id)
        {
            var data = _schedule.GetClassSchedule(id);
            return Json(new {data});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ScheduleViewModel scheduleViewModel)
        {
            if (!ModelState.IsValid) return View(scheduleViewModel);
            var obj = _schedule.Upsert(scheduleViewModel);
            if (obj == 0) return View(scheduleViewModel);
            return RedirectToAction("ClassSchedule", new {classId = scheduleViewModel.ScheduleModel.ClassId});
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _schedule.GetAll();
            return Json(new {data = allObj});
        }

        [HttpGet]
        public IActionResult GetDisplay()
        {
            var allObj = _schedule.GetDisplay();
            return Json(new {data = allObj});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _schedule.GetById(id);
            if (objFromDb == null) return Json(new {success = false, message = "Error while deleting"});

            _schedule.Delete(id);
            return Json(new {success = true, message = "Delete Successful"});
        }

        #endregion APICall
    }
}