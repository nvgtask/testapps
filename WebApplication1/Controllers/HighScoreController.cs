using System.Web.Mvc;
using WebApplication1.Business;
using WebApplication1.Constants;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel.HighScore;

namespace WebApplication1.Controllers
{
    public class HighScoreController : Controller
    {
        // GET: HighScore
        public ActionResult Index()
        {
            HighScoreBusiness hsBus = new HighScoreBusiness();
            IndexViewModel viewModel = new IndexViewModel {HighScores = hsBus.GetAll()};
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            HighScoreModel hsModel = new HighScoreModel();
            return View(hsModel);
        }

        [HttpPost]
        public ActionResult Create(HighScoreModel highScore)
        {
            if (ModelState.IsValid)
            {
                HighScoreBusiness hsBus = new HighScoreBusiness();
                hsBus.CreateNew(highScore);
                return RedirectToAction("Index");
            }
            return Json(new {Message = Message.CannotCreate}, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            HighScoreBusiness hsBus = new HighScoreBusiness();
            bool result = hsBus.Delete(id);
            return Json(new { Id = id, IsDeleted = result }, JsonRequestBehavior.AllowGet);

        }
    }
}