using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class RMSDBContext : DbContext
    {
        public RMSDBContext() : base("RMS")
        {

        }
        public DbSet<reg_Page> Reg_Pages { get; set; }
    }
}