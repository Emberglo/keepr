using System;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _repo;
        public ProfilesService(ProfilesRepository repo)
        {
            _repo = repo;
        }

        public Profile GetOrCreateProfile(Profile userInfo)
        {
            Profile foundProfile = _repo.GetByEmail(userInfo.Email);
            if (foundProfile == null)
            {
                return _repo.Create(userInfo);
            }
            return foundProfile;
        }

        internal Profile GetOtherProfile(string profileId)
        {
            return _repo.GetOtherProfile(profileId);
        }
    }
}