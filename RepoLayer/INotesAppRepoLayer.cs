using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace RepoLayer
{
    public interface INotesAppRepoLayer
    {
        Task<Profile?> GetProfileByUserIDAsync(string id);
        Task<Profile> UpdateProfileAsync(Profile updatedProfile);
        Task<bool> DeleteProfileAsync(string auth0id);
        Task<Profile?> CreateProfileAsync(CreateProfileDto request, string auth0id);
    }
}