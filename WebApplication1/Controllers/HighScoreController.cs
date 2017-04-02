using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Business;

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
    }
}