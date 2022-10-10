using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.NotesApp
{
    public class Helpers
    {
        private readonly Random _r = new Random();

        private readonly string _placeKittenUrl = "https://placekitten.com/g/200/300";

        public string fakeString(string prepend)
        {
            return $"{prepend} {_r.Next(1000)}";
        }

        public string fakeEmail(string prepend)
        {
            return $"{prepend}{_r.Next(1000)}@email.com";
        }

        public User fakeUser()
        {
            return new User()
            {
                UserId = fakeString("test user"),
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
        }

        public Profile fakeProfile()
        {
            return new Profile()
            {
                ProfileId = Guid.NewGuid(),
                FkUserId = fakeString("test user"),
                Name = fakeString("test name"),
                Email = fakeEmail("testemail"),
                Picture = _placeKittenUrl,
                Nickname = fakeString("test nick")
            };
        }

        public Notebook fakeNotebook()
        {
            string userId = fakeString("test user");
        
            return new Notebook()
            {
                NotebookId = Guid.NewGuid(),
                FkUserId = userId,
                Name = fakeString("test name"),
                NoteCount = _r.Next(1000),
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                FkUser = new User()
                {
                    UserId = userId,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                Notes = new List<Note>()
            };
        }

        public Note fakeNote()
        {
            Guid notebookId = Guid.NewGuid();
            string userId = fakeString("test user");

            return new Note()
            {
                NoteId = Guid.NewGuid(),
                FkNotebookId = notebookId,
                Title = fakeString("test title"),
                Type = _r.Next(1000),
                Content = fakeString("test content"),
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                FkNotebook = new Notebook()
                {
                    NotebookId = notebookId,
                    FkUserId = userId,
                    Name = fakeString("test name"),
                    NoteCount = _r.Next(1000),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Notes = new List<Note>(),
                    FkUser = new User()
                    {
                        UserId = userId,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    }
                }
            };
        }
    }
}