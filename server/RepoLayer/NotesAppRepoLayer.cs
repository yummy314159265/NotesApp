using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace RepoLayer
{
    public class NotesAppRepoLayer : INotesAppRepoLayer
    {
        private readonly IConfiguration _config;
        private noteddbContext _context;

        public NotesAppRepoLayer(IConfiguration config, noteddbContext context)
        {
            _config = config;
            _context = context;
        }




        // CRUD USER

        public async Task<User?> CheckIfUserExists(string auth0id)
        {
            return await _context.Users.SingleOrDefaultAsync(user => user.UserId == auth0id);
        }




        // CRUD PROFILE

        public async Task<Profile?> CreateProfileAsync(CreateProfileDto request, string auth0id)
        {
            User u = await _context.Users.SingleAsync(user => user.UserId == auth0id);
            
            Profile p = new Profile()
            {
                FkUserId = auth0id,
                Name = request.Name,
                Email = request.Email,
                Picture = request.Picture,
                Nickname = request.Nickname
            };

            await _context.Profiles.AddAsync(p);

            int ret = await _context.SaveChangesAsync();

            if(ret == 0)
            {
                return null;
            }

            return p;
        }

        public async Task<Profile?> GetProfileByUserIDAsync(String id)
        {
            return await _context.Profiles.SingleOrDefaultAsync(prof => prof.FkUserId== id);
        }

        public async Task<Profile> UpdateProfileAsync(Profile updatedProfile)
        {
            Profile currentProfile = _context.Profiles.Single(prof => prof.ProfileId == updatedProfile.ProfileId);

            currentProfile = updatedProfile;

            await _context.SaveChangesAsync();

            return updatedProfile;
        }

        public async Task<bool> DeleteProfileAsync(string auth0id)
        {
            Profile p = await _context.Profiles.SingleAsync(prof => prof.FkUserId == auth0id);
            
            _context.Profiles.Remove(p);
            
            int ret = await _context.SaveChangesAsync();

            return (ret > 0);
        }




        // CRUD NOTEBOOK

        public async Task<Notebook?> CreateNotebookAsync(CreateNotebookDto request, string auth0id)
        {
            User u = await _context.Users.SingleAsync(user => user.UserId == auth0id);

            Notebook n = new Notebook()
            {
                FkUserId = auth0id,
                Name = request.Name
            };

            await _context.Notebooks.AddAsync(n);

            int ret = await _context.SaveChangesAsync();

            if (ret == 0)
            {
                return null;
            }

            return n;
        }

        public async Task<List<Notebook>> GetUserNotebooksAsync(UserIdDto request)
        {
            return await _context.Notebooks.Where(nb => nb.FkUserId == request.ID).OrderByDescending(nb=> nb.DateModified).ToListAsync();
        }

        public async Task<Notebook?> GetNotebookByNotebookID(Guid notebookID)
        {
            return await _context.Notebooks.SingleOrDefaultAsync(nb => nb.NotebookId == notebookID);
        }

        public async Task<Notebook?> UpdateNotebookAsync(Notebook n)
        {
            Notebook currentNotebook = await _context.Notebooks.SingleAsync(nb => nb.NotebookId == n.NotebookId);

            currentNotebook.Name = n.Name;

            int ret = await _context.SaveChangesAsync();

            if(ret == 0)
            {
                return null;
            }

            return currentNotebook;
        }

        public async Task<bool> DeleteNotebookAsync(Guid guid)
        {
            Notebook n = await _context.Notebooks.SingleAsync(nb => nb.NotebookId == guid);

            _context.Notebooks.Remove(n);

            int ret = await _context.SaveChangesAsync();

            return (ret > 0);
        }
    }
}