using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIS4200ProjectTeam7.Models
{
    public class position
    {
        [Key]

        public int positionId { get; set; }

        [Display(Name = "Employee Title")]
        public string empTitle { get; set; }

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime hireDate { get; set; }

        public Guid bossId { get; set; }

        public Guid workerId { get; set; }

        [ForeignKey("workerId")]
        public virtual ProfileInfo worker { get; set; }


        [ForeignKey("bossId")]
        public virtual ProfileInfo boss { get; set; }


    }
}
