using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_ELearning.Models;
using Smart_ELearning.Services.Interfaces;

namespace Smart_ELearning.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "Teacher")]
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var subjectModel = new SubjectModel();
            if (id == null) return View(subjectModel);
            var subjectId = id.Value;
            subjectModel = await _subjectService.GetById(subjectId);
            return View(subjectModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(SubjectModel subjectModel)
        {
            if (!ModelState.IsValid) return View(subjectModel);
            var result = await _subjectService.Upsert(subjectModel);
            if (result == 0) return View(subjectModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _subjectService.GetAllAsync();
            return Json(new {data});
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _subjectService.Delete(id);
            if (result == 0) return BadRequest("Cound not found");
            return Json(new {success = true, message = "Delete Successful"});
            ;
        }
    }
}