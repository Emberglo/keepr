using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr_server.Models;

namespace keepr_server.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep Get(int id)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE id = @id";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
        }

        public int Create(VaultKeep newVk)
        {
            string sql = @"INSERT INTO vaultkeeps (creatorId, vaultId, keepId) VALUES (@CreatorId, @VaultId, @KeepId);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newVk);
        }

        internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
        {
            string sql = "SELECT k.*, vk.id as VaultKeepId, p.* FROM vaultkeeps vk JOIN keeps k ON k.id = vk.keepId JOIN profiles p ON p.id = k.creatorId WHERE vaultId = @vaultId;";
            return _db.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql, (keep, profile) =>
            { keep.Creator = profile; return keep; }, new { vaultId }, splitOn: "id");
        }

        internal bool Remove(int id)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @id";
            int valid = _db.Execute(sql, new { id });
            return valid > 0;
        }

    }
}