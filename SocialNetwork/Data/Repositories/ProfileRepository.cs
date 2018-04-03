using Data.Context;
using Domain.Interfaces.Repositories;
using DomainModel.Entities;
using DomainModel.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProfileRepository : IRepository<Profile>
    {
        private DbConnectionString _socialNetworkContext;
        private DbSet<Profile> _dbSet;

        public ProfileRepository(DbConnectionString socialNetworkContext)
        {

            _socialNetworkContext = socialNetworkContext;
            _dbSet = socialNetworkContext.Set<Profile>();
        }

        public IEnumerable<Profile> GetAll()
        {
            return _dbSet;
        }

        public Profile GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public bool Remove(Profile profile)
        {
            try
            {
                _dbSet.Remove(profile);
                _socialNetworkContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetIdByEmail(string email)
        {
            var connection = new SqlConnection("Server=tcp:socialnetworkdb.database.windows.net,1433;Initial Catalog=SocialNetworkDB;Persist Security Info=False;User ID=snadmin;Password=PROJETO_infnet;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand sqlCommand = new SqlCommand($"SELECT Id from AspNetUSers WHERE Email='{email}'", connection);
            string Email = "";

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    Email = reader["Email"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
                return Email;
        }

        public bool Save(Profile obj)
        {
            try
            {
                _dbSet.Add(obj);
                _socialNetworkContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpDate(Profile profile)
        {
            try
            {
                _socialNetworkContext.Entry(profile).State = EntityState.Modified;
                _socialNetworkContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
