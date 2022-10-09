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
        Task<Notebook?> CreateNotebookAsync(CreateNotebookDto request, string auth0id);
        Task<User?> CheckIfUserExists(string auth0id);
        Task<List<Notebook>> GetUserNotebooksAsync(UserIdDto request);
        Task<Notebook?> GetNotebookByNotebookID(Guid notebookID);
        Task<Notebook?> UpdateNotebookAsync(Notebook n);
        Task<bool> DeleteNotebookAsync(Guid guid);
    }
}