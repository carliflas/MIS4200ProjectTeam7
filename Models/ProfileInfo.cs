using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200ProjectTeam7.Models
{
    public class ProfileInfo
    {

        [Key]
        public Guid ProfileId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [StringLength(20)]

        [Required]
        [Display(Name = "Last Name")]
        
        public string lastName { get; set; }


        [Display(Name = "Business Unit")]
        public string bizUnit { get; set; }

        [Display(Name = "Employee Title")]
        public string empTitle { get; set; }

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime hireDate { get; set; }

        [Display(Name = "Short Bio")]
        [StringLength(500)]
        public string bio { get; set; }

        [Required]
        [Display(Name = "Primary Phone")]
        [Phone]
        [StringLength(20)]
        public string phone { get; set; }


        [Required]
        [Display(Name = "Work Email")]
        [EmailAddress]
             public string WorkEmail { get; set; }
    }

       
    }
