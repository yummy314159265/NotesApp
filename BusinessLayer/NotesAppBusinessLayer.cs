using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using RepoLayer;

namespace BusinessLayer
{
    public class NotesAppBusinessLayer : INotesAppBusinessLayer
    {

        private readonly INotesAppRepoLayer _repo;

        public NotesAppBusinessLayer(INotesAppRepoLayer repo)
        {
            _repo = repo;
        }

        public async Task<Profile?> CreateProfileAsync(CreateProfileDto request, string auth0id)
        {
            Profile? alreadyExistingProfile = await this._repo.GetProfileByUserIDAsync(auth0id);

            if (alreadyExistingProfile != null)
            {
                return null;
            }

            Profile? createdProfile = await this._repo.CreateProfileAsync(request, auth0id);

            return createdProfile;
        }

        public async Task<bool> DeleteProfileAsync(string auth0id)
        {
            Profile? p = await this._repo.GetProfileByUserIDAsync(auth0id);

            if (p == null)
            {
                return false;
            }

            bool deletedSuccess = await this._repo.DeleteProfileAsync(auth0id);

            return deletedSuccess;
        }

        public async Task<Profile?> GetUserProfileAsync(UserIdDto userID)
        {
            return await this._repo.GetProfileByUserIDAsync(userID.ID);
        }

        public async Task<Profile?> UpdateProfileAsync(UpdateProfileDto request, string auth0id)
        {
            Profile? currentProfile = await this._repo.GetProfileByUserIDAsync(request.Fk_UserID);

            if (currentProfile == null)
            {
                return null;
            }

            bool notThisUsersProfile = (request.Fk_UserID == auth0id);
            
            if (notThisUsersProfile)
            {
                return null;
            }

            bool noChangeMade = (currentProfile.Name == request.Name && currentProfile.Nickname == request.Nickname && currentProfile.Picture == request.Picture);

            if (noChangeMade)
            {
                return currentProfile;
            }

            Profile updatedProfile = new Profile()
            {
                FkUserId = currentProfile.FkUserId,
                Name = request.Name,
                Nickname = request.Nickname,
                Picture = request.Picture,
                Email = currentProfile.Email,
                ProfileId = currentProfile.ProfileId,
                FkUser = currentProfile.FkUser
            };

            return await this._repo.UpdateProfileAsync(updatedProfile);
        }
    }
}