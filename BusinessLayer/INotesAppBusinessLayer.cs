using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace BusinessLayer
{
    public interface INotesAppBusinessLayer
    {
        Task<Profile?> GetUserProfileAsync(UserIdDto userID);
        Task<Profile?> UpdateProfileAsync(UpdateProfileDto request, string auth0id);
        Task<bool> DeleteProfileAsync(string auth0id);
        Task<Profile?> CreateProfileAsync(CreateProfileDto request, string auth0id);
    }
}