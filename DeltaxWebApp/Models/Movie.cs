using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeltaxWebApp.Models
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime yearOfRelease { get; set; }
        public string plot { get; set; }
        public string Poster { get; set; }
        public string Actors { get; set; }

    }
}