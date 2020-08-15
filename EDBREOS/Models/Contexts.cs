using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EDBREOS.Models
{
    public class Contexts : DbContext
    {

        public Contexts(DbContextOptions<Contexts> options)
            : base(options)
        {
        }

        public DbSet<Models.Project> Project { get; set; }
        public DbSet<Models.Projects> Projects { get; set; }
        public DbSet<Models.ProjectAdditionalDetails> ProjectAD { get; set; }
    }
}
