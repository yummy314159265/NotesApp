using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Notebook
    {
        public Notebook()
        {
            Notes = new HashSet<Note>();
        }

        public Guid NotebookId { get; set; }
        public string FkUserId { get; set; } = null!;
        public string? Name { get; set; }
        public int? NoteCount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public virtual User FkUser { get; set; } = null!;
        public virtual ICollection<Note> Notes { get; set; }
    }
}
