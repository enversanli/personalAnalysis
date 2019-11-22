using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace projectForWork.Models
{
    //Veritabanı Veri Modelleri
    public class databaseContext : DbContext
    {
        public DbSet<questions> Questions { get; set; }

        public DbSet<variables> Variables { get; set; }

       
    }
}