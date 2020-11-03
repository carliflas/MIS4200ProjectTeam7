using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200ProjectTeam7.Models
{
    public class EmployeeContact
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [StringLength(20)]

        [Required]
        [Display(Name = "Last Name")]

        public string lastName { get; set; }



        [Display(Name = "Employee Title")]
        public string empTitle { get; set; }

        [Display(Name = "Work Email")]
        public string Wemail
        {
            get; set;

        }
    }
}