using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using MIS4200ProjectTeam7.Models;

namespace MIS4200ProjectTeam7.DAL
{
    public class MIS4200Team7Context : DbContext
    {
        public MIS4200Team7Context() : base ("name=DefaultConnection")

        {

        }

        public DbSet <ProfileInfo> ProfileInfos { get; set; }

    }
}