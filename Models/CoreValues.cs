using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200ProjectTeam7.Models
{
    public class CoreValues
    {
        public int ID { get; set; }
        
        [Display(Name = "Core value recognized")]
        public CoreValue award { get; set; }
        
        [Display(Name = "ID of Person giving the recognition")]
        public Guid recognizor { get; set; }
        
        
        [Display(Name = "ID of Person receiving the recognition")]
        public Guid recognized { get; set; }


        [Display(Name = "Personalized description of recognition")]
        public string description { get; set; }
       
       
        [Display(Name = "Date recognition given")]
        public DateTime recognizationDate { get; set; }
        public enum CoreValue
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Innovate = 4,
            Balance = 5
        }
    }
}