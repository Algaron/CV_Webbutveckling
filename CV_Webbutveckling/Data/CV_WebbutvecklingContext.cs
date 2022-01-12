#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CV_Webbutveckling.Models;

namespace CV_Webbutveckling.Data
{
    public class CV_WebbutvecklingContext : DbContext
    {
        public CV_WebbutvecklingContext (DbContextOptions<CV_WebbutvecklingContext> options)
            : base(options)
        {
        }

        public DbSet<CV_Webbutveckling.Models.WorkExperience> WorkExperience { get; set; }

        public DbSet<CV_Webbutveckling.Models.EducationExperience> EducationExperience { get; set; }
    }
}
