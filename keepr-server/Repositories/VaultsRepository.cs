using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr_server.Models;

namespace vaultr_server.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        // private readonly string populateCreator = "SELECT vault.*, profile.* FROM vaults vault INNER JOIN profiles profile ON vault.creatorId = profile.id";

        public Vault GetVaultById(int id)
        {
            Vault selectedVault = this.GetOne(id);
            return selectedVault;
        }

        public IEnumerable<Vault> GetVaultsByProfile(string profileId)
        {
            string sql = "SELECT vault.*, p.* FROM vaults vault JOIN profiles p ON vault.creatorId = p.id WHERE vault.creatorId = @profileId;";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, new { profileId }, splitOn: "id");
        }

        internal Vault GetOne(int id)
        {
            string sql = "SELECT * FROM vaults WHERE id = @id";
            return _db.QueryFirstOrDefault<Vault>(sql, new { id });
        }

        internal int Create(Vault newVault)
        {
            string sql = @"INSERT INTO vaults (name, description, creatorId, isPrivate) VALUES (@Name, @Description, @CreatorId, @IsPrivate);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newVault);
        }

        internal bool Delete(int id)
        {
            string sql = "DELETE FROM vaults WHERE id = @id";
            int valid = _db.Execute(sql, new { id });
            return valid > 0;
        }
    }
}