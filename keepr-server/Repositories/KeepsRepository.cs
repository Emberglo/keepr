using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr_server.Models;

namespace keepr_server.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;
        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        private readonly string populateCreator = "SELECT keep.*, profile.* FROM keeps keep INNER JOIN profiles profile ON keep.creatorId = profile.id";

        public IEnumerable<Keep> Get()
        {
            string sql = populateCreator;
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, splitOn: "id");
        }

        public Keep GetKeepById(int id)
        {
            Keep selectedKeep = this.GetOne(id);
            return selectedKeep;
        }

        internal Keep GetOne(int id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }

        internal int Create(Keep newKeep)
        {
            string sql = @"INSERT INTO keeps (name, description, creatorId, img, views, shares, keeps) VALUES (@Name, @Description, @CreatorId, @Img, @Views, @Shares, @Keeps);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newKeep);
        }

        internal void Edit(Keep editedKeep)
        {
            string sql = "UPDATE keeps SET views = @Views, shares = @Shares, keeps = @keeps WHERE id = @Id;";
            _db.Execute(sql, editedKeep);
        }

        internal bool Delete(int keepId)
        {
            string sql = "DELETE FROM keeps WHERE keepId = @id";
            int valid = _db.Execute(sql, new { keepId });
            return valid > 0;
        }
    }
}