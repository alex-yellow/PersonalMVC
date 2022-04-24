using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalMvc.Models
{
    public class Personal
    {
        public int Id { get; set; }
        [Display(Name = "ФИО")]
        public string Name { get; set; }
        public int? ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        [Display(Name = "Зарплата")]
        public int Salary { get; set; }
    }
}