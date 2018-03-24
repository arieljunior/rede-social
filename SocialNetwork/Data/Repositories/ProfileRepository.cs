using Domain.Interfaces.Repositories;
using DomainModel.Entities;
using DomainModel.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProfileRepository : IRepository<ProfileModel>
    {
        private string _connectionString;
        private SqlConnection _sqlConnection;

        public ProfileRepository()
        {
            _connectionString = Data.Properties.Settings.Default.DbConnectionString;
            _sqlConnection = new SqlConnection(_connectionString);
        }
        public IEnumerable<ProfileModel> GetAll()
        {
            return null;
        }

        public ProfileModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string id)
        {
            var result = false;
            SqlCommand cmd = new SqlCommand($"DELETE FROM Profile WHERE Id = '{id}'", _sqlConnection);
            try
            {
                _sqlConnection.Open();
                result = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _sqlConnection.Close();
            }
            return result;
        }

        public bool Save(ProfileModel profile)
        {
            var result = false;
            SqlCommand cmd = new SqlCommand($"INSERT INTO Profile (Id, FirstName, LastName, Password, UrlPhoto, Email," +
                $"City, DateCreated) Values ('{profile.IdProfile}'," +
                $"'{profile.Name}', '{profile.LastName}', '{profile.Password}','{profile.UrlPhoto}'," +
                $"'{profile.Email}', '{profile.City}', '{profile.DateCreated}' )", _sqlConnection);
            try
            {
                _sqlConnection.Open();
                result = cmd.ExecuteNonQuery() > 0 ? true : false;
            }catch(Exception ex)
            {

            }
            finally
            {
                _sqlConnection.Close();
            }
            return result;
        }

        public bool UpDate(ProfileModel obj)
        {
            var result = false;
            SqlCommand cmd = new SqlCommand($"DELETE FROM Profile WHERE Id = '{id}'", _sqlConnection);
            try
            {
                _sqlConnection.Open();
                result = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _sqlConnection.Close();
            }
            return result;
        }
    }
}
