using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIS4200ProjectTeam7.Models
{
    public class CoreValues
    {
        public int ID { get; set; }
        
        [Display(Name = "Core value displayed")]
        public CoreValue award { get; set; }
        
        [Display(Name = "Nominator")]
        public Guid recognizor { get; set; }
        
        
        [Display(Name = "Nominee")]
        public Guid recognized { get; set; }


        [Display(Name = "Personalized description of event")]
        public string description { get; set; }
       
       
        [Display(Name = "Date of recognition")]
        public DateTime recognizationDate { get; set; }

       [ForeignKey("recognized")]
        public virtual ProfileInfo nominee { get; set; }

        [ForeignKey("recognizor")]
        public virtual ProfileInfo nominator { get; set; }


        public enum CoreValue
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balance = 5,
                Culture = 6,
                Passion = 7

        }
    }
}