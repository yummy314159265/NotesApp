using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class CreateNoteDto
    {
        public CreateNoteDto(Guid fk_notebookID, string? title, int type, string content)
        {
            Fk_notebookID = fk_notebookID;
            Title = title;
            Type = type;
            Content = content;
        }

        public Guid Fk_notebookID { get; set; }
        public string? Title { get; set; }
        public int Type { get; set; }
        public string Content { get; set; }

    }
}
