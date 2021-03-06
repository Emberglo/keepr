using System;
using System.Data;
using Dapper;
using keepr_server.Models;

namespace keepr_server.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;
        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }

        public Profile GetByEmail(string email)
        {
            string sql = "SELECT * FROM profiles WHERE email = @Email";
            return _db.QueryFirstOrDefault<Profile>(sql, new { email });
        }

        public Profile GetOtherProfile(string profileId)
        {
            string sql = "SELECT * FROM profiles WHERE id = @profileId";
            return _db.QueryFirstOrDefault<Profile>(sql, new { profileId });
        }

        public Profile Create(Profile userInfo)
        {
            string sql = "INSERT INTO profiles (name, picture, email, id) VALUES (@Name, @Picture, @Email, @Id)";
            _db.Execute(sql, userInfo);
            return userInfo;
        }
    }
}