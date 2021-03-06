using System;
using System.Collections.Generic;
using System.Linq;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Keep> Get()
        {
            return _repo.Get();
        }

        public Keep GetKeepById(int id)
        {
            return _repo.GetKeepById(id);
        }

        public IEnumerable<Keep> GetKeepsByProfile(string profileId, string userId)
        {
            // return _repo.GetKeepsByProfile(profileId).ToList().FindAll(k => k.CreatorId == userId); CHANGED TO PROFILEID
            return _repo.GetKeepsByProfile(profileId).ToList().FindAll(k => k.CreatorId == profileId);
        }

        public Keep Create(Keep newKeep)
        {
            newKeep.Id = _repo.Create(newKeep);
            return newKeep;
        }

        internal Keep Edit(Keep editedKeep, string userId)
        {
            Keep originalKeep = _repo.GetOne(editedKeep.Id);
            if (originalKeep == null) { throw new Exception("Incorrect ID"); }
            if (originalKeep.CreatorId != userId)
            {
                throw new Exception("Not Your Keep");
            }
            _repo.Edit(editedKeep);
            return _repo.GetOne(editedKeep.Id);
        }

        internal string Delete(int id, string userId)
        {
            Keep selectedKeep = _repo.GetOne(id);
            if (selectedKeep == null) { throw new Exception("Incorrect ID"); }
            if (selectedKeep.CreatorId != userId)
            {
                throw new Exception("Not Your Keep");
            }
            if (_repo.Delete(id))
            {
                return "Great Success";
            }
            return "Much Failure";
        }
    }
}