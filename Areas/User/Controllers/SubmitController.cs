using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_ELearning.Services.Interfaces;

namespace Smart_ELearning.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "Teacher")]
    public class SubmitController : Controller
    {
        private readonly ISubmissionService _submissionService;

        public SubmitController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _submissionService.Delete(id);
            if (result == 0) return BadRequest("Cound not found");
            return Json(new {success = true, message = "Delete Successful"});
            ;
        }
    }
}