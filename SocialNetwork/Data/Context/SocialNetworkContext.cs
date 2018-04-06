using DomainModel.Entities.Post;
using DomainModel.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext()
            : base(Data.Properties.Settings.Default.DbConnectionString)
        { }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
