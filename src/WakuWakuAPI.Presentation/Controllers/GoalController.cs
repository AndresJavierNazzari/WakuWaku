using Microsoft.AspNetCore.Mvc;

namespace WakuWakuAPI.Presentation.Controllers {
    public class GoalController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
