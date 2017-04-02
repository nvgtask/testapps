using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebApplication1.Business;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HighScoreController : Controller
    {
        // GET: HighScore
        public ActionResult Index()
        {
            HighScoreBusiness hsBus = new HighScoreBusiness();
            var highScores = hsBus.GetAll();
            return View(highScores);
        }

        [HttpPost]
        public JsonResult Create(HighScoreModel highScore)
        {
            HighScoreBusiness hsBus = new HighScoreBusiness();
            hsBus.CreateNew(highScore);
            return Json(new {Message = "Success"});
        }
    }
}