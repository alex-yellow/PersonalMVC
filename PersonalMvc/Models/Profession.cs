using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalMvc.Models
{
    public class Profession
    {
        public int Id { get; set; }
        [Display(Name = "Профессия")]
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Personal> Personals { get; set; }
        public Profession()
        {
            Personals = new List<Personal>();
        }
    }
}