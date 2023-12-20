using Microsoft.AspNetCore.Mvc;

namespace WakuWakuAPI.Presentation.Controllers {
    public class SkillController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
