using DomainModel.Entities;
using DomainModel.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SocialNetworkContext : DbContext
    {
        public DbSet<ProfileModel> Profiles { get; set; }

        public SocialNetworkContext() : base(Data.Properties.Settings.Default.DbConnectionString)
        {
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
