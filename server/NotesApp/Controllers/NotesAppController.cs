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
        public async Task<ActionResult<Profile?>> CreateProfileAsync(CreateProfileDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (User.Identity?.Name == null)
            {
                return Unauthorized();
            }

            string auth0id = User.Identity.Name;

            Profile? p = await this._bus.CreateProfileAsync(request, auth0id);

            if (p == null)
            {
                return Conflict();
            }

            return Created("", p);
        }

        [HttpPost("get-user-profile")]
        [AllowAnonymous]
        public async Task<ActionResult<Profile?>> GetUserProfileAsync(UserIdDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Profile? p = await this._bus.GetUserProfileAsync(request);
            
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }
        
        [HttpPut("update-profile")]
        public async Task<ActionResult<Profile?>> UpdateProfileAsync(UpdateProfileDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (User.Identity?.Name == null)
            {
                return Unauthorized();
            }

            string auth0id = User.Identity.Name;

            Profile? p = await this._bus.UpdateProfileAsync(request, auth0id);

            if (p != null)
            {
                return Conflict();
            }

            return Ok(p);
        }

        [HttpDelete("delete-profile")]
        public async Task<ActionResult<bool>> DeleteProfileAsync()
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
        public async Task<ActionResult<Notebook?>> CreateNotebookAsync(CreateNotebookDto request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            if (User.Identity?.Name == null)
            {
                return Unauthorized();
            }

            string auth0id = User.Identity.Name;

            Notebook? n = await this._bus.CreateNotebookAsync(request, auth0id);

            if (n == null)
            {
                return Conflict ();
            }

            return Created("", n);
        }

        [HttpPost("get-user-notebooks")]
        public async Task<ActionResult<List<Notebook>?>> GetUserNotebooksAsync(UserIdDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (User.Identity?.Name == null)
            {
                return Unauthorized();
            }

            string auth0id = User.Identity.Name;

            if (request.ID != auth0id)
            {
                return Unauthorized();
            }

            List<Notebook>? notebooks = await this._bus.GetUserNotebooksAsync(request, auth0id);

            if(notebooks == null)
            {
                return NotFound();
            }

            return Ok(notebooks);
        }

        [HttpPut("update-notebook")]
        public async Task<ActionResult<Notebook?>> UpdateNotebookAsync(UpdateNotebookDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (User.Identity?.Name == null)
            {
                return Unauthorized();
            }

            string auth0id = User.Identity.Name;

            Notebook? n = await this._bus.UpdateNotebookAsync(request, auth0id);

            if (n == null)
            {
                return Conflict();
            }

            return Ok(n);
        }

        [HttpDelete("delete-notebook")]
        public async Task<ActionResult<bool>> DeleteNotebookAsync(IdDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(false);
            }

            if (User.Identity?.Name == null)
            {
                return Unauthorized(false);
            }

            string auth0id = User.Identity.Name;

            bool deletedSuccess = await this._bus.DeleteNotebookAsync(request, auth0id);

            if (deletedSuccess == false)
            {
                return Conflict(false);
            }

            return Ok(true);
        }





        // CRUD Notes

        public async Task<ActionResult<List<Note>>> CreateNoteAsync(CreateNoteDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (User.Identity?.Name == null)
            {
                return Unauthorized();
            }

            string auth0id = User.Identity.Name;

            Note? n = await this._bus.CreateNoteAsync(request, auth0id);

            if (n == null)
            {
                return Conflict();
            }

            return Ok(n);

        }   
    }
}