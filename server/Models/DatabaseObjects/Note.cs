using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{
    public partial class Note
    {
        public Guid NoteId { get; set; }
        public Guid FkNotebookId { get; set; }
        public string? Title { get; set; }
        public int Type { get; set; }
        public string Content { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [JsonIgnore]
        public virtual Notebook FkNotebook { get; set; } = null!;
    }
}
