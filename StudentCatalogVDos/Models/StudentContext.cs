using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentCatalogVDos.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> StudentDatBase { get; set; }
    }
}