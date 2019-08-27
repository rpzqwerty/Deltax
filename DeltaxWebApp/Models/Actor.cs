using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeltaxWebApp.Models
{
    public class Actor
    {
        [Key]
        public int id { get; set; }
        public String Name { get; set; }
        public string sex { get; set; }
        public DateTime dob { get; set; }
        public string bio { get; set; }
    }
}