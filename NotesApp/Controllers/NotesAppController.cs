using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using Models;
using Microsoft.AspNetCore.Authorization;

namespace NotesApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotesAppController : ControllerBase
    {
        private readonly INotesAppBusinessLayer _bus; 

        public NotesAppController (INotesAppBusinessLayer bus)
        {
            this._bus = bus;
        }

        // CRUD PROFILE

        [HttpPost("create-profile")]
        public async Task<ActionResult> CreateProfileAsync(CreateProfileDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }

            if (User.Identity?.Name == null)
            {
                return Unauthorized(request);
            }

            string auth0id = User.Identity.Name;

            Profile? p = await this._bus.CreateProfileAsync(request, auth0id);

            if (p == null)
            {
                return Conflict(request);
            }

            return Created("", p);
        }

        [HttpPost("get-user-profile")]
        [AllowAnonymous]
        public async Task<ActionResult> GetUserProfileAsync(UserIdDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }

            Profile? p = await this._bus.GetUserProfileAsync(request);
            
            if (p == null)
            {
                return NotFound(new UserIdNotFoundDto(request.ID));
            }

            return Ok(p);
        }
        
        [HttpPut("update-profile")]
        public async Task<ActionResult> UpdateProfileAsync(UpdateProfileDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }

            if (User.Identity?.Name == null)
            {
                return Unauthorized(request);
            }

            string auth0id = User.Identity.Name;

            Profile? p = await this._bus.UpdateProfileAsync(request, auth0id);

            if (p != null)
            {
                return Conflict(request);
            }

            return Ok(p);
        }

        [HttpDelete("delete-profile")]
        public async Task<ActionResult> DeleteProfileAsync()
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(false);
            }

            if (User.Identity?.Name == null)
            {
                return Unauthorized(false);
            }

            string auth0id = User.Identity.Name;

            bool deletedSuccess = await this._bus.DeleteProfileAsync(auth0id);

            if(deletedSuccess == false)
            {
                return Conflict(false);
            }

            return Ok(true);
        }

        // CRUD NOTEBOOK

        [HttpPost("create-notebook")]
        public async Task<ActionResult> CreateNotebookAsync(CreateNotebookDto request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(request);
            }

            if (User.Identity?.Name == null)
            {
                return Unauthorized(request);
            }

            string auth0id = User.Identity.Name;

            Notebook? n = await this._bus.CreateNotebookAsync(request, auth0id);

            if (n == null)
            {
                return Conflict (request);
            }

            return Created("", n);
        }
    }
}