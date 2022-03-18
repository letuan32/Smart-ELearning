using Microsoft.AspNetCore.Mvc;

namespace Smart_ELearning.Areas.User.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult TempMessage()
        {
            return PartialView();
        }
    }
}