using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class CommentModel
    {
        [Key]
        public String PosterName { get; set; }
        public String Description { get; set; }
        public double Stars { get; set; }
    }
}


