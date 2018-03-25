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
            var Profiles = new List<ProfileModel>();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Profile", _sqlConnection);

            try
            {
                _sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var profile = new ProfileModel();
                    profile.IdProfile = Guid.Parse(reader["Id"].ToString());
                    profile.Name = reader["FirstName"].ToString();
                    profile.LastName = reader["LastName"].ToString();
                    profile.Password = reader["Password"].ToString();
                    profile.UrlPhoto = reader["UrlPhoto"].ToString();
                    profile.City = reader["City"].ToString();
                    profile.DateCreated = DateTime.Parse(reader["DateCreated"].ToString());
                    profile.Email = reader["Email"].ToString();
                    profile.Followers = 0;//reader["Followers"] != null? (int)reader["Followers"] : 0;
                    profile.Following = 0;//reader["Following"] != null? (int)reader["Following"] : 0;
                    Profiles.Add(profile);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _sqlConnection.Close();
            }

            return Profiles;
        }

        public ProfileModel GetById(string id)
        {
            ProfileModel profileResult = new ProfileModel();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Profile WHERE Id='{id.ToUpper()}'", _sqlConnection);

            try
            {
                _sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    profileResult.IdProfile = Guid.Parse(reader["Id"].ToString());
                    profileResult.Name = reader["FirstName"].ToString();
                    profileResult.LastName = reader["LastName"].ToString();
                    profileResult.Password = reader["Password"].ToString();
                    profileResult.UrlPhoto = reader["UrlPhoto"].ToString();
                    profileResult.City = reader["City"].ToString();
                    profileResult.DateCreated = DateTime.Parse(reader["DateCreated"].ToString());
                    profileResult.Email = reader["Email"].ToString();
                    profileResult.Followers = 0;//reader["Followers"] != null? (int)reader["Followers"] : 0;
                    profileResult.Following = 0;//reader["Following"] != null? (int)reader["Following"] : 0;

                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                _sqlConnection.Close();
            }

            return profileResult;
        }

        public bool Remove(string id)
        {
            var result = false;
            SqlCommand cmd = new SqlCommand($"DELETE FROM Profile WHERE Id = '{id.ToUpper()}'", _sqlConnection);
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

        public bool UpDate(string id, ProfileModel profile)
        {
            var result = false;
            SqlCommand cmd = new SqlCommand($"UPDATE Profile SET FirstName = '{profile.Name}', LastName='{profile.LastName}', " +
                $"Password='{profile.Password}', UrlPhoto='{profile.UrlPhoto}', Email='{profile.Email}'," +
                $"City='{profile.City}' WHERE Id = '{id.ToUpper()}'", _sqlConnection);
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
