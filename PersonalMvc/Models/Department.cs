using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name = "Отдел")]
        public string Name { get; set; }
        public ICollection<Profession> Professions { get; set; }
        public ICollection<Personal> Personals { get; set; }
        public Department()
        {
            Professions = new List<Profession>();
            Personals = new List<Personal>();
        }
    }
}