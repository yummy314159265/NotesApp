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



        

        // CRUD PROFILES

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

            if (p == null || p.FkUserId != auth0id)
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





        // CRUD NOTEBOOKS

        public async Task<Notebook?> CreateNotebookAsync(CreateNotebookDto request, string auth0id)
        {
            Notebook? createdNotebook = await this._repo.CreateNotebookAsync(request, auth0id);

            return createdNotebook; 
        }

        public async Task<List<Notebook>?> GetUserNotebooksAsync(UserIdDto request, string auth0id)
        {
            User? u = await this._repo.CheckIfUserExists(request.ID);

            if (u == null)
            {
                return null;
            }

            List<Notebook> notebooks = await this._repo.GetUserNotebooksAsync(request);

            return notebooks;
        }

        public async Task<Notebook?> UpdateNotebookAsync(UpdateNotebookDto request, string auth0id)
        {
            Notebook? n = await this._repo.GetNotebookByNotebookID(request.NotebookID);

            if (n == null)
            {
                return null;
            }

            if (n.FkUserId != auth0id)
            {
                return null;
            }

            if (request.Name == n.Name)
            {
                return n;
            }

            n.Name = request.Name;

            Notebook? updatedN = await this._repo.UpdateNotebookAsync(n);

            return updatedN;
        }

        public async Task<bool> DeleteNotebookAsync(IdDto request, string auth0id)
        {
            Notebook? n = await this._repo.GetNotebookByNotebookID(request.guid);

            if (n == null || n.FkUserId != auth0id)
            {
                return false;
            }

            bool deletedSuccess = await this._repo.DeleteNotebookAsync(request.guid);

            return deletedSuccess;
        }

    }
}