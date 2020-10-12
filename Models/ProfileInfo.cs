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
        public int profileId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }
        public string fullname { get; set; }

        public string bizUnit { get; set; }

        public DateTime hireDate { get; set; }

        public string bio { get; set; }

        public string phone { get; set; }

        public string email { get; set; }
    }
}