using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace BusinessLayer
{
    public interface INotesAppBusinessLayer
    {

        // CRUD Profiles
        Task<Profile?> GetUserProfileAsync(UserIdDto userID);
        Task<Profile?> UpdateProfileAsync(UpdateProfileDto request, string auth0id);
        Task<bool> DeleteProfileAsync(string auth0id);
        Task<Profile?> CreateProfileAsync(CreateProfileDto request, string auth0id);
        Task<Notebook?> CreateNotebookAsync(CreateNotebookDto request, string auth0id);
        Task<List<Notebook>?> GetUserNotebooksAsync(UserIdDto request, string auth0id);
        Task<Notebook?> UpdateNotebookAsync(UpdateNotebookDto request, string auth0id);
        Task<bool> DeleteNotebookAsync(IdDto request, string auth0id);
        Task<Note?> CreateNoteAsync(CreateNoteDto request, string auth0id);

        // CRUD Notebooks
    }
}