using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using WebApplication1.Frame.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Business
{
    public class HighScoreBusiness
    {
        public List<HighScoreModel> GetAll()
        {
            using (var sdp = new SQLiteDataProvider())
            {
                var results = new List<HighScoreModel>();
                var query = "select rowid, * from highscores";
                SQLiteCommand command = sdp.GetCommand(query);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new HighScoreModel
                    {
                        Id = Double.Parse(reader["rowid"].ToString()),
                        Name = reader["name"].ToString(),
                        Score = (int) reader["score"]
                    });
                }
                return results;
            }
        }

        public void CreateNew(HighScoreModel highScore)
        {
            using (var sdp = new SQLiteDataProvider())
            {
                var results = new List<HighScoreModel>();
                var query = $"insert into highscores (name, score) values ({highScore.Name}, {highScore.Score})";
                sdp.ExecuteNonQuery(query);    
            }
        }
    }
}