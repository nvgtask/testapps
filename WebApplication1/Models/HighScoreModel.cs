using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HighScoreModel
    {
        public double Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(Int32.MinValue,Int32.MaxValue)]
        public int Score { get; set; }
    }
}