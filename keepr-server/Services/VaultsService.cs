using System;
using System.Collections.Generic;
using System.Linq;
using keepr_server.Models;
using keepr_server.Repositories;
using vaultr_server.Repositories;

namespace keepr_server.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        public Vault GetVaultById(int id, string userId)
        {
            Vault selectedVault = _repo.GetOne(id);
            if (selectedVault.CreatorId != userId && selectedVault.isPrivate == true)
            {
                throw new Exception("Private Vault");
            }
            return _repo.GetVaultById(id);
        }

        public IEnumerable<Vault> GetVaultsByProfile(string profileId, string userId)
        {
            return _repo.GetVaultsByProfile(profileId).ToList().FindAll(v => v.CreatorId == userId || v.isPrivate == false);
        }

        public Vault Create(Vault newVault)
        {
            newVault.Id = _repo.Create(newVault);
            return newVault;
        }

        internal string Delete(int id, string userId)
        {
            Vault selectedVault = _repo.GetOne(id);
            if (selectedVault == null) { throw new Exception("Incorrect ID"); }
            if (selectedVault.CreatorId != userId)
            {
                throw new Exception("Not Your Vault");
            }
            if (_repo.Delete(id))
            {
                return "Great Success";
            }
            return "Much Failure";
        }
    }
}