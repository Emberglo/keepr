using System;
using System.Collections.Generic;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        public VaultKeep Create(VaultKeep newVk, string userId, Vault selectedVault)
        {
            if (selectedVault == null) { throw new Exception("Bad Id"); }
            if (selectedVault.CreatorId != userId)
            {
                throw new Exception("Not Your Vault");
            }
            newVk.Id = _repo.Create(newVk);
            return newVk;
        }

        internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
        {
            return _repo.GetKeepsByVaultId(vaultId);
        }

        internal string Delete(int id, string userId)
        {
            VaultKeep selectedVaultKeep = _repo.Get(id);
            if (selectedVaultKeep == null)
            {
                throw new Exception("Bad Id");
            }
            if (selectedVaultKeep.CreatorId != userId)
            {
                throw new Exception("Not Your VaultKeep");
            }
            if (_repo.Remove(id))
            {
                return "Great Success!";
            }
            return "Much Failure";
        }
    }
}