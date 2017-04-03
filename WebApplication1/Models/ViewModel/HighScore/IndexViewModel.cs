using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel.HighScore
{
    public class IndexViewModel
    {
        public List<HighScoreModel> HighScores { get; set; }

        public IndexViewModel()
        {
            HighScores = new List<HighScoreModel>();
        }
    }
}